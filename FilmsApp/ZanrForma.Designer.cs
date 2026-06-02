namespace FilmsApp
{
    partial class ZanrForma
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
            this.dgvZanrovi = new System.Windows.Forms.DataGridView();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNovi = new System.Windows.Forms.Button();
            this.btnFilmovi = new System.Windows.Forms.Button();
            this.btnLINQ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZanrovi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvZanrovi
            // 
            this.dgvZanrovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZanrovi.Location = new System.Drawing.Point(55, 159);
            this.dgvZanrovi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvZanrovi.MultiSelect = false;
            this.dgvZanrovi.Name = "dgvZanrovi";
            this.dgvZanrovi.ReadOnly = true;
            this.dgvZanrovi.RowHeadersWidth = 51;
            this.dgvZanrovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZanrovi.Size = new System.Drawing.Size(340, 229);
            this.dgvZanrovi.TabIndex = 0;
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(181, 417);
            this.btnIzmeni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(100, 38);
            this.btnIzmeni.TabIndex = 2;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(315, 417);
            this.btnObrisi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(100, 38);
            this.btnObrisi.TabIndex = 3;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista svih zanrova filmova:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dobrodosli u aplikaciju!";
            // 
            // btnNovi
            // 
            this.btnNovi.Location = new System.Drawing.Point(43, 417);
            this.btnNovi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(100, 38);
            this.btnNovi.TabIndex = 1;
            this.btnNovi.Text = "Novi";
            this.btnNovi.UseVisualStyleBackColor = true;
            this.btnNovi.Click += new System.EventHandler(this.btnNovi_Click);
            // 
            // btnFilmovi
            // 
            this.btnFilmovi.Location = new System.Drawing.Point(315, 105);
            this.btnFilmovi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFilmovi.Name = "btnFilmovi";
            this.btnFilmovi.Size = new System.Drawing.Size(100, 30);
            this.btnFilmovi.TabIndex = 6;
            this.btnFilmovi.Text = "Filmovi";
            this.btnFilmovi.UseVisualStyleBackColor = true;
            this.btnFilmovi.Click += new System.EventHandler(this.btnFilmovi_Click);
            // 
            // btnLINQ
            // 
            this.btnLINQ.Location = new System.Drawing.Point(181, 498);
            this.btnLINQ.Margin = new System.Windows.Forms.Padding(4);
            this.btnLINQ.Name = "btnLINQ";
            this.btnLINQ.Size = new System.Drawing.Size(100, 38);
            this.btnLINQ.TabIndex = 7;
            this.btnLINQ.Text = "LINQ Prikaz";
            this.btnLINQ.UseVisualStyleBackColor = true;
            this.btnLINQ.Click += new System.EventHandler(this.btnLINQ_Click);
            // 
            // ZanrForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 559);
            this.Controls.Add(this.btnLINQ);
            this.Controls.Add(this.btnFilmovi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnNovi);
            this.Controls.Add(this.dgvZanrovi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ZanrForma";
            this.Text = "ZanrForma";
            this.Load += new System.EventHandler(this.ZanrForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZanrovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvZanrovi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNovi;
        private System.Windows.Forms.Button btnFilmovi;
        private System.Windows.Forms.Button btnLINQ;
    }
}