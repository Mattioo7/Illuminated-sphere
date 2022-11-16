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
		public float x { get; set; }
		public float y { get; set; }
		public float z { get; set; }

		public Vector3 normal { get; set; }
		public byte A { get; set; }
		public byte R { get; set; }
		public byte G { get; set; }
		public byte B { get; set; }

		public Color Color => this.color();

		public Vertex()	{}

		public Vertex(float x, float y, float z, Normal normal = default)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.normal = new Vector3(normal.X, normal.Y, normal.Z);
		}

		public Vertex(ObjLoader.Loader.Data.VertexData.Vertex vertex, Normal normal = default)
		{
			this.x = vertex.X;
			this.y = vertex.Y; 
			this.z = vertex.Z;
			this.normal = new Vector3(normal.X, normal.Y, normal.Z);
		}

		public static implicit operator Point(Vertex vertex) => new Point((int)vertex.x, (int)vertex.y);

		public static implicit operator Vector3(Vertex vertex) => new Vector3(vertex.x, vertex.y, vertex.z);

		public Color color() => Color.FromArgb(A, R, G, B);
	}
}
