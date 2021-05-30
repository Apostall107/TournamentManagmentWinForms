using AppLibrary.Models;
using Dapper;
using System.Data;


namespace AppLibrary.Connections
{//   	@PlaceNumber int,
 //@PlaceName nvarchar(50),
 //@PrizeAmount money,
 //   @PrizePercentage float,
 //@ID int = 0 output
    public class SqlConnector : IDataConnection
    {
        //TODO  - Make the CreatePrize method  to save data
        /// <summary>
        /// Saves a new proze to the database
        /// </summary>
        /// <param name="model"> The prize info.</param>
        /// <returns>The prize info, incuding unique identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("TournamentDB")))
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
    }
}
