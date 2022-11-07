using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Models
{
	internal class AETPointer
	{
		public double y_max { get; set; }
		public double x { get; set; }
		public double alfa { get; set; }

		public AETPointer()
		{
		}

		public AETPointer(double y_max, double x, double alfa)
		{
			this.y_max = y_max;
			this.x = x;
			this.alfa = alfa;
		}

	}
}
