using AppLibrary.Models;
using System.Collections.Generic;

namespace AppLibrary.Connections
{
    public interface IDataConnection
    {
        #region Creators
        PrizeModel CreatePrize(PrizeModel model);
        PersonModel CreatePerson(PersonModel model);
        TeamModel CreateTeam(TeamModel model);
        TournamentModel CreateTournament(TournamentModel model);
        #endregion


        #region Getrers
        List<TeamModel> Teams_GetAll();
        List<PersonModel> People_GetAll();
        #endregion
    }
}
