using AppLibrary;
using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace TournamentManagementWinForms
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel _Tournament;
        BindingList<int> _Rounds = new BindingList<int>();
        BindingList<MatchupModel> _SelectedMatchups = new BindingList<MatchupModel>();
        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            _Tournament = tournamentModel;


            _Tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

            WireUpLists();

            LoadStartupData();

            LoadRounds();
        }

        private void Tournament_OnTournamentComplete(object sender, DateTime e)
        {
            this.Close();
        }


        private void LoadStartupData()
        {

            TournamentName_Label.Text = _Tournament.TournamentName;

        }


        private void WireUpLists()
        {
            Round_DropBox.DataSource = _Rounds;
            Matchup_ListBox.DataSource = _SelectedMatchups;
            Matchup_ListBox.DisplayMember = "DisplayName";
        }


        private void LoadRounds()
        {

            _Rounds.Clear();

            _Rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchups in _Tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    _Rounds.Add(currentRound);
                }
            }

            LoadMatchups(1);


        }
        private void Round_DropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)Round_DropBox.SelectedItem);
        }

        private void LoadMatchups(int round)
        {

            foreach (List<MatchupModel> matchups in _Tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {

                    _SelectedMatchups.Clear();

                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !Unplayed_CheckBox.Checked)
                        {
                            _SelectedMatchups.Add(m);
                        }
                    }
                }
            }

            if (_SelectedMatchups.Count > 0)
            {
                LoadMatchup(_SelectedMatchups.First());
            }

            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (_SelectedMatchups.Count > 0);

            FirstTeam_Label.Visible = isVisible;
            FirstTeamScore_Label.Visible = isVisible;
            FirstTeamScore_TextBox.Visible = isVisible;
            SecondTeam_Label.Visible = isVisible;
            SecondTeamScore_Label.Visible = isVisible;
            SecondTeamScore_TextBox.Visible = isVisible;
            VS_Label.Visible = isVisible;
            Score_Button.Visible = isVisible;
        }

        private void LoadMatchup(MatchupModel mModel)
        {
            for (int i = 0; i < mModel.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (mModel.Entries[0].TeamCompeting != null)
                    {
                        FirstTeam_Label.Text = mModel.Entries[0].TeamCompeting.TeamName;
                        FirstTeamScore_TextBox.Text = mModel.Entries[0].Score.ToString();

                        SecondTeam_Label.Text = "<none>";
                        SecondTeamScore_TextBox.Text = "0";
                    }
                    else
                    {
                        FirstTeam_Label.Text = "Does not Set";
                        FirstTeamScore_TextBox.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (mModel.Entries[1].TeamCompeting != null)
                    {
                        SecondTeam_Label.Text = mModel.Entries[1].TeamCompeting.TeamName;
                        SecondTeamScore_TextBox.Text = mModel.Entries[1].Score.ToString();
                    }
                    else
                    {
                        SecondTeam_Label.Text = "Does not Set";
                        SecondTeamScore_TextBox.Text = "";
                    }
                }
            }
        }

        private void Matchup_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)Matchup_ListBox.SelectedItem);
        }


        private void Unplayed_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)Round_DropBox.SelectedItem);
        }


        private string ValidateData()
        {
            string output = "";

            double firstTeamScore = 0;
            double secondTeamScore = 0;

            bool firstScoreValid = double.TryParse(FirstTeamScore_TextBox.Text, out firstTeamScore);
            bool secindScoreValid = double.TryParse(SecondTeamScore_TextBox.Text, out secondTeamScore);

            if (!firstScoreValid)
            {
                output = "The first team score  value is not a valid .";
            }
            else if (!secindScoreValid)
            {
                output = "The second team score value is not a valid .";
            }
            else if (firstTeamScore == 0 && secondTeamScore == 0)
            {
                output = "You did not enter a score for either team.";
            }
            else if (firstTeamScore == secondTeamScore)
            {
                output = "We do not allow ties in this application.";
            }

            return output;
        }



        private void Score_Button_Click(object sender, EventArgs e)
        {
            string errorMessage = ValidateData();

            if (errorMessage.Length > 0)
            {
                MessageBox.Show($"Input Error: { errorMessage }");
                return;
            }

            MatchupModel mModel = (MatchupModel)Matchup_ListBox.SelectedItem;
            double firstTeamScore = 0;
            double secondTeamScore = 0;

            for (int i = 0; i < mModel.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (mModel.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(FirstTeamScore_TextBox.Text, out firstTeamScore);

                        if (scoreValid)
                        {
                            mModel.Entries[0].Score = firstTeamScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for first team.");
                            return;
                        }
                    }
                }

                if (i == 1)
                {
                    if (mModel.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(SecondTeamScore_TextBox.Text, out secondTeamScore);

                        if (scoreValid)
                        {
                            mModel.Entries[1].Score = secondTeamScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for second team.");
                            return;
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(_Tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The application had the following error: { ex.Message }");
                return;
            }


            LoadMatchups((int)Round_DropBox.SelectedItem);

        }




    }
}
