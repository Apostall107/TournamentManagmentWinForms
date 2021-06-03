using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary.Connections;

namespace AppLibrary.Models
{
    public class MatchupEntryModel
    {

        /// <summary>       
        /// Represents one team in the matchup.        
        /// </summary>

        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represemts the score of the particular team.
        /// </summary>

        public double Score { get; set; }

        /// <summary>
        /// Represents the matchup that this team  player in prev round.(winners only possible)
        /// </summary>
        public MatchupEntryModel ParentMatchup { get; set; }



    }
}
