using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index.Quadtree;
using NetTopologySuite.IO;

namespace Json_problem
{
    internal class Program
    {
        internal static string geojson_pfad = string.Empty;
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (!IsJson(arg))
                {
                    continue;
                }
                var reader = new GeoJsonReader();
                // TODO can crash because not right coordinates
                FeatureCollection featuresCollection = reader.Read<FeatureCollection>(File.ReadAllText(geojson_pfad));

                foreach (var feature in featuresCollection)
                {
                    Console.WriteLine("KEKSE TEST");
                    bool test = feature.Geometry.IsValid;
                    Console.WriteLine(test);
                }

                Console.WriteLine(featuresCollection);
                Console.WriteLine(arg);
                Console.WriteLine("KEKSE");
            }
        }

        internal static bool IsJson(string datei_pfad)
        {
            FileInfo file = new FileInfo(datei_pfad);
            if (!file.Exists)
            {
                System.Environment.Exit(0); // TODO FEHLER CODE xx
            }
            if(file.Extension.Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                geojson_pfad = datei_pfad;
                return true;
            }
            return false;
        }
    }
}
