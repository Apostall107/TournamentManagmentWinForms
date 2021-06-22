using System.Collections.Generic;

namespace AppLibrary.Models
{
    public class MatchupModel
    {

        public int ID { get; set; }

        /// <summary>
        /// The set of teams that were involved in this match.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// The ID from the database that will be used to identify the winner.
        /// </summary>
        public int WinnerID { get; set; }




        public TeamModel Winner { get; set; }


        /// <summary>
        /// Which round this match is part of.
        /// </summary>
        public int MatchupRound { get; set; }


        public string DisplayName
        {
            get
            {
                string output = "";

                foreach (MatchupEntryModel matchupEntry in Entries)
                {
                    if (matchupEntry.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = matchupEntry.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. { matchupEntry.TeamCompeting.TeamName }";
                        }
                    }
                    else
                    {
                        output = "Matchup is not determined yet!";
                        break;
                    }
                }

                return output;
            }

        }



    }
}
