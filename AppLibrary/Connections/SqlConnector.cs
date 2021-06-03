using AppLibrary.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AppLibrary.Connections
{



    public class SqlConnector : IDataConnection
    {
        private const string db = "TournamentDB";



        #region Creators

        public PersonModel CreatePerson(PersonModel model)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {

                connection.Open();

                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@Email", model.Email);
                p.Add("@PhoneNum", model.PhoneNum);
                p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);


                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.ID = p.Get<int>("@ID");



                return model;

            }

        }

        /// <summary>
        /// Saves a new prize to the database
        /// </summary>
        /// <param name="model"> The prize info.</param>
        /// <returns>The prize info, incuding unique identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {

                connection.Open();

                var prize = new DynamicParameters();
                prize.Add("@PlaceNumber", model.PlaceNumber);
                prize.Add("@PlaceName", model.PlaceName);
                prize.Add("@PrizeAmount", model.PrizeAmount);
                prize.Add("@PrizePercentage", model.PrizePercentage);
                prize.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);


                connection.Execute("dbo.spPrizes_Insert", prize, commandType: CommandType.StoredProcedure);

                model.ID = prize.Get<int>("@ID");



                return model;

            }


        }

        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                connection.Open();

                var p = new DynamicParameters();
                p.Add("@TeamName", model.TeamName);
                p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);


                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                model.ID = p.Get<int>("@ID");

                foreach (PersonModel tm in model.TeamMembers)
                {

                    p = new DynamicParameters();
                    p.Add(("@TeamID"), model.ID);
                    p.Add(("@PersonID"),tm.ID);

                    connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                connection.Open();




                SaveTournament(connection, model);

                SaveTournamentPrizes(connection, model);

                SaveTournamentEntries(connection, model);

                SaveTournamentRounds(connection, model);

              //  TournamentLogic.UpdateTournamentResults(model);










                return model;
            }
        }


        #region CreateTournament Methods
        private void SaveTournament(IDbConnection connection, TournamentModel model)
        {

            var p = new DynamicParameters();
            p.Add("@TournamentName", model.TournamentName);
            p.Add("@EntryFee", model.EntryFee);
            p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournaments_Insert", p, commandType: CommandType.StoredProcedure);

            model.ID = p.Get<int>("@ID");
        }

        private void SaveTournamentPrizes(IDbConnection connection, TournamentModel model)
        {
            foreach (PrizeModel prize in model.Prizes)
            {

                var p = new DynamicParameters();
                p.Add(("@TournamentID"), model.ID);
                p.Add(("@PrizeID"), prize.ID);

                p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTournamentPrizes_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentEntries(IDbConnection connection, TournamentModel model)
        {

            foreach (TeamModel team in model.EnteredTeams)
            {

                var p = new DynamicParameters();
                p.Add(("@TournamentID"), model.ID);
                p.Add(("@PrizeID"), team.ID);

                p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentRounds(IDbConnection connection, TournamentModel model)
        {
            //foreach (List<MatchupModel> round in model.Rounds)
            //{
            //    foreach (MatchupModel matchup in round)
            //    {
            //        var p = new DynamicParameters();
            //        p.Add("@TournamentId", model.Id);
            //        p.Add("@MatchupRound", matchup.MatchupRound);
            //        p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            //        connection.Execute("[dbo].[spMatchups_Insert]", p, commandType: CommandType.StoredProcedure);

            //        matchup.Id = p.Get<int>("@Id");

            //        foreach (MatchupEntryModel entry in matchup.Entries)
            //        {
            //            p = new DynamicParameters();

            //            p.Add("@MatchupId", matchup.Id);

            //            if (entry.ParentMatchup == null)
            //            {
            //                p.Add("@ParentMatchupId", null);
            //            }
            //            else
            //            {
            //                p.Add("@ParentMatchupId", entry.ParentMatchup.Id);
            //            }

            //            if (entry.TeamCompeting == null)
            //            {
            //                p.Add("@TeamCompetingId", null);
            //            }
            //            else
            //            {
            //                p.Add("@TeamCompetingId", entry.TeamCompeting.Id);
            //            }

            //            p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            //            connection.Execute("[dbo].[spMatchupEntries_Insert]", p, commandType: CommandType.StoredProcedure);
            //        }
            //    }
            //}
        }
        #endregion




        #endregion


        #region Getrers
        public List<PersonModel> People_GetAll()
        {
            List<PersonModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                connection.Open();

                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();

            }


            return output;
        }

        public List<TeamModel> Teams_GetAll()
        {
            List<TeamModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                connection.Open();

                output = connection.Query<TeamModel>("dbo.spTeams_GetAll").ToList();

                foreach (TeamModel team in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@TeamID", team.ID);

                    team.TeamMembers = connection.Query<PersonModel>("spTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return output;
        }
        #endregion

    }
}
