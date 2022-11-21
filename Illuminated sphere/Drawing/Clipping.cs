using Illuminated_sphere.Models;
using Illuminated_sphere.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.Drawing
{
	internal class Clipping
	{
		static uint INSIDE = 0; // 0000
		static uint LEFT = 1;   // 0001
		static uint RIGHT = 2;  // 0010
		static uint BOTTOM = 4; // 0100
		static uint TOP = 8;    // 1000

		public static uint ComputeOutCode(float x, float y, ProjectData projectData)
		{
			uint code = INSIDE;  // initialised as being inside of clip window

			uint xmin = (uint)projectData.left.X;
			uint xmax = (uint)projectData.right.X;
			uint ymin = (uint)projectData.left.Y;
			uint ymax = (uint)projectData.right.X;


			if (x < xmin)           // to the left of clip window
				code |= LEFT;
			else if (x > xmax)      // to the right of clip window
				code |= RIGHT;
			if (y < ymin)           // below the clip window
				code |= BOTTOM;
			else if (y > ymax)      // above the clip window
				code |= TOP;

			return code;
		}

		public static bool CohenSutherlandLineClip(Vertex v0, Vertex v1, ProjectData projectData)
		{

			uint outcode0 = ComputeOutCode(v0.x, v0.y, projectData);
			uint outcode1 = ComputeOutCode(v1.x, v1.y, projectData);
			bool accept = false;

			while (true)
			{
				if ((outcode0 | outcode1) == 0)
				{
					accept = true;
					break;
				}
				else if ((outcode0 & outcode1) != 0)
				{
					break;
				}
				else
				{

					double x = 0, y = 0;


					uint outcodeOut = outcode1 > outcode0 ? outcode1 : outcode0;

					if ((outcodeOut & TOP) > 0)
					{
						x = v0.x + (v1.x - v0.x) * (projectData.right.Y - v0.y) / (v1.y - v0.y);
						y = projectData.right.Y;
					}
					else if ((outcodeOut & BOTTOM) > 0)
					{
						x = v0.x + (v1.x - v0.x) * (projectData.left.Y - v0.y) / (v1.y - v0.y);
						y = projectData.left.Y;
					}
					else if ((outcodeOut & RIGHT) > 0)
					{
						y = v0.y + (v1.y - v0.y) * (projectData.right.X - v0.x) / (v1.x - v0.x);
						x = projectData.right.X;
					}
					else if ((outcodeOut & LEFT) > 0)
					{
						y = v0.y + (v1.y - v0.y) * (projectData.left.X - v0.x) / (v1.x - v0.x);
						x = projectData.left.X;
					}

					if (outcodeOut == outcode0)
					{
						v0.x = (float)x;	
						v0.y = (float)y;	
						outcode0 = ComputeOutCode(v0.x, v0.y, projectData);
					}
					else
					{
						v1.x = (float)x;
						v1.y = (float)y;
						outcode1 = ComputeOutCode(v1.x, v1.y, projectData);
					}
				}
			}
			return accept;
		}
	}
}
