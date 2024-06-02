namespace CanteenApp
{
    partial class MainForm
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.history = new FontAwesome.Sharp.IconButton();
            this.shop = new FontAwesome.Sharp.IconButton();
            this.product = new FontAwesome.Sharp.IconButton();
            this.category = new FontAwesome.Sharp.IconButton();
            this.dashboard = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.mainLabel = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Panel();
            this.logout = new FontAwesome.Sharp.IconButton();
            this.content = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.panelMenu.Controls.Add(this.history);
            this.panelMenu.Controls.Add(this.shop);
            this.panelMenu.Controls.Add(this.product);
            this.panelMenu.Controls.Add(this.category);
            this.panelMenu.Controls.Add(this.dashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 561);
            this.panelMenu.TabIndex = 0;
            // 
            // history
            // 
            this.history.Dock = System.Windows.Forms.DockStyle.Top;
            this.history.FlatAppearance.BorderSize = 0;
            this.history.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.history.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.history.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.history.IconChar = FontAwesome.Sharp.IconChar.FileText;
            this.history.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.history.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.history.IconSize = 30;
            this.history.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.history.Location = new System.Drawing.Point(0, 340);
            this.history.Name = "history";
            this.history.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.history.Size = new System.Drawing.Size(220, 70);
            this.history.TabIndex = 5;
            this.history.Text = "History";
            this.history.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.history.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.history.UseVisualStyleBackColor = true;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // shop
            // 
            this.shop.Dock = System.Windows.Forms.DockStyle.Top;
            this.shop.FlatAppearance.BorderSize = 0;
            this.shop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shop.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.shop.IconChar = FontAwesome.Sharp.IconChar.ShoppingBag;
            this.shop.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.shop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.shop.IconSize = 30;
            this.shop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.shop.Location = new System.Drawing.Point(0, 270);
            this.shop.Name = "shop";
            this.shop.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.shop.Size = new System.Drawing.Size(220, 70);
            this.shop.TabIndex = 4;
            this.shop.Text = "Shop";
            this.shop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.shop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.shop.UseVisualStyleBackColor = true;
            this.shop.Click += new System.EventHandler(this.shop_Click);
            // 
            // product
            // 
            this.product.Dock = System.Windows.Forms.DockStyle.Top;
            this.product.FlatAppearance.BorderSize = 0;
            this.product.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.product.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.product.IconChar = FontAwesome.Sharp.IconChar.Hamburger;
            this.product.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.product.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.product.IconSize = 30;
            this.product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.product.Location = new System.Drawing.Point(0, 200);
            this.product.Name = "product";
            this.product.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.product.Size = new System.Drawing.Size(220, 70);
            this.product.TabIndex = 3;
            this.product.Text = "Product";
            this.product.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.product.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.product.UseVisualStyleBackColor = true;
            this.product.Click += new System.EventHandler(this.product_Click);
            // 
            // category
            // 
            this.category.Dock = System.Windows.Forms.DockStyle.Top;
            this.category.FlatAppearance.BorderSize = 0;
            this.category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.category.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.category.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.category.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.category.IconSize = 30;
            this.category.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.category.Location = new System.Drawing.Point(0, 130);
            this.category.Name = "category";
            this.category.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.category.Size = new System.Drawing.Size(220, 70);
            this.category.TabIndex = 2;
            this.category.Text = "Category";
            this.category.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.category.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.category.UseVisualStyleBackColor = true;
            this.category.Click += new System.EventHandler(this.category_Click);
            // 
            // dashboard
            // 
            this.dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboard.FlatAppearance.BorderSize = 0;
            this.dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.dashboard.IconChar = FontAwesome.Sharp.IconChar.House;
            this.dashboard.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.dashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dashboard.IconSize = 30;
            this.dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard.Location = new System.Drawing.Point(0, 60);
            this.dashboard.Name = "dashboard";
            this.dashboard.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.dashboard.Size = new System.Drawing.Size(220, 70);
            this.dashboard.TabIndex = 1;
            this.dashboard.Text = "Dashboard";
            this.dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboard.UseVisualStyleBackColor = true;
            this.dashboard.Click += new System.EventHandler(this.dashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.White;
            this.panelLogo.Controls.Add(this.mainLabel);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 60);
            this.panelLogo.TabIndex = 0;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.mainLabel.Location = new System.Drawing.Point(42, 8);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(118, 45);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Canteen";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.header.Controls.Add(this.logout);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(220, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(604, 60);
            this.header.TabIndex = 1;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // logout
            // 
            this.logout.Dock = System.Windows.Forms.DockStyle.Right;
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.logout.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromBracket;
            this.logout.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(186)))));
            this.logout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logout.IconSize = 20;
            this.logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.Location = new System.Drawing.Point(524, 0);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(80, 60);
            this.logout.TabIndex = 0;
            this.logout.Text = "Logout";
            this.logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            this.logout.MouseLeave += new System.EventHandler(this.logout_Leave);
            this.logout.MouseHover += new System.EventHandler(this.logout_Hover);
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(220, 60);
            this.content.Name = "content";
            this.content.Padding = new System.Windows.Forms.Padding(10);
            this.content.Size = new System.Drawing.Size(604, 501);
            this.content.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(824, 561);
            this.Controls.Add(this.content);
            this.Controls.Add(this.header);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel header;
        private FontAwesome.Sharp.IconButton dashboard;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton history;
        private FontAwesome.Sharp.IconButton shop;
        private FontAwesome.Sharp.IconButton product;
        private FontAwesome.Sharp.IconButton category;
        private System.Windows.Forms.Label mainLabel;
        private FontAwesome.Sharp.IconButton logout;
        private System.Windows.Forms.Panel content;
    }
}

