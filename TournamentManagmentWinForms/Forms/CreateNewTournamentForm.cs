using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLibrary;
using AppLibrary.Models;

namespace TournamentManagmentWinForms.Forms
{
    public partial class CreateNewTournamentForm : Form
    {

        List<AppLibrary.Models.TeamModel> _AvaliableTeams = GlobalConfig.Connection.Teams_GetAll();
        List<TeamModel> _SelectedTeams = new List<TeamModel>();
        List<PrizeModel> _SelectedPrizes = new List<PrizeModel>();

        public CreateNewTournamentForm()
        {
            InitializeComponent();

            InitializeLists();
        }


        private void InitializeLists()
        {

            SelectTeam_DropBox.DataSource = _AvaliableTeams;
            SelectTeam_DropBox.DisplayMember = "TeamName";


            ParticipantsListBox.DataSource = _SelectedTeams;
            ParticipantsListBox.DisplayMember = "TeamName";

            Prize_ListBox.DataSource = _SelectedPrizes;
            Prize_ListBox.DisplayMember = "PlaceName";

        }

        private void SelectTeam_DropBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
