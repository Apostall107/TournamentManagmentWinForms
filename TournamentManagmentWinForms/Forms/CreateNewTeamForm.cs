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
    public partial class CreateNewTeamForm : Form
    {



        private List<PersonModel> _AvaliableTeamMember = GlobalConfig.Connection.People_GetAll(); //list for drop box
        private List<PersonModel> _SelectedTeamMember = new List<PersonModel>(); // list for listbox


        public CreateNewTeamForm()
        {
            InitializeComponent();

#if DEBUG
            //CreateSampleData();
#endif


            WireUpLists();

        }



#if DEBUG
        //private void CreateSampleData()
        //{
        //    _AvaliableTeamMember.Add(new PersonModel { FirstName = "Sasha", LastName = "Hryn" });
        //    _AvaliableTeamMember.Add(new PersonModel { FirstName = "Sasha2", LastName = "Hryn2" });

        //    _SelectedTeamMember.Add(new PersonModel { FirstName = "NotSasha", LastName = "NotHryn" });
        //    _SelectedTeamMember.Add(new PersonModel { FirstName = "NotSasha2", LastName = "NotHryn2" });
        //}

#endif



        private void WireUpLists()
        {

            SelectTeamMember_DropBox.DataSource = null;// needed to move objectts from box to list and vice verca

            SelectTeamMember_DropBox.DataSource = _AvaliableTeamMember;
            SelectTeamMember_DropBox.DisplayMember = "FullName";


            TeamMembers_ListBox.DataSource = null;// needed to move objectts from box to list and vice verca

            TeamMembers_ListBox.DataSource = _SelectedTeamMember;
            TeamMembers_ListBox.DisplayMember = "FullName";




        }


        #region CreateMember_Button_Click
        private void CreateMember_Button_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                AppLibrary.Models.PersonModel person = new AppLibrary.Models.PersonModel();

                person.FirstName = FirstName_TextBox.Text;
                person.LastName = LastName_TextBox.Text;
                person.Email = Email_TextBox.Text;
                person.PhoneNum = PhoneNum_TextBox.Text;

                GlobalConfig.Connection.CreatePerson(person);

                _SelectedTeamMember.Add(person);

                WireUpLists();

                ResetMemberBoxes();


            }

            else
            {
                MessageBox.Show("Invalid data was entered! \nTry again.");
            }
        }
        private bool ValidateForm()
        {
            if (FirstName_TextBox.Text.Length == 0)
            {
                return false;
            }
            if (LastName_TextBox.Text.Length == 0)
            {
                return false;
            }
            if (Email_TextBox.Text.Length == 0)
            {
                return false;
            }
            if (PhoneNum_TextBox.Text.Length == 0)
            {
                return false;
            }

            return true;


        }
        private void ResetMemberBoxes()
        {

            FirstName_TextBox.Text = "";
            LastName_TextBox.Text = "";
            Email_TextBox.Text = "";
            PhoneNum_TextBox.Text = "";

        }

        #endregion



        private void AddTeamMember_Button_Click(object sender, EventArgs e)
        {

            PersonModel person = (PersonModel)SelectTeamMember_DropBox.SelectedItem;
            if (person != null) //catching null due to bug occured when selected field is empty
            {
                _AvaliableTeamMember.Remove(person); //remove person and add ====>
                _SelectedTeamMember.Add(person);// ===>  it here <====


                WireUpLists();
            }

            

        }

        private void RemoveSelected_Button_Click(object sender, EventArgs e)
        {

            PersonModel person = (PersonModel)TeamMembers_ListBox.SelectedItem;

            if (person != null)//catching null due to bug occured when selected field is empty
            {
                _SelectedTeamMember.Remove(person); //remove person and add ====>
                _AvaliableTeamMember.Add(person);// ===>  it here <====

                WireUpLists();
            }

            

        }

        private void CreateTeam_Button_Click(object sender, EventArgs e)
        {

            TeamModel model = new TeamModel();
            model.TeamName = TeamName_TextBox.Text;
            model.TeamMembers = _SelectedTeamMember;


            model = GlobalConfig.Connection.CreateTeam(model);

            ResetForm();

        }


        void ResetForm()
        {

            TeamName_TextBox.Text = "";
        
        }


    }
}
