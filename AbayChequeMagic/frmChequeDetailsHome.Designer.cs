namespace AbayChequeMagic
{
    partial class frmChequeDetailsHome
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.trvMain = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvChequeDetails = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnWriteCheque = new System.Windows.Forms.Button();
            this.btnViewAllCheque = new System.Windows.Forms.Button();
            this.lblChequeBook = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeDetails)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pnlRight);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 518);
            this.panel1.TabIndex = 42;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.lblCompanyName);
            this.pnlRight.Controls.Add(this.trvMain);
            this.pnlRight.Location = new System.Drawing.Point(15, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(15, 3, 10, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(250, 570);
            this.pnlRight.TabIndex = 42;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(145)))), ((int)(((byte)(194)))));
            this.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompanyName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(0, 0);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Padding = new System.Windows.Forms.Padding(5);
            this.lblCompanyName.Size = new System.Drawing.Size(250, 31);
            this.lblCompanyName.TabIndex = 38;
            this.lblCompanyName.Text = "Company Name";
            // 
            // trvMain
            // 
            this.trvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvMain.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.trvMain.FullRowSelect = true;
            this.trvMain.Location = new System.Drawing.Point(10, 41);
            this.trvMain.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.trvMain.Name = "trvMain";
            this.trvMain.Size = new System.Drawing.Size(230, 523);
            this.trvMain.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(15, 567);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 23);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.dgvChequeDetails);
            this.pnlLeft.Controls.Add(this.pnlBottom);
            this.pnlLeft.Controls.Add(this.lblChequeBook);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(275, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(649, 518);
            this.pnlLeft.TabIndex = 46;
            // 
            // dgvChequeDetails
            // 
            this.dgvChequeDetails.AllowUserToAddRows = false;
            this.dgvChequeDetails.AllowUserToDeleteRows = false;
            this.dgvChequeDetails.AllowUserToResizeColumns = false;
            this.dgvChequeDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvChequeDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChequeDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChequeDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvChequeDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChequeDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChequeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChequeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChequeDetails.EnableHeadersVisualStyles = false;
            this.dgvChequeDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.dgvChequeDetails.Location = new System.Drawing.Point(10, 32);
            this.dgvChequeDetails.MultiSelect = false;
            this.dgvChequeDetails.Name = "dgvChequeDetails";
            this.dgvChequeDetails.ReadOnly = true;
            this.dgvChequeDetails.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvChequeDetails.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChequeDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChequeDetails.Size = new System.Drawing.Size(629, 378);
            this.dgvChequeDetails.TabIndex = 41;
            this.dgvChequeDetails.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnWriteCheque);
            this.pnlBottom.Controls.Add(this.btnViewAllCheque);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(10, 410);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(629, 98);
            this.pnlBottom.TabIndex = 40;
            // 
            // btnWriteCheque
            // 
            this.btnWriteCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnWriteCheque.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnWriteCheque.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnWriteCheque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnWriteCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWriteCheque.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnWriteCheque.ForeColor = System.Drawing.Color.White;
            this.btnWriteCheque.Location = new System.Drawing.Point(117, 9);
            this.btnWriteCheque.Margin = new System.Windows.Forms.Padding(0);
            this.btnWriteCheque.Name = "btnWriteCheque";
            this.btnWriteCheque.Size = new System.Drawing.Size(112, 27);
            this.btnWriteCheque.TabIndex = 41;
            this.btnWriteCheque.Text = "Write Cheque";
            this.btnWriteCheque.UseVisualStyleBackColor = false;
            this.btnWriteCheque.Visible = false;
            // 
            // btnViewAllCheque
            // 
            this.btnViewAllCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnViewAllCheque.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnViewAllCheque.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnViewAllCheque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnViewAllCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAllCheque.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnViewAllCheque.ForeColor = System.Drawing.Color.White;
            this.btnViewAllCheque.Location = new System.Drawing.Point(0, 9);
            this.btnViewAllCheque.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewAllCheque.Name = "btnViewAllCheque";
            this.btnViewAllCheque.Size = new System.Drawing.Size(112, 27);
            this.btnViewAllCheque.TabIndex = 40;
            this.btnViewAllCheque.Text = "View All Cheque";
            this.btnViewAllCheque.UseVisualStyleBackColor = false;
            this.btnViewAllCheque.Visible = false;
            // 
            // lblChequeBook
            // 
            this.lblChequeBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChequeBook.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeBook.Location = new System.Drawing.Point(10, 10);
            this.lblChequeBook.Margin = new System.Windows.Forms.Padding(0);
            this.lblChequeBook.Name = "lblChequeBook";
            this.lblChequeBook.Size = new System.Drawing.Size(629, 22);
            this.lblChequeBook.TabIndex = 37;
            this.lblChequeBook.Text = "Cheque Book Name (00001-00050)";
            this.lblChequeBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChequeBook.Visible = false;
            // 
            // frmChequeDetailsHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 518);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.panel1);
            this.Name = "frmChequeDetailsHome";
            this.Text = "frmChequeDetailsHome";
            this.panel1.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeDetails)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TreeView trvMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.DataGridView dgvChequeDetails;
        private System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.Button btnWriteCheque;
        public System.Windows.Forms.Button btnViewAllCheque;
        private System.Windows.Forms.Label lblChequeBook;
    }
}