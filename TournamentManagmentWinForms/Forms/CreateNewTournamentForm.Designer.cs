
namespace TournamentManagementWinForms.Forms
{
    partial class CreateNewTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewTournamentForm));
            this.CreateTournament_HeaderLabel = new System.Windows.Forms.Label();
            this.AddTeam_Button = new System.Windows.Forms.Button();
            this.CreatePrize_Button = new System.Windows.Forms.Button();
            this.DeleteParticipants_Button = new System.Windows.Forms.Button();
            this.RemovePrize_Button = new System.Windows.Forms.Button();
            this.CreateTournament_Button = new System.Windows.Forms.Button();
            this.TournamentName_TextBox = new System.Windows.Forms.TextBox();
            this.EntryFee_TextBox = new System.Windows.Forms.TextBox();
            this.TournamentName_Label = new System.Windows.Forms.Label();
            this.EntryFee_Label = new System.Windows.Forms.Label();
            this.SelectTeam_Label = new System.Windows.Forms.Label();
            this.ParticipantsTeam_Label = new System.Windows.Forms.Label();
            this.ParticipantsPrize_Label = new System.Windows.Forms.Label();
            this.ParticipantsListBox = new System.Windows.Forms.ListBox();
            this.Prize_ListBox = new System.Windows.Forms.ListBox();
            this.SelectTeam_DropBox = new System.Windows.Forms.ComboBox();
            this.CreateTeam_LinkLabel = new System.Windows.Forms.LinkLabel();
            this.CreateTeam_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateTournament_HeaderLabel
            // 
            this.CreateTournament_HeaderLabel.AutoSize = true;
            this.CreateTournament_HeaderLabel.Font = new System.Drawing.Font("Sitka Small", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTournament_HeaderLabel.Location = new System.Drawing.Point(16, 15);
            this.CreateTournament_HeaderLabel.Name = "CreateTournament_HeaderLabel";
            this.CreateTournament_HeaderLabel.Size = new System.Drawing.Size(498, 71);
            this.CreateTournament_HeaderLabel.TabIndex = 1;
            this.CreateTournament_HeaderLabel.Text = "Create Tournament";
            // 
            // AddTeam_Button
            // 
            this.AddTeam_Button.Location = new System.Drawing.Point(27, 465);
            this.AddTeam_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddTeam_Button.Name = "AddTeam_Button";
            this.AddTeam_Button.Size = new System.Drawing.Size(112, 37);
            this.AddTeam_Button.TabIndex = 2;
            this.AddTeam_Button.Text = "Add Team";
            this.AddTeam_Button.UseVisualStyleBackColor = true;
            this.AddTeam_Button.Click += new System.EventHandler(this.AddTeam_Button_Click);
            // 
            // CreatePrize_Button
            // 
            this.CreatePrize_Button.Location = new System.Drawing.Point(147, 465);
            this.CreatePrize_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreatePrize_Button.Name = "CreatePrize_Button";
            this.CreatePrize_Button.Size = new System.Drawing.Size(112, 37);
            this.CreatePrize_Button.TabIndex = 3;
            this.CreatePrize_Button.Text = "Create Prize";
            this.CreatePrize_Button.UseVisualStyleBackColor = true;
            this.CreatePrize_Button.Click += new System.EventHandler(this.CreatePrize_Button_Click);
            // 
            // DeleteParticipants_Button
            // 
            this.DeleteParticipants_Button.Location = new System.Drawing.Point(301, 324);
            this.DeleteParticipants_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteParticipants_Button.Name = "DeleteParticipants_Button";
            this.DeleteParticipants_Button.Size = new System.Drawing.Size(217, 29);
            this.DeleteParticipants_Button.TabIndex = 4;
            this.DeleteParticipants_Button.Text = "Remove Selected";
            this.DeleteParticipants_Button.UseVisualStyleBackColor = true;
            this.DeleteParticipants_Button.Click += new System.EventHandler(this.DeleteParticipants_Button_Click);
            // 
            // RemovePrize_Button
            // 
            this.RemovePrize_Button.Location = new System.Drawing.Point(301, 602);
            this.RemovePrize_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RemovePrize_Button.Name = "RemovePrize_Button";
            this.RemovePrize_Button.Size = new System.Drawing.Size(217, 29);
            this.RemovePrize_Button.TabIndex = 5;
            this.RemovePrize_Button.Text = "Remove Selected";
            this.RemovePrize_Button.UseVisualStyleBackColor = true;
            this.RemovePrize_Button.Click += new System.EventHandler(this.RemovePrize_Button_Click);
            // 
            // CreateTournament_Button
            // 
            this.CreateTournament_Button.Location = new System.Drawing.Point(64, 583);
            this.CreateTournament_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateTournament_Button.Name = "CreateTournament_Button";
            this.CreateTournament_Button.Size = new System.Drawing.Size(180, 51);
            this.CreateTournament_Button.TabIndex = 6;
            this.CreateTournament_Button.Text = "Create Tournament";
            this.CreateTournament_Button.UseVisualStyleBackColor = true;
            this.CreateTournament_Button.Click += new System.EventHandler(this.CreateTournament_Button_Click);
            // 
            // TournamentName_TextBox
            // 
            this.TournamentName_TextBox.Location = new System.Drawing.Point(28, 156);
            this.TournamentName_TextBox.Name = "TournamentName_TextBox";
            this.TournamentName_TextBox.Size = new System.Drawing.Size(230, 29);
            this.TournamentName_TextBox.TabIndex = 7;
            // 
            // EntryFee_TextBox
            // 
            this.EntryFee_TextBox.Location = new System.Drawing.Point(107, 209);
            this.EntryFee_TextBox.Name = "EntryFee_TextBox";
            this.EntryFee_TextBox.Size = new System.Drawing.Size(151, 29);
            this.EntryFee_TextBox.TabIndex = 8;
            this.EntryFee_TextBox.Text = "0";
            // 
            // TournamentName_Label
            // 
            this.TournamentName_Label.AutoSize = true;
            this.TournamentName_Label.Location = new System.Drawing.Point(24, 132);
            this.TournamentName_Label.Name = "TournamentName_Label";
            this.TournamentName_Label.Size = new System.Drawing.Size(142, 21);
            this.TournamentName_Label.TabIndex = 9;
            this.TournamentName_Label.Text = "Tournament Name:";
            // 
            // EntryFee_Label
            // 
            this.EntryFee_Label.AutoSize = true;
            this.EntryFee_Label.Location = new System.Drawing.Point(24, 212);
            this.EntryFee_Label.Name = "EntryFee_Label";
            this.EntryFee_Label.Size = new System.Drawing.Size(77, 21);
            this.EntryFee_Label.TabIndex = 10;
            this.EntryFee_Label.Text = "Entry Fee:";
            // 
            // SelectTeam_Label
            // 
            this.SelectTeam_Label.AutoSize = true;
            this.SelectTeam_Label.Location = new System.Drawing.Point(24, 289);
            this.SelectTeam_Label.Name = "SelectTeam_Label";
            this.SelectTeam_Label.Size = new System.Drawing.Size(91, 21);
            this.SelectTeam_Label.TabIndex = 11;
            this.SelectTeam_Label.Text = "Select Team";
            // 
            // ParticipantsTeam_Label
            // 
            this.ParticipantsTeam_Label.AutoSize = true;
            this.ParticipantsTeam_Label.Location = new System.Drawing.Point(340, 103);
            this.ParticipantsTeam_Label.Name = "ParticipantsTeam_Label";
            this.ParticipantsTeam_Label.Size = new System.Drawing.Size(139, 21);
            this.ParticipantsTeam_Label.TabIndex = 12;
            this.ParticipantsTeam_Label.Text = "Participants/Teams";
            // 
            // ParticipantsPrize_Label
            // 
            this.ParticipantsPrize_Label.AutoSize = true;
            this.ParticipantsPrize_Label.Location = new System.Drawing.Point(384, 377);
            this.ParticipantsPrize_Label.Name = "ParticipantsPrize_Label";
            this.ParticipantsPrize_Label.Size = new System.Drawing.Size(51, 21);
            this.ParticipantsPrize_Label.TabIndex = 13;
            this.ParticipantsPrize_Label.Text = "Prizes";
            // 
            // ParticipantsListBox
            // 
            this.ParticipantsListBox.FormattingEnabled = true;
            this.ParticipantsListBox.ItemHeight = 21;
            this.ParticipantsListBox.Location = new System.Drawing.Point(301, 126);
            this.ParticipantsListBox.Name = "ParticipantsListBox";
            this.ParticipantsListBox.Size = new System.Drawing.Size(217, 193);
            this.ParticipantsListBox.TabIndex = 14;
            // 
            // Prize_ListBox
            // 
            this.Prize_ListBox.FormattingEnabled = true;
            this.Prize_ListBox.ItemHeight = 21;
            this.Prize_ListBox.Location = new System.Drawing.Point(301, 401);
            this.Prize_ListBox.Name = "Prize_ListBox";
            this.Prize_ListBox.Size = new System.Drawing.Size(217, 193);
            this.Prize_ListBox.TabIndex = 15;
            // 
            // SelectTeam_DropBox
            // 
            this.SelectTeam_DropBox.FormattingEnabled = true;
            this.SelectTeam_DropBox.Location = new System.Drawing.Point(28, 317);
            this.SelectTeam_DropBox.Name = "SelectTeam_DropBox";
            this.SelectTeam_DropBox.Size = new System.Drawing.Size(230, 29);
            this.SelectTeam_DropBox.TabIndex = 16;
            this.SelectTeam_DropBox.SelectedIndexChanged += new System.EventHandler(this.SelectTeam_DropBox_SelectedIndexChanged);
            // 
            // CreateTeam_LinkLabel
            // 
            this.CreateTeam_LinkLabel.AutoSize = true;
            this.CreateTeam_LinkLabel.LinkColor = System.Drawing.Color.Blue;
            this.CreateTeam_LinkLabel.Location = new System.Drawing.Point(177, 289);
            this.CreateTeam_LinkLabel.Name = "CreateTeam_LinkLabel";
            this.CreateTeam_LinkLabel.Size = new System.Drawing.Size(82, 21);
            this.CreateTeam_LinkLabel.TabIndex = 17;
            this.CreateTeam_LinkLabel.TabStop = true;
            this.CreateTeam_LinkLabel.Text = "New Team";
            // 
            // CreateTeam_Button
            // 
            this.CreateTeam_Button.Location = new System.Drawing.Point(92, 362);
            this.CreateTeam_Button.Name = "CreateTeam_Button";
            this.CreateTeam_Button.Size = new System.Drawing.Size(112, 35);
            this.CreateTeam_Button.TabIndex = 18;
            this.CreateTeam_Button.Text = "New Team";
            this.CreateTeam_Button.UseVisualStyleBackColor = true;
            this.CreateTeam_Button.Click += new System.EventHandler(this.CreateTeam_Button_Click);
            // 
            // CreateNewTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 652);
            this.Controls.Add(this.CreateTeam_Button);
            this.Controls.Add(this.CreateTeam_LinkLabel);
            this.Controls.Add(this.SelectTeam_DropBox);
            this.Controls.Add(this.Prize_ListBox);
            this.Controls.Add(this.ParticipantsListBox);
            this.Controls.Add(this.ParticipantsPrize_Label);
            this.Controls.Add(this.ParticipantsTeam_Label);
            this.Controls.Add(this.SelectTeam_Label);
            this.Controls.Add(this.EntryFee_Label);
            this.Controls.Add(this.TournamentName_Label);
            this.Controls.Add(this.EntryFee_TextBox);
            this.Controls.Add(this.TournamentName_TextBox);
            this.Controls.Add(this.CreateTournament_Button);
            this.Controls.Add(this.RemovePrize_Button);
            this.Controls.Add(this.DeleteParticipants_Button);
            this.Controls.Add(this.CreatePrize_Button);
            this.Controls.Add(this.AddTeam_Button);
            this.Controls.Add(this.CreateTournament_HeaderLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateNewTournamentForm";
            this.Text = "Create Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CreateTournament_HeaderLabel;
        private System.Windows.Forms.Button AddTeam_Button;
        private System.Windows.Forms.Button CreatePrize_Button;
        private System.Windows.Forms.Button DeleteParticipants_Button;
        private System.Windows.Forms.Button RemovePrize_Button;
        private System.Windows.Forms.Button CreateTournament_Button;
        private System.Windows.Forms.TextBox TournamentName_TextBox;
        private System.Windows.Forms.TextBox EntryFee_TextBox;
        private System.Windows.Forms.Label TournamentName_Label;
        private System.Windows.Forms.Label EntryFee_Label;
        private System.Windows.Forms.Label SelectTeam_Label;
        private System.Windows.Forms.Label ParticipantsTeam_Label;
        private System.Windows.Forms.Label ParticipantsPrize_Label;
        private System.Windows.Forms.ListBox ParticipantsListBox;
        private System.Windows.Forms.ListBox Prize_ListBox;
        private System.Windows.Forms.ComboBox SelectTeam_DropBox;
        private System.Windows.Forms.LinkLabel CreateTeam_LinkLabel;
        private System.Windows.Forms.Button CreateTeam_Button;
    }
}