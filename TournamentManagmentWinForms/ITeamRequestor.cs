using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManagmentWinForms
{
    public interface ITeamRequestor
    {

        void TeamComplete(AppLibrary.Models.TeamModel model);

    }
}
