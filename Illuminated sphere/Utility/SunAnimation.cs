using Illuminated_sphere.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Illuminated_sphere.Utility
{
    internal class SunAnimation
    {
		public static void calculateSunPosition(Object obj, EventArgs myEventArgs, ProjectData projectData)
		{
			if (projectData.sunPosition.X < 600 && projectData.sunPosition.Y == 100)
			{
				projectData.sunPosition += new Vector3(10, 0, 0);
			}
			else if (projectData.sunPosition.X >= 600 && projectData.sunPosition.Y < 600)
			{
				projectData.sunPosition += new Vector3(0, 10, 0);
			}
			else if (projectData.sunPosition.X >= 100 && projectData.sunPosition.Y >= 600)
			{
				projectData.sunPosition += new Vector3(-10, 0, 0);
			}
			else if (projectData.sunPosition.X <= 100 && projectData.sunPosition.Y > 100)
			{
				projectData.sunPosition += new Vector3(0, -10, 0);
			}

			Filler.fillPolygons(projectData);
		}
	}
}
