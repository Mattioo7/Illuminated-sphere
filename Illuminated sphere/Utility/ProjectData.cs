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
		public float kd { get; set; } = 1f;
		public float ks { get; set; } = 0.5f;
		public int m { get; set; } = 20;
		public Color sun { get; set; }
		public Color objColor { get; set; } = Color.LightGray;
		public bool colorInterpolation { get; set; }
		public PictureBox workingArea { get; set; }
		public List<Polygon> polygons { get; set; }
		public Vector3 sunPosition { get; set; } = new Vector3(100, 100, 900);
		public bool sunAnimation { get; set; }
		public Color sunColor { get; set; } = Color.LightGreen;
		public float sunHeightModifier { get; set; } = 1;
	}
}
