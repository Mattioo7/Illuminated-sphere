using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Models
{
	internal class Polygon
	{
		public List<Vertex> vertices { get; set; }

		public Polygon() 
		{
			vertices = new List<Vertex>();
		}

		public Polygon(List<Vertex> vertices)
		{
			this.vertices = vertices;
		}

		public static List<Polygon> makePolygonListFromLoadResult(LoadResult loadResult)
		{
			List<Polygon> polygons = new List<Polygon>();

			// każdego for'a mogę rozbić na metody
			for (int i = 0; i < loadResult.Groups[0].Faces.Count; i++)
			{
				Polygon polygon = new Polygon();
				Face face = loadResult.Groups[0].Faces[i];

				for (int j = 0; j < face.Count; j++)
				{
					FaceVertex faceVertex = face[j];
					Vertex newVertex = new Vertex(loadResult.Vertices[faceVertex.VertexIndex - 1]);

					polygon.vertices.Add(newVertex);
				}

				polygons.Add(polygon);
			}

			return polygons;
		}
	}
}
