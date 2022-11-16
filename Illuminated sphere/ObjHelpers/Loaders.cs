using Illuminated_sphere.Models;
using ObjLoader.Loader.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminated_sphere.ObjHelpers
{
	internal static class Loaders
	{
		public static LoadResult loadObj(string fileName)
		{
			var objLoaderFactory = new ObjLoaderFactory();
			var objLoader = objLoaderFactory.Create();

			string path = Path.Combine(Environment.CurrentDirectory, @"Props\", fileName);

			FileStream fileStream = new FileStream(path, FileMode.Open);
			LoadResult? loadResult = objLoader.Load(fileStream);

			fileStream.Close();

			return loadResult;
		}

		public static List<Polygon> loadNormalisedObj(string fileName, int width, int heigth)
		{
			LoadResult? loadResult = loadObj(fileName);

			List<Polygon> polygons = Polygon.makePolygonListFromLoadResult(loadResult);
			Converters.convertVerticesFromNormalizedObj(polygons, width, heigth);

			Parallel.ForEach(polygons, polygon => polygon.calculateDenominator());

			return polygons;
		}

		public static List<Polygon> loadNotNormalisedObj(string fileName)
		{
			LoadResult? loadResult = loadObj(fileName);

			List<Polygon> polygons = Polygon.makePolygonListFromLoadResult(loadResult);

			Parallel.ForEach(polygons, polygon => polygon.calculateDenominator());

			return polygons;
		}
	}
}
