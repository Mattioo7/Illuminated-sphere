using Illuminated_sphere.Models;
using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vertex = Illuminated_sphere.Models.Vertex;

namespace Illuminated_sphere.Drawing
{
	internal static class ColorGenerator
	{
		public static void setVerticesColors(Polygon polygon)
		{
			float kd = 1;
			float ks = 1;
			int m = 60;
			Color sun = Color.LightGreen;
			Vector3 sunPosition = new Vector3(200, 400, 1200);
			Color objColor = Color.Gray;

			foreach (Vertex vertex in polygon.vertices)
			{
				Vector3 sunVector = sunPosition - vertex;
				Vector3 L = Vector3.Normalize(sunVector);

				Vector3 N = Vector3.Normalize(vertex.normal);
				Vector3 rVec = 2 * dot(N, L) * N - L;
				Vector3 R = Vector3.Normalize(rVec);

				Vector3 V = new Vector3(0, 0, 1);

				float RR = toUnity(sun.R) * toUnity(objColor.R) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));
				float GG = toUnity(sun.G) * toUnity(objColor.G) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));
				float BB = toUnity(sun.B) * toUnity(objColor.B) * (kd * cosine(N, L) + ks * (float)Math.Pow(cosine(V, R), m));

				vertex.R = fromUnity(RR); if (vertex.R > 255) vertex.R = 255; if (vertex.R < 0) vertex.R = 0;
				vertex.G = fromUnity(GG); if (vertex.G > 255) vertex.G = 255; if (vertex.G < 0) vertex.G = 0;
				vertex.B = fromUnity(BB); if (vertex.B > 255) vertex.B = 255; if (vertex.B < 0) vertex.B = 0;
				vertex.A = 255;
			}
		}

		public static void setVerticesColorsTest(Polygon polygon)
		{
			for (int i = 0; i < 3; ++i)
			{
				polygon.vertices[i].A = 250;

				if (i == 0)
				{
					polygon.vertices[i].R = 250;
					polygon.vertices[i].G = 1;
					polygon.vertices[i].B = 1;
				}
				if (i == 1)
				{
					polygon.vertices[i].R = 1;
					polygon.vertices[i].G = 250;
					polygon.vertices[i].B = 1;
				}
				if (i == 2)
				{
					polygon.vertices[i].R = 1;
					polygon.vertices[i].G = 1;
					polygon.vertices[i].B = 250;
				}
			}
		}

		public static Color generatePixelColor(Polygon polygon, int x, int y)
		{
			Vertex v1 = polygon.vertices[0];
			Vertex v2 = polygon.vertices[1];
			Vertex v3 = polygon.vertices[2];

			double denominator = ((v2.y - v3.y) * (v1.x - v3.x) + (v3.x - v2.x) * (v1.y - v3.y));
			double W_v1 = ((v2.y - v3.y) * (x - v3.x) + (v3.x - v2.x) * (y - v3.y)) / denominator;
			double W_v2 = ((v3.y - v1.y) * (x - v3.x) + (v1.x - v3.x) * (y - v3.y)) / denominator;
			double W_v3 = 1 - W_v1 - W_v2;

			int colorA = (int)(v1.A * W_v1 + v2.A * W_v2 + v3.A * W_v3);
			int colorR = (int)(v1.R * W_v1 + v2.R * W_v2 + v3.R * W_v3);
			int colorG = (int)(v1.G * W_v1 + v2.G * W_v2 + v3.G * W_v3);
			int colorB = (int)(v1.B * W_v1 + v2.B * W_v2 + v3.B * W_v3);

			if (colorA > 255) colorA = 255; if (colorA < 0) colorA = 0;
			if (colorR > 255) colorR = 255;	if (colorR < 0) colorR = 0;
			if (colorG > 255) colorG = 255;	if (colorG < 0) colorG = 0;
			if (colorB > 255) colorB = 255;	if (colorB < 0) colorB = 0;

			Color color = Color.FromArgb(colorA, colorR, colorG, colorB);

			return color;
		}

		public static void interpolateNormal()
		{

		}

		public static void interpolateColor()
		{

		}

		public static float cosine(Vector3 v1, Vector3 v2)
		{
			return Math.Max(v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z, 0);
		}

		public static float dot(Vector3 v1, Vector3 v2)
		{
			return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
		}

		public static float toUnity(int a)	// do innej klasy
		{
			return a / 255.0f;
		}

		public static byte fromUnity(float a) // do innej klasy
		{
			return (byte)(a * 255.0f);
		}
	}
}
