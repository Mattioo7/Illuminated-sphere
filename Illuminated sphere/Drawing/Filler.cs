using Illuminated_sphere.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Drawing
{
	internal static class Filler
	{
		public static void fillPolygons(List<Polygon> polygons, PictureBox workingArea)
		{
			foreach (Polygon polygon in polygons)
			{
				fillPolygon(polygon, workingArea);
			}
		}

		public static void fillPolygons(List<Polygon> polygons, PictureBox workingArea, int i)
		{
			fillPolygon(polygons[i], workingArea);
		}

		public static void fillPolygon(Polygon polygon, PictureBox workingArea)
		{
			List<Vertex> vertices = polygon.vertices;

			List<Vertex> sortedVertices = vertices.OrderBy(vertex => vertex.y).ToList();
			//sortedVertices.Sort((vertex1, vertex2) => vertex1.y > vertex2.y ? 1 : -1);

			int[] ind = new int[polygon.vertices.Count];
			for (int i = 0; i < vertices.Count; i++)
			{
				/*ind[i] = sortedVertices.IndexOf(vertices[i]);*/
				ind[i] = vertices.IndexOf(sortedVertices[i]);
			}

			int ymin = (int)sortedVertices.First().y;
			int ymax = (int)sortedVertices.Last().y;

			List<AETPointer> AET = new List<AETPointer>();

			int k = 0;  // iterator po tablicy sortedVerticesIndexes
			for (int y = ymin + 1; y <= ymax; ++y)
			{
				while ((int)vertices[ind[k]].y == y - 1)
				{
					int prevVertexIndex = (ind[k] - 1 + vertices.Count) % vertices.Count;
					int nextVertexIndex = (ind[k] + 1 + vertices.Count) % vertices.Count;

					if (vertices[prevVertexIndex].y >= vertices[ind[k]].y)
					{
						Vertex u = vertices[prevVertexIndex];
						Vertex v = vertices[ind[k]];

						double m = (u.y - v.y) / (u.x - v.x);
						double alfa;
						if (Math.Abs(m) < 0.00000001)
							alfa = 0;
						else
							alfa = 1 / m;

						AETPointer pointer = new AETPointer(u.y, v.x, alfa);
						AET.Add(pointer);
					}

					if (vertices[nextVertexIndex].y >= vertices[ind[k]].y)
					{
						Vertex u = vertices[nextVertexIndex];
						Vertex v = vertices[ind[k]];

						double m = (u.y - v.y) / (u.x - v.x);
						double alfa;
						if (Math.Abs(m) < 0.00000001)
							alfa = 0;
						else
							alfa = 1 / m;

						AETPointer pointer = new AETPointer(u.y, v.x, alfa);
						AET.Add(pointer);
					}

					k++;

					AET.RemoveAll(pointer => (int)pointer.y_max <= y - 1);
				}

				AET = AET.OrderBy(pointer => pointer.x).ToList();

				if (AET.Count % 2 == 1)
				{
					Debug.WriteLine("xxxxx");
				}

				if (AET.Count % 2 == 0)
				{
					for (int i = 0; i < Math.Min(AET.Count, 2); i += 2)
					{
						for (int x = (int)AET[i].x; x <= (int)AET[i + 1].x; ++x)
						{
							if (x >= workingArea.Width || x <= 0)
							{
								Debug.WriteLine("x: " + x);
								Debug.WriteLine("y: " + y);
								continue;
							}

							((Bitmap)workingArea.Image).SetPixel(x, y, Color.Red);
						}
					}
				}
				

				foreach (var a in AET)
				{
					a.x += a.alfa;
				}

				workingArea.Refresh();
			}
		}
	}
}
