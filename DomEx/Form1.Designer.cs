namespace DomEx
{
    partial class Form1
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
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.exitsBox = new System.Windows.Forms.ComboBox();
            this.goHereButton = new System.Windows.Forms.Button();
            this.goThroughtDoor = new System.Windows.Forms.Button();
            this.hiddeButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(260, 137);
            this.descriptionBox.TabIndex = 0;
            // 
            // exitsBox
            // 
            this.exitsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitsBox.FormattingEnabled = true;
            this.exitsBox.Location = new System.Drawing.Point(105, 155);
            this.exitsBox.Name = "exitsBox";
            this.exitsBox.Size = new System.Drawing.Size(167, 21);
            this.exitsBox.TabIndex = 1;
            // 
            // goHereButton
            // 
            this.goHereButton.Location = new System.Drawing.Point(12, 155);
            this.goHereButton.Name = "goHereButton";
            this.goHereButton.Size = new System.Drawing.Size(87, 21);
            this.goHereButton.TabIndex = 2;
            this.goHereButton.Text = "Idź tutaj";
            this.goHereButton.UseVisualStyleBackColor = true;
            this.goHereButton.Click += new System.EventHandler(this.goHereButton_Click);
            // 
            // goThroughtDoor
            // 
            this.goThroughtDoor.Location = new System.Drawing.Point(12, 182);
            this.goThroughtDoor.Name = "goThroughtDoor";
            this.goThroughtDoor.Size = new System.Drawing.Size(260, 23);
            this.goThroughtDoor.TabIndex = 3;
            this.goThroughtDoor.Text = "Przejdź przez drzwi";
            this.goThroughtDoor.UseVisualStyleBackColor = true;
            this.goThroughtDoor.Visible = false;
            this.goThroughtDoor.Click += new System.EventHandler(this.goThroughtDoor_Click);
            // 
            // hiddeButton
            // 
            this.hiddeButton.Location = new System.Drawing.Point(12, 240);
            this.hiddeButton.Name = "hiddeButton";
            this.hiddeButton.Size = new System.Drawing.Size(260, 23);
            this.hiddeButton.TabIndex = 4;
            this.hiddeButton.Text = "Kryj się";
            this.hiddeButton.UseVisualStyleBackColor = true;
            this.hiddeButton.Visible = false;
            this.hiddeButton.Click += new System.EventHandler(this.hiddeButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(12, 211);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(260, 23);
            this.checkButton.TabIndex = 5;
            this.checkButton.Text = "Sprawdź kryjówkę";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Visible = false;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 275);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.hiddeButton);
            this.Controls.Add(this.goThroughtDoor);
            this.Controls.Add(this.goHereButton);
            this.Controls.Add(this.exitsBox);
            this.Controls.Add(this.descriptionBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Dom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.ComboBox exitsBox;
        private System.Windows.Forms.Button goHereButton;
        private System.Windows.Forms.Button goThroughtDoor;
        private System.Windows.Forms.Button hiddeButton;
        private System.Windows.Forms.Button checkButton;
    }
}

