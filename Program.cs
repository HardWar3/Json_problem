using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index.Quadtree;
using NetTopologySuite.IO;
// AD, AE, AF, AG, AI, AL, AM, AO, AQ, AR, AS, AT, AU, AW, AX, AZ, BA, BB, BD, BE, BF, BG, BH, BI, BJ, BL, BM, BN, BO, BQ, BR, BS, BT, BV, BW, BY, BZ, CA, CC, CD, CF, CG, CH, CI, CK, CL, CM, CN, CO, CR, CU, CV, CW, CX, CY, CZ, DE, DJ, DK, DM, DO, DZ, EC, EE, EG, EH, ER, ES, ET, FI, FJ, FK, FM, FO, FR, GA, GB, GD, GE, GF, GG, GH, GI, GL, GM, GN, GP, GQ, GR, GT, GU, GW, GY, HK, HM, HN, HR, HT, HU, ID, IE, IL, IM, IN, IO, IQ, IR, IS, IT, JE, JM, JO, JP, KE, KG, KH, KI, KM, KN, KP, KR, KW, KY, KZ, LA, LB, LC, LI, LK, LR, LS, LT, LU, LV, LY, MA, MC, MD, ME, MF, MG, MH, MK, ML, MM, MN, MO, MP, MQ, MR, MS, MT, MU, MV, MW, MX, MY, MZ, NA, NC, NE, NF, NG, NI, NL, NO, NP, NR, NU, NZ, OM, PA, PE, PF, PG, PH, PK, PL, PM, PN, PR, PT, PW, PY, QA, RE, RO, RS, RU, RW, SA, SB, SC, SD, SE, SG, SH, SI, SJ, SK, SL, SM, SN, SO, SR, SS, ST, SV, SX, SY, SZ, TC, TD, TF, TG, TH, TJ, TK, TL, TM, TN, TO, TR, TT, TV, TW, TZ, UA, UG, UM, US, UY, UZ, VA, VC, VE, VG, VI, VN, VU, WF, WS, YE, YT, ZA, ZM, ZW

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
