using AppLibrary.Models;
using System.Collections.Generic;

namespace AppLibrary.Connections
{
    public interface IDataConnection
    {
        void CompleteTournament(TournamentModel model);
        void UpdateMatchup(MatchupModel model);

        #region Creators
        void CreatePrize(PrizeModel model);
        void CreatePerson(PersonModel model);
        void CreateTeam(TeamModel model);
        void CreateTournament(TournamentModel model);
        #endregion

        #region Getrers
        List<TeamModel> Teams_GetAll();
        List<PersonModel> People_GetAll();

        List<TournamentModel> Tournament_GetAll();



        #endregion
    }
}
