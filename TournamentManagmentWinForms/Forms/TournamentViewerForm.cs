using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournamentManagmentWinForms
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel _Tournament;
        List<int> _Rounds = new List<int>();
        BindingList<MatchupModel> _SelectedMatchups = new BindingList<MatchupModel>();
        public TournamentViewerForm(AppLibrary.Models.TournamentModel tournamentModel)
        {
            InitializeComponent();

            _Tournament = tournamentModel;


            WireUpLists();


            LoadStartupData();

            LoadRounds();
        }

        private void WireUpLists()
        {
            Round_DropBox.DataSource = _Rounds;
            Matchup_ListBox.DataSource = _SelectedMatchups;
            Matchup_ListBox.DisplayMember = "DisplayName";
        }
        private void LoadStartupData()
        {

            TournamentName_Label.Text = _Tournament.TournamentName;

        }

        private void LoadRounds()
        {

            _Rounds.Clear();

            _Rounds.Add(1);
            int currRound = 1;

            foreach (List<MatchupModel> matchups in _Tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    _Rounds.Add(currRound);
                }
            }

            LoadMatchups(1);


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
                        if (m.Winner == null || ! Unplayed_CheckBox.Checked)
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


        private void DisplayMatchupInfo()//
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

        private void LoadMatchup(MatchupModel m)
        {
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        FirstTeam_Label.Text = m.Entries[0].TeamCompeting.TeamName;
                        FirstTeamScore_TextBox.Text = m.Entries[0].Score.ToString();

                        SecondTeam_Label.Text = "<bye>";
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
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        SecondTeam_Label.Text = m.Entries[1].TeamCompeting.TeamName;
                        SecondTeamScore_TextBox.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        SecondTeam_Label.Text = "Does not Set";
                        SecondTeamScore_TextBox.Text = "";
                    }
                }
            }
        }



    }
}
