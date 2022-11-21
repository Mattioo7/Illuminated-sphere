using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Models
{
	internal class Outcode
	{
		public uint all { get; set; }
		public uint left { get; set; }
		public uint right { get; set; }
		public uint bottom { get; set; }
		public uint top { get; set; }
	}
}
