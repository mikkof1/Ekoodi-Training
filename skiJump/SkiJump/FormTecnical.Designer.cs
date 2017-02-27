namespace SkiJump
{
    partial class FormTecnical
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
            this.label2 = new System.Windows.Forms.Label();
            this.txbDifficulity = new System.Windows.Forms.TextBox();
            this.txbKPoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbStageHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vaikeuskerroin ";
            // 
            // txbDifficulity
            // 
            this.txbDifficulity.Location = new System.Drawing.Point(62, 124);
            this.txbDifficulity.Name = "txbDifficulity";
            this.txbDifficulity.Size = new System.Drawing.Size(100, 20);
            this.txbDifficulity.TabIndex = 3;
            this.txbDifficulity.Text = "1,8";
            this.txbDifficulity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbMultiplier_KeyPress);
            // 
            // txbKPoint
            // 
            this.txbKPoint.Location = new System.Drawing.Point(65, 72);
            this.txbKPoint.Name = "txbKPoint";
            this.txbKPoint.Size = new System.Drawing.Size(100, 20);
            this.txbKPoint.TabIndex = 1;
            this.txbKPoint.Text = "100";
            this.txbKPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbKPoint_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "K-piste (m)";
            // 
            // txbStageHeight
            // 
            this.txbStageHeight.Location = new System.Drawing.Point(242, 72);
            this.txbStageHeight.Name = "txbStageHeight";
            this.txbStageHeight.Size = new System.Drawing.Size(100, 20);
            this.txbStageHeight.TabIndex = 2;
            this.txbStageHeight.Text = "0";
            this.txbStageHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbStage_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lähtölava";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(232, 134);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 46);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Tallenna ja poistu";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormTecnical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 220);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbStageHeight);
            this.Controls.Add(this.txbDifficulity);
            this.Controls.Add(this.txbKPoint);
            this.Controls.Add(this.label1);
            this.Name = "FormTecnical";
            this.Text = "Kisan tiedot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDifficulity;
        private System.Windows.Forms.TextBox txbKPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbStageHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}