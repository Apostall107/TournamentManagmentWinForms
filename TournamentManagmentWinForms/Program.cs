using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentManagmentWinForms.Forms;

namespace TournamentManagmentWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            AppLibrary.GlobalConfig.InitializeConnection(AppLibrary.DataStorageType.TextFile);

            Application.Run(new CreateNewTeamForm());
        }
    }
}
