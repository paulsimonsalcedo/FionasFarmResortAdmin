﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Admin_Login
{
    public partial class AddDepartmentAndPosition : Form
    {

        AddEmployee ae = new AddEmployee();
        Login login = new Login();
        string selectedDepartmentName = "";
        long selectedDepartmentId = 0;
        public AddDepartmentAndPosition()
        {
            InitializeComponent();
        }
        //DROP SHADOw
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
        // MAKE BASIC RATE TEXT BOX ACCEPT ONLY NUMBERS
        private void txtBasicRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void cmbDepartment_MouseClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT DepartmentName FROM Department";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "DepartmentName");
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.DataSource = data.Tables["DepartmentName"];
            }
        }
        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedDepartmentName = cmbDepartment.GetItemText(cmbDepartment.SelectedItem);
            string query2 = "SELECT DepartmentID FROM Department WHERE DepartmentName='" + selectedDepartmentName + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        selectedDepartmentId = reader.GetInt64(0);
                        reader.Close();
                    }
                }
            }
        }
        private void btn_AddDepartment_Click(object sender, EventArgs e)
        {
            if (!(Regex.IsMatch(txtDepartmentName.Text, ae.FullNameFormat)))
            {
                MessageBox.Show("Invalid Department name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = new SqlConnection(login.connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Insert Into Department(DepartmentName)Values(@DepartmentName)", conn);
                cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text);
                cmd.ExecuteNonQuery();

                AuditTrail audit = new AuditTrail();
                audit.AuditAddDepartment(txtDepartmentName.Text.ToString());

                conn.Close();

                MessageBox.Show("New Department Has been Successfully Added", "Department Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDepartmentName.Text = "";
            }
        }
        private void btn_AddPosition_Click(object sender, EventArgs e)
        {
            if (!(Regex.IsMatch(txtPositionName.Text, ae.FullNameFormat)))
            {
                MessageBox.Show("Invalid Position name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "INSERT INTO Position" +
                        "(PositionName, DepartmentID, BasicRate, Custom, Manegerial)" +
                        "VALUES" +
                        "(@PositionName, @DepartmentID, @BasicRate, @Custom, @Manegerial)",
                        connection);

                    // CONVERT STRING TO DECIMAL
                    decimal string_to_decimal;

                    if (Decimal.TryParse(txtBasicRate.Text, out string_to_decimal))
                    {
                        Console.WriteLine(string_to_decimal.ToString("0.##"));
                    }
                    else
                    {
                        Console.WriteLine("not a Decimal");
                    }

                    command.Parameters.AddWithValue("@PositionName", txtPositionName.Text);
                    command.Parameters.AddWithValue("@DepartmentID", selectedDepartmentId);
                    command.Parameters.AddWithValue("@BasicRate", string_to_decimal);
                    command.Parameters.AddWithValue("@Custom", 0);

                    if (cbManegerial.Checked == true)
                    {
                        command.Parameters.AddWithValue("@Manegerial", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Manegerial", 0);
                    }

                    command.ExecuteNonQuery();

                    AuditTrail audit = new AuditTrail();
                    audit.AuditAddPosition(
                        txtPositionName.Text.ToString(),
                        txtBasicRate.Text.ToString(),
                        cmbDepartment.Text.ToString());

                    MessageBox.Show("New Position Has been Successfully Added", "Position Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPositionName.Text = "";
                    cmbDepartment.SelectedIndex = -1;
                    txtBasicRate.Text = "";
                }
            }
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Department and Position";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void cmbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}