using Illuminated_sphere.Drawing;
using Illuminated_sphere.Models;
using Illuminated_sphere.ObjHelpers;
using ObjLoader.Loader.Loaders;
using System.Diagnostics;
using System.Numerics;

namespace Illuminated_sphere;

public partial class form_mainWindow : Form
{
	static int a = 0;
	List<Polygon> polygons;

	public form_mainWindow()
	{
		InitializeComponent();

		obj_test();
	}

	private void obj_test()
	{
		int file = 1;
		string fileName;

		if (file == 0)
		{
			fileName = "sphere.obj";
			polygons = Loaders.loadNotNormalisedObj(fileName);
		}
		else if (file == 1)
		{
			fileName = "sphere3mXXXLSmooth.obj";
			polygons = Loaders.loadNormalisedObj(fileName, 1000, 700);
		}
		else
		{
			fileName = "proj2_sfera.obj";
			polygons = Loaders.loadNormalisedObj(fileName, 1000, 700);
		}


		// initialize
		Bitmap drawArea = new Bitmap(this.pictureBox_workingArea.Size.Width, this.pictureBox_workingArea.Size.Height);
		this.pictureBox_workingArea.Image = drawArea;

		// load


		using (Graphics g = Graphics.FromImage(drawArea))
		{
			g.Clear(Color.AliceBlue);
		}
		Filler.fillPolygons(polygons, this.pictureBox_workingArea);
		/*BasicDrawing.drawVertices(polygons, this.pictureBox_workingArea);
		BasicDrawing.drawLines(polygons, this.pictureBox_workingArea);*/
		BasicDrawing.drawVertex(new Point(200, 400), this.pictureBox_workingArea);

		this.pictureBox_workingArea.Refresh();

		return;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		BasicDrawing.drawVertices(polygons, this.pictureBox_workingArea);
		BasicDrawing.drawLines(polygons, this.pictureBox_workingArea);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Stopwatch timing = new Stopwatch();
		timing.Start();

		Debug.WriteLine("i: " + a);
		Filler.fillPolygons(polygons, this.pictureBox_workingArea, a);
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

		Filler.fillPolygons(polygons, this.pictureBox_workingArea);

		this.pictureBox_workingArea.Refresh();

		timing.Stop();
		Debug.WriteLine("Elapsed time: {0} ms = {1} s", timing.ElapsedMilliseconds, timing.ElapsedMilliseconds / 1000);
	}
}