using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Models
{
    class TeamModel
    {

        /// <summary>
        ///  List of the ppl in the team.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();


        public string TeamName { get; set; }

    }
}
