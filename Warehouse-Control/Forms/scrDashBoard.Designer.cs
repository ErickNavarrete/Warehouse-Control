 namespace Warehouse_Control.Forms
{
    partial class scrDashBoard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNUsuario = new MaterialSkin.Controls.MaterialLabel();
            this.MaterialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnDistrict = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.ucDistrict1 = new Warehouse_Control.Forms.ucDistrict();
            this.ucItems1 = new Warehouse_Control.Forms.ucItems();
            this.ucInventory1 = new Warehouse_Control.Forms.ucInventory();
            this.users1 = new Warehouse_Control.Forms.users();
            this.ucPrincipal1 = new Warehouse_Control.Forms.ucPrincipal();
            this.ucInventoryPanel1 = new Warehouse_Control.Forms.ucInventoryPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.lblNUsuario);
            this.panel1.Controls.Add(this.MaterialLabel1);
            this.panel1.Location = new System.Drawing.Point(-3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 38);
            this.panel1.TabIndex = 0;
            // 
            // lblNUsuario
            // 
            this.lblNUsuario.AutoSize = true;
            this.lblNUsuario.Depth = 0;
            this.lblNUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblNUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNUsuario.Location = new System.Drawing.Point(108, 9);
            this.lblNUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNUsuario.Name = "lblNUsuario";
            this.lblNUsuario.Size = new System.Drawing.Size(24, 18);
            this.lblNUsuario.TabIndex = 4;
            this.lblNUsuario.Text = "¿?";
            // 
            // MaterialLabel1
            // 
            this.MaterialLabel1.AutoSize = true;
            this.MaterialLabel1.Depth = 0;
            this.MaterialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MaterialLabel1.Location = new System.Drawing.Point(8, 9);
            this.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaterialLabel1.Name = "MaterialLabel1";
            this.MaterialLabel1.Size = new System.Drawing.Size(106, 18);
            this.MaterialLabel1.TabIndex = 3;
            this.MaterialLabel1.Text = "BIENVENIDO: ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.ucInventoryPanel1);
            this.panel2.Controls.Add(this.btnChangeUser);
            this.panel2.Controls.Add(this.btnReports);
            this.panel2.Controls.Add(this.btnDistrict);
            this.panel2.Controls.Add(this.btnInventory);
            this.panel2.Controls.Add(this.btnUser);
            this.panel2.Location = new System.Drawing.Point(0, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 526);
            this.panel2.TabIndex = 2;
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeUser.Location = new System.Drawing.Point(5, 494);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(264, 23);
            this.btnChangeUser.TabIndex = 5;
            this.btnChangeUser.Text = "CAMBIAR USUARIO";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(5, 93);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(264, 23);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "REPORTES";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnDistrict
            // 
            this.btnDistrict.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistrict.Location = new System.Drawing.Point(5, 64);
            this.btnDistrict.Name = "btnDistrict";
            this.btnDistrict.Size = new System.Drawing.Size(264, 23);
            this.btnDistrict.TabIndex = 3;
            this.btnDistrict.Text = "DISTRITOS";
            this.btnDistrict.UseVisualStyleBackColor = true;
            this.btnDistrict.Click += new System.EventHandler(this.btnDistrict_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(5, 35);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(264, 23);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.Text = "INVENTARIO";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnUser
            // 
            this.btnUser.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Location = new System.Drawing.Point(5, 6);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(264, 23);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = "USUARIOS";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // ucDistrict1
            // 
            this.ucDistrict1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDistrict1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucDistrict1.Location = new System.Drawing.Point(283, 102);
            this.ucDistrict1.Name = "ucDistrict1";
            this.ucDistrict1.Size = new System.Drawing.Size(780, 524);
            this.ucDistrict1.TabIndex = 6;
            this.ucDistrict1.Visible = false;
            // 
            // ucItems1
            // 
            this.ucItems1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucItems1.Location = new System.Drawing.Point(283, 102);
            this.ucItems1.Name = "ucItems1";
            this.ucItems1.Size = new System.Drawing.Size(780, 524);
            this.ucItems1.TabIndex = 5;
            this.ucItems1.Visible = false;
            // 
            // ucInventory1
            // 
            this.ucInventory1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucInventory1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucInventory1.Location = new System.Drawing.Point(283, 102);
            this.ucInventory1.Name = "ucInventory1";
            this.ucInventory1.Size = new System.Drawing.Size(780, 524);
            this.ucInventory1.TabIndex = 4;
            this.ucInventory1.Visible = false;
            // 
            // users1
            // 
            this.users1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.users1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.users1.Location = new System.Drawing.Point(283, 102);
            this.users1.Name = "users1";
            this.users1.Size = new System.Drawing.Size(780, 524);
            this.users1.TabIndex = 3;
            this.users1.Visible = false;
            // 
            // ucPrincipal1
            // 
            this.ucPrincipal1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPrincipal1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ucPrincipal1.Location = new System.Drawing.Point(283, 102);
            this.ucPrincipal1.Name = "ucPrincipal1";
            this.ucPrincipal1.Size = new System.Drawing.Size(780, 524);
            this.ucPrincipal1.TabIndex = 0;
            // 
            // ucInventoryPanel1
            // 
            this.ucInventoryPanel1.Location = new System.Drawing.Point(12, 64);
            this.ucInventoryPanel1.Name = "ucInventoryPanel1";
            this.ucInventoryPanel1.Size = new System.Drawing.Size(250, 244);
            this.ucInventoryPanel1.TabIndex = 5;
            this.ucInventoryPanel1.Visible = false;
            // 
            // scrDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 631);
            this.Controls.Add(this.ucDistrict1);
            this.Controls.Add(this.ucItems1);
            this.Controls.Add(this.ucInventory1);
            this.Controls.Add(this.users1);
            this.Controls.Add(this.ucPrincipal1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "scrDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Inventario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal MaterialSkin.Controls.MaterialLabel lblNUsuario;
        internal MaterialSkin.Controls.MaterialLabel MaterialLabel1;
        internal System.Windows.Forms.Button btnUser;
        internal System.Windows.Forms.Button btnChangeUser;
        internal System.Windows.Forms.Button btnReports;
        internal System.Windows.Forms.Button btnDistrict;
        internal System.Windows.Forms.Button btnInventory;
        private ucPrincipal ucPrincipal1;
        private users users1;
        private ucInventory ucInventory1;
        private ucInventoryPanel ucInventoryPanel1;
        private ucItems ucItems1;
        private ucDistrict ucDistrict1;
    }
}