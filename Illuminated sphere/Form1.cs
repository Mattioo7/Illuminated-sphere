using Illuminated_sphere.Drawing;
using Illuminated_sphere.Models;
using ObjLoader.Loader.Loaders;
using System.Diagnostics;

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
		var objLoaderFactory = new ObjLoaderFactory();
		var objLoader = objLoaderFactory.Create();

		string fileName = "sphere.obj";
		string path = Path.Combine(Environment.CurrentDirectory, @"Props\", fileName);

		FileStream fileStream = new FileStream(path, FileMode.Open);
		LoadResult? loadResult = objLoader.Load(fileStream);

		Bitmap drawArea = new Bitmap(this.pictureBox_workingArea.Size.Width, this.pictureBox_workingArea.Size.Height);
		this.pictureBox_workingArea.Image = drawArea;

		polygons = Polygon.makePolygonListFromLoadResult(loadResult);

		using (Graphics g = Graphics.FromImage(drawArea))
		{
			g.Clear(Color.AliceBlue);
		}
		Filler.fillPolygons(polygons, this.pictureBox_workingArea);
		BasicDrawing.drawVertices(polygons, this.pictureBox_workingArea);
		BasicDrawing.drawLines(polygons, this.pictureBox_workingArea);

		this.pictureBox_workingArea.Refresh();

		fileStream.Close();
		return;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		BasicDrawing.drawVertices(polygons, this.pictureBox_workingArea);
		BasicDrawing.drawLines(polygons, this.pictureBox_workingArea);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Debug.WriteLine("i: " + a);
		Filler.fillPolygons(polygons, this.pictureBox_workingArea, a);

		a++;
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Filler.fillPolygons(polygons, this.pictureBox_workingArea);
	}
}