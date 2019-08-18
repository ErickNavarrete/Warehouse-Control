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
            this.button2 = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(7, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "ALMACÉN";
            this.button2.UseVisualStyleBackColor = true;
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
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(7, 147);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(230, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "ENTRDAS";
            this.button4.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ucInventoryPanel";
            this.Size = new System.Drawing.Size(250, 244);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDepartures;
    }
}
