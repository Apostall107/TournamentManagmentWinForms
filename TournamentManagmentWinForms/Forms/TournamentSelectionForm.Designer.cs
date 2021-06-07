
namespace TournamentManagmentWinForms.Forms
{
    partial class TournamentSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentSelectionForm));
            this.TournamentSelection_HeaderLabel = new System.Windows.Forms.Label();
            this.LoadExistingTournament_Label = new System.Windows.Forms.Label();
            this.LoadExistingTournament_DropBox = new System.Windows.Forms.ComboBox();
            this.LoadTournament_Button = new System.Windows.Forms.Button();
            this.CreateTournament_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TournamentSelection_HeaderLabel
            // 
            this.TournamentSelection_HeaderLabel.AutoSize = true;
            this.TournamentSelection_HeaderLabel.Font = new System.Drawing.Font("Sitka Small", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TournamentSelection_HeaderLabel.Location = new System.Drawing.Point(13, 9);
            this.TournamentSelection_HeaderLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TournamentSelection_HeaderLabel.Name = "TournamentSelection_HeaderLabel";
            this.TournamentSelection_HeaderLabel.Size = new System.Drawing.Size(563, 71);
            this.TournamentSelection_HeaderLabel.TabIndex = 4;
            this.TournamentSelection_HeaderLabel.Text = "Tournament Selection";
            // 
            // LoadExistingTournament_Label
            // 
            this.LoadExistingTournament_Label.AutoSize = true;
            this.LoadExistingTournament_Label.Location = new System.Drawing.Point(200, 102);
            this.LoadExistingTournament_Label.Name = "LoadExistingTournament_Label";
            this.LoadExistingTournament_Label.Size = new System.Drawing.Size(188, 21);
            this.LoadExistingTournament_Label.TabIndex = 5;
            this.LoadExistingTournament_Label.Text = "Load Existing Tournament";
            this.LoadExistingTournament_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // LoadExistingTournament_DropBox
            // 
            this.LoadExistingTournament_DropBox.FormattingEnabled = true;
            this.LoadExistingTournament_DropBox.Location = new System.Drawing.Point(115, 126);
            this.LoadExistingTournament_DropBox.Name = "LoadExistingTournament_DropBox";
            this.LoadExistingTournament_DropBox.Size = new System.Drawing.Size(359, 29);
            this.LoadExistingTournament_DropBox.TabIndex = 6;
            // 
            // LoadTournament_Button
            // 
            this.LoadTournament_Button.Location = new System.Drawing.Point(198, 202);
            this.LoadTournament_Button.Name = "LoadTournament_Button";
            this.LoadTournament_Button.Size = new System.Drawing.Size(193, 51);
            this.LoadTournament_Button.TabIndex = 7;
            this.LoadTournament_Button.Text = "Load Tournament";
            this.LoadTournament_Button.UseVisualStyleBackColor = true;
            this.LoadTournament_Button.Click += new System.EventHandler(this.LoadTournament_Button_Click);
            // 
            // CreateTournament_Button
            // 
            this.CreateTournament_Button.Location = new System.Drawing.Point(155, 292);
            this.CreateTournament_Button.Name = "CreateTournament_Button";
            this.CreateTournament_Button.Size = new System.Drawing.Size(279, 69);
            this.CreateTournament_Button.TabIndex = 8;
            this.CreateTournament_Button.Text = "Create Tournament";
            this.CreateTournament_Button.UseVisualStyleBackColor = true;
            this.CreateTournament_Button.Click += new System.EventHandler(this.CreateTournament_Button_Click);
            // 
            // TournamentSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 373);
            this.Controls.Add(this.CreateTournament_Button);
            this.Controls.Add(this.LoadTournament_Button);
            this.Controls.Add(this.LoadExistingTournament_DropBox);
            this.Controls.Add(this.LoadExistingTournament_Label);
            this.Controls.Add(this.TournamentSelection_HeaderLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TournamentSelectionForm";
            this.Text = "TournamentSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TournamentSelection_HeaderLabel;
        private System.Windows.Forms.Label LoadExistingTournament_Label;
        private System.Windows.Forms.ComboBox LoadExistingTournament_DropBox;
        private System.Windows.Forms.Button LoadTournament_Button;
        private System.Windows.Forms.Button CreateTournament_Button;
    }
}