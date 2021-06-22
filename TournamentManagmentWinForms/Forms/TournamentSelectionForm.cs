using AppLibrary;
using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace TournamentManagementWinForms.Forms
{
    public partial class TournamentSelectionForm : Form
    {

        List<TournamentModel> tournaments = GlobalConfig.Connection.Tournament_GetAll();
        public TournamentSelectionForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        #region exidental
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion


        private void WireUpLists()
        {

            LoadExistingTournament_DropBox.DataSource = tournaments;
            LoadExistingTournament_DropBox.DisplayMember = "TournamentName";

        }

        private void LoadTournament_Button_Click(object sender, EventArgs e)
        {

            TournamentModel tm = (TournamentModel)LoadExistingTournament_DropBox.SelectedItem;
            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
        }

        private void CreateTournament_Button_Click(object sender, EventArgs e)
        {
            CreateNewTournamentForm frm = new CreateNewTournamentForm();
            frm.Show();
        }
    }
}
