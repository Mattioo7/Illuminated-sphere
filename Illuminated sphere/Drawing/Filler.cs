using Illuminated_sphere.Models;
using Illuminated_sphere.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Illuminated_sphere.Utility;
using System.Numerics;
using System.Runtime.Intrinsics;
using ObjLoader.Loader.Data.VertexData;

namespace Illuminated_sphere.Drawing
{
	internal static class Filler
	{
		public static void fillPolygons(ProjectData projectData)
		{
			using (var snoop = new BmpPixelSnoop((Bitmap)projectData.workingArea.Image))
			{
				if (projectData.useTexture && projectData.useNormalMap)
				{
					using (var texture = new BmpPixelSnoop(projectData.texture))
					using (var normalMap = new BmpPixelSnoop(projectData.normalMap))
					{
						Parallel.ForEach(projectData.polygons, polygon => fillPolygon(polygon, projectData, snoop, texture, null, normalMap));
						/*foreach (Polygon polygon in projectData.polygons)
							fillPolygon(polygon, projectData, snoop, texture, null, normalMap);*/
					}
				}
				else if (projectData.useTexture)
				{
					using (var texture = new BmpPixelSnoop(projectData.texture))
					{
						Parallel.ForEach(projectData.polygons, polygon => fillPolygon(polygon, projectData, snoop, texture, null, null));
						/*foreach (Polygon polygon in projectData.polygons)
							fillPolygon(polygon, projectData, snoop, texture, null, normalMap);*/
					}
				}
				else if (projectData.useNormalMap)
				{
					using (var normalMap = new BmpPixelSnoop(projectData.normalMap))
					{
						Parallel.ForEach(projectData.polygons, polygon => fillPolygon(polygon, projectData, snoop, null, null, normalMap));
						/*foreach (Polygon polygon in projectData.polygons)
							fillPolygon(polygon, projectData, snoop, texture, null, normalMap);*/
					}
				}
			}

			projectData.workingArea.Refresh();
			return;
		}

		public static void fillPolygons2(ProjectData projectData, int i, Color? polyColor = null)
		{
			using (var snoop = new BmpPixelSnoop((Bitmap)projectData.workingArea.Image))
			{
				fillPolygon(projectData.polygons[i], projectData, snoop, null, polyColor, null);
			}
		}

		public static void fillPolygon(Polygon polygon, ProjectData projectData, BmpPixelSnoop bitmap, BmpPixelSnoop? texture, Color? objectColor = null, BmpPixelSnoop? normalMap = null)
		{
			//Stopwatch timing = new Stopwatch();
			//timing.Start();

			List<Vertex> vertices = polygon.vertices;

			if (projectData.interpolateColor)
			{
				ColorGenerator.setVerticesColors(polygon, projectData, texture);
			}
		
			List<Vertex> sortedVertices = vertices.OrderBy(vertex => vertex.y).ToList();

			int[] ind = new int[polygon.vertices.Count];
			for (int i = 0; i < vertices.Count; i++)
			{
				ind[i] = vertices.IndexOf(sortedVertices[i]);
			}

			int ymin = (int)sortedVertices.First().y;
			int ymax = (int)sortedVertices.Last().y;

			List<AETPointer> AET = new List<AETPointer>();

	
			{ // do debugowania
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

					if (AET.Count % 2 == 0) // todo: usunąć ---------------------------
					{
						for (int i = 0; i < Math.Min(AET.Count, 2); i += 2) // todo: usunąć Math.Min ---------------------------
						{
							for (int x = (int)AET[i].x; x <= (int)AET[i + 1].x; ++x)
							{
								if (x >= projectData.workingArea.Width || x <= 0)
								{
									/*Debug.WriteLine("x: " + x);
									Debug.WriteLine("y: " + y);*/
									continue;
								}

								Color color = Color.Red;
								// interpolacja koloru 
								if (projectData.interpolateColor)
								{
									color = ColorGenerator.generatePixelColor(polygon, x, y);
								}
								else
								{
									// albo interpolacja wektora
									Vector3 normal = ColorGenerator.interpolateNormal(polygon, x, y);
									if (projectData.useNormalMap)
									{
										normal = NormalMapOperations.modifyNormal(projectData, normal, x, y, normalMap);
									}

									color = ColorGenerator.generatePixelColorFromNormalVector(polygon, projectData, x, y, normal, texture);
									//Debug.WriteLine("Draw poly" + polygon.ToString());
								}

								// debugowanie
								if (objectColor != null)
								{
									color = (Color)objectColor;
								}

								bitmap.SetPixel(x, y, color);
							}
						}
					}


					foreach (var a in AET)
					{
						a.x += a.alfa;
					}

				}
			}

			//timing.Stop();
			//Debug.WriteLine("Elapsed time fillPolygon: {0} ms", timing.ElapsedMilliseconds);
		}
	}
}
