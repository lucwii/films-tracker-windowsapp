namespace LINQtoSQL
{
    partial class LINQMasterDetailsForma
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
            this.lblZanrovi = new System.Windows.Forms.Label();
            this.lblFilmovi = new System.Windows.Forms.Label();
            this.dgvZanrovi = new System.Windows.Forms.DataGridView();
            this.dgvFilmovi = new System.Windows.Forms.DataGridView();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnLINQUpit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZanrovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmovi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblZanrovi
            // 
            this.lblZanrovi.AutoSize = true;
            this.lblZanrovi.Location = new System.Drawing.Point(56, 48);
            this.lblZanrovi.Name = "lblZanrovi";
            this.lblZanrovi.Size = new System.Drawing.Size(55, 16);
            this.lblZanrovi.TabIndex = 0;
            this.lblZanrovi.Text = "Zanrovi:";
            // 
            // lblFilmovi
            // 
            this.lblFilmovi.AutoSize = true;
            this.lblFilmovi.Location = new System.Drawing.Point(56, 310);
            this.lblFilmovi.Name = "lblFilmovi";
            this.lblFilmovi.Size = new System.Drawing.Size(53, 16);
            this.lblFilmovi.TabIndex = 1;
            this.lblFilmovi.Text = "Filmovi:";
            // 
            // dgvZanrovi
            // 
            this.dgvZanrovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZanrovi.Location = new System.Drawing.Point(59, 102);
            this.dgvZanrovi.MultiSelect = false;
            this.dgvZanrovi.Name = "dgvZanrovi";
            this.dgvZanrovi.ReadOnly = true;
            this.dgvZanrovi.RowHeadersWidth = 51;
            this.dgvZanrovi.RowTemplate.Height = 24;
            this.dgvZanrovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZanrovi.Size = new System.Drawing.Size(307, 170);
            this.dgvZanrovi.TabIndex = 2;
            this.dgvZanrovi.SelectionChanged += new System.EventHandler(this.dgvZanrovi_SelectionChanged);
            // 
            // dgvFilmovi
            // 
            this.dgvFilmovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilmovi.Location = new System.Drawing.Point(59, 361);
            this.dgvFilmovi.MultiSelect = false;
            this.dgvFilmovi.Name = "dgvFilmovi";
            this.dgvFilmovi.ReadOnly = true;
            this.dgvFilmovi.RowHeadersWidth = 51;
            this.dgvFilmovi.RowTemplate.Height = 24;
            this.dgvFilmovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilmovi.Size = new System.Drawing.Size(307, 170);
            this.dgvFilmovi.TabIndex = 3;
            // 
            // btnNovi
            // 
            this.btnNovi.Location = new System.Drawing.Point(35, 570);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(134, 51);
            this.btnNovi.TabIndex = 4;
            this.btnNovi.Text = "Novi";
            this.btnNovi.UseVisualStyleBackColor = true;
            this.btnNovi.Click += new System.EventHandler(this.btnNovi_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(211, 570);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(134, 51);
            this.btnIzmeni.TabIndex = 5;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(378, 570);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(134, 51);
            this.btnObrisi.TabIndex = 6;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnLINQUpit
            // 
            this.btnLINQUpit.Location = new System.Drawing.Point(417, 445);
            this.btnLINQUpit.Name = "btnLINQUpit";
            this.btnLINQUpit.Size = new System.Drawing.Size(134, 51);
            this.btnLINQUpit.TabIndex = 7;
            this.btnLINQUpit.Text = "LINQ Upit";
            this.btnLINQUpit.UseVisualStyleBackColor = true;
            this.btnLINQUpit.Click += new System.EventHandler(this.btnLINQUpit_Click);
            // 
            // LINQMasterDetailsForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 665);
            this.Controls.Add(this.btnLINQUpit);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnNovi);
            this.Controls.Add(this.dgvFilmovi);
            this.Controls.Add(this.dgvZanrovi);
            this.Controls.Add(this.lblFilmovi);
            this.Controls.Add(this.lblZanrovi);
            this.Name = "LINQMasterDetailsForma";
            this.Text = "LINQMasterDetailsForma";
            this.Load += new System.EventHandler(this.LINQMasterDetailsForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZanrovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblZanrovi;
        private System.Windows.Forms.Label lblFilmovi;
        private System.Windows.Forms.DataGridView dgvZanrovi;
        private System.Windows.Forms.DataGridView dgvFilmovi;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnLINQUpit;
    }
}