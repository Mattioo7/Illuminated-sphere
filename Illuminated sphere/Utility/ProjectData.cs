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
		public float kd { get; set; }
		public float ks { get; set; }
		public int m { get; set; }
		public Color sun { get; set; }
		public Vector3 sunPosition { get; set; }
		public Color objColor { get; set; }
		public bool colorInterpolation { get; set; }
		public PictureBox workingArea { get; set; }
		public List<Polygon> polygons { get; set; }

	}
}
