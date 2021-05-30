using System.Collections.Generic;
using AppLibrary.Connections;
using System.Configuration;

namespace AppLibrary
{
    public class GlobalConfig
    {

        /// <summary>
        /// will not work till .NET 4.6
        /// </summary>
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool databese, bool textFiles)
        {

            if (databese)
            {

                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);

            }

            if (textFiles)
            {

                TextConnector txt = new TextConnector();
                Connections.Add(txt);

            }


        }



        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString; ;
        }




    }
}
