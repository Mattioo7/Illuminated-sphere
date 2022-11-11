using Illuminated_sphere.Drawing;
using Illuminated_sphere.Models;
using Illuminated_sphere.ObjHelpers;
using Illuminated_sphere.Utility;
using ObjLoader.Loader.Loaders;
using System.Diagnostics;
using System.Numerics;

namespace Illuminated_sphere;

public partial class form_mainWindow : Form
{
	static int a = 0;
	ProjectData projectData { get; set; }

	public form_mainWindow()
	{
		InitializeComponent();

		initalizeEnviroment();

		obj_test();
	}

	private void obj_test()
	{
		int file = 1;
		string fileName;

		if (file == 0)
		{
			fileName = "sphere.obj";
			projectData.polygons = Loaders.loadNotNormalisedObj(fileName);
		}
		else if (file == 1)
		{
			fileName = "sphere3mXXXLSmooth.obj";
			projectData.polygons = Loaders.loadNormalisedObj(fileName, 1000, 700);
		}
		else
		{
			fileName = "proj2_sfera.obj";
			projectData.polygons = Loaders.loadNormalisedObj(fileName, 1000, 700);
		}

		using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
		{
			g.Clear(Color.AliceBlue);
		}
		Filler.fillPolygons(projectData.polygons, projectData);

		this.pictureBox_workingArea.Refresh();

		return;
	}

	public void initalizeEnviroment()
	{
		projectData = new ProjectData();

		Bitmap bitmap = new Bitmap(this.pictureBox_workingArea.Size.Width, this.pictureBox_workingArea.Size.Height);
		this.pictureBox_workingArea.Image = bitmap;
		projectData.workingArea = this.pictureBox_workingArea;

		defaultValues();
	}

	public void defaultValues()
	{
		projectData.kd = 1f;
		projectData.ks = 0.5f;
		projectData.m = 20;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		BasicDrawing.drawVertices(projectData.polygons, projectData);
		BasicDrawing.drawLines(projectData.polygons, projectData);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Stopwatch timing = new Stopwatch();
		timing.Start();

		Debug.WriteLine("i: " + a);
		Filler.fillPolygons(projectData.polygons, projectData, a);
		/*Filler.fillPolygons(polygons, this.pictureBox_workingArea, a, Color.Red);*/

		a++;

		timing.Stop();
		Debug.WriteLine("Elapsed time: {0} ms", timing.ElapsedMilliseconds);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Stopwatch timing = new Stopwatch();
		Debug.WriteLine("Started timer");
		timing.Start();

		Filler.fillPolygons(projectData.polygons, projectData);

		this.pictureBox_workingArea.Refresh();

		timing.Stop();
		Debug.WriteLine("Elapsed time: {0} ms = {1} s", timing.ElapsedMilliseconds, timing.ElapsedMilliseconds / 1000);
	}

	private void trackBar_kd_Scroll(object sender, EventArgs e)
	{
		projectData.kd = (this.trackBar_kd.Value / 100f);

		if (this.trackBar_kd.Value < 0.01)
		{
			this.trackBar_kd.Text = "0,00";
		}
		else
		{
			this.label_kdValue.Text = projectData.kd.ToString();
		}
		Filler.fillPolygons(projectData.polygons, projectData);
	}

	private void trackBar_ks_Scroll(object sender, EventArgs e)
	{
		projectData.ks = (this.trackBar_ks.Value / 100f);

		if (this.trackBar_ks.Value < 0.01)
		{
			this.label_ksValue.Text = "0,00";
		}
		else
		{
			this.label_ksValue.Text = projectData.ks.ToString();
		}
		Filler.fillPolygons(projectData.polygons, projectData);
	}

	private void trackBar_m_Scroll(object sender, EventArgs e)
	{
		projectData.m = this.trackBar_m.Value;

		this.label_mValue.Text = projectData.m.ToString();

		Filler.fillPolygons(projectData.polygons, projectData);
	}
}