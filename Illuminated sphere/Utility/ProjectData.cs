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
		public Color sun { get; set; }
		public bool sunAnimation { get; set; }
		public Color sunColor { get; set; } = Color.LightGreen;
		public float sunHeightModifier { get; set; } = 1;

		// obj color / texture
		public bool useBitmap { get; set; } = true;
		public Color objColor { get; set; } = Color.White;
		public Bitmap bitmap { get; set; }

		// interpolation
		public bool interpolateColor { get; set; } = true;
		public bool colorInterpolation { get; set; }

		// others
		public PictureBox workingArea { get; set; }
		public List<Polygon> polygons { get; set; }
	}
}
