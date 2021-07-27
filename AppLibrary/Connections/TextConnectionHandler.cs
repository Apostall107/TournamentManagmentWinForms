using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using AppLibrary.Models;

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


        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {

            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {

                string[] column = line.Split(separator[0]);

                PrizeModel p = new PrizeModel
                {
                    ID = int.Parse(column[0]),
                    PlaceNumber = int.Parse(column[1]),
                    PlaceName = column[2],
                    PrizeAmount = decimal.Parse(column[3]),
                    PrizePercentage = double.Parse(column[4])
                };
                output.Add(p);

            }

            return output;
        }
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] column = line.Split(separator[0]);

                PersonModel person = new PersonModel
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

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines)
        {
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullTxtFilePath().LoadFile().ConvertToTeamModels();
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullTxtFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullTxtFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                string[] columns = line.Split(separator[0]);

                TournamentModel tm = new TournamentModel
                {
                    ID = int.Parse(columns[0]),
                    TournamentName = columns[1],

                    EntryFee = decimal.Parse(columns[2])
                };

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
                    List<MatchupModel> ms = new List<MatchupModel>();

                    foreach (string matchupModelTextID in msTxt)
                    {
                        ms.Add(matchups.Where(x => x.ID == int.Parse(matchupModelTextID)).First());
                    }

                    tm.Rounds.Add(ms);
                }

                output.Add(tm);
            }

            return output;

        }

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
        {

            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> ppl = GlobalConfig.PeopleFile.FullTxtFilePath().LoadFile().ConvertToPersonModels();


            string[] column;


            foreach (string line in lines)
            {
                column = line.Split(separator[0]);

                TeamModel team = new TeamModel
                {
                    ID = int.Parse(column[0]),
                    TeamName = column[1]
                };



                string[] personIDs = column[2].Split(separator[1]);

                foreach (string id in personIDs)
                {

                    team.TeamMembers.Add(ppl.Where(x => x.ID == int.Parse(id)).First());


                }

                output.Add(team);

            }

            return output;
        }

        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {

            //TODO check and fix all
            // Id = 0, TeamCompeting = 1, Score = 2, ParentMatchup = 3
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(separator[0]);

                MatchupEntryModel matchupEntry = new MatchupEntryModel
                {
                    ID = int.Parse(columns[0])
                };

                if (columns[1].Length == 0)
                {
                    matchupEntry.TeamCompeting = null;
                }
                else
                {
                    matchupEntry.TeamCompeting = LookupTeamByID(int.Parse(columns[1]));
                }

                matchupEntry.Score = double.Parse(columns[2]);



                int parentID = 0;

                if (int.TryParse(columns[3], out parentID))
                {
                    matchupEntry.ParentMatchup = LookupMatchupByID(parentID);
                }
                else
                {
                    matchupEntry.ParentMatchup = null;
                }

                output.Add(matchupEntry);
            }

            return output;
        }



        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {


            //TODO check all 
            // Id = 0, Entries = 1(pipe delimited by Id), Winner = 2, MatchupRound = 3
            var output = new List<MatchupModel>();

            foreach (string line in lines)
            {


                string[] columns = line.Split(separator[0]);

                var m = new MatchupModel
                {
                    ID = int.Parse(columns[0])
                };
                ;
                m.Entries = ConvertStingToMatchupEntryModels(columns[1]);

                if (columns[2].Length == 0)
                {
                    m.Winner = null;
                }
                else
                {
                    m.Winner = LookupTeamByID(int.Parse(columns[2]));
                }

                m.MatchupRound = int.Parse(columns[3]);

                output.Add(m);


            }


            return output;
        }



        #endregion



        #endregion






        #region SaveTo...File

        public static void SaveToTournamentFile(this List<TournamentModel> models)
        {
            // Id = 0
            // TournamentName = 1
            // EntryFee = 2
            // EnteredTeams = 3
            // Prizes = 4
            // Rounds = 5 (Id^Id^Id^|Id^Id^Id|Id^Id^Id)
            List<string> lines = new List<string>();

            foreach (Models.TournamentModel tm in models)
            {
                lines.Add($"{ tm.ID },{ tm.TournamentName },{ tm.EntryFee },{ ConvertTeamListToString(tm.EnteredTeams) },{ ConvertPrizeListToString(tm.Prizes) },{ ConvertRoundListToString(tm.Rounds) }");
            }

            File.WriteAllLines(GlobalConfig.TournamentFile.FullTxtFilePath(), lines);
        }
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {

            List<string> lines = new List<string>();

            foreach (Models.PrizeModel prize in models)
            {

                lines.Add($"{ prize.ID},{prize.PlaceNumber },{ prize.PlaceName},{prize.PrizeAmount},{prize.PrizePercentage}");

            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);

        }

        public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Models.PersonModel person in models)
            {
                lines.Add($"{ person.ID },{ person.FirstName },{ person.LastName },{ person.Email },{ person.PhoneNumber }");
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Models.TeamModel team in models)
            {
                lines.Add($"{ team.ID },{ team.TeamName},{ConvertPeopleListToString(team.TeamMembers) }");
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);
        }

        public static void SaveToTournametFile(this List<TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Models.TournamentModel tournamentM in models)
            {
                lines.Add($"{ tournamentM.ID }," +
                    $"{ tournamentM.TournamentName }," +
                    $"{ tournamentM.EntryFee }," +
                    $"{ ConvertTeamListToString(tournamentM.EnteredTeams) }," +
                    $"{ ConvertPrizeListToString(tournamentM.Prizes) }," +
                    $"{ ConvertRoundListToString(tournamentM.Rounds) }");
            }

            File.WriteAllLines(fileName.FullTxtFilePath(), lines);
        }
        public static void SoveRoundsToFile(this TournamentModel model)
        {

            foreach (List<Models.MatchupModel> round in model.Rounds)
            {

                foreach (Models.MatchupModel matchup in round)
                {

                    matchup.SaveMatchupToFile();



                }

            }

        }

        public static void SaveMatchupToFile(this MatchupModel matchup)
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
    
        public static void UpdateMatchupToFile(this MatchupModel matchup)
        {

            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullTxtFilePath().LoadFile().ConvertToMatchupModels();

            MatchupModel oldMatchup = new MatchupModel();

            foreach (MatchupModel m in matchups)
            {
                if (m.ID == matchup.ID)
                {
                    oldMatchup = m;
                }
            }

            matchups.Remove(oldMatchup);

            matchups.Add(matchup);

            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                entry.UpdateEntryToFile();
            }

            List<string> lines = new List<string>();

            foreach (MatchupModel mModel in matchups)
            {
                string winner = "";
                if (mModel.Winner != null)
                {
                    winner = mModel.Winner.ID.ToString();
                }
                lines.Add($"{ mModel.ID },{ ConvertMatchupEntryListToString(mModel.Entries) },{ winner },{ mModel.MatchupRound }");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullTxtFilePath(), lines);

        }

        public static void SaveEntryToFile(this MatchupEntryModel entry)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullTxtFilePath().LoadFile().ConvertToMatchupEntryModels();

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
     
        public static void UpdateEntryToFile(this MatchupEntryModel entry)
        {
            List<Models.MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullTxtFilePath().LoadFile().ConvertToMatchupEntryModels();
            Models.MatchupEntryModel oldEntryModel = new Models.MatchupEntryModel();


            foreach (Models.MatchupEntryModel e in entries)
            {
                if (e.ID == entry.ID)
                {
                    oldEntryModel = e;
                }
            }

            entries.Remove(oldEntryModel);

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
        #endregion





        #region Convert list to str /  Helper Methods


        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
        {
            string output = string.Empty;

            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (MatchupModel m in matchups)
            {
                output += $"{ m.ID }{separator[2]}";
            }

            output = output.Substring(0, output.Length - 1);

            return output.Trim(separator[1]);
        }
    
        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            // (Id^Id^Id^|Id^Id^Id|Id^Id^Id)
            string output = string.Empty;

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<MatchupModel> r in rounds)
            {
                output += $"{ ConvertMatchupListToString(r) }{separator[1]}";
            }

            output = output.Substring(0, output.Length - 1);

            return output.Trim(separator[1]);
        }
      
        private static string ConvertPeopleListToString(List<PersonModel> ppl)
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

        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (TeamModel tm in teams)
            {

                output += $" {tm.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;

        }

        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (PrizeModel pm in prizes)
            {

                output += $" {pm.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output;

        }

        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> matchupEntries)
        {

            string output = "";

            if (matchupEntries.Count == 0)
            {
                return "";
            }

            foreach (MatchupEntryModel me in matchupEntries)
            {

                output += $" {me.ID}{separator[1]}";

            }

            output = output.Substring(0, output.Length - 1);// save all output string with all length 0 to n-1

            return output.Trim(separator[1]);




        }

        private static List<MatchupEntryModel> ConvertStingToMatchupEntryModels(string input)
        {

            //TODO check
            string[] ids = input.Split(separator[1]);
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
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


        private static TeamModel LookupTeamByID(int ID)
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

        private static MatchupModel LookupMatchupByID(int ID)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullTxtFilePath().LoadFile();


            foreach (string matchup in matchups)
            {

                string[] cols = matchup.Split(separator[0]);

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
