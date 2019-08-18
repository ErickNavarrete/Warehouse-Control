namespace Warehouse_Control.Forms
{
    partial class ucReports
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpF1 = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpF2 = new System.Windows.Forms.DateTimePicker();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cbKind = new System.Windows.Forms.ComboBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.btnQuery = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // dtpF1
            // 
            this.dtpF1.CustomFormat = "dd/MMMM/yyyy";
            this.dtpF1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpF1.Location = new System.Drawing.Point(203, 100);
            this.dtpF1.Name = "dtpF1";
            this.dtpF1.Size = new System.Drawing.Size(147, 20);
            this.dtpF1.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(100, 100);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(100, 0, 3, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(97, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Fecha inicial:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(430, 100);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(86, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Fecha final:";
            // 
            // dtpF2
            // 
            this.dtpF2.CustomFormat = "dd/MMMM/yyyy";
            this.dtpF2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpF2.Location = new System.Drawing.Point(533, 98);
            this.dtpF2.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.dtpF2.Name = "dtpF2";
            this.dtpF2.Size = new System.Drawing.Size(147, 20);
            this.dtpF2.TabIndex = 2;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(199, 154);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(100, 0, 3, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(99, 19);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Tipo Reporte:";
            // 
            // cbKind
            // 
            this.cbKind.FormattingEnabled = true;
            this.cbKind.Items.AddRange(new object[] {
            "Entradas",
            "Salidas"});
            this.cbKind.Location = new System.Drawing.Point(304, 154);
            this.cbKind.Name = "cbKind";
            this.cbKind.Size = new System.Drawing.Size(212, 21);
            this.cbKind.TabIndex = 5;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(186, 200);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(100, 0, 3, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(112, 19);
            this.materialLabel4.TabIndex = 6;
            this.materialLabel4.Text = "Autorizado por:";
            // 
            // cbUser
            // 
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(304, 200);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(212, 21);
            this.cbUser.TabIndex = 7;
            // 
            // btnQuery
            // 
            this.btnQuery.Depth = 0;
            this.btnQuery.Location = new System.Drawing.Point(354, 261);
            this.btnQuery.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Primary = true;
            this.btnQuery.Size = new System.Drawing.Size(99, 37);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "Consultar";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // ucReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.cbKind);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dtpF2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dtpF1);
            this.Name = "ucReports";
            this.Size = new System.Drawing.Size(780, 524);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpF1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DateTimePicker dtpF2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.ComboBox cbKind;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.ComboBox cbUser;
        private MaterialSkin.Controls.MaterialRaisedButton btnQuery;
    }
}
