using Illuminated_sphere.Models;
using ObjLoader.Loader.Data.VertexData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;
using Vertex = Illuminated_sphere.Models.Vertex;

namespace Illuminated_sphere.Utility
{
	internal static class NormalMapOperations
	{
		public static void modifyNormals(ProjectData projectData)
		{
			using (var normalMap = new BmpPixelSnoop(projectData.normalMap))
			{
				foreach (Polygon polygon in projectData.polygons)
				{
					foreach (Vertex vertex in polygon.vertices)
					{
						Color color = normalMap.GetPixel((int)vertex.x, (int)vertex.y);

						float Nx = normalizeColor1(color.R);
						float Ny = normalizeColor1(color.G);
						float Nz = normalizeColor2(color.B);

						Vector3 N_tekstury = new Vector3(Nx, Ny, Nz);
						Vector3 N_powierzchni = vertex.normal;
						Vector3 B;
						if (N_powierzchni == new Vector3(0, 0, 1)) B = new Vector3(0, 1, 0);
						else B = Vector3.Cross(N_powierzchni, new Vector3(0, 0, 1));
						Vector3 T = Vector3.Cross(B, N_powierzchni);

						vertex.normal = matrixVectorProduct(T, B, N_powierzchni, N_tekstury);
					}
				}
			}
		}

		public static Vector3 modifyNormal(ProjectData projectData, Vector3 normal, int x, int y, BmpPixelSnoop normalMap)
		{
			Color color = normalMap.GetPixel(x, y);

			float Nx = normalizeColor1(color.R);
			float Ny = normalizeColor1(color.G);
			float Nz = normalizeColor2(color.B);

			Vector3 N_tekstury = new Vector3(Nx, Ny, Nz);
			Vector3 N_powierzchni = normal;
			Vector3 B;
			if (N_powierzchni == new Vector3(0, 0, 1)) B = new Vector3(0, 1, 0);
			else B = Vector3.Cross(N_powierzchni, new Vector3(0, 0, 1));
			Vector3 T = Vector3.Cross(B, N_powierzchni);

			Vector3 result = matrixVectorProduct(T, B, N_powierzchni, N_tekstury);


			return result;
		}

		private static float normalizeColor1(byte color)
		{
			// Konwersja x z [c,d] do [a,b]
			// a + (b - a) * (x - c) / (d - c)

			// [c, d]   do [a,  b]
			// [0, 255] do [-1, 1]
			//  a + (b - a) * (x - c) / (d - c)
			// -1 + (1 + 1) * (x - 0) / (255 - 0)

			return -1f + 2f * color / 255f;
		}

		private static float normalizeColor2(byte color)
		{
			// Konwersja x z [c,d] do [a,b]
			// a + (b - a) * (x - c) / (d - c)

			// [c, d]   do [a,  b]
			// [0, 255] do [0, 1]
			//  a + (b - a) * (x - c) / (d - c)
			//  x / 255

			return color / 255f;
		}

		private static Vector3 matrixVectorProduct(Vector3 T, Vector3 B, Vector3 N_pow, Vector3 N_tek)
		{
			float[,] M = new float[3, 3];
			M[0, 0] = T.X;
			M[0, 1] = B.X;
			M[0, 2] = N_pow.X;
			M[1, 0] = T.Y;
			M[1, 1] = B.Y;
			M[1, 2] = N_pow.Y;
			M[2, 0] = T.Z;
			M[2, 1] = B.Z;
			M[2, 2] = N_pow.Z;

			float[,] Mv = new float[3, 1];

			float[,] v = new float[3, 1];
			v[0, 0] = N_tek.X;
			v[1, 0] = N_tek.Y;
			v[2, 0] = N_tek.Z;

			for (int i = 0; i < 3; i++)
			{
				Mv[i, 0] = 0f;
				for (int j = 0; j < 3; j++)
				{
					Mv[i, 0] += (M[i, j] * v[j, 0]);
				}
			}
			
			Vector3 result = new Vector3(Mv[0, 0], Mv[1, 0], Mv[2, 0]);

			return result;
		}
	}
}
