using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary.Models;

namespace TournamentManagmentWinForms
{
    public static class TournamentLogic
    {

        public static void CreateRounds(TournamentModel model)
        { 
        

        
        }


        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }



    }
}
