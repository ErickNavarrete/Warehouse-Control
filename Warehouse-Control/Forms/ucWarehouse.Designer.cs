namespace Warehouse_Control.Forms
{
    partial class ucWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWarehouse));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbIdDistrict = new MaterialSkin.Controls.MaterialLabel();
            this.lbAddress = new MaterialSkin.Controls.MaterialLabel();
            this.lbName = new MaterialSkin.Controls.MaterialLabel();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_district = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.btnSearch,
            this.btnNew,
            this.btnSave,
            this.btnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(375, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 22);
            this.btnSearch.Text = "Buscar";
            // 
            // btnNew
            // 
            this.btnNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 22);
            this.btnNew.Text = "Nuevo almacen";
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 22);
            this.btnSave.Text = "Guardar";
            this.btnSave.ToolTipText = "toolStripButton3";
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 22);
            this.btnCancel.Text = "Cancelar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.address,
            this.id_district});
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(383, 461);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDistrict);
            this.groupBox1.Controls.Add(this.tbAddress);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.lbIdDistrict);
            this.groupBox1.Controls.Add(this.lbAddress);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Location = new System.Drawing.Point(403, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 248);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de almacen";
            // 
            // cbDistrict
            // 
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(24, 204);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(293, 21);
            this.cbDistrict.TabIndex = 5;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(24, 126);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(293, 20);
            this.tbAddress.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(24, 53);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(293, 20);
            this.tbName.TabIndex = 3;
            // 
            // lbIdDistrict
            // 
            this.lbIdDistrict.AutoSize = true;
            this.lbIdDistrict.Depth = 0;
            this.lbIdDistrict.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbIdDistrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbIdDistrict.Location = new System.Drawing.Point(20, 176);
            this.lbIdDistrict.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbIdDistrict.Name = "lbIdDistrict";
            this.lbIdDistrict.Size = new System.Drawing.Size(59, 19);
            this.lbIdDistrict.TabIndex = 2;
            this.lbIdDistrict.Text = "Distrito";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Depth = 0;
            this.lbAddress.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbAddress.Location = new System.Drawing.Point(20, 104);
            this.lbAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(73, 19);
            this.lbAddress.TabIndex = 1;
            this.lbAddress.Text = "Dirección";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Depth = 0;
            this.lbName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbName.Location = new System.Drawing.Point(20, 31);
            this.lbName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(63, 19);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Nombre";
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            // 
            // address
            // 
            this.address.HeaderText = "Dirección";
            this.address.Name = "address";
            // 
            // id_district
            // 
            this.id_district.HeaderText = "Distrito";
            this.id_district.Name = "id_district";
            // 
            // ucWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ucWarehouse";
            this.Size = new System.Drawing.Size(780, 524);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbName;
        private MaterialSkin.Controls.MaterialLabel lbIdDistrict;
        private MaterialSkin.Controls.MaterialLabel lbAddress;
        private MaterialSkin.Controls.MaterialLabel lbName;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_district;
    }
}
