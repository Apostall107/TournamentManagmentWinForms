
namespace TournamentManagementWinForms
{
    partial class TournamentViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewerForm));
            this.Tournament_Label = new System.Windows.Forms.Label();
            this.TournamentName_Label = new System.Windows.Forms.Label();
            this.Round_Label = new System.Windows.Forms.Label();
            this.Round_DropBox = new System.Windows.Forms.ComboBox();
            this.Unplayed_CheckBox = new System.Windows.Forms.CheckBox();
            this.FirstTeam_Label = new System.Windows.Forms.Label();
            this.SecondTeam_Label = new System.Windows.Forms.Label();
            this.VS_Label = new System.Windows.Forms.Label();
            this.FirstTeamScore_Label = new System.Windows.Forms.Label();
            this.SecondTeamScore_Label = new System.Windows.Forms.Label();
            this.FirstTeamScore_TextBox = new System.Windows.Forms.TextBox();
            this.SecondTeamScore_TextBox = new System.Windows.Forms.TextBox();
            this.Score_Button = new System.Windows.Forms.Button();
            this.Matchup_ListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // Tournament_Label
            // 
            this.Tournament_Label.AutoSize = true;
            this.Tournament_Label.Font = new System.Drawing.Font("Sitka Small", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tournament_Label.Location = new System.Drawing.Point(10, 10);
            this.Tournament_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Tournament_Label.Name = "Tournament_Label";
            this.Tournament_Label.Size = new System.Drawing.Size(194, 40);
            this.Tournament_Label.TabIndex = 0;
            this.Tournament_Label.Text = "Tournament:";
            // 
            // TournamentName_Label
            // 
            this.TournamentName_Label.AutoSize = true;
            this.TournamentName_Label.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TournamentName_Label.Location = new System.Drawing.Point(208, 17);
            this.TournamentName_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TournamentName_Label.Name = "TournamentName_Label";
            this.TournamentName_Label.Size = new System.Drawing.Size(97, 31);
            this.TournamentName_Label.TabIndex = 1;
            this.TournamentName_Label.Text = "<none>";
            // 
            // Round_Label
            // 
            this.Round_Label.AutoSize = true;
            this.Round_Label.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Round_Label.Location = new System.Drawing.Point(27, 67);
            this.Round_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Round_Label.Name = "Round_Label";
            this.Round_Label.Size = new System.Drawing.Size(72, 28);
            this.Round_Label.TabIndex = 2;
            this.Round_Label.Text = "Round";
            // 
            // Round_DropBox
            // 
            this.Round_DropBox.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Round_DropBox.FormattingEnabled = true;
            this.Round_DropBox.Location = new System.Drawing.Point(114, 67);
            this.Round_DropBox.Margin = new System.Windows.Forms.Padding(2);
            this.Round_DropBox.Name = "Round_DropBox";
            this.Round_DropBox.Size = new System.Drawing.Size(142, 31);
            this.Round_DropBox.TabIndex = 3;
            this.Round_DropBox.SelectedIndexChanged += new System.EventHandler(this.Round_DropBox_SelectedIndexChanged);
            // 
            // Unplayed_CheckBox
            // 
            this.Unplayed_CheckBox.AutoSize = true;
            this.Unplayed_CheckBox.Location = new System.Drawing.Point(288, 69);
            this.Unplayed_CheckBox.Name = "Unplayed_CheckBox";
            this.Unplayed_CheckBox.Size = new System.Drawing.Size(147, 28);
            this.Unplayed_CheckBox.TabIndex = 4;
            this.Unplayed_CheckBox.Text = "Unplayed Only";
            this.Unplayed_CheckBox.UseVisualStyleBackColor = true;
            this.Unplayed_CheckBox.CheckedChanged += new System.EventHandler(this.Unplayed_CheckBox_CheckedChanged);
            // 
            // FirstTeam_Label
            // 
            this.FirstTeam_Label.AutoSize = true;
            this.FirstTeam_Label.Location = new System.Drawing.Point(29, 212);
            this.FirstTeam_Label.Name = "FirstTeam_Label";
            this.FirstTeam_Label.Size = new System.Drawing.Size(114, 24);
            this.FirstTeam_Label.TabIndex = 5;
            this.FirstTeam_Label.Text = "<FirstTeam>\n";
            // 
            // SecondTeam_Label
            // 
            this.SecondTeam_Label.AutoSize = true;
            this.SecondTeam_Label.Location = new System.Drawing.Point(303, 212);
            this.SecondTeam_Label.Name = "SecondTeam_Label";
            this.SecondTeam_Label.Size = new System.Drawing.Size(132, 24);
            this.SecondTeam_Label.TabIndex = 6;
            this.SecondTeam_Label.Text = "<SecondTeam>";
            // 
            // VS_Label
            // 
            this.VS_Label.AutoSize = true;
            this.VS_Label.Location = new System.Drawing.Point(197, 212);
            this.VS_Label.Name = "VS_Label";
            this.VS_Label.Size = new System.Drawing.Size(45, 24);
            this.VS_Label.TabIndex = 7;
            this.VS_Label.Text = "-VS-";
            // 
            // FirstTeamScore_Label
            // 
            this.FirstTeamScore_Label.AutoSize = true;
            this.FirstTeamScore_Label.Location = new System.Drawing.Point(29, 302);
            this.FirstTeamScore_Label.Name = "FirstTeamScore_Label";
            this.FirstTeamScore_Label.Size = new System.Drawing.Size(61, 24);
            this.FirstTeamScore_Label.TabIndex = 8;
            this.FirstTeamScore_Label.Text = "Score:";
            // 
            // SecondTeamScore_Label
            // 
            this.SecondTeamScore_Label.AutoSize = true;
            this.SecondTeamScore_Label.Location = new System.Drawing.Point(303, 299);
            this.SecondTeamScore_Label.Name = "SecondTeamScore_Label";
            this.SecondTeamScore_Label.Size = new System.Drawing.Size(61, 24);
            this.SecondTeamScore_Label.TabIndex = 9;
            this.SecondTeamScore_Label.Text = "Score:";
            // 
            // FirstTeamScore_TextBox
            // 
            this.FirstTeamScore_TextBox.Location = new System.Drawing.Point(96, 302);
            this.FirstTeamScore_TextBox.Name = "FirstTeamScore_TextBox";
            this.FirstTeamScore_TextBox.Size = new System.Drawing.Size(56, 27);
            this.FirstTeamScore_TextBox.TabIndex = 10;
            // 
            // SecondTeamScore_TextBox
            // 
            this.SecondTeamScore_TextBox.Location = new System.Drawing.Point(370, 299);
            this.SecondTeamScore_TextBox.Name = "SecondTeamScore_TextBox";
            this.SecondTeamScore_TextBox.Size = new System.Drawing.Size(56, 27);
            this.SecondTeamScore_TextBox.TabIndex = 11;
            // 
            // Score_Button
            // 
            this.Score_Button.BackColor = System.Drawing.Color.Transparent;
            this.Score_Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Score_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.Score_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Score_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Score_Button.Location = new System.Drawing.Point(149, 391);
            this.Score_Button.Name = "Score_Button";
            this.Score_Button.Size = new System.Drawing.Size(168, 40);
            this.Score_Button.TabIndex = 12;
            this.Score_Button.Text = "Score";
            this.Score_Button.UseVisualStyleBackColor = false;
            this.Score_Button.Click += new System.EventHandler(this.Score_Button_Click);
            // 
            // Matchup_ListBox
            // 
            this.Matchup_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Matchup_ListBox.FormattingEnabled = true;
            this.Matchup_ListBox.Location = new System.Drawing.Point(453, 17);
            this.Matchup_ListBox.Name = "Matchup_ListBox";
            this.Matchup_ListBox.Size = new System.Drawing.Size(280, 420);
            this.Matchup_ListBox.TabIndex = 13;
            this.Matchup_ListBox.SelectedIndexChanged += new System.EventHandler(this.Matchup_ListBox_SelectedIndexChanged);
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 460);
            this.Controls.Add(this.Matchup_ListBox);
            this.Controls.Add(this.Score_Button);
            this.Controls.Add(this.SecondTeamScore_TextBox);
            this.Controls.Add(this.FirstTeamScore_TextBox);
            this.Controls.Add(this.SecondTeamScore_Label);
            this.Controls.Add(this.FirstTeamScore_Label);
            this.Controls.Add(this.VS_Label);
            this.Controls.Add(this.SecondTeam_Label);
            this.Controls.Add(this.FirstTeam_Label);
            this.Controls.Add(this.Unplayed_CheckBox);
            this.Controls.Add(this.Round_DropBox);
            this.Controls.Add(this.Round_Label);
            this.Controls.Add(this.TournamentName_Label);
            this.Controls.Add(this.Tournament_Label);
            this.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TournamentViewerForm";
            this.Text = "Tournament Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Tournament_Label;
        private System.Windows.Forms.Label TournamentName_Label;
        private System.Windows.Forms.Label Round_Label;
        private System.Windows.Forms.ComboBox Round_DropBox;
        private System.Windows.Forms.CheckBox Unplayed_CheckBox;
        private System.Windows.Forms.Label FirstTeam_Label;
        private System.Windows.Forms.Label SecondTeam_Label;
        private System.Windows.Forms.Label VS_Label;
        private System.Windows.Forms.Label FirstTeamScore_Label;
        private System.Windows.Forms.Label SecondTeamScore_Label;
        private System.Windows.Forms.TextBox FirstTeamScore_TextBox;
        private System.Windows.Forms.TextBox SecondTeamScore_TextBox;
        private System.Windows.Forms.Button Score_Button;
        private System.Windows.Forms.CheckedListBox Matchup_ListBox;
    }
}

