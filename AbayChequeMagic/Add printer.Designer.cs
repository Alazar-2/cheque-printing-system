namespace AbayChequeMagic
{
    partial class Add_printer
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
            this.gbxAddPrinter = new System.Windows.Forms.GroupBox();
            this.lkbtn = new System.Windows.Forms.LinkLabel();
            this.lblSelectedPrinters = new System.Windows.Forms.Label();
            this.lblInstalledPrinters = new System.Windows.Forms.Label();
            this.lbxInstalledPrinter = new System.Windows.Forms.ListBox();
            this.lbxcChoosenPrinter = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gbxAddPrinter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAddPrinter
            // 
            this.gbxAddPrinter.Controls.Add(this.lkbtn);
            this.gbxAddPrinter.Controls.Add(this.lblSelectedPrinters);
            this.gbxAddPrinter.Controls.Add(this.lblInstalledPrinters);
            this.gbxAddPrinter.Controls.Add(this.lbxInstalledPrinter);
            this.gbxAddPrinter.Controls.Add(this.lbxcChoosenPrinter);
            this.gbxAddPrinter.Controls.Add(this.btnAdd);
            this.gbxAddPrinter.Controls.Add(this.btnRemove);
            this.gbxAddPrinter.Location = new System.Drawing.Point(51, 97);
            this.gbxAddPrinter.Name = "gbxAddPrinter";
            this.gbxAddPrinter.Size = new System.Drawing.Size(506, 235);
            this.gbxAddPrinter.TabIndex = 1;
            this.gbxAddPrinter.TabStop = false;
            this.gbxAddPrinter.Text = "Add Printer";
            // 
            // lkbtn
            // 
            this.lkbtn.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.lkbtn.AutoSize = true;
            this.lkbtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lkbtn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.lkbtn.Location = new System.Drawing.Point(299, 202);
            this.lkbtn.Name = "lkbtn";
            this.lkbtn.Size = new System.Drawing.Size(126, 15);
            this.lkbtn.TabIndex = 15;
            this.lkbtn.TabStop = true;
            this.lkbtn.Text = "Set as default printer";
            this.lkbtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbtn_LinkClicked);
            // 
            // lblSelectedPrinters
            // 
            this.lblSelectedPrinters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPrinters.Location = new System.Drawing.Point(296, 24);
            this.lblSelectedPrinters.Name = "lblSelectedPrinters";
            this.lblSelectedPrinters.Size = new System.Drawing.Size(100, 15);
            this.lblSelectedPrinters.TabIndex = 14;
            this.lblSelectedPrinters.Text = "Selected Printers";
            // 
            // lblInstalledPrinters
            // 
            this.lblInstalledPrinters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstalledPrinters.Location = new System.Drawing.Point(20, 24);
            this.lblInstalledPrinters.Name = "lblInstalledPrinters";
            this.lblInstalledPrinters.Size = new System.Drawing.Size(100, 15);
            this.lblInstalledPrinters.TabIndex = 13;
            this.lblInstalledPrinters.Text = "Installed Printers";
            // 
            // lbxInstalledPrinter
            // 
            this.lbxInstalledPrinter.FormattingEnabled = true;
            this.lbxInstalledPrinter.Location = new System.Drawing.Point(21, 50);
            this.lbxInstalledPrinter.Name = "lbxInstalledPrinter";
            this.lbxInstalledPrinter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxInstalledPrinter.Size = new System.Drawing.Size(189, 147);
            this.lbxInstalledPrinter.TabIndex = 0;
            // 
            // lbxcChoosenPrinter
            // 
            this.lbxcChoosenPrinter.FormattingEnabled = true;
            this.lbxcChoosenPrinter.Location = new System.Drawing.Point(297, 50);
            this.lbxcChoosenPrinter.Name = "lbxcChoosenPrinter";
            this.lbxcChoosenPrinter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxcChoosenPrinter.Size = new System.Drawing.Size(189, 147);
            this.lbxcChoosenPrinter.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(216, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(216, 80);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Add_printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 437);
            this.Controls.Add(this.gbxAddPrinter);
            this.Name = "Add_printer";
            this.Text = "Add_printer";
            this.Load += new System.EventHandler(this.Add_printer_Load);
            this.gbxAddPrinter.ResumeLayout(false);
            this.gbxAddPrinter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddPrinter;
        private System.Windows.Forms.LinkLabel lkbtn;
        private System.Windows.Forms.Label lblSelectedPrinters;
        private System.Windows.Forms.Label lblInstalledPrinters;
        private System.Windows.Forms.ListBox lbxInstalledPrinter;
        private System.Windows.Forms.ListBox lbxcChoosenPrinter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}