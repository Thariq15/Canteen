using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanteenApp.Pages;
using FontAwesome.Sharp;
using CanteenApp.Controllers;
using CanteenApp.Models;

namespace CanteenApp
{
    public partial class MainForm : Form
    {
        // Fields
        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentChildForm;

        public MainForm()
        {
            InitializeComponent();
            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(10,70);
            panelMenu.Controls.Add(leftBorderButton);
        }

        private struct RGBColors
        {
            public static Color color = Color.FromArgb(116, 43, 222);
            public static Color purple = Color.FromArgb(116, 43, 222);
            public static Color gray = Color.FromArgb(160, 165, 186);
            public static Color white = Color.FromArgb(251, 251, 253);
        }

        // Methods
        private void ActiveButton(object sender, Color color)
        {
            if (sender != null)
            {
                DisableButton();
                currentButton = (IconButton)sender;
                currentButton.BackColor = RGBColors.purple;
                currentButton.ForeColor = color;
                currentButton.IconColor = color;
                leftBorderButton.BackColor = RGBColors.gray;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(251, 251, 253);
                currentButton.ForeColor = Color.FromArgb(160, 165, 186);
                currentButton.IconColor = Color.FromArgb(160, 165, 186);
            }
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.white);
            OpenChildForm(new DashboardForm());
        }

        private void category_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.white);
            OpenChildForm(new CategoryForm());
        }

        private void product_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.white);
            OpenChildForm(new ProductForm());
        }

        private void shop_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.white);
            OpenChildForm(new ShopForm());
        }

        private void history_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.white);
            OpenChildForm(new HistoryForm());
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void logout_Leave(object sender, EventArgs e)
        {
            logout.BackColor = Color.FromArgb(251, 251, 253);
            logout.ForeColor = Color.FromArgb(160, 165, 186);
            logout.IconColor = Color.FromArgb(160, 165, 186);
        }

        private void logout_Hover(object sender, EventArgs e)
        {
            logout.BackColor = RGBColors.purple;
            logout.ForeColor = RGBColors.white;
            logout.IconColor = RGBColors.white;
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            content.Controls.Add(childForm);
            content.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            this.Close();
        }
    }
}
