using Illuminated_sphere.Models;
using Illuminated_sphere.Utility;
using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertex = Illuminated_sphere.Models.Vertex;

namespace Illuminated_sphere.Drawing
{
	internal static class BasicDrawing
	{
		public static void drawVertices(List<Polygon> polygons, ProjectData projectData)
		{
			int RADIUS = 4;

			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				for (int i = 0; i < polygons.Count; ++i)
				{
					for (int j = 0; j < polygons[i].vertices.Count; ++j)
					{
						Vertex vertex = polygons[i].vertices[j];
						g.FillEllipse(Brushes.Black, (int)vertex.x - RADIUS + 2, (int)vertex.y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
					}
				}
			}

			projectData.workingArea.Refresh();
		}

		public static void drawVertex(Point point, ProjectData projectData)
		{
			int RADIUS = 8;

			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				g.FillEllipse(Brushes.Black, (int)point.X - RADIUS + 2, (int)point.Y - RADIUS + 2, (RADIUS - 2) * 2, (RADIUS - 2) * 2);
			}

			projectData.workingArea.Refresh();
		}

		public static void drawLines(List<Polygon> polygons, ProjectData projectData)
		{
			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				Point a = projectData.left;
				Point b = new Point(projectData.left.X, projectData.right.Y);
				Point c = projectData.right;
				Point d = new Point(projectData.right.X, projectData.left.Y);

				g.DrawLine(new Pen(Color.GreenYellow, 2), a, b);
				g.DrawLine(new Pen(Color.GreenYellow, 2), b, c);
				g.DrawLine(new Pen(Color.GreenYellow, 2), c, d);
				g.DrawLine(new Pen(Color.GreenYellow, 2), d, a);

				for (int i = 0; i < polygons.Count; ++i)
				{
					for (int j = 0; j < polygons[i].vertices.Count; ++j)
					{


						Vertex vertex1 = polygons[i].vertices[j];
						Vertex vertex2 = polygons[i].vertices[(polygons[i].vertices.Count + j - 1) % polygons[i].vertices.Count];

						/*if (vertex1.x > projectData.left.X && vertex1.x < projectData.right.X && vertex1.y > projectData.left.Y && vertex1.y < projectData.right.Y
							&& vertex2.x > projectData.left.X && vertex2.x < projectData.right.X && vertex2.y > projectData.left.Y && vertex2.y < projectData.right.Y)
						{
							g.DrawLine(new Pen(Color.Red, 1), vertex1, vertex2);
						}
						else
						{
							g.DrawLine(new Pen(Color.Black, 1), vertex1, vertex2);
						}*/
						//g.DrawLine(new Pen(Color.Black, 1), vertex1, vertex2);

						if (Clipping.CohenSutherlandLineClip(vertex1, vertex2, projectData))
						{
							g.DrawLine(new Pen(Color.Red, 1), vertex1, vertex2);
							projectData.workingArea.Refresh();
						}
					}
				}
			}

			projectData.workingArea.Refresh();
		}
	}
}
