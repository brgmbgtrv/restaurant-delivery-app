using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DataAccess;

namespace WinFormsApp2
{
    public partial class formLogin : Form
    {
        private DBClient _dBClient;
        public formLogin()
        {
            InitializeComponent();
            _dBClient = new DBClient();
        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {
            var user = _dBClient.Login(loginField.Text, passwordField.Text);

            if (user == null)
            {
                labelLoginError.Visible = true;
                return;
            }
            else
            {
                CurrentUser.UserInfo = user;

                switch (user.UserRole.Name)
                {
                    case "manager":
                        this.Hide();
                        var f = new formManager();
                        f.Show();
                        this.Owner = f;
                        break;
                    case "kitchen-worker":
                        this.Hide();
                        var ff = new formKitchen();
                        ff.Show();
                        this.Owner = ff;
                        break;
                    case "courier":
                        this.Hide();
                        var fff = new formDelivery();
                        fff.Show();
                        this.Owner = fff;
                        break;
                    default:
                        break;
                }
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void labelLoginError_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new formRegistration();
            f.Show();
            f.FormClosed += new FormClosedEventHandler(delegate { Close(); });
        }
    }
}
