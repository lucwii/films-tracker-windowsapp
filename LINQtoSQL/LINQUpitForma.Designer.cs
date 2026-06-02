namespace LINQtoSQL
{
    partial class LINQUpitForma
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
            this.lblNaslov = new System.Windows.Forms.Label();
            this.dgvUpit = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Location = new System.Drawing.Point(321, 62);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(140, 16);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "Zanrovi i njihovi filmovi";
            // 
            // dgvUpit
            // 
            this.dgvUpit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpit.Location = new System.Drawing.Point(129, 109);
            this.dgvUpit.Name = "dgvUpit";
            this.dgvUpit.RowHeadersWidth = 51;
            this.dgvUpit.RowTemplate.Height = 24;
            this.dgvUpit.Size = new System.Drawing.Size(526, 272);
            this.dgvUpit.TabIndex = 1;
            // 
            // LINQUpitForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvUpit);
            this.Controls.Add(this.lblNaslov);
            this.Name = "LINQUpitForma";
            this.Text = "LINQUpitForma";
            this.Load += new System.EventHandler(this.LINQUpitForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.DataGridView dgvUpit;
    }
}