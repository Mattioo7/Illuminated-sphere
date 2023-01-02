using Illuminated_sphere.Drawing;
using Illuminated_sphere.Models;
using Illuminated_sphere.ObjHelpers;
using Illuminated_sphere.Utility;
using ObjLoader.Loader.Loaders;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Numerics;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Illuminated_sphere;

public partial class form_mainWindow : Form
{
	ProjectData projectData;
	ProjectDataLab projectDataLab;

	Timer timer = new Timer();

	public form_mainWindow()
	{
		InitializeComponent();

		//initalizeEnviroment();
		
		initalizeEnviroment2();

		//obj_test(projectData.currentObj);

		lab4(projectDataLab);
	}

	private void lab4(ProjectDataLab projectDataLab)
	{
		int a = projectDataLab.a;
		//table of vector4 for a cube of side a
		Vector4[] vertices = new Vector4[8];
		vertices[0] = new Vector4(-a, -a, -a, 1);
		vertices[1] = new Vector4(-a, -a, a, 1);
		vertices[2] = new Vector4(-a, a, -a, 1);
		vertices[3] = new Vector4(-a, a, a, 1);
		vertices[4] = new Vector4(a, -a, -a, 1);
		vertices[5] = new Vector4(a, -a, a, 1);
		vertices[6] = new Vector4(a, a, -a, 1);
		vertices[7] = new Vector4(a, a, a, 1);

		projectDataLab.vertices = vertices;


		// rotation
		rotateVector4AroundYAxis(projectDataLab);

		// translation
		translateCube(projectDataLab);

		// projection
		projectCube(projectDataLab);

		// normalization
		normalizeCube(projectDataLab);

		// from -a,a to 0,width
		
		
		// drawCube
		drawCube2(projectDataLab);


	}

	private void drawCube2(ProjectDataLab projectDataLab)
	{
		using (Graphics g = Graphics.FromImage(projectDataLab.pictureBox.Image))
		{
			// draw lines
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[0].X, projectDataLab.vertices[0].Y, projectDataLab.vertices[1].X, projectDataLab.vertices[1].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[0].X, projectDataLab.vertices[0].Y, projectDataLab.vertices[2].X, projectDataLab.vertices[2].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[0].X, projectDataLab.vertices[0].Y, projectDataLab.vertices[4].X, projectDataLab.vertices[4].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[1].X, projectDataLab.vertices[1].Y, projectDataLab.vertices[3].X, projectDataLab.vertices[3].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[1].X, projectDataLab.vertices[1].Y, projectDataLab.vertices[5].X, projectDataLab.vertices[5].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[2].X, projectDataLab.vertices[2].Y, projectDataLab.vertices[3].X, projectDataLab.vertices[3].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[2].X, projectDataLab.vertices[2].Y, projectDataLab.vertices[6].X, projectDataLab.vertices[6].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[3].X, projectDataLab.vertices[3].Y, projectDataLab.vertices[7].X, projectDataLab.vertices[7].Y);
			g.DrawLine(new Pen(Color.Black, 2), projectDataLab.vertices[4].X, projectDataLab.vertices[4].Y, projectDataLab.vertices[5].X, projectDataLab.vertices[5].Y);
		}
	}

	private void rotateVector4AroundYAxis(ProjectDataLab projectDataLab)
	{
		// rotation matrix 4x4
		Matrix4x4 rotationMatrix = new Matrix4x4();

		float angle = projectDataLab.angle;

		// rotation matrix
		rotationMatrix.M11 = (float)Math.Cos(angle);
		rotationMatrix.M12 = 0;
		rotationMatrix.M13 = -(float)Math.Sin(angle);
		rotationMatrix.M14 = 0;
		
		rotationMatrix.M21 = 0;
		rotationMatrix.M22 = 1;
		rotationMatrix.M23 = 0;
		rotationMatrix.M24 = 0;
		
		rotationMatrix.M31 = (float)Math.Sin(angle);
		rotationMatrix.M32 = 0;
		rotationMatrix.M33 = (float)Math.Cos(angle);
		rotationMatrix.M34 = 0;
		
		rotationMatrix.M41 = 0;
		rotationMatrix.M42 = 0;
		rotationMatrix.M43 = 0;
		rotationMatrix.M44 = 1;


		for (int i = 0; i < projectDataLab.vertices.Length; ++i)
		{
			// multiply rotationMatrix and rotationMatrix
			projectDataLab.vertices[i] = Vector4.Transform(projectDataLab.vertices[i], rotationMatrix);
		}
	}

	private void translateCube(ProjectDataLab projectDataLab)
	{
		// translation matrix4x4
		Matrix4x4 translationMatrix = new Matrix4x4();

		int x = 0;
		int y = 0;
		int z = -5 * projectDataLab.a;

		translationMatrix.M11 = 1;
		translationMatrix.M12 = 0;
		translationMatrix.M13 = 0;
		translationMatrix.M14 = x;

		translationMatrix.M21 = 0;
		translationMatrix.M22 = 1;
		translationMatrix.M23 = 0;
		translationMatrix.M24 = y;

		translationMatrix.M31 = 0;
		translationMatrix.M32 = 0;
		//translationMatrix.M33 = z;
		//translationMatrix.M34 = 1;
		translationMatrix.M33 = 1;
		translationMatrix.M34 = z;

		translationMatrix.M41 = 0;
		translationMatrix.M42 = 0;
		translationMatrix.M43 = 0;
		translationMatrix.M44 = 1;

		for (int i = 0; i < projectDataLab.vertices.Length; ++i)
		{
			projectDataLab.vertices[i] = Vector4.Transform(projectDataLab.vertices[i], translationMatrix);
		}
	}

	private void projectCube(ProjectDataLab projectDataLab)
	{
		int width = projectDataLab.pictureBox.Width;
		int height = projectDataLab.pictureBox.Height;

		float cot = (float)Math.Cos(Math.PI / 2f) / (float)Math.Sin(Math.PI / 2f);
		cot = 1;
		float s = width / 2f * cot;

		float Cx = width / 2f;
		float Cy = height / 2f;

		// projection matrix4x4
		Matrix4x4 projectionMatrix = new Matrix4x4();

		projectionMatrix.M11 = s;
		projectionMatrix.M12 = 0;
		projectionMatrix.M13 = Cx;
		projectionMatrix.M14 = 0;

		projectionMatrix.M21 = 0;
		projectionMatrix.M22 = s;
		projectionMatrix.M23 = Cy;
		projectionMatrix.M24 = 0;

		projectionMatrix.M31 = 0;
		projectionMatrix.M32 = 0;
		projectionMatrix.M33 = 0;
		projectionMatrix.M34 = 1;

		projectionMatrix.M41 = 0;
		projectionMatrix.M42 = 0;
		projectionMatrix.M43 = 1;
		projectionMatrix.M44 = 0;

		for (int i = 0; i < projectDataLab.vertices.Length; ++i)
		{
			projectDataLab.vertices[i] = Vector4.Transform(projectDataLab.vertices[i], projectionMatrix);
		}
	}

	private void projectCube2(ProjectDataLab projectDataLab)
	{
		int width = projectDataLab.pictureBox.Width;
		int height = projectDataLab.pictureBox.Height;

		

		
	}

	private void normalizeCube(ProjectDataLab projectDataLab)
	{
		for (int i = 0; i < projectDataLab.vertices.Length; ++i)
		{
			projectDataLab.vertices[i] /= projectDataLab.vertices[i].W;
		}
	}

	private (int x1, int y1) convertVertexPosition(int x, int y, int width, int height)
	{
		int x1 = x;// x + width / 2;
		int y1 = y;// height / 2 - y;
		
		return (x1, y1);
	}

	private void drawCube(ProjectDataLab projectDataLab)
	{
		Vector4[] vertices = projectDataLab.vertices;
		PictureBox pictureBox = projectDataLab.pictureBox;

		// draw cube
		using (Graphics g = Graphics.FromImage(pictureBox.Image))
		{
			for (int i = 0; i < vertices.Length - 1; ++i)
			{
				int x1, y1, x2, y2;
				
				(x1, y1) = convertVertexPosition((int)vertices[i].X, (int)vertices[i].Y, pictureBox.Width / 2, pictureBox.Height / 2);
				(x2, y2) = convertVertexPosition((int)vertices[i + 1].X, (int)vertices[i + 1].Y, pictureBox.Width / 2, pictureBox.Height / 2);

				g.DrawLine(new Pen(Brushes.Black), x1, y1, x2, y2);
			}

			int x1a, y1a, x2a, y2a;

			(x1a, y1a) = convertVertexPosition((int)vertices[vertices.Length - 1].X, (int)vertices[vertices.Length - 1].Y, pictureBox.Width, pictureBox.Height);
			(x2a, y2a) = convertVertexPosition((int)vertices[0].X, (int)vertices[0].Y, pictureBox.Width, pictureBox.Height);
			g.DrawLine(new Pen(Brushes.Black), x1a, y1a, x2a, y2a);

		}

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

	public void initalizeEnviroment2()
	{
		projectData = new ProjectData();
		projectDataLab = new ProjectDataLab();

		Bitmap bitmap = new Bitmap(this.pictureBox_workingArea.Size.Width, this.pictureBox_workingArea.Size.Height);
		this.pictureBox_workingArea.Image = bitmap;

		projectDataLab.pictureBox = this.pictureBox_workingArea;



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