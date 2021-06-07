using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



	}
}
