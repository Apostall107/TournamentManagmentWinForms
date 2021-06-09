using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManagementWinForms
{
    public interface ITeamRequestor
    {

        void TeamComplete(AppLibrary.Models.TeamModel model);

    }
}
