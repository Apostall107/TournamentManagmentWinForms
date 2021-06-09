
namespace TournamentManagementWinForms.Forms
{
    partial class CreateNewPrizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewPrizeForm));
            this.CreatePrize_HeaderLabel = new System.Windows.Forms.Label();
            this.PlaceNumber_Label = new System.Windows.Forms.Label();
            this.PlaceNumber_TextBox = new System.Windows.Forms.TextBox();
            this.PlaceName_Label = new System.Windows.Forms.Label();
            this.PlaceName_TextBox = new System.Windows.Forms.TextBox();
            this.PrizeAmount_Label = new System.Windows.Forms.Label();
            this.PrizeAmount_TextBox = new System.Windows.Forms.TextBox();
            this.PrizePercentage_Label = new System.Windows.Forms.Label();
            this.PrizePercentage_TextBox = new System.Windows.Forms.TextBox();
            this.CreatePrize_Button = new System.Windows.Forms.Button();
            this.Or_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreatePrize_HeaderLabel
            // 
            this.CreatePrize_HeaderLabel.AutoSize = true;
            this.CreatePrize_HeaderLabel.Font = new System.Drawing.Font("Sitka Small", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreatePrize_HeaderLabel.Location = new System.Drawing.Point(37, 9);
            this.CreatePrize_HeaderLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CreatePrize_HeaderLabel.Name = "CreatePrize_HeaderLabel";
            this.CreatePrize_HeaderLabel.Size = new System.Drawing.Size(332, 71);
            this.CreatePrize_HeaderLabel.TabIndex = 3;
            this.CreatePrize_HeaderLabel.Text = "Create Team";
            // 
            // PlaceNumber_Label
            // 
            this.PlaceNumber_Label.AutoSize = true;
            this.PlaceNumber_Label.Location = new System.Drawing.Point(14, 110);
            this.PlaceNumber_Label.Name = "PlaceNumber_Label";
            this.PlaceNumber_Label.Size = new System.Drawing.Size(108, 21);
            this.PlaceNumber_Label.TabIndex = 12;
            this.PlaceNumber_Label.Text = "Place Number";
            // 
            // PlaceNumber_TextBox
            // 
            this.PlaceNumber_TextBox.Location = new System.Drawing.Point(124, 107);
            this.PlaceNumber_TextBox.Name = "PlaceNumber_TextBox";
            this.PlaceNumber_TextBox.Size = new System.Drawing.Size(241, 29);
            this.PlaceNumber_TextBox.TabIndex = 11;
            // 
            // PlaceName_Label
            // 
            this.PlaceName_Label.AutoSize = true;
            this.PlaceName_Label.Location = new System.Drawing.Point(22, 147);
            this.PlaceName_Label.Name = "PlaceName_Label";
            this.PlaceName_Label.Size = new System.Drawing.Size(92, 21);
            this.PlaceName_Label.TabIndex = 14;
            this.PlaceName_Label.Text = "Place Name";
            // 
            // PlaceName_TextBox
            // 
            this.PlaceName_TextBox.Location = new System.Drawing.Point(124, 144);
            this.PlaceName_TextBox.Name = "PlaceName_TextBox";
            this.PlaceName_TextBox.Size = new System.Drawing.Size(241, 29);
            this.PlaceName_TextBox.TabIndex = 13;
            // 
            // PrizeAmount_Label
            // 
            this.PrizeAmount_Label.AutoSize = true;
            this.PrizeAmount_Label.Location = new System.Drawing.Point(16, 184);
            this.PrizeAmount_Label.Name = "PrizeAmount_Label";
            this.PrizeAmount_Label.Size = new System.Drawing.Size(104, 21);
            this.PrizeAmount_Label.TabIndex = 16;
            this.PrizeAmount_Label.Text = "Prize Amount";
            // 
            // PrizeAmount_TextBox
            // 
            this.PrizeAmount_TextBox.Location = new System.Drawing.Point(124, 181);
            this.PrizeAmount_TextBox.Name = "PrizeAmount_TextBox";
            this.PrizeAmount_TextBox.Size = new System.Drawing.Size(241, 29);
            this.PrizeAmount_TextBox.TabIndex = 15;
            this.PrizeAmount_TextBox.Text = "0";
            // 
            // PrizePercentage_Label
            // 
            this.PrizePercentage_Label.AutoSize = true;
            this.PrizePercentage_Label.Location = new System.Drawing.Point(38, 287);
            this.PrizePercentage_Label.Name = "PrizePercentage_Label";
            this.PrizePercentage_Label.Size = new System.Drawing.Size(61, 21);
            this.PrizePercentage_Label.TabIndex = 18;
            this.PrizePercentage_Label.Text = "Prize %";
            // 
            // PrizePercentage_TextBox
            // 
            this.PrizePercentage_TextBox.Location = new System.Drawing.Point(124, 284);
            this.PrizePercentage_TextBox.Name = "PrizePercentage_TextBox";
            this.PrizePercentage_TextBox.Size = new System.Drawing.Size(241, 29);
            this.PrizePercentage_TextBox.TabIndex = 17;
            this.PrizePercentage_TextBox.Text = "0";
            // 
            // CreatePrize_Button
            // 
            this.CreatePrize_Button.Location = new System.Drawing.Point(103, 372);
            this.CreatePrize_Button.Name = "CreatePrize_Button";
            this.CreatePrize_Button.Size = new System.Drawing.Size(199, 59);
            this.CreatePrize_Button.TabIndex = 19;
            this.CreatePrize_Button.Text = "Create Prize";
            this.CreatePrize_Button.UseVisualStyleBackColor = true;
            this.CreatePrize_Button.Click += new System.EventHandler(this.CreatePrize_Button_Click);
            // 
            // Or_Label
            // 
            this.Or_Label.AutoSize = true;
            this.Or_Label.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Or_Label.Location = new System.Drawing.Point(98, 236);
            this.Or_Label.Name = "Or_Label";
            this.Or_Label.Size = new System.Drawing.Size(46, 25);
            this.Or_Label.TabIndex = 20;
            this.Or_Label.Text = "-or-";
            // 
            // CreateNewPrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 457);
            this.Controls.Add(this.Or_Label);
            this.Controls.Add(this.CreatePrize_Button);
            this.Controls.Add(this.PrizePercentage_Label);
            this.Controls.Add(this.PrizePercentage_TextBox);
            this.Controls.Add(this.PrizeAmount_Label);
            this.Controls.Add(this.PrizeAmount_TextBox);
            this.Controls.Add(this.PlaceName_Label);
            this.Controls.Add(this.PlaceName_TextBox);
            this.Controls.Add(this.PlaceNumber_Label);
            this.Controls.Add(this.PlaceNumber_TextBox);
            this.Controls.Add(this.CreatePrize_HeaderLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateNewPrizeForm";
            this.Text = "Create Prize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CreatePrize_HeaderLabel;
        private System.Windows.Forms.Label PlaceNumber_Label;
        private System.Windows.Forms.TextBox PlaceNumber_TextBox;
        private System.Windows.Forms.Label PlaceName_Label;
        private System.Windows.Forms.TextBox PlaceName_TextBox;
        private System.Windows.Forms.Label PrizeAmount_Label;
        private System.Windows.Forms.TextBox PrizeAmount_TextBox;
        private System.Windows.Forms.Label PrizePercentage_Label;
        private System.Windows.Forms.TextBox PrizePercentage_TextBox;
        private System.Windows.Forms.Button CreatePrize_Button;
        private System.Windows.Forms.Label Or_Label;
    }
}