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
    public partial class CreateNewTournamentForm : Form, IPrizeRequestor, ITeamRequestor
    {

        List<AppLibrary.Models.TeamModel> _AvaliableTeams = GlobalConfig.Connection.Teams_GetAll();
        List<TeamModel> _SelectedTeams = new List<TeamModel>();
        List<PrizeModel> _SelectedPrizes = new List<PrizeModel>();
   

        public CreateNewTournamentForm()
        {
            InitializeComponent();


            WireUpLists();
        }


        private void WireUpLists()
        {
            SelectTeam_DropBox.DataSource = null;// needed to move objectts from box to list and vice verca

            SelectTeam_DropBox.DataSource = _AvaliableTeams;
            SelectTeam_DropBox.DisplayMember = "TeamName";

            ParticipantsListBox.DataSource = null;

            ParticipantsListBox.DataSource = _SelectedTeams;
            ParticipantsListBox.DisplayMember = "TeamName";

            Prize_ListBox.DataSource = null;

            Prize_ListBox.DataSource = _SelectedPrizes;
            Prize_ListBox.DisplayMember = "ID";

        }


        private void SelectTeam_DropBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTeam_Button_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)SelectTeam_DropBox.SelectedItem;
            if (team != null) //catching null due to bug occured when selected field is empty
            {
                _AvaliableTeams.Remove(team); //remove person and add ====>
                _SelectedTeams.Add(team);// ===>  it here <====

                WireUpLists();
                
            }


        }


        private void DeleteParticipants_Button_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)ParticipantsListBox.SelectedItem;
            if (team != null) //catching null due to bug occured when selected field is empty
            {
            
                
                _SelectedTeams.Remove(team);// ===>  it here <====
                _AvaliableTeams.Add(team); //remove person and add ====>

                WireUpLists();

            }
        }

        private void CreatePrize_Button_Click(object sender, EventArgs e)
        {
            //TODO: Prize list box visualization of PlaceName bug fix

            CreateNewPrizeForm cnpf = new CreateNewPrizeForm(this); //this - is this specific instance

            cnpf.Show();

        }

        public void PrizeComplete(PrizeModel model)
        {
            _SelectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            throw new NotImplementedException();
        }

        private void CreateTeam_Button_Click(object sender, EventArgs e)
        {
            CreateNewTeamForm cntf = new CreateNewTeamForm(this);
            cntf.Show();


        }
    }
}
