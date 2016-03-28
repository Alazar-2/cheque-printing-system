namespace AbayChequeMagic
{
    partial class Form1
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAmountInWords1 = new System.Windows.Forms.Label();
            this.lblAmountInWords2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(45, 26);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(566, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // lblAmountInWords1
            // 
            this.lblAmountInWords1.AccessibleName = "Amount In Words";
            this.lblAmountInWords1.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountInWords1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmountInWords1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWords1.Location = new System.Drawing.Point(42, 67);
            this.lblAmountInWords1.Name = "lblAmountInWords1";
            this.lblAmountInWords1.Size = new System.Drawing.Size(499, 21);
            this.lblAmountInWords1.TabIndex = 4;
            // 
            // lblAmountInWords2
            // 
            this.lblAmountInWords2.AccessibleName = "Amount In Words";
            this.lblAmountInWords2.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountInWords2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmountInWords2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWords2.Location = new System.Drawing.Point(50, 125);
            this.lblAmountInWords2.Name = "lblAmountInWords2";
            this.lblAmountInWords2.Size = new System.Drawing.Size(324, 21);
            this.lblAmountInWords2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 322);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAmountInWords2);
            this.Controls.Add(this.lblAmountInWords1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAmountInWords1;
        private System.Windows.Forms.Label lblAmountInWords2;
        private System.Windows.Forms.Button button1;
    }
}

