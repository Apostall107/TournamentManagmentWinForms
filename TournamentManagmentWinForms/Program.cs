using System;
using System.Windows.Forms;
using TournamentManagementWinForms.Forms;

namespace TournamentManagementWinForms
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

            Application.Run(new TournamentSelectionForm());
        }
    }
}
