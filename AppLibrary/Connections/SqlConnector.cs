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

                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);


                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.ID = p.Get<int>("@ID");



                return model;

            }


        }

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
    }
}
