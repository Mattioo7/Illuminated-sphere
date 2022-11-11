using Illuminated_sphere.Models;
using Illuminated_sphere.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Drawing
{
	internal static class BasicDrawing
	{
		public static void drawVertices(List<Polygon> polygons, ProjectData projectData)
		{
			int RADIUS = 4;

			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))
			{
				/*g.Clear(Color.AliceBlue);*/
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
			using (Graphics g = Graphics.FromImage(projectData.workingArea.Image))	// czy to będzie spowalniało program?
			{
				//g.Clear(Color.AliceBlue);
				for (int i = 0; i < polygons.Count; ++i)
				{
					for (int j = 0; j < polygons[i].vertices.Count; ++j)
					{
						Vertex vertex1 = polygons[i].vertices[j];
						Vertex vertex2 = polygons[i].vertices[(polygons[i].vertices.Count + j - 1) % polygons[i].vertices.Count];
						g.DrawLine(new Pen(Color.Black, 1), vertex1, vertex2);
					}
				}
			}

			projectData.workingArea.Refresh();
		}
	}
}
