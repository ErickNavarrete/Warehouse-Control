namespace Warehouse_Control.Forms
{
    partial class ucInventoryPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucInventoryPanel));
            this.button1 = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnEntry = new System.Windows.Forms.Button();
            this.btnDepartures = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "ARTÍCULOS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Image = ((System.Drawing.Image)(resources.GetObject("btnWarehouse.Image")));
            this.btnWarehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWarehouse.Location = new System.Drawing.Point(7, 53);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(230, 40);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.Text = "ALMACÉN";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.Image")));
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(7, 100);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(230, 40);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "INVENTARIO";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnEntry
            // 
            this.btnEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnEntry.Image")));
            this.btnEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntry.Location = new System.Drawing.Point(7, 147);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(230, 40);
            this.btnEntry.TabIndex = 4;
            this.btnEntry.Text = "ENTRADAS";
            this.btnEntry.UseVisualStyleBackColor = true;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // btnDepartures
            // 
            this.btnDepartures.Image = ((System.Drawing.Image)(resources.GetObject("btnDepartures.Image")));
            this.btnDepartures.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartures.Location = new System.Drawing.Point(7, 194);
            this.btnDepartures.Name = "btnDepartures";
            this.btnDepartures.Size = new System.Drawing.Size(230, 40);
            this.btnDepartures.TabIndex = 5;
            this.btnDepartures.Text = "SALIDAS";
            this.btnDepartures.UseVisualStyleBackColor = true;
            this.btnDepartures.Click += new System.EventHandler(this.btnDepartures_Click);
            // 
            // ucInventoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDepartures);
            this.Controls.Add(this.btnEntry);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnWarehouse);
            this.Controls.Add(this.button1);
            this.Name = "ucInventoryPanel";
            this.Size = new System.Drawing.Size(250, 244);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnEntry;
        private System.Windows.Forms.Button btnDepartures;
    }
}
