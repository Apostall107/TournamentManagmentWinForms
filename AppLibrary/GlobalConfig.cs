using System.Collections.Generic;
using AppLibrary.Connections;
using System.Configuration;

namespace AppLibrary
{
    public static class GlobalConfig
    {


        #region Filespath strings


        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModel.csv";
        public const string MatchupFile = "MatchupModel.csv";
        public const string MatchupEntryFile = "MatchupEntryModel.csv";

        #endregion


        /// <summary>
        /// will not work till .NET 4.6
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnection(DataStorageType _DataStorageType)
        {


            switch (_DataStorageType)
            {

                case DataStorageType.SQL:
                    SqlConnector _SQL = new SqlConnector();
                    Connection = _SQL;
                    break;

                case DataStorageType.TextFile:
                    TextConnector _Text = new TextConnector();
                    Connection = _Text;
                    break;

                default:
                    break;


            }

         


        }



        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString; ;
        }




    }
}
