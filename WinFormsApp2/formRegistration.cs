using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WinFormsApp2.DataAccess;

namespace WinFormsApp2
{
    public partial class formRegistration : Form
    {
        public formRegistration()
        {
            InitializeComponent();
            var queryString = $"SELECT * FROM UserRoles";
            try
            {
                DBClient.sqlConnection.Open();
                SqlCommand command = new SqlCommand(queryString, DBClient.sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBoxRoles.Items.Add(reader.GetString(1));
                    }
                }
            }
            catch (SqlException e)
            {

            }
            finally
            {
                DBClient.sqlConnection.Close();
            }
        }

        private void formRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (loginField.Text != "" && passwordField.Text != "")
            {
                if (passwordField.Text == passwordField2.Text)
                {
                    if (!UserExists())
                    {
                        var user = new DBClient();
                        user.Register(loginField.Text, passwordField.Text, comboBoxRoles.Text);
                        MessageBox.Show("You've succesfully registered", "Registration");
                        this.Hide();
                        var f = new formLogin();
                        this.Owner = f;
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("User with such username already exists", "Alert");
                        loginField.Text = "";
                    }
                }
                else
                {
                    labelRegisterError.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("All fields should be filled", "Alert");
            }
        }

        private Boolean UserExists()
        {
            DBClient _dbClient = new DBClient();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand($" SELECT * FROM Users WHERE [login] = @login", DBClient.sqlConnection);
            command.Parameters.Add("@login", SqlDbType.NVarChar).Value = loginField.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new formLogin();
            f.Show();
            this.Owner = f;
        }
    }
}
