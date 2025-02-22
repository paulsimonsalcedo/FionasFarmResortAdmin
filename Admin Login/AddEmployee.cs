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
    public partial class AddEmployee : Form
    {
        public string FullNameFormat = @"^[a-zA-Z ]+$";
        public string EmailFormat = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public string NumberDecimal = @"^-?\\d*(\\.\\d+)?$";
        public string adminname;

        Login login = new Login();
    
        string selectedDepartmentName = "";
        long selectedDepartmentId = 0;
        string selectedPositionName = "";
        long selectedPositionId = 0;
        string Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday;

        int checkCounter = 0;

        public AddEmployee()
        {
            InitializeComponent();
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

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            txtContactNum.Text = "(+63)";
            dtpScheduleIn.Format = DateTimePickerFormat.Time;
            dtpScheduleIn.ShowUpDown = true;

            dtpScheduleOut.Format = DateTimePickerFormat.Time;
            dtpScheduleOut.ShowUpDown = true;

            dtpBreakPeriod.Format = DateTimePickerFormat.Time;
            dtpBreakPeriod.ShowUpDown = true;

            dtpScheduleIn.Format = DateTimePickerFormat.Custom;
            dtpScheduleIn.CustomFormat = "hh:mm:ss tt";

            dtpScheduleOut.Format = DateTimePickerFormat.Custom;
            dtpScheduleOut.CustomFormat = "hh:mm:ss tt";

            dtpBreakPeriod.Format = DateTimePickerFormat.Custom;
            dtpBreakPeriod.CustomFormat = "hh:mm:ss tt";

            dtpDateofBirth.Format = DateTimePickerFormat.Custom;
            dtpDateofBirth.CustomFormat = "MMMM dd, yyyy";

            dtpDateHired.Format = DateTimePickerFormat.Custom;
            dtpDateHired.CustomFormat = "MMMM dd, yyyy";
        }      

        public void insertNewEmployeeSchedule()
        {
            string schedIn = dtpScheduleIn.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpScheduleOut.Value.ToString("hh:mm:ss tt");
            string breakPer = dtpBreakPeriod.Value.ToString("hh:mm:ss tt");

            DateTime breakDt = dtpBreakPeriod.Value.AddHours(1);
            string breakEnd = breakDt.ToString("hh:mm:ss tt").ToUpper();

            if (cbMonday.Checked)
            {
                Monday = "1";
            }
            else
            {
                Monday = "0";
            }

            if (cbTuesday.Checked)
            {
                Tuesday = "1";
            }
            else
            {
                Tuesday = "0";
            }

            if (cbWednesday.Checked)
            {
                Wednesday = "1";
            }
            else
            {
                Wednesday = "0";
            }

            if (cbThursday.Checked)
            {
                Thursday = "1";
            }
            else
            {
                Thursday = "0";
            }

            if (cbFriday.Checked)
            {
                Friday = "1";
            }
            else
            {
                Friday = "0";
            }

            if (cbSaturday.Checked)
            {
                Saturday = "1";
            }
            else
            {
                Saturday = "0";
            }

            if (cbSunday.Checked)
            {
                Sunday = "1";
            }
            else
            {
                Sunday = "0";
            }

            using (SqlConnection connection2 = new SqlConnection(login.connectionString))
            {
                connection2.Open();
                string query =
                    "INSERT INTO EmployeeSchedule (EmployeeID) SELECT EmployeeID = MAX(A.EmployeeID) FROM EmployeeInfo as A";

                string query2 =
                    "UPDATE EmployeeSchedule " +
                    "SET ScheduleIn ='" + schedIn.ToUpper() + "', " +
                    "ScheduleOut ='" + schedOut.ToUpper() +"', " +
                    "Monday ='" + Monday + "', " +
                    "Tuesday ='" + Tuesday + "', " +
                    "Wednesday ='" + Wednesday + "', " +
                    "Thursday ='" + Thursday + "', " +
                    "Friday ='" + Friday + "', " +
                    "Saturday ='" + Saturday + "', " +
                    "Sunday ='" + Sunday + "', " +
                    "BreakPeriod='" + breakPer.ToUpper() + "' " +
                    "WHERE EmployeeID = (SELECT MAX(EmployeeID) FROM EmployeeInfo)";

                SqlCommand cmd = new SqlCommand(query, connection2);
                SqlCommand cmd2 = new SqlCommand(query2, connection2);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }

        private void txtDepartment_MouseClick(object sender, MouseEventArgs e)
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
                cmbDepartment.SelectedIndex = -1;
                cmbPosition.SelectedIndex = -1;
            }
        }

        private void txtSSSID_TextChanged(object sender, EventArgs e)
        {
            if(txtSSSID.TextLength == 3)
            {
                txtSSSID.Text =txtSSSID.Text+ "-";
                txtSSSID.SelectionStart = txtSSSID.TextLength;
             
            }
            if (txtSSSID.TextLength == 6)
            {
                 txtSSSID.Text = txtSSSID.Text+ "-";
                txtSSSID.SelectionStart = txtSSSID.TextLength;
            }
        }

        private void txtPagibigNo_TextChanged(object sender, EventArgs e)
        {
            if (txtPagibigNo.TextLength == 4)
            {
                txtPagibigNo.Text = txtPagibigNo.Text + "-";
                txtPagibigNo.SelectionStart = txtPagibigNo.TextLength;

            }
            if (txtPagibigNo.TextLength == 9)
            {
                txtPagibigNo.Text = txtPagibigNo.Text + "-";
                txtPagibigNo.SelectionStart = txtPagibigNo.TextLength;
            }

        }

        private void txtPhilhealthNo_TextChanged(object sender, EventArgs e)
        {
        
            if (txtPhilhealthNo.TextLength == 2)
            {
                txtPhilhealthNo.Text = txtPhilhealthNo.Text + "-";
                txtPhilhealthNo.SelectionStart = txtPhilhealthNo.TextLength;

            }
            if (txtPhilhealthNo.TextLength == 12)
            {
                txtPhilhealthNo.Text = txtPhilhealthNo.Text + "-";
                txtPhilhealthNo.SelectionStart = txtPhilhealthNo.TextLength;
            }
        }

        private void txtContactNum_TextChanged(object sender, EventArgs e)
        {

            if(txtContactNum.TextLength == 0)
            {
                txtContactNum.Text = "(+63)" + txtContactNum.Text;
                txtContactNum.SelectionStart = txtContactNum.Text.Length;
            }

        }

        private void txtTIN_TextChanged(object sender, EventArgs e)
        {
            if (txtTIN.TextLength == 3)
            {
                txtTIN.Text = txtTIN.Text + "-";
                txtTIN.SelectionStart = txtTIN.TextLength;
            }
            if (txtTIN.TextLength == 7)
            {
                txtTIN.Text = txtTIN.Text + "-";
                txtTIN.SelectionStart = txtTIN.TextLength;
            }
            if (txtTIN.TextLength == 11)
            {
                txtTIN.Text = txtTIN.Text + "-";
                txtTIN.SelectionStart = txtTIN.TextLength;
            }
        }

        private void txtSSSID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPagibigNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhilhealthNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
            cmbPosition.SelectedIndex = -1;
            lblBasicRate.Text = "---";
        }

        private void txtPosition_MouseClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT PositionName FROM Position WHERE DepartmentID='" + selectedDepartmentId + "' AND Custom=0";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "PositionName");
                cmbPosition.DisplayMember = "PositionName";
                cmbPosition.DataSource = data.Tables["PositionName"];
            }
        }

        public Int64 GetLatestEmployeeID()
        {
            string query2 =
                "SELECT MAX(EmployeeID) FROM EmployeeInfo";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt64(0);
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            //Compute Age Using DateTimePicker
            var checkAge = DateTime.Today.Year - dtpDateofBirth.Value.Year;

            string Bdate = dtpDateofBirth.Value.ToString("MMMM dd, yyyy");
            string Hdate = dtpDateHired.Value.ToString("MMMM dd, yyyy");

            if (!(Regex.IsMatch(txtFullName.Text, FullNameFormat)))
            {
                MessageBox.Show("FullName Should not be Empty or contain digits", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!(Regex.IsMatch(txtEmailAdd.Text, EmailFormat)))
            {
                MessageBox.Show("Invalid Email\nValid entries include: someone@example.com", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkAge < 18)
            {
                MessageBox.Show("Can not register underage employees","Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query = 
                        "INSERT INTO EmployeeInfo(" +
                        "EmployeeFullName, " +
                        "Address, " +
                        "SSS_ID, " +
                        "PAGIBIG_NO, " +
                        "PHIL_HEALTH_NO, " +
                        "Email, " +
                        "EmployeeMaritalStatus, " +
                        "ContactNumber, " +
                        "DateHired, " +
                        "Gender, " +
                        "BirthDate, " +
                        "EmploymentType, " +
                        "Age," +
                        "DepartmentID," +
                        "PositionID," +
                        "AccumulatedDayOffs," +
                        "SickLeaveCredits," +
                        "VacationLeaveCredits," +
                        "TIN," +
                        "Status)" +
                        "VALUES(" +
                        "@EmployeeFullName, " +
                        "@Address, " +
                        "@SSS_ID, " +
                        "@PAGIBIG_NO, " +
                        "@PHIL_HEALTH_NO, " +
                        "@Email, " +
                        "@EmployeeMaritalStatus, " +
                        "@ContactNumber, " +
                        "@DateHired, " +
                        "@Gender, " +
                        "@BirthDate, " +
                        "@EmploymentType, " +
                        "@Age," +
                        "@DepartmentID," +
                        "@PositionID," +
                        "@AccumulatedDayOffs," +
                        "@SickLeaveCredits," +
                        "@VacationLeaveCredits," +
                        "@TIN," +
                        "@Status)";

                    string schedIn = dtpScheduleIn.Value.ToString("hh:mm:ss tt");
                    string schedOut = dtpScheduleOut.Value.ToString("hh:mm:ss tt");
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@EmployeeFullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@SSS_ID", txtSSSID.Text);
                    cmd.Parameters.AddWithValue("@PAGIBIG_NO", txtPagibigNo.Text);
                    cmd.Parameters.AddWithValue("@PHIL_HEALTH_NO", txtPhilhealthNo.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmailAdd.Text);
                    cmd.Parameters.AddWithValue("@EmployeeMaritalStatus", txtCivilStatus.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContactNum.Text); 
                    cmd.Parameters.AddWithValue("@DateHired", Hdate);
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", Bdate);
                    cmd.Parameters.AddWithValue("@DepartmentID", selectedDepartmentId);
                    cmd.Parameters.AddWithValue("@PositionID", selectedPositionId);
                    cmd.Parameters.AddWithValue("@EmploymentType", txtEmploymentType.Text);
                    cmd.Parameters.AddWithValue("@AccumulatedDayOffs", 0);
                    cmd.Parameters.AddWithValue("@SickLeaveCredits", 0);
                    cmd.Parameters.AddWithValue("@VacationLeaveCredits", 0);
                    cmd.Parameters.AddWithValue("@TIN", txtTIN.Text);
                    cmd.Parameters.AddWithValue("@Status", "Active");

                    //Compute Age Using DateTimePicker
                    int currentAge = DateTime.Today.Year - dtpDateofBirth.Value.Year;

                    cmd.Parameters.AddWithValue("@Age", currentAge.ToString());
                    cmd.ExecuteNonQuery();

                    insertNewEmployeeSchedule();

                    //
                    //  ADD AUDIT
                    //
                    AuditTrail audit = new AuditTrail();
                    audit.AuditAddEmployee(GetLatestEmployeeID().ToString(), txtFullName.Text.ToString());

                    clearAll();
                }

                MessageBox.Show("Employee Successfully Registered", "Employee Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                menu.Text = "Fiona's Farm and Resort - Employee List";
                menu.Menu_Load(menu, EventArgs.Empty);
                Dispose();
            }
        }
        private void cmbPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedPositionName = cmbPosition.GetItemText(cmbPosition.SelectedItem);
            string query = "SELECT PositionID FROM Position WHERE PositionName='" + selectedPositionName + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        selectedPositionId = reader.GetInt64(0);
                        reader.Close();
                    }
                }
            }
            lblBasicRate.Text = GetBasicRate(selectedPositionId.ToString()).ToString();
        }

        private decimal GetBasicRate(string posID)
        {
            string query = "SELECT BasicRate FROM Position WHERE PositionID='" + posID + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetDecimal(0);
                    }
                    else
                    {
                        return 0.0m;
                    }
                }
            }
        }

        public void clearAll()
        {
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtSSSID.Text = "";
            txtPagibigNo.Text = "";
            txtPhilhealthNo.Text = "";
            txtEmailAdd.Text = "";
            txtCivilStatus.Text = "";
            txtContactNum.Text = "";
            dtpDateHired.Text = "";
            txtGender.Text = "";
            txtEmploymentType.Text = "";
            cmbDepartment.Text = "";
            cmbPosition.Text = "";
            txtTIN.Text = "";
            txtCivilStatus.Text = "";
            txtGender.Text = "";
            txtEmploymentType.Text = "";
            cmbDepartment.Text = "";
            cmbPosition.Text = "";
            cbMonday.Checked = false;
            cbTuesday.Checked = false;
            cbWednesday.Checked = false;
            cbThursday.Checked = false;
            cbFriday.Checked = false;
            cbSaturday.Checked = false;
            cbSunday.Checked = false;
        }

        private void txtCivilStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            string breakPer = dtpBreakPeriod.Value.ToString("hh:mm:ss tt");

            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        //
        //  CHECK LIMIER
        //

        private void cbMonday_CheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 7)
            {
                MessageBox.Show("Employee must have at least one Rest Day", "Employee Workday", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                box.Checked = false;
            }
        }

        private void cmbDepartment_Click(object sender, EventArgs e)
        {
            lblBasicRate.Text = "---";
        }

        private void cbTuesday_CheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 7)
            {
                MessageBox.Show("Employee must have at least one Rest Day", "Employee Workday", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                box.Checked = false;
            }
        }

        private void cbWednesday_CheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 7)
            {
                MessageBox.Show("Employee must have at least one Rest Day", "Employee Workday", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                box.Checked = false;
            }
        }

        private void cbThursday_CheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 7)
            {
                MessageBox.Show("Employee must have at least one Rest Day", "Employee Workday", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                box.Checked = false;
            }
        }

        private void cbFriday_CheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 7)
            {
                MessageBox.Show("Employee must have at least one Rest Day", "Employee Workday", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                box.Checked = false;
            }
        }

        private void cbSaturday_CheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 7)
            {
                MessageBox.Show("Employee must have at least one Rest Day", "Employee Workday", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                box.Checked = false;
            }
        }

        private void cbSunday_CheckedChanged(object sender, EventArgs e)
        {
            // Increase or decrease the check counter
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 7)
            {
                MessageBox.Show("Employee must have at least one Rest Day", "Employee Workday", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                box.Checked = false;
            }
        }
    }
 }