using System;
using System.Collections.Generic;

namespace AppLibrary.Models
{
    public class TournamentModel
    {
        public event EventHandler<DateTime> OnTournamentComplete;
        public int ID { get; set; }

        /// <summary>
        ///  Name of the particular tournament to identify it.
        /// </summary>
        public string TournamentName { get; set; }

        public decimal EntryFee { get; set; }

        /// <summary>
        ///  Holds the info of teams that participate on that particular tournament.
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

        /// <summary>
        /// Keeps ths info of prizes for participants based on their placement on that tournament,
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();


        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();


        public void CompleteTournament()
        {
            OnTournamentComplete?.Invoke(this, DateTime.Now);
        }

    }
}
