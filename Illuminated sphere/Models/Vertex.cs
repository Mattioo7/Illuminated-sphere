using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Models
{
	// albo skorzystać z ObjLoader.Loader.Data.VertexData.Vertex
	internal class Vertex
	{
		public double x { get; set; }
		public double y { get; set; }
		public double z { get; set; }

		public Vertex()	{}

		public Vertex(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vertex(ObjLoader.Loader.Data.VertexData.Vertex vertex)
		{
			this.x = vertex.X;
			this.y = vertex.Y; 
			this.z = vertex.Z;
		}

		public static implicit operator Point(Vertex vertex) => new Point((int)vertex.x, (int)vertex.y);
	}
}
