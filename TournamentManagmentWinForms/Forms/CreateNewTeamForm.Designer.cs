
namespace TournamentManagmentWinForms.Forms
{
    partial class CreateNewTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewTeamForm));
            this.CreateTeam_HeaderLabel = new System.Windows.Forms.Label();
            this.TeamName_Label = new System.Windows.Forms.Label();
            this.SelectTeamMember_Label = new System.Windows.Forms.Label();
            this.FirstName_Label = new System.Windows.Forms.Label();
            this.LastName_Label = new System.Windows.Forms.Label();
            this.Email_Label = new System.Windows.Forms.Label();
            this.PhoneNum_Label = new System.Windows.Forms.Label();
            this.SelectTeamMember_DropBox = new System.Windows.Forms.ComboBox();
            this.TeamName_TextBox = new System.Windows.Forms.TextBox();
            this.TeamMembers_ListBox = new System.Windows.Forms.ListBox();
            this.CreateMember_Button = new System.Windows.Forms.Button();
            this.DeleteSelected_Button = new System.Windows.Forms.Button();
            this.CreateTeam_Button = new System.Windows.Forms.Button();
            this.AddNewMember_GroupBox = new System.Windows.Forms.GroupBox();
            this.PhoneNum_TextBox = new System.Windows.Forms.TextBox();
            this.Email_TextBox = new System.Windows.Forms.TextBox();
            this.LastName_TextBox = new System.Windows.Forms.TextBox();
            this.FirstName_TextBox = new System.Windows.Forms.TextBox();
            this.AddNewMember_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateTeam_HeaderLabel
            // 
            this.CreateTeam_HeaderLabel.AutoSize = true;
            this.CreateTeam_HeaderLabel.Font = new System.Drawing.Font("Sitka Small", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTeam_HeaderLabel.Location = new System.Drawing.Point(176, 9);
            this.CreateTeam_HeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CreateTeam_HeaderLabel.Name = "CreateTeam_HeaderLabel";
            this.CreateTeam_HeaderLabel.Size = new System.Drawing.Size(332, 71);
            this.CreateTeam_HeaderLabel.TabIndex = 2;
            this.CreateTeam_HeaderLabel.Text = "Create Team";
            // 
            // TeamName_Label
            // 
            this.TeamName_Label.AutoSize = true;
            this.TeamName_Label.Location = new System.Drawing.Point(16, 104);
            this.TeamName_Label.Name = "TeamName_Label";
            this.TeamName_Label.Size = new System.Drawing.Size(92, 21);
            this.TeamName_Label.TabIndex = 3;
            this.TeamName_Label.Text = "Team Name";
            // 
            // SelectTeamMember_Label
            // 
            this.SelectTeamMember_Label.AutoSize = true;
            this.SelectTeamMember_Label.Location = new System.Drawing.Point(16, 160);
            this.SelectTeamMember_Label.Name = "SelectTeamMember_Label";
            this.SelectTeamMember_Label.Size = new System.Drawing.Size(162, 21);
            this.SelectTeamMember_Label.TabIndex = 4;
            this.SelectTeamMember_Label.Text = "Select Team Memeber";
            // 
            // FirstName_Label
            // 
            this.FirstName_Label.AutoSize = true;
            this.FirstName_Label.Location = new System.Drawing.Point(8, 31);
            this.FirstName_Label.Name = "FirstName_Label";
            this.FirstName_Label.Size = new System.Drawing.Size(86, 21);
            this.FirstName_Label.TabIndex = 5;
            this.FirstName_Label.Text = "First Name";
            // 
            // LastName_Label
            // 
            this.LastName_Label.AutoSize = true;
            this.LastName_Label.Location = new System.Drawing.Point(8, 66);
            this.LastName_Label.Name = "LastName_Label";
            this.LastName_Label.Size = new System.Drawing.Size(84, 21);
            this.LastName_Label.TabIndex = 6;
            this.LastName_Label.Text = "Last Name";
            // 
            // Email_Label
            // 
            this.Email_Label.AutoSize = true;
            this.Email_Label.Location = new System.Drawing.Point(8, 101);
            this.Email_Label.Name = "Email_Label";
            this.Email_Label.Size = new System.Drawing.Size(48, 21);
            this.Email_Label.TabIndex = 7;
            this.Email_Label.Text = "Email";
            // 
            // PhoneNum_Label
            // 
            this.PhoneNum_Label.AutoSize = true;
            this.PhoneNum_Label.Location = new System.Drawing.Point(8, 136);
            this.PhoneNum_Label.Name = "PhoneNum_Label";
            this.PhoneNum_Label.Size = new System.Drawing.Size(96, 21);
            this.PhoneNum_Label.TabIndex = 8;
            this.PhoneNum_Label.Text = "Phone Num.";
            // 
            // SelectTeamMember_DropBox
            // 
            this.SelectTeamMember_DropBox.FormattingEnabled = true;
            this.SelectTeamMember_DropBox.Location = new System.Drawing.Point(20, 184);
            this.SelectTeamMember_DropBox.Name = "SelectTeamMember_DropBox";
            this.SelectTeamMember_DropBox.Size = new System.Drawing.Size(217, 29);
            this.SelectTeamMember_DropBox.TabIndex = 10;
            // 
            // TeamName_TextBox
            // 
            this.TeamName_TextBox.Location = new System.Drawing.Point(20, 128);
            this.TeamName_TextBox.Name = "TeamName_TextBox";
            this.TeamName_TextBox.Size = new System.Drawing.Size(217, 29);
            this.TeamName_TextBox.TabIndex = 11;
            // 
            // TeamMembers_ListBox
            // 
            this.TeamMembers_ListBox.FormattingEnabled = true;
            this.TeamMembers_ListBox.ItemHeight = 21;
            this.TeamMembers_ListBox.Location = new System.Drawing.Point(375, 104);
            this.TeamMembers_ListBox.Name = "TeamMembers_ListBox";
            this.TeamMembers_ListBox.Size = new System.Drawing.Size(251, 403);
            this.TeamMembers_ListBox.TabIndex = 12;
            // 
            // CreateMember_Button
            // 
            this.CreateMember_Button.Location = new System.Drawing.Point(6, 187);
            this.CreateMember_Button.Name = "CreateMember_Button";
            this.CreateMember_Button.Size = new System.Drawing.Size(302, 35);
            this.CreateMember_Button.TabIndex = 13;
            this.CreateMember_Button.Text = "Create Member";
            this.CreateMember_Button.UseVisualStyleBackColor = true;
            this.CreateMember_Button.Click += new System.EventHandler(this.CreateMember_Button_Click);
            // 
            // DeleteSelected_Button
            // 
            this.DeleteSelected_Button.Location = new System.Drawing.Point(375, 514);
            this.DeleteSelected_Button.Name = "DeleteSelected_Button";
            this.DeleteSelected_Button.Size = new System.Drawing.Size(251, 29);
            this.DeleteSelected_Button.TabIndex = 14;
            this.DeleteSelected_Button.Text = "Delete Selected";
            this.DeleteSelected_Button.UseVisualStyleBackColor = true;
            // 
            // CreateTeam_Button
            // 
            this.CreateTeam_Button.Location = new System.Drawing.Point(426, 571);
            this.CreateTeam_Button.Name = "CreateTeam_Button";
            this.CreateTeam_Button.Size = new System.Drawing.Size(154, 41);
            this.CreateTeam_Button.TabIndex = 15;
            this.CreateTeam_Button.Text = "Create Team";
            this.CreateTeam_Button.UseVisualStyleBackColor = true;
            // 
            // AddNewMember_GroupBox
            // 
            this.AddNewMember_GroupBox.Controls.Add(this.PhoneNum_TextBox);
            this.AddNewMember_GroupBox.Controls.Add(this.Email_TextBox);
            this.AddNewMember_GroupBox.Controls.Add(this.LastName_TextBox);
            this.AddNewMember_GroupBox.Controls.Add(this.CreateMember_Button);
            this.AddNewMember_GroupBox.Controls.Add(this.FirstName_TextBox);
            this.AddNewMember_GroupBox.Controls.Add(this.FirstName_Label);
            this.AddNewMember_GroupBox.Controls.Add(this.LastName_Label);
            this.AddNewMember_GroupBox.Controls.Add(this.Email_Label);
            this.AddNewMember_GroupBox.Controls.Add(this.PhoneNum_Label);
            this.AddNewMember_GroupBox.Location = new System.Drawing.Point(20, 315);
            this.AddNewMember_GroupBox.Name = "AddNewMember_GroupBox";
            this.AddNewMember_GroupBox.Size = new System.Drawing.Size(314, 228);
            this.AddNewMember_GroupBox.TabIndex = 16;
            this.AddNewMember_GroupBox.TabStop = false;
            this.AddNewMember_GroupBox.Text = "Add New Member";
            // 
            // PhoneNum_TextBox
            // 
            this.PhoneNum_TextBox.Location = new System.Drawing.Point(110, 133);
            this.PhoneNum_TextBox.Name = "PhoneNum_TextBox";
            this.PhoneNum_TextBox.Size = new System.Drawing.Size(198, 29);
            this.PhoneNum_TextBox.TabIndex = 12;
            // 
            // Email_TextBox
            // 
            this.Email_TextBox.Location = new System.Drawing.Point(110, 98);
            this.Email_TextBox.Name = "Email_TextBox";
            this.Email_TextBox.Size = new System.Drawing.Size(198, 29);
            this.Email_TextBox.TabIndex = 11;
            // 
            // LastName_TextBox
            // 
            this.LastName_TextBox.Location = new System.Drawing.Point(110, 63);
            this.LastName_TextBox.Name = "LastName_TextBox";
            this.LastName_TextBox.Size = new System.Drawing.Size(198, 29);
            this.LastName_TextBox.TabIndex = 10;
            // 
            // FirstName_TextBox
            // 
            this.FirstName_TextBox.Location = new System.Drawing.Point(110, 28);
            this.FirstName_TextBox.Name = "FirstName_TextBox";
            this.FirstName_TextBox.Size = new System.Drawing.Size(198, 29);
            this.FirstName_TextBox.TabIndex = 9;
            // 
            // CreateNewTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 639);
            this.Controls.Add(this.AddNewMember_GroupBox);
            this.Controls.Add(this.CreateTeam_Button);
            this.Controls.Add(this.DeleteSelected_Button);
            this.Controls.Add(this.TeamMembers_ListBox);
            this.Controls.Add(this.TeamName_TextBox);
            this.Controls.Add(this.SelectTeamMember_DropBox);
            this.Controls.Add(this.SelectTeamMember_Label);
            this.Controls.Add(this.TeamName_Label);
            this.Controls.Add(this.CreateTeam_HeaderLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateNewTeamForm";
            this.Text = "Create Team";
            this.AddNewMember_GroupBox.ResumeLayout(false);
            this.AddNewMember_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CreateTeam_HeaderLabel;
        private System.Windows.Forms.Label TeamName_Label;
        private System.Windows.Forms.Label SelectTeamMember_Label;
        private System.Windows.Forms.Label FirstName_Label;
        private System.Windows.Forms.Label LastName_Label;
        private System.Windows.Forms.Label Email_Label;
        private System.Windows.Forms.Label PhoneNum_Label;
        private System.Windows.Forms.ComboBox SelectTeamMember_DropBox;
        private System.Windows.Forms.TextBox TeamName_TextBox;
        private System.Windows.Forms.ListBox TeamMembers_ListBox;
        private System.Windows.Forms.Button CreateMember_Button;
        private System.Windows.Forms.Button DeleteSelected_Button;
        private System.Windows.Forms.Button CreateTeam_Button;
        private System.Windows.Forms.GroupBox AddNewMember_GroupBox;
        private System.Windows.Forms.TextBox PhoneNum_TextBox;
        private System.Windows.Forms.TextBox Email_TextBox;
        private System.Windows.Forms.TextBox LastName_TextBox;
        private System.Windows.Forms.TextBox FirstName_TextBox;
    }
}