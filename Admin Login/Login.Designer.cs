﻿
namespace Admin_Login
{
    partial class Login
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
            this.LoginLabel = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UsernameError = new System.Windows.Forms.Label();
            this.PasswordError = new System.Windows.Forms.Label();
            this.ExitIcon = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ExitIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.Location = new System.Drawing.Point(9, 7);
            this.LoginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(441, 36);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Fiona\'s Farm and Resort - Login";
            // 
            // Username
            // 
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Username.Location = new System.Drawing.Point(349, 296);
            this.Username.Margin = new System.Windows.Forms.Padding(2);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(263, 37);
            this.Username.TabIndex = 3;
            this.Username.Text = " Username";
            this.Username.Enter += new System.EventHandler(this.NameText_Enter);
            this.Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Username_KeyDown);
            this.Username.Leave += new System.EventHandler(this.NameText_Leave);
            // 
            // Password
            // 
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Password.Location = new System.Drawing.Point(349, 353);
            this.Password.Margin = new System.Windows.Forms.Padding(2);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(263, 37);
            this.Password.TabIndex = 4;
            this.Password.Text = " Password";
            this.Password.Enter += new System.EventHandler(this.PassText_Enter);
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            this.Password.Leave += new System.EventHandler(this.PassText_Leave);
            // 
            // LoginButton
            // 
            this.LoginButton.AutoSize = true;
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(405, 433);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(150, 65);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UsernameError
            // 
            this.UsernameError.AutoSize = true;
            this.UsernameError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsernameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameError.ForeColor = System.Drawing.Color.Red;
            this.UsernameError.Location = new System.Drawing.Point(616, 310);
            this.UsernameError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsernameError.Name = "UsernameError";
            this.UsernameError.Size = new System.Drawing.Size(12, 18);
            this.UsernameError.TabIndex = 7;
            this.UsernameError.Text = " ";
            // 
            // PasswordError
            // 
            this.PasswordError.AutoSize = true;
            this.PasswordError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordError.ForeColor = System.Drawing.Color.Red;
            this.PasswordError.Location = new System.Drawing.Point(616, 368);
            this.PasswordError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordError.Name = "PasswordError";
            this.PasswordError.Size = new System.Drawing.Size(12, 18);
            this.PasswordError.TabIndex = 8;
            this.PasswordError.Text = " ";
            // 
            // ExitIcon
            // 
            this.ExitIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.ExitIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitIcon.Image = global::Admin_Login.Properties.Resources.Exit_Icon1;
            this.ExitIcon.Location = new System.Drawing.Point(926, 9);
            this.ExitIcon.Margin = new System.Windows.Forms.Padding(2);
            this.ExitIcon.Name = "ExitIcon";
            this.ExitIcon.Size = new System.Drawing.Size(26, 35);
            this.ExitIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ExitIcon.TabIndex = 9;
            this.ExitIcon.TabStop = false;
            this.ExitIcon.Click += new System.EventHandler(this.ExitIcon_Click);
            // 
            // Logo
            // 
            this.Logo.Image = global::Admin_Login.Properties.Resources.FullLogo_02;
            this.Logo.Location = new System.Drawing.Point(405, 106);
            this.Logo.Margin = new System.Windows.Forms.Padding(2);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(150, 162);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 2;
            this.Logo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(966, 54);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(876, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 46);
            this.label1.TabIndex = 10;
            this.label1.Text = "-";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 585);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitIcon);
            this.Controls.Add(this.PasswordError);
            this.Controls.Add(this.UsernameError);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiona\'s Farm and Resort - Login";
            ((System.ComponentModel.ISupportInitialize)(this.ExitIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label UsernameError;
        private System.Windows.Forms.Label PasswordError;
        private System.Windows.Forms.PictureBox ExitIcon;
        public System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label1;
    }
}

