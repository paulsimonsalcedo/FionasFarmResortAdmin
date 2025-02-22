﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;

namespace Admin_Login
{
    public partial class Login : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int right,
            int top,
            int bottom,
            int width,
            int height
            );

        private string getConnectionString()
        {
            var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string text = File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Database Settings\\Database Address.txt");
            return text;
        }

        //DEFAULT CONNECTION STRING
        //public string connectionString =
        //    "Data Source=" +
        //    File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Database Settings\\Database Address.txt") +
        //    ";Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";

        //DEVIN CONNECTION STRING
        //public string connectionString = "Data Source=DESKTOP-EHBRJVA\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //CUNAN CONNECTION STRING
        public string connectionString = @"Data Source=JOHN-CUNAN\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //JOVS CONNECTION STRING
        //public string connectionString = "Data Source=DESKTOP-2NTMR5E\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //PAUL CONNECTION STRING
        //public string connectionString = "Data Source=DESKTOP-B80EBU7\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //PAUL PC
        //public string connectionString = @"Data Source=DESKTOP-0Q352R7\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //PAUL HIRAMLAPTOP
        //public string connectionString = @"Data Source=LAPTOP-73509PLO\SQLEXPRESS;Initial Catalog = FFRUsers; Integrated Security = True;MultipleActiveResultSets=True";

        public new string Name;
        string userType;
        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
        }
        //Dropshadow
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }
        private void NameText_Enter(object sender, EventArgs e)
        {
            UsernameError.Text = "";
            if (Username.Text == " Username")
            {
                Username.Text = "";
                Username.ForeColor = Color.Black;
            }
        }
        private void NameText_Leave(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = " Username";
                Username.ForeColor = Color.Silver;
            }
        }
        private void PassText_Enter(object sender, EventArgs e)
        {
            PasswordError.Text = "";
            Password.PasswordChar = '*';
            if (Password.Text == " Password")
            {
                Password.Text = "";
                Password.ForeColor = Color.Black;
            }
        }
        private void PassText_Leave(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                Password.PasswordChar = '\0';
                Password.Text = " Password";
                Password.ForeColor = Color.Silver;
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginUser();
        }
        private void ExitIcon_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                DateTime today = DateTime.Today;

                string query =
                    "BACKUP DATABASE FFRUsers " +
                    "TO DISK = '" + path + "\\Database Backups\\Backup - " +
                    today.ToString("MMMM dd yyyy") + " " + DateTime.Now.ToString("h-mm-ss tt").ToUpper() + ".bak'";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            System.Environment.Exit(0);
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginUser();
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginUser();
            }
        }
        public void loginUser()
        {
            if (Username.Text == " Username" || Username.Text == "")
            {
                UsernameError.Text = "This field is required.";
            }
            else if (Password.Text == " Password" || Password.Text == "")
            {
                PasswordError.Text = "This field is required.";
            }
            else
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand loginCommand = new SqlCommand("SELECT * FROM Users WHERE Username_ = '"+Username.Text+"'AND Password_ = '"+Password.Text+"'",connection);
     
                    SqlDataReader Reader;
                    Reader = loginCommand.ExecuteReader();
          
                    if (Reader.Read() == true)//if Match
                    {
                        Name = Reader.GetValue(1).ToString();
                        AddEmployee ad = new AddEmployee();
                        Menu menu = new Menu(Name);
                        this.Hide();
                        menu.ShowDialog();
                        if (!Reader.Read())
                        {
                            PasswordError.Text = "Wrong password.";
                            Password.PasswordChar = '\0';
                            Password.Text = " Password";
                            Password.ForeColor = Color.Silver;
                        }
                      
                    }
                    else
                    {
                        UsernameError.Text = "Incorrect user name or password";
                        //Username.Text = " Username";
                        //Username.ForeColor = Color.Silver;
                        Password.Text = " Password";
                        Password.ForeColor = Color.Silver;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}