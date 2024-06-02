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

namespace CanteenApp.Pages
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DBAuth dBAuth = new DBAuth();
            int checkEmail = dBAuth.CheckEmail(txtEmail.Text.Trim());

            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Email Harus Diisi");
                return;
            }
            else if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Email Harus Diisi");
                return;
            }
            else if (checkEmail > 0)
            {
                MessageBox.Show("Email Sudah Digunakan");
                return;
            }
            else if (txtPhone.Text.Trim().Length == 0)
            {
                MessageBox.Show("Phone Harus Diisi");
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
            else if (btnRegister.Text == "Register")
            {
                UserModel user = new UserModel(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtPassword.Text.Trim());
                dBAuth.Register(user);
                Clear();
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
