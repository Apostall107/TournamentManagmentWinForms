﻿using AppLibrary.Models;
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
                p.Add("@PhoneNumber", model.PhoneNumber);
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

        public void CreateTournament(TournamentModel model)
        {
         
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                connection.Open();


                SaveTournament(connection, model);

                SaveTournamentPrizes(connection, model);

                SaveTournamentEntries(connection, model);

                SaveTournamentRounds(connection, model);

            
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
                p.Add(("@TeamID"), team.ID);

                p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentRounds(IDbConnection connection, TournamentModel model)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {


                    var p = new DynamicParameters();
                    p.Add("@TournamentID", model.ID);
                    p.Add("@MatchupRound", matchup.MatchupRound);
                    p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spMatchups_Insert", p, commandType: CommandType.StoredProcedure);

                    matchup.ID = p.Get<int>("@ID");

                 
                    foreach (MatchupEntryModel entry in matchup.Entries)
                    {
                       
                        p = new DynamicParameters();

                        p.Add("@MatchupID", matchup.ID);



                        if (entry.ParentMatchup == null)
                        {
                            p.Add("@ParentMatchupID", null);
                        }
                        else
                        {
                            p.Add("@ParentMatchupID", entry.ParentMatchup.ID);
                        }



                        if (entry.TeamCompeting == null)
                        {
                            p.Add("@TeamCompetingID", null);
                        }
                        else
                        {
                            p.Add("@TeamCompetingID", entry.TeamCompeting.ID);
                        }



                        p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute("dbo.spMatchupEntries_Insert", p, commandType: CommandType.StoredProcedure);


                    }
                }
            }
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

        public List<TournamentModel> Tournament_GetAll()
        {
            List<TournamentModel> output;
            var p = new DynamicParameters();


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                connection.Open();

                output = connection.Query<TournamentModel>("[dbo].[spTournaments_GetAll]", commandType: CommandType.StoredProcedure).ToList();


                foreach (TournamentModel t in output)
                {
                    // Populating Prizes
                    p = new DynamicParameters();
                    p.Add("@TournamentID", t.ID);


                    t.Prizes = connection.Query<PrizeModel>("[dbo].[spPrizes_GetByTournament]", p, commandType: CommandType.StoredProcedure).ToList();


                    // Populating Teams
                    p = new DynamicParameters();
                    p.Add("@TournamentID", t.ID);


                    t.EnteredTeams = connection.Query<TeamModel>("[dbo].[spTeam_getByTournament]", p, commandType: CommandType.StoredProcedure).ToList();


                    foreach (TeamModel team in t.EnteredTeams)
                    {
                        p = new DynamicParameters();
                        p.Add("@TeamID", team.ID);


                        team.TeamMembers = connection.Query<PersonModel>("[dbo].[spTeamMembers_GetByTeam]", p, commandType: CommandType.StoredProcedure).ToList();
                    }


                    p = new DynamicParameters();
                    p.Add("@TournamentID", t.ID);


                    // Populating Rounds
                    List<MatchupModel> matchups = connection.Query<MatchupModel>("[dbo].[spMatchups_GetByTournament]", p, commandType: CommandType.StoredProcedure).ToList();


                    foreach (MatchupModel m in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("@MatchupID", m.ID);


                        // Populating Rounds
                        m.Entries = connection.Query<MatchupEntryModel>("[dbo].[spMatchupEntries_GetByMatchup]", p, commandType: CommandType.StoredProcedure).ToList();


                        // Populating  entries (2 models)
                        // Populating  matchups (1 model)
                        List<TeamModel> allTeams = Teams_GetAll();


                        if (m.WinnerID > 0)
                        {
                            m.Winner = allTeams.Where(x => x.ID == m.WinnerID).First();
                        }


                        foreach (var me in m.Entries)
                        {
                            if (me.TeamCompetingID > 0)
                            {
                                me.TeamCompeting = allTeams.Where(x => x.ID == me.TeamCompetingID).First();
                            }


                            if (me.ParentMatchupID > 0)
                            {
                                me.ParentMatchup = matchups.Where(x => x.ID == me.ParentMatchupID).First();
                            }
                        }
                    }


                    // List<List<MatchupModel>>
                    List<MatchupModel> currentRow = new List<MatchupModel>();
                    int currentRound = 1;


                    foreach (MatchupModel m in matchups)
                    {
                        if (m.MatchupRound > currentRound)
                        {
                            t.Rounds.Add(currentRow);
                            currentRow = new List<MatchupModel>();
                            currentRound += 1;
                        }


                        currentRow.Add(m);
                    }


                    t.Rounds.Add(currentRow);
                }
            }


            return output;



        }
        #endregion



        public void UpdateMatchup(MatchupModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {

                connection.Open();

                var p = new DynamicParameters();

                if (model.Winner != null)
                {
                    p.Add("@ID", model.ID);
                    p.Add("@WinnerID", model.Winner.ID);

                    connection.Execute("dbo.spMatchups_Update", p, commandType: CommandType.StoredProcedure);
                }

                foreach (MatchupEntryModel me in model.Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        p = new DynamicParameters();
                        p.Add("@ID", me.ID);
                        p.Add("@TeamCompetingID", me.TeamCompeting.ID);
                        p.Add("@Score", me.Score);

                        connection.Execute("dbo.spMatchupEntries_Update", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }


    }
}
