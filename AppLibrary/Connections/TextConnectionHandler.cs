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

        #region path/load
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

        #endregion




        #region ConvertTo...Models
        
        private const char separator = '|';

        public static List<Models.PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {

            List<Models.PrizeModel> output = new List<Models.PrizeModel>();

            foreach (string line in lines)
            {

                string[] column = line.Split(separator);

                Models.PrizeModel p = new Models.PrizeModel();
                p.ID = int.Parse(column[0]);
                p.PlaceNumber = int.Parse(column[1]);
                p.PlaceName = column[2];
                p.PrizeAmount = decimal.Parse(column[3]);
                p.PrizePercentage = double.Parse(column[4]);
                output.Add(p);

            }

            return output;
        }
        public static List<Models.PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<Models.PersonModel> output = new List<Models.PersonModel>();

            foreach (string line in lines)
            {
                string[] column = line.Split(separator);

                Models.PersonModel person = new Models.PersonModel
                {
                    ID = int.Parse(column[0]),
                    FirstName = column[1],
                    LastName = column[2],
                    Email = column[3],
                    PhoneNum = column[4]
                };

                output.Add(person);
            }

            return output;
        }

        #endregion



        #region SaveTo...File

        public static void SaveToPrizeFile(this List<Models.PrizeModel> models, string fileName)
        {


            List<string> lines = new List<string>();

            foreach (Models.PrizeModel prize in models)
            {

                lines.Add($"{ prize.ID},{prize.PlaceNumber },{ prize.PlaceName},{prize.PrizeAmount},{prize.PrizePercentage}");
            
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);

        }
        
        public static void SaveToPeopleFile(this List<Models.PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Models.PersonModel person in models)
            {
                lines.Add($"{ person.ID },{ person.FirstName },{ person.LastName },{ person.Email },{ person.PhoneNum }");
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);
        }
        #endregion





    }

}
