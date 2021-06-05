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

        private const string separator = ",|—";



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


        public static List<Models.PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {

            List<Models.PrizeModel> output = new List<Models.PrizeModel>();

            foreach (string line in lines)
            {

                string[] column = line.Split(separator[0]);

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
                string[] column = line.Split(separator[0]);

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



        #region Pipe Separator

        public static List<Models.TournamentModel> ConvertToTournamentModels(this List<string> lines, string teamFileName, string peopleFileName, string pizesFileName)
        {
            List<Models.TournamentModel> output = new List<Models.TournamentModel>();
            List<Models.TeamModel> teams = teamFileName.FullTxtFilePath().LoadFile().ConvertToTeamModels(peopleFileName);
            List<Models.PrizeModel> prizes = pizesFileName.FullTxtFilePath().LoadFile().ConvertToPrizeModels();
            //        List<Models.MatchupModel> matchups = MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(separator[0]);

                Models.TournamentModel tm = new Models.TournamentModel();
                tm.ID = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split(separator[1]);

                foreach (string Id in teamIds)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.ID == int.Parse(Id)).First());
                }

                if (cols[4].Length > 0)
                {
                    string[] prizeIds = cols[4].Split(separator[1]);

                    foreach (string Id in prizeIds)
                    {
                        tm.Prizes.Add(prizes.Where(x => x.ID == int.Parse(Id)).First());
                    }
                }

                //TODO: realize round capture.

                //// Capture Rounds information
                //string[] rounds = cols[5].Split('|');

                //foreach (string round in rounds)
                //{
                //    string[] msText = round.Split('^');
                //    List<MatchupModel> ms = new List<MatchupModel>();

                //    foreach (string matchupModelTextId in msText)
                //    {
                //        ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First());
                //    }

                //    tm.Rounds.Add(ms);
                //}

                output.Add(tm);
            }

            return output;

        }

        public static List<Models.TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
        {

            List<Models.TeamModel> output = new List<Models.TeamModel>();
            List<Models.PersonModel> ppl = peopleFileName.FullTxtFilePath().LoadFile().ConvertToPersonModels();


            string[] column;


            foreach (string line in lines)
            {
                column = line.Split(separator[0]);

                Models.TeamModel team = new Models.TeamModel();


                team.ID = int.Parse(column[0]);
                team.TeamName = column[1];



                string[] personIDs = column[2].Split(separator[1]);

                foreach (string id in personIDs)
                {

                    team.TeamMembers.Add(ppl.Where(x => x.ID == int.Parse(id)).First());


                }

                output.Add(team);

            }

            return output;
        }



        #endregion



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


        public static void SaveToTeamFile(this List<Models.TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Models.TeamModel team in models)
            {
                lines.Add($"{ team.ID },{ team.TeamName},{ConvertPeopleListToString(team.TeamMembers) }");
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);
        }


        public static void SaveToTournametFile(this List<Models.TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Models.TournamentModel tournamentM in models)
            {
                lines.Add($@"{ tournamentM.ID },
                                      { tournamentM.TournamentName },
                                      { tournamentM.EntryFee },
                                      { ConvertTeamListToString(tournamentM.EnteredTeams) }, 
                                      { ConvertPrizeListToString(tournamentM.Prizes) },
                                      { "" }");
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);
        }


        #endregion





        #region Convert list to str /  Helper Methods

        private static string ConvertPeopleListToString(List<Models.PersonModel> ppl)
        {

            string output = "";

            if (ppl.Count == 0)
            {
                return "";
            }

            foreach (Models.PersonModel person in ppl)
            {

                output += $" {person.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;
        }

        private static string ConvertTeamListToString(List<Models.TeamModel> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (Models.TeamModel tm in teams)
            {

                output += $" {tm.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;

        }


        private static string ConvertPrizeListToString(List<Models.PrizeModel> prizes)
        {
            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (Models.PrizeModel pm in prizes)
            {

                output += $" {pm.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;

        }


        private static string ConvertRoundsListToString(List<List<Models.MatchupModel>> rounds)
        {
            string output = "";

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<Models.MatchupModel> r in rounds)
            {

                output += $" {ConvertMatchupsListToString(r)}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;

        }

        private static string ConvertMatchupsListToString(List<Models.MatchupModel> matchups)
        {
            string output = "";

            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (Models.MatchupModel mm in matchups)
            {

                output += $" {mm.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;

        }



        #endregion



    }

}
