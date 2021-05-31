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
        public CreateNewTeamForm()
        {
            InitializeComponent();
        }

        private void CreateMember_Button_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                AppLibrary.Models.PersonModel p = new  AppLibrary.Models.PersonModel();

                p.FirstName = FirstName_TextBox.Text;
                p.LastName = LastName_TextBox.Text;
                p.Email = Email_TextBox.Text;
                p.PhoneNum = PhoneNum_TextBox.Text;

                GlobalConfig.Connection.CreatePerson(p);



                FirstName_TextBox.Text = "";
                LastName_TextBox.Text = "";
                Email_TextBox.Text = "";
                PhoneNum_TextBox.Text = "";
            }

            else
            {
                MessageBox.Show("You need to fill in all of the fields.");
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
    }
}
