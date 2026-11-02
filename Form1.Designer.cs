namespace Progetto_tesi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Puls_esc = new System.Windows.Forms.Button();
            this.Puls_Coll_Modbus_RTU = new System.Windows.Forms.Button();
            this.Puls_Auto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PulsNumCas = new System.Windows.Forms.Button();
            this.PulsDemo = new System.Windows.Forms.Button();
            this.PulsSalvVal = new System.Windows.Forms.Button();
            this.PulsInfluxdb = new System.Windows.Forms.Button();
            this.PulsCanval = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelHeader.Controls.Add(this.Puls_esc);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 64);
            this.panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Energy Monitoring Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.groupBox1.Location = new System.Drawing.Point(20, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 400);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modalità 1 — Impianto reale (Modbus RTU)";
            this.groupBox1.Controls.Add(this.Puls_Coll_Modbus_RTU);
            this.groupBox1.Controls.Add(this.Puls_Auto);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.groupBox2.Location = new System.Drawing.Point(510, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 400);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modalità 2 — Dati simulati";
            this.groupBox2.Controls.Add(this.PulsNumCas);
            this.groupBox2.Controls.Add(this.PulsDemo);
            this.groupBox2.Controls.Add(this.PulsSalvVal);
            this.groupBox2.Controls.Add(this.PulsInfluxdb);
            this.groupBox2.Controls.Add(this.PulsCanval);
            this.groupBox2.Controls.Add(this.textBox);
            // 
            // Puls_esc
            // 
            this.Puls_esc.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.Puls_esc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Puls_esc.FlatAppearance.BorderSize = 0;
            this.Puls_esc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Puls_esc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Puls_esc.ForeColor = System.Drawing.Color.White;
            this.Puls_esc.Location = new System.Drawing.Point(880, 16);
            this.Puls_esc.Name = "Puls_esc";
            this.Puls_esc.Size = new System.Drawing.Size(90, 32);
            this.Puls_esc.TabIndex = 3;
            this.Puls_esc.Text = "Esci";
            this.Puls_esc.UseVisualStyleBackColor = false;
            this.Puls_esc.Click += new System.EventHandler(this.Puls_esc_Click);
            // 
            // Puls_Coll_Modbus_RTU
            // 
            this.Puls_Coll_Modbus_RTU.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.Puls_Coll_Modbus_RTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Puls_Coll_Modbus_RTU.FlatAppearance.BorderSize = 0;
            this.Puls_Coll_Modbus_RTU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Puls_Coll_Modbus_RTU.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Puls_Coll_Modbus_RTU.ForeColor = System.Drawing.Color.White;
            this.Puls_Coll_Modbus_RTU.Location = new System.Drawing.Point(20, 30);
            this.Puls_Coll_Modbus_RTU.Name = "Puls_Coll_Modbus_RTU";
            this.Puls_Coll_Modbus_RTU.Size = new System.Drawing.Size(430, 38);
            this.Puls_Coll_Modbus_RTU.TabIndex = 4;
            this.Puls_Coll_Modbus_RTU.Text = "Collegamento Modbus RTU";
            this.Puls_Coll_Modbus_RTU.UseVisualStyleBackColor = false;
            this.Puls_Coll_Modbus_RTU.Click += new System.EventHandler(this.Puls_Coll_Modbus_RTU_Click);
            // 
            // Puls_Auto
            // 
            this.Puls_Auto.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.Puls_Auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Puls_Auto.FlatAppearance.BorderSize = 0;
            this.Puls_Auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Puls_Auto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Puls_Auto.ForeColor = System.Drawing.Color.White;
            this.Puls_Auto.Location = new System.Drawing.Point(20, 78);
            this.Puls_Auto.Name = "Puls_Auto";
            this.Puls_Auto.Size = new System.Drawing.Size(210, 38);
            this.Puls_Auto.TabIndex = 5;
            this.Puls_Auto.Text = "Avvia acquisizione automatica";
            this.Puls_Auto.UseVisualStyleBackColor = false;
            this.Puls_Auto.Click += new System.EventHandler(this.Puls_Auto_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(240, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ferma acquisizione";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PulsDemo
            // 
            this.PulsDemo.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.PulsDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PulsDemo.FlatAppearance.BorderSize = 0;
            this.PulsDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PulsDemo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsDemo.ForeColor = System.Drawing.Color.White;
            this.PulsDemo.Location = new System.Drawing.Point(240, 30);
            this.PulsDemo.Name = "PulsDemo";
            this.PulsDemo.Size = new System.Drawing.Size(210, 38);
            this.PulsDemo.TabIndex = 20;
            this.PulsDemo.Text = "Genera 50 punti di prova";
            this.PulsDemo.UseVisualStyleBackColor = false;
            this.PulsDemo.Click += new System.EventHandler(this.PulsDemo_Click);
            // 
            // PulsNumCas
            // 
            this.PulsNumCas.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.PulsNumCas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PulsNumCas.FlatAppearance.BorderSize = 0;
            this.PulsNumCas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PulsNumCas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsNumCas.ForeColor = System.Drawing.Color.White;
            this.PulsNumCas.Location = new System.Drawing.Point(20, 30);
            this.PulsNumCas.Name = "PulsNumCas";
            this.PulsNumCas.Size = new System.Drawing.Size(210, 38);
            this.PulsNumCas.TabIndex = 7;
            this.PulsNumCas.Text = "Genera valori casuali";
            this.PulsNumCas.UseVisualStyleBackColor = false;
            this.PulsNumCas.Click += new System.EventHandler(this.PulsNumCas_Click);
            // 
            // PulsSalvVal
            // 
            this.PulsSalvVal.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.PulsSalvVal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PulsSalvVal.FlatAppearance.BorderSize = 0;
            this.PulsSalvVal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PulsSalvVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsSalvVal.ForeColor = System.Drawing.Color.White;
            this.PulsSalvVal.Location = new System.Drawing.Point(20, 342);
            this.PulsSalvVal.Name = "PulsSalvVal";
            this.PulsSalvVal.Size = new System.Drawing.Size(138, 38);
            this.PulsSalvVal.TabIndex = 8;
            this.PulsSalvVal.Text = "Salva su CSV";
            this.PulsSalvVal.UseVisualStyleBackColor = false;
            this.PulsSalvVal.Click += new System.EventHandler(this.PulsSalvVal_Click);
            // 
            // PulsInfluxdb
            // 
            this.PulsInfluxdb.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.PulsInfluxdb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PulsInfluxdb.FlatAppearance.BorderSize = 0;
            this.PulsInfluxdb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PulsInfluxdb.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsInfluxdb.ForeColor = System.Drawing.Color.White;
            this.PulsInfluxdb.Location = new System.Drawing.Point(166, 342);
            this.PulsInfluxdb.Name = "PulsInfluxdb";
            this.PulsInfluxdb.Size = new System.Drawing.Size(138, 38);
            this.PulsInfluxdb.TabIndex = 9;
            this.PulsInfluxdb.Text = "Carica su InfluxDB";
            this.PulsInfluxdb.UseVisualStyleBackColor = false;
            this.PulsInfluxdb.Click += new System.EventHandler(this.PulsInfluxdb_Click);
            // 
            // PulsCanval
            // 
            this.PulsCanval.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.PulsCanval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PulsCanval.FlatAppearance.BorderSize = 0;
            this.PulsCanval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PulsCanval.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsCanval.ForeColor = System.Drawing.Color.White;
            this.PulsCanval.Location = new System.Drawing.Point(312, 342);
            this.PulsCanval.Name = "PulsCanval";
            this.PulsCanval.Size = new System.Drawing.Size(138, 38);
            this.PulsCanval.TabIndex = 10;
            this.PulsCanval.Text = "Cancella CSV";
            this.PulsCanval.UseVisualStyleBackColor = false;
            this.PulsCanval.Click += new System.EventHandler(this.PulsCanval_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(20, 128);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(430, 250);
            this.textBox1.TabIndex = 11;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(20, 80);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(430, 250);
            this.textBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1000, 510);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progetto tesi — Energy Monitoring Dashboard";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Puls_esc;
        private System.Windows.Forms.Button Puls_Coll_Modbus_RTU;
        private System.Windows.Forms.Button Puls_Auto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button PulsNumCas;
        private System.Windows.Forms.Button PulsDemo;
        private System.Windows.Forms.Button PulsSalvVal;
        private System.Windows.Forms.Button PulsInfluxdb;
        private System.Windows.Forms.Button PulsCanval;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox;
    }
}
