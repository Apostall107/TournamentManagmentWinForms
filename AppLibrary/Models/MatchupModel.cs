using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Models
{
    class MatchupModel
    {

        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();


        /// <summary>
        /// Represents the team that won tournament .
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Matchup round counter.
        /// </summary>
        public int MatchupRound { get; set; }



    }
}
