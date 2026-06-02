namespace LINQtoSQL
{
    partial class LINQFilmDetaljiForma
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(75, 61);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 16);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(75, 109);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(44, 16);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Naziv:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(75, 154);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(49, 16);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(75, 204);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(159, 61);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(196, 22);
            this.txtId.TabIndex = 4;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(159, 109);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(196, 22);
            this.txtNaziv.TabIndex = 5;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(159, 154);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(196, 22);
            this.dtpDatum.TabIndex = 6;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(159, 204);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(196, 24);
            this.cmbStatus.TabIndex = 7;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(148, 264);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(94, 38);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // LINQFilmDetaljiForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 330);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.lblId);
            this.Name = "LINQFilmDetaljiForma";
            this.Text = "LINQFilmDetaljiForma";
            this.Load += new System.EventHandler(this.LINQFilmDetaljiForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSacuvaj;
    }
}