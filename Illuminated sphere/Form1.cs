using Illuminated_sphere.Drawing;
using Illuminated_sphere.Models;
using Illuminated_sphere.ObjHelpers;
using Illuminated_sphere.Utility;
using ObjLoader.Loader.Loaders;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Illuminated_sphere;

public partial class form_mainWindow : Form
{
	ProjectData projectData;

	Timer timer = new Timer();

	public form_mainWindow()
	{
		InitializeComponent();

		initalizeEnviroment();

		obj_test(projectData.currentObj);
	}

	private void obj_test(int file)
	{
		string fileName;

		if (file == 0)
		{
			projectData.currentObj = 0;
			fileName = "sphere.obj";
			projectData.polygons = Loaders.loadNormalisedObj(fileName, this.pictureBox_workingArea.Width - 40, this.pictureBox_workingArea.Height - 40);
			
		}
		else if (file == 1)
		{
			projectData.currentObj = 1;
			fileName = "TorusSmooth.obj";
			projectData.polygons = Loaders.loadNormalisedObj(fileName, this.pictureBox_workingArea.Width - 40, this.pictureBox_workingArea.Height - 40);
		}

		// normals tab
		projectData.useNormalMap = false;
		this.label_normalMapFile.Text = "File name";
		projectData.normalsTab = new Vector3[this.pictureBox_workingArea.Width, this.pictureBox_workingArea.Height];
		NormalMapOperations.calculateNormalsTab(projectData);

		using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
		{
			g.Clear(Color.AliceBlue);
		}

		using (var snoop = new BmpPixelSnoop((Bitmap)projectData.workingArea.Image))
		{
			projectData.snoop = snoop;
		}

		Filler.fillPolygons(projectData);

		this.pictureBox_workingArea.Refresh();

		return;
	}

	public void initalizeEnviroment()
	{
		projectData = new ProjectData();

		Bitmap bitmap = new Bitmap(this.pictureBox_workingArea.Size.Width, this.pictureBox_workingArea.Size.Height);
		this.pictureBox_workingArea.Image = bitmap;
		projectData.workingArea = this.pictureBox_workingArea;

		// object
		this.panel_objColor.BackColor = projectData.objColor;

		// sun
		this.panel_sunColor.BackColor = projectData.sunColor;

		SunAnimation sunAnimation = new SunAnimation();

		timer.Tick += new EventHandler((sender, e) => SunAnimation.calculateSunPosition(sender, e, projectData));
		timer.Interval = 5;
		timer.Start();
		timer.Enabled = false;

		// default texture
		string path = Path.Combine(Environment.CurrentDirectory, @"Props\", "basketball.png");
		projectData.texture = new Bitmap(path);
		projectData.texture = new Bitmap(projectData.texture, this.pictureBox_workingArea.Width, this.pictureBox_workingArea.Height);

		using (var textureSnoop = new BmpPixelSnoop((Bitmap)projectData.texture))
		{
			projectData.textureSnoop = textureSnoop;
		}

		projectData.form = this;
	}

	private void button_outline_Click(object sender, EventArgs e)
	{
		BasicDrawing.drawVertices(projectData.polygons, projectData);
		BasicDrawing.drawLines(projectData.polygons, projectData);
	}



	private void button_redraw_Click(object sender, EventArgs e)
	{
		Filler.fillPolygons(projectData);

		this.pictureBox_workingArea.Refresh();
	}

	private void trackBar_kd_Scroll(object sender, EventArgs e)
	{
		projectData.kd = (this.trackBar_kd.Value / 100f);

		if (this.trackBar_kd.Value < 1)
		{
			this.label_kdValue.Text = "0,00";
		}
		else if (this.trackBar_kd.Value > 99)
		{
			this.label_kdValue.Text = "1,00";
		}
		else
		{
			this.label_kdValue.Text = projectData.kd.ToString();
		}
		Filler.fillPolygons(projectData);
	}

	private void trackBar_ks_Scroll(object sender, EventArgs e)
	{
		projectData.ks = (this.trackBar_ks.Value / 100f);

		if (this.trackBar_ks.Value < 1)
		{
			this.label_ksValue.Text = "0,00";
		}
		else if (this.trackBar_ks.Value > 99)
		{
			this.label_ksValue.Text = "1,00";
		}
		else
		{
			this.label_ksValue.Text = projectData.ks.ToString();
		}
		Filler.fillPolygons(projectData);
	}

	private void trackBar_m_Scroll(object sender, EventArgs e)
	{
		projectData.m = this.trackBar_m.Value;

		this.label_mValue.Text = projectData.m.ToString();

		Filler.fillPolygons(projectData);
	}

	private void checkBox_sunAnimation_CheckedChanged(object sender, EventArgs e)
	{
		projectData.sunAnimation = (checkBox_sunAnimation.Checked == true);
		
		timer.Enabled = (checkBox_sunAnimation.Checked == true);
	}

	private void trackBar_sunHeight_Scroll(object sender, EventArgs e)
	{
		projectData.sunHeightModifier = (this.trackBar_sunHeight.Value / 10f);

		this.label_sunHeightValue.Text = projectData.sunHeightModifier.ToString();

		Filler.fillPolygons(projectData);
	}

	private void panel_sunColor_Click(object sender, EventArgs e)
	{
		ColorDialog colorDialog = new ColorDialog();
		if (colorDialog.ShowDialog() == DialogResult.OK)
		{
			this.panel_sunColor.BackColor = colorDialog.Color;
			projectData.sunColor = this.panel_sunColor.BackColor;
			Filler.fillPolygons(projectData);
		}
	}

	private void panel_objColor_Click(object sender, EventArgs e)
	{
		ColorDialog colorDialog = new ColorDialog();
		if (colorDialog.ShowDialog() == DialogResult.OK)
		{
			this.panel_objColor.BackColor = colorDialog.Color;
			projectData.objColor = this.panel_objColor.BackColor;
			projectData.useTexture = false;

			Filler.fillPolygons(projectData);
			this.pictureBox_workingArea.Refresh();
		}
	}

	private void radioButton_texture_CheckedChanged(object sender, EventArgs e)
	{
		projectData.useTexture = radioButton_texture.Checked;

		Filler.fillPolygons(projectData);
		this.pictureBox_workingArea.Refresh();
	}

	private void button_texture_Click(object sender, EventArgs e)
	{
		OpenFileDialog fileDialog = new OpenFileDialog();
		fileDialog.InitialDirectory = Environment.CurrentDirectory;
		fileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
		if (fileDialog.ShowDialog() == DialogResult.OK)
		{
			projectData.texture = new Bitmap(fileDialog.FileName);
			projectData.texture = new Bitmap(projectData.texture, this.pictureBox_workingArea.Width, this.pictureBox_workingArea.Height);

			using (var textureSnoop = new BmpPixelSnoop((Bitmap)projectData.texture))
			{
				projectData.textureSnoop = textureSnoop;
			}
		}
	}

	private void button_loadNormalMap_Click(object sender, EventArgs e)
	{
		OpenFileDialog fileDialog = new OpenFileDialog();
		fileDialog.InitialDirectory = Environment.CurrentDirectory;
		fileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
		if (fileDialog.ShowDialog() == DialogResult.OK)
		{
			obj_test(projectData.currentObj);

			projectData.normalMap = new Bitmap(fileDialog.FileName);
			projectData.normalMap = new Bitmap(projectData.normalMap, this.pictureBox_workingArea.Width, this.pictureBox_workingArea.Height);

			projectData.useNormalMap = true;

			using (var normalMap = new BmpPixelSnoop(projectData.normalMap))
			{
				projectData.normalMapSnoop = normalMap;
			}

			this.label_normalMapFile.Text = fileDialog.SafeFileName;

			NormalMapOperations.calculateNormalsTabWithNormalMap(projectData);
			NormalMapOperations.modifyNormals(projectData);

			Filler.fillPolygons(projectData);
			this.pictureBox_workingArea.Refresh();
		}
	}

	private void button_clearNormalMap_Click(object sender, EventArgs e)
	{
		this.label_normalMapFile.Text = "File name";
		obj_test(projectData.currentObj);
	}

	private void radioButton_colorInterpolation_CheckedChanged(object sender, EventArgs e)
	{
		projectData.interpolateColor = radioButton_colorInterpolation.Checked;

		Filler.fillPolygons(projectData);
		this.pictureBox_workingArea.Refresh();
	}

	private void button_figure1_Click(object sender, EventArgs e)
	{
		//timer.Stop();
		//initalizeEnviroment();
		using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
		{
			g.Clear(Color.AliceBlue);
		}
		obj_test(0);
	}

	private void button_figure2_Click(object sender, EventArgs e)
	{
		//timer.Stop();
		//initalizeEnviroment();
		using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
		{
			g.Clear(Color.AliceBlue);
		}
		obj_test(1);
	}

	private void button_clear_Click(object sender, EventArgs e)
	{
		using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
		{
			g.Clear(Color.AliceBlue);
		}

		this.pictureBox_workingArea.Refresh();
	}

}