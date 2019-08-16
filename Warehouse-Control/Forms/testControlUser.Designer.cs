namespace Warehouse_Control.Forms
{
    partial class testControlUser
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
            this.users1 = new Warehouse_Control.Forms.users();
            this.SuspendLayout();
            // 
            // users1
            // 
            this.users1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.users1.Location = new System.Drawing.Point(8, 12);
            this.users1.Name = "users1";
            this.users1.Size = new System.Drawing.Size(780, 524);
            this.users1.TabIndex = 0;
            // 
            // testControlUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 571);
            this.Controls.Add(this.users1);
            this.Name = "testControlUser";
            this.Text = "testControlUser";
            this.ResumeLayout(false);

        }

        #endregion

        private users users1;
    }
}