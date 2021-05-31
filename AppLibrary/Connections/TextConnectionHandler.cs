using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Connections.TextConnectionHandler
{
    public static class TextConnectionHandler
    {

        public static string FullTxtFilePath(this string fileName)
        {

            return $"{ ConfigurationManager.AppSettings["FilePath"] }\\{fileName}";

        }

        public static List<string> LoadFile(this string file)
        {

            if (!File.Exists(file))
            {

                return new List<string>();

            }

            return File.ReadAllLines(file).ToList();




        }


        public static List<Models.PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {

            List<Models.PrizeModel> output = new List<Models.PrizeModel>();

            foreach (string ln in lines)
            {

                string[]  cols = ln.Split(',');

                Models.PrizeModel p = new Models.PrizeModel();
                p.ID = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);

            }

            return output;
        }


        public static void SaveToPrizeFile(this List<Models.PrizeModel> models, string fileName)
        {


            List<string> ln = new List<string>();

            foreach (Models.PrizeModel p in models)
            {

                ln.Add($"{ p.ID},{p.PlaceNumber },{ p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), ln);

        }


    }

}
