using Illuminated_sphere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Utility
{
	internal class ProjectData
	{
		// parameters
		public float kd { get; set; } = 1f;
		public float ks { get; set; } = 0.5f;
		public int m { get; set; } = 20;

		// dun
		public Vector3 sunPosition { get; set; } = new Vector3(100, 100, 900);
		public bool sunAnimation { get; set; }
		public Color sunColor { get; set; } = Color.White;
		public float sunHeightModifier { get; set; } = 1;

		// obj color / texture
		public bool useTexture { get; set; } = true;
		public Color objColor { get; set; } = Color.LightGreen;
		public Bitmap texture { get; set; }
		public BmpPixelSnoop textureSnoop { get; set; }

		//normal map
		public bool useNormalMap { get; set; } = false;
		public Bitmap normalMap { get; set; }
		public BmpPixelSnoop normalMapSnoop { get; set; }
		public Vector3[,] normalsTab { get; set; }

		// interpolation
		public bool interpolateColor { get; set; } = true;

		// others
		public PictureBox workingArea { get; set; }
		public BmpPixelSnoop snoop { get; set; }
		public List<Polygon> polygons { get; set; }
		public Form form { get; set; }
		public int currentObj { get; set; } = 0;

		// rectangle
		public Point left { get; set; } = new Point(200, 300);
		public Point right { get; set; } = new Point(500, 500);
	}
}
