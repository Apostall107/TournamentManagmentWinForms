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

        private const string separator = ",|*";



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
                    PhoneNumber = column[4]
                };

                output.Add(person);
            }

            return output;
        }



        #region Pipe Separator

        public static List<Models.TournamentModel> ConvertToTournamentModels(this List<string> lines)
        {
            List<Models.TournamentModel> output = new List<Models.TournamentModel>();
            List<Models.TeamModel> teams = GlobalConfig.TeamFile.FullTxtFilePath().LoadFile().ConvertToTeamModels();
            List<Models.PrizeModel> prizes = GlobalConfig.PrizesFile.FullTxtFilePath().LoadFile().ConvertToPrizeModels();
            List<Models.MatchupModel> matchups = GlobalConfig.MatchupFile.FullTxtFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                string[] columns = line.Split(separator[0]);

                Models.TournamentModel tm = new Models.TournamentModel();

                //TODO drops here
                tm.ID = int.Parse(columns[0]);
                tm.TournamentName = columns[1];

                tm.EntryFee = decimal.Parse(columns[2]);

                string[] teamIDs = columns[3].Split(separator[1]);

                foreach (string Id in teamIDs)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.ID == int.Parse(Id)).First());
                }

                if (columns[4].Length > 0)
                {
                    string[] prizeIDs = columns[4].Split(separator[1]);

                    foreach (string Id in prizeIDs)
                    {
                        tm.Prizes.Add(prizes.Where(x => x.ID == int.Parse(Id)).First());
                    }
                }



                // Capture Rounds info / populating all our rounds
                string[] rounds = columns[5].Split(separator[1]);

                foreach (string round in rounds)
                {
                    string[] msTxt = round.Split(separator[2]);
                    List<Models.MatchupModel> ms = new List<Models.MatchupModel>();

                    foreach (string matchupModelTextId in msTxt)
                    {
                        ms.Add(matchups.Where(x => x.ID == int.Parse(matchupModelTextId)).First());
                    }

                    tm.Rounds.Add(ms);
                }

                output.Add(tm);
            }

            return output;

        }

        public static List<Models.TeamModel> ConvertToTeamModels(this List<string> lines)
        {

            List<Models.TeamModel> output = new List<Models.TeamModel>();
            List<Models.PersonModel> ppl =GlobalConfig.PeopleFile.FullTxtFilePath().LoadFile().ConvertToPersonModels();


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

        public static List<Models.MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {

            //TODO check and fix all
            // Id = 0, TeamCompeting = 1, Score = 2, ParentMatchup = 3

            List<Models.MatchupEntryModel> output = new List<Models.MatchupEntryModel>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(separator[0]);

                Models.MatchupEntryModel matchupEntry = new Models.MatchupEntryModel();

                matchupEntry.ID = int.Parse(columns[0]);

                if (columns[1].Length == 0)
                {
                    matchupEntry.TeamCompeting = null;
                }
                else
                {
                    matchupEntry.TeamCompeting = LookupTeamById(int.Parse(columns[1]));
                }

                matchupEntry.Score = double.Parse(columns[2]);



                int parentID = 0;

                if (int.TryParse(columns[3], out parentID))
                {
                    matchupEntry.ParentMatchup = LookupMatchupById(parentID);
                }
                else
                {
                    matchupEntry.ParentMatchup = null;
                }

                output.Add(matchupEntry);
            }

            return output;
        }



        public static List<Models.MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {


            //TODO check all 
            // Id = 0, Entries = 1(pipe delimited by Id), Winner = 2, MatchupRound = 3
            var output = new List<Models.MatchupModel>();

            foreach (string line in lines)
            {


                string[] columns = line.Split(separator[0]);

                var m = new Models.MatchupModel();

                m.ID = int.Parse(columns[0]); ;
                m.Entries = ConvertStingToMatchupEntryModels(columns[1]);

                if (columns[2].Length == 0)
                {
                    m.Winner = null;
                }
                else
                {
                    m.Winner = LookupTeamById(int.Parse(columns[2]));
                }

                m.MatchupRound = int.Parse(columns[3]);

                output.Add(m);


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
                lines.Add($"{ person.ID },{ person.FirstName },{ person.LastName },{ person.Email },{ person.PhoneNumber }");
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
                lines.Add($"{ tournamentM.ID }," +
                    $"{ tournamentM.TournamentName }," +
                    $"{ tournamentM.EntryFee }," +
                    $"{ ConvertTeamListToString(tournamentM.EnteredTeams) }," +
                    $"{ ConvertPrizeListToString(tournamentM.Prizes) }," +
                    $"{ "" }");
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);
        }

        public static void SoveRoundsToFile(this Models.TournamentModel model)
        {

            foreach (List<Models.MatchupModel> round in model.Rounds)
            {

                foreach (Models.MatchupModel matchup in round)
                {

                    matchup.SaveMatchupToFile();



                }

            }

        }

        
        public static void SaveMatchupToFile(this Models.MatchupModel matchup)
        {
            List<Models.MatchupModel> matchups = GlobalConfig.MatchupFile.FullTxtFilePath().LoadFile().ConvertToMatchupModels();

            int currentID = 1;

            if (matchups.Count > 0)
            {
                currentID = matchups.OrderByDescending(x => x.ID).First().ID + 1;
            }

            matchup.ID = currentID;

            matchups.Add(matchup);



            foreach (Models.MatchupEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile();
            }


            //savin it to file
            List<string> lines = new List<string>();

            foreach (Models.MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.ID.ToString();
                }
                lines.Add($"{ m.ID },{ ConvertMatchupEntryListToString(m.Entries) },{ winner },{ m.MatchupRound }");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullTxtFilePath(), lines);
        }

        public static void UpdateMatchupToFile(this Models.MatchupModel matchup)
        {
        }

        public static void SaveEntryToFile(this Models.MatchupEntryModel entry)
        {
            List<Models.MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullTxtFilePath().LoadFile().ConvertToMatchupEntryModels();

            int currentID = 1;

            if (entries.Count > 0)
            {
                currentID = entries.OrderByDescending(x => x.ID).First().ID + 1; ;
            }

            entry.ID = currentID;
            entries.Add(entry);



            List<string> lines = new List<string>();

            foreach (Models.MatchupEntryModel e in entries)
            {
                string parent = "";
                if (e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.ID.ToString();
                }

                string teamCompeting = "";
                if (e.TeamCompeting != null)
                {
                    teamCompeting = e.TeamCompeting.ID.ToString();
                }

                lines.Add($"{ e.ID },{ teamCompeting },{ e.Score },{ parent }");
            }


            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullTxtFilePath(), lines);

        }

        public static void UpdateEntryToFile(this Models.MatchupEntryModel entry)
        {

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


        //TODO check and fix below.

        private static string ConvertMatchupEntryListToString(List<Models.MatchupEntryModel> matchupEntries)
        {

            string output = "";

            if (matchupEntries.Count == 0)
            {
                return "";
            }

            foreach (Models.MatchupEntryModel me in matchupEntries)
            {

                output += $" {me.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;




        }




        private static List<Models.MatchupEntryModel> ConvertStingToMatchupEntryModels(string input)
        {

            //TODO check
            string[] ids = input.Split(separator[1]);
            List<Models.MatchupEntryModel> output = new List<Models.MatchupEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullTxtFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] columns = entry.Split(separator[0]);

                    if (columns[0] == id)
                    {

                        matchingEntries.Add(entry);

                    }

                }
            }

            output = matchingEntries.ConvertToMatchupEntryModels();

            return output;
        }


        private static Models.TeamModel LookupTeamById(int ID)
        {
         
            List<string> teams = GlobalConfig.TeamFile.FullTxtFilePath().LoadFile();


            foreach (string team in teams)
            {
              
              
                string[] columns = team.Split(separator[0]);

                if (columns[0] == ID.ToString())
                {

                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                  
                    
                    return matchingTeams.ConvertToTeamModels().First();
                    
                }


            }

            return null;

        }

        private static Models.MatchupModel LookupMatchupById(int ID)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullTxtFilePath().LoadFile();


            foreach (string matchup in matchups)
            {
               
                string[] cols = matchup.Split(',');

                if (cols[0] == ID.ToString())
                {
                   
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchupModels().First();

                }

            }

            return null;
        }




        #endregion



    }

}
