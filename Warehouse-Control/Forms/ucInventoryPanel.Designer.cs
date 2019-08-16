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
            this.btnItems = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // btnItems
            // 
            this.btnItems.AutoSize = true;
            this.btnItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnItems.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnItems.BackgroundImage")));
            this.btnItems.Depth = 0;
            this.btnItems.Image = ((System.Drawing.Image)(resources.GetObject("btnItems.Image")));
            this.btnItems.Location = new System.Drawing.Point(92, 81);
            this.btnItems.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnItems.Name = "btnItems";
            this.btnItems.Primary = false;
            this.btnItems.Size = new System.Drawing.Size(85, 36);
            this.btnItems.TabIndex = 0;
            this.btnItems.Text = "Artículos";
            this.btnItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItems.UseVisualStyleBackColor = true;
            // 
            // ucInventoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnItems);
            this.Name = "ucInventoryPanel";
            this.Size = new System.Drawing.Size(277, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton btnItems;
    }
}
