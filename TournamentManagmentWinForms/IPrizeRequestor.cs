using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary.Models;

namespace TournamentManagementWinForms
{
    public interface IPrizeRequestor
    {

        void PrizeComplete(PrizeModel model);

    }
}
