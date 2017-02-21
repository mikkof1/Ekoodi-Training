namespace barcode_creator
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbAccountNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbReferenceNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbMoneySummarium = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.btnMakeVirtualBarcode = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txbVirtualBarcode = new System.Windows.Forms.TextBox();
            this.picBarcodeDraw = new System.Windows.Forms.PictureBox();
            this.cbxInternational = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcodeDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tilinumero";
            // 
            // txbAccountNumber
            // 
            this.txbAccountNumber.Location = new System.Drawing.Point(43, 53);
            this.txbAccountNumber.Name = "txbAccountNumber";
            this.txbAccountNumber.Size = new System.Drawing.Size(316, 20);
            this.txbAccountNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Viitenumero";
            // 
            // txbReferenceNumber
            // 
            this.txbReferenceNumber.Location = new System.Drawing.Point(43, 110);
            this.txbReferenceNumber.Name = "txbReferenceNumber";
            this.txbReferenceNumber.Size = new System.Drawing.Size(316, 20);
            this.txbReferenceNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Laskun summa";
            // 
            // txbMoneySummarium
            // 
            this.txbMoneySummarium.Location = new System.Drawing.Point(43, 171);
            this.txbMoneySummarium.Name = "txbMoneySummarium";
            this.txbMoneySummarium.Size = new System.Drawing.Size(100, 20);
            this.txbMoneySummarium.TabIndex = 5;
            this.txbMoneySummarium.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbMoneySummarium_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Eräpäivä";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Location = new System.Drawing.Point(43, 226);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(150, 20);
            this.dtpPaymentDate.TabIndex = 7;
            // 
            // btnMakeVirtualBarcode
            // 
            this.btnMakeVirtualBarcode.Location = new System.Drawing.Point(43, 311);
            this.btnMakeVirtualBarcode.Name = "btnMakeVirtualBarcode";
            this.btnMakeVirtualBarcode.Size = new System.Drawing.Size(100, 41);
            this.btnMakeVirtualBarcode.TabIndex = 8;
            this.btnMakeVirtualBarcode.Text = "Tee viivakoodi";
            this.btnMakeVirtualBarcode.UseVisualStyleBackColor = true;
            this.btnMakeVirtualBarcode.Click += new System.EventHandler(this.btnMakeVirtualBarcode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Virtuaali viivakoodi";
            // 
            // txbVirtualBarcode
            // 
            this.txbVirtualBarcode.Location = new System.Drawing.Point(43, 389);
            this.txbVirtualBarcode.Name = "txbVirtualBarcode";
            this.txbVirtualBarcode.Size = new System.Drawing.Size(381, 20);
            this.txbVirtualBarcode.TabIndex = 10;
            // 
            // picBarcodeDraw
            // 
            this.picBarcodeDraw.BackColor = System.Drawing.SystemColors.Control;
            this.picBarcodeDraw.Location = new System.Drawing.Point(43, 415);
            this.picBarcodeDraw.Name = "picBarcodeDraw";
            this.picBarcodeDraw.Size = new System.Drawing.Size(507, 135);
            this.picBarcodeDraw.TabIndex = 11;
            this.picBarcodeDraw.TabStop = false;
            // 
            // cbxInternational
            // 
            this.cbxInternational.AutoSize = true;
            this.cbxInternational.Location = new System.Drawing.Point(43, 265);
            this.cbxInternational.Name = "cbxInternational";
            this.cbxInternational.Size = new System.Drawing.Size(126, 17);
            this.cbxInternational.TabIndex = 12;
            this.cbxInternational.Text = "Kansainvälinen lasku";
            this.cbxInternational.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 566);
            this.Controls.Add(this.cbxInternational);
            this.Controls.Add(this.picBarcodeDraw);
            this.Controls.Add(this.txbVirtualBarcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMakeVirtualBarcode);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbMoneySummarium);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbReferenceNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbAccountNumber);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Barcode";
            ((System.ComponentModel.ISupportInitialize)(this.picBarcodeDraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAccountNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbReferenceNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbMoneySummarium;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Button btnMakeVirtualBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbVirtualBarcode;
        private System.Windows.Forms.PictureBox picBarcodeDraw;
        private System.Windows.Forms.CheckBox cbxInternational;
    }
}

