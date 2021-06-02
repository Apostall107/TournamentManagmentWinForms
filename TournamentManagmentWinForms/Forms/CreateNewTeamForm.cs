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
            CreateSampleData();
       #endif


            WireUpLists();

        }
       

        
        #if DEBUG
        private void CreateSampleData()
        {
            _AvaliableTeamMember.Add(new PersonModel { FirstName = "Sasha", LastName = "Hryn" });
            _AvaliableTeamMember.Add(new PersonModel { FirstName = "Sasha2", LastName = "Hryn2" });

            _SelectedTeamMember.Add(new PersonModel { FirstName = "NotSasha", LastName = "NotHryn" });
            _SelectedTeamMember.Add(new PersonModel { FirstName = "NotSasha2", LastName = "NotHryn2" });
        }
       
        
        #endif

        private void WireUpLists()
        {

            SelectTeamMember_DropBox.DataSource = _AvaliableTeamMember;
            SelectTeamMember_DropBox.DisplayMember = "FullName";

            TeamMembers_ListBox.DataSource = _SelectedTeamMember;
            TeamMembers_ListBox.DisplayMember = "FullName";



        }


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





    }
}
