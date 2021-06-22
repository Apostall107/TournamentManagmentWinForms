using System.Collections.Generic;

namespace AppLibrary.Models
{
    public class TeamModel
    {


        /// <summary>
        ///  List of the ppl in the team.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        public int ID { get; set; }

        public string TeamName { get; set; }

    }
}
