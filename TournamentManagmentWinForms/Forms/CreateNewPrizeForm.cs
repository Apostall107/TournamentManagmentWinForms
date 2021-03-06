using AppLibrary;
using AppLibrary.Models;
using System;
using System.Windows.Forms;



namespace TournamentManagementWinForms.Forms
{
    public partial class CreateNewPrizeForm : Form
    {

        IPrizeRequestor requestingForm;
        public CreateNewPrizeForm(IPrizeRequestor requestor)
        {
            InitializeComponent();

            requestingForm = requestor;

        }

        private void CreatePrize_Button_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {

                PrizeModel model = new PrizeModel(
                    PlaceNumber_TextBox.Text,
                    PlaceName_TextBox.Text,
                    PrizeAmount_TextBox.Text,
                    PrizePercentage_TextBox.Text);

                GlobalConfig.Connection.CreatePrize(model);

                requestingForm.PrizeComplete(model);

                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid data was entered! \nTry again.");
            }







            ResetBoxes();

        }



        private void ResetBoxes()
        {

            PlaceName_TextBox.Text = "";
            PlaceNumber_TextBox.Text = "";
            PrizeAmount_TextBox.Text = "0";
            PrizePercentage_TextBox.Text = "0";

        }

        private bool ValidationForm()
        {

            bool output = true;

            // TODO - add error massages.


            // Place number Validation

            int placeNumber = 0;

            bool _PlaceName_TextBox_IsValidValue = int.TryParse(PlaceNumber_TextBox.Text, out placeNumber);

            if (!_PlaceName_TextBox_IsValidValue)
            {
                output = false;
            }

            if (PlaceName_TextBox.Text.Length == 0)
            {

                output = false;

            }

            if (placeNumber < 1)
            {

                output = false;

            }



            // Prize amount validation

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool _PrizeAmount_TextBox_IsValid = decimal.TryParse(PrizeAmount_TextBox.Text, out prizeAmount);
            bool _PrizePercentage_TextBox_IsValid = double.TryParse(PrizePercentage_TextBox.Text, out prizePercentage);


            if (!_PrizeAmount_TextBox_IsValid || !_PrizePercentage_TextBox_IsValid)
            {

                output = false;

            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {

                output = false;

            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {

                output = false;

            }


            return output;

        }




    }


}

