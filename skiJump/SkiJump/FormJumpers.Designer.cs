namespace SkiJump
{
    partial class FormJumpers
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
            this.lbxJumpers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddJumper = new System.Windows.Forms.Button();
            this.btnRemoveJumper = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCup = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTecnical = new System.Windows.Forms.Button();
            this.btnModifyJumper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxJumpers
            // 
            this.lbxJumpers.Location = new System.Drawing.Point(34, 157);
            this.lbxJumpers.Name = "lbxJumpers";
            this.lbxJumpers.Size = new System.Drawing.Size(146, 290);
            this.lbxJumpers.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hyppyjärjestys";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(233, 218);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(190, 20);
            this.txbName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nimi:";
            // 
            // btnAddJumper
            // 
            this.btnAddJumper.Location = new System.Drawing.Point(233, 255);
            this.btnAddJumper.Name = "btnAddJumper";
            this.btnAddJumper.Size = new System.Drawing.Size(75, 23);
            this.btnAddJumper.TabIndex = 3;
            this.btnAddJumper.Text = "Lisää";
            this.btnAddJumper.UseVisualStyleBackColor = true;
            this.btnAddJumper.Click += new System.EventHandler(this.btnAddJumper_Click);
            // 
            // btnRemoveJumper
            // 
            this.btnRemoveJumper.Location = new System.Drawing.Point(233, 353);
            this.btnRemoveJumper.Name = "btnRemoveJumper";
            this.btnRemoveJumper.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveJumper.TabIndex = 5;
            this.btnRemoveJumper.Text = "Poista";
            this.btnRemoveJumper.UseVisualStyleBackColor = true;
            this.btnRemoveJumper.Click += new System.EventHandler(this.btnRemoveJumper_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kisa:";
            // 
            // txbCup
            // 
            this.txbCup.Location = new System.Drawing.Point(40, 41);
            this.txbCup.Name = "txbCup";
            this.txbCup.Size = new System.Drawing.Size(293, 20);
            this.txbCup.TabIndex = 1;
            this.txbCup.Text = "World Cup";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 451);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Paluu";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTecnical
            // 
            this.btnTecnical.Location = new System.Drawing.Point(339, 39);
            this.btnTecnical.Name = "btnTecnical";
            this.btnTecnical.Size = new System.Drawing.Size(84, 23);
            this.btnTecnical.TabIndex = 8;
            this.btnTecnical.Text = "Tornin tiedot";
            this.btnTecnical.UseVisualStyleBackColor = true;
            this.btnTecnical.Click += new System.EventHandler(this.btnTecnical_Click);
            // 
            // btnModifyJumper
            // 
            this.btnModifyJumper.Location = new System.Drawing.Point(233, 294);
            this.btnModifyJumper.Name = "btnModifyJumper";
            this.btnModifyJumper.Size = new System.Drawing.Size(75, 23);
            this.btnModifyJumper.TabIndex = 4;
            this.btnModifyJumper.Text = "Muuta";
            this.btnModifyJumper.UseVisualStyleBackColor = true;
            this.btnModifyJumper.Click += new System.EventHandler(this.btnModifyJumper_Click);
            // 
            // FormJumpers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 505);
            this.Controls.Add(this.btnTecnical);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txbCup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoveJumper);
            this.Controls.Add(this.btnModifyJumper);
            this.Controls.Add(this.btnAddJumper);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxJumpers);
            this.Name = "FormJumpers";
            this.Text = "Osallistujat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxJumpers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddJumper;
        private System.Windows.Forms.Button btnRemoveJumper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbCup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTecnical;
        private System.Windows.Forms.Button btnModifyJumper;
    }
}