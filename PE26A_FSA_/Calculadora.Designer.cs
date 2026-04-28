namespace PE26A_FSA_
{
    partial class Calculadora
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
            this.ConvierteFAC = new System.Windows.Forms.Button();
            this.LbxGradosC = new System.Windows.Forms.Label();
            this.ConvierteCaF = new System.Windows.Forms.Button();
            this.TbxResultado1 = new System.Windows.Forms.TextBox();
            this.TbxGradosF = new System.Windows.Forms.TextBox();
            this.TbxResultado2 = new System.Windows.Forms.TextBox();
            this.TbxGradosC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConvierteFAC
            // 
            this.ConvierteFAC.Location = new System.Drawing.Point(339, 190);
            this.ConvierteFAC.Name = "ConvierteFAC";
            this.ConvierteFAC.Size = new System.Drawing.Size(75, 23);
            this.ConvierteFAC.TabIndex = 16;
            this.ConvierteFAC.Text = "FAC";
            this.ConvierteFAC.UseVisualStyleBackColor = true;
            this.ConvierteFAC.Click += new System.EventHandler(this.ConvierteFAC_Click);
            // 
            // LbxGradosC
            // 
            this.LbxGradosC.AutoSize = true;
            this.LbxGradosC.Location = new System.Drawing.Point(191, 101);
            this.LbxGradosC.Name = "LbxGradosC";
            this.LbxGradosC.Size = new System.Drawing.Size(102, 13);
            this.LbxGradosC.TabIndex = 10;
            this.LbxGradosC.Text = "Grados Centígrados";
            // 
            // ConvierteCaF
            // 
            this.ConvierteCaF.Location = new System.Drawing.Point(339, 126);
            this.ConvierteCaF.Name = "ConvierteCaF";
            this.ConvierteCaF.Size = new System.Drawing.Size(75, 23);
            this.ConvierteCaF.TabIndex = 15;
            this.ConvierteCaF.Text = "CAF";
            this.ConvierteCaF.UseVisualStyleBackColor = true;
            this.ConvierteCaF.Click += new System.EventHandler(this.ConvierteCaF_Click);
            // 
            // TbxResultado1
            // 
            this.TbxResultado1.Location = new System.Drawing.Point(303, 128);
            this.TbxResultado1.Name = "TbxResultado1";
            this.TbxResultado1.Size = new System.Drawing.Size(30, 20);
            this.TbxResultado1.TabIndex = 11;
            // 
            // TbxGradosF
            // 
            this.TbxGradosF.Location = new System.Drawing.Point(190, 189);
            this.TbxGradosF.Name = "TbxGradosF";
            this.TbxGradosF.Size = new System.Drawing.Size(100, 20);
            this.TbxGradosF.TabIndex = 12;
            // 
            // TbxResultado2
            // 
            this.TbxResultado2.Location = new System.Drawing.Point(303, 190);
            this.TbxResultado2.Name = "TbxResultado2";
            this.TbxResultado2.Size = new System.Drawing.Size(30, 20);
            this.TbxResultado2.TabIndex = 14;
            // 
            // TbxGradosC
            // 
            this.TbxGradosC.Location = new System.Drawing.Point(193, 128);
            this.TbxGradosC.Name = "TbxGradosC";
            this.TbxGradosC.Size = new System.Drawing.Size(100, 20);
            this.TbxGradosC.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Grados Fahrenheit";
            // 
            // Calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConvierteFAC);
            this.Controls.Add(this.LbxGradosC);
            this.Controls.Add(this.ConvierteCaF);
            this.Controls.Add(this.TbxResultado1);
            this.Controls.Add(this.TbxGradosF);
            this.Controls.Add(this.TbxResultado2);
            this.Controls.Add(this.TbxGradosC);
            this.Controls.Add(this.label2);
            this.Name = "Calculadora";
            this.Text = "Calculadora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvierteFAC;
        private System.Windows.Forms.Label LbxGradosC;
        private System.Windows.Forms.Button ConvierteCaF;
        private System.Windows.Forms.TextBox TbxResultado1;
        private System.Windows.Forms.TextBox TbxGradosF;
        private System.Windows.Forms.TextBox TbxResultado2;
        private System.Windows.Forms.TextBox TbxGradosC;
        private System.Windows.Forms.Label label2;
    }
}