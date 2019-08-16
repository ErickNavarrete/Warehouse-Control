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
            this.users1 = new Warehouse_Control.Forms.users();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNUsuario = new MaterialSkin.Controls.MaterialLabel();
            this.MaterialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnDistrict = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.lblNUsuario);
            this.panel1.Controls.Add(this.MaterialLabel1);
            this.panel1.Location = new System.Drawing.Point(-3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 38);
            this.panel1.TabIndex = 0;
            // 
            // users1
            // 
            this.users1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.users1.Location = new System.Drawing.Point(283, 104);
            this.users1.Name = "users1";
            this.users1.Size = new System.Drawing.Size(780, 524);
            this.users1.TabIndex = 1;
            // 
            // panel2
            // 
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
            // lblNUsuario
            // 
            this.lblNUsuario.AutoSize = true;
            this.lblNUsuario.Depth = 0;
            this.lblNUsuario.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNUsuario.Location = new System.Drawing.Point(108, 9);
            this.lblNUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNUsuario.Name = "lblNUsuario";
            this.lblNUsuario.Size = new System.Drawing.Size(23, 19);
            this.lblNUsuario.TabIndex = 4;
            this.lblNUsuario.Text = "¿?";
            // 
            // MaterialLabel1
            // 
            this.MaterialLabel1.AutoSize = true;
            this.MaterialLabel1.Depth = 0;
            this.MaterialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MaterialLabel1.Location = new System.Drawing.Point(8, 9);
            this.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaterialLabel1.Name = "MaterialLabel1";
            this.MaterialLabel1.Size = new System.Drawing.Size(104, 19);
            this.MaterialLabel1.TabIndex = 3;
            this.MaterialLabel1.Text = "BIENVENIDO: ";
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
            // scrDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 631);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.users1);
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
        private users users1;
        private System.Windows.Forms.Panel panel2;
        internal MaterialSkin.Controls.MaterialLabel lblNUsuario;
        internal MaterialSkin.Controls.MaterialLabel MaterialLabel1;
        internal System.Windows.Forms.Button btnUser;
        internal System.Windows.Forms.Button btnChangeUser;
        internal System.Windows.Forms.Button btnReports;
        internal System.Windows.Forms.Button btnDistrict;
        internal System.Windows.Forms.Button btnInventory;
    }
}