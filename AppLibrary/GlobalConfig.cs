using System.Collections.Generic;
using AppLibrary.Connections;
using System.Configuration;

namespace AppLibrary
{
    public static class GlobalConfig
    {

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
