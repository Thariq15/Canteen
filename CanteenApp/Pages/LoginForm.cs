using CanteenApp.Controllers;
using CanteenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CanteenApp.Pages
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Email Harus Diisi");
                return;
            }
            else if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password Harus Diisi");
                return;
            }
            else if (txtPassword.Text.Trim().Length < 6)
            {
                MessageBox.Show("Password Minimal 6 Karakter");
                return;
            }
            else if (btnLogin.Text == "Login")
            {
                DBAuth dBAuth = new DBAuth();
                dBAuth.Login(txtEmail.Text.Trim(), txtPassword.Text.Trim(), this);
            }
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
