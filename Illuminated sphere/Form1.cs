using ObjLoader.Loader.Loaders;

namespace Illuminated_sphere;

public partial class form_mainWindow : Form
{
	public form_mainWindow()
	{
		InitializeComponent();

		obj_test();
	}

	private void obj_test()
	{
		LoadResult loadResult = new LoadResult();

		var objLoaderFactory = new ObjLoaderFactory();
		var objLoader = objLoaderFactory.Create();

		string fileName = "sphere.obj";
		string path = Path.Combine(Environment.CurrentDirectory, @"Props\", fileName);

		var fileStream = new FileStream(path, FileMode.Open);
		var result = objLoader.Load(fileStream);

	}
}