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
		Vector3 sunPosition;
		float time;
		double angle;

		public void AnimateSun(ProjectData projectData)
        {
			sunPosition = projectData.sunPosition;

			projectData.sunPosition += new Vector3(10, 0, 0);

            /*Timer timer = new Timer();
			timer.Tick += new EventHandler(calculateSunPosition);
			timer.Interval = 100;

			timer.Start();*/

			
		}

		public void calculateSunPosition(Object myObject, EventArgs myEventArgs)
		{
			float deltaTime = 0.1f;
			float timeSpeed = 1f;
			float angleSpeed = 1f;
			
			
			time += deltaTime * timeSpeed;
			angle += deltaTime * angleSpeed;
			if (angle > 2 * Math.PI) angle -= 2 * Math.PI;

			sunPosition.X = (float)Math.Cos(angle) * time;
			sunPosition.Y = (float)Math.Sin(angle) * time;

		}

		public void calculateSunPosition(ProjectData projectData)
		{
			float deltaTime = 0.1f;
			float timeSpeed = 1f;
			float angleSpeed = 1f;


			time += deltaTime * timeSpeed;
			angle += deltaTime * angleSpeed;
			if (angle > 2 * Math.PI) angle -= 2 * Math.PI;

			sunPosition.X = (float)Math.Cos(angle) * time;
			sunPosition.Y = (float)Math.Sin(angle) * time;

		}

		public static async void sun(ProjectData projectData)
		{
			SunAnimation sunAnimation = new SunAnimation();
			var periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(1));
			while (await periodicTimer.WaitForNextTickAsync())
			{
				if (projectData.sunAnimation == true)
				{
					sunAnimation.AnimateSun(projectData);
					//projectData.sunPosition = new Vector3(1000, 100, 900);
					Filler.fillPolygons(projectData);
				}
			}

		}
	}
}
