namespace AbayChequeMagic
{
    partial class DefaultPrinter
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
            this.lbxInstalledPrinter = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxInstalledPrinter
            // 
            this.lbxInstalledPrinter.FormattingEnabled = true;
            this.lbxInstalledPrinter.Location = new System.Drawing.Point(59, 81);
            this.lbxInstalledPrinter.Name = "lbxInstalledPrinter";
            this.lbxInstalledPrinter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxInstalledPrinter.Size = new System.Drawing.Size(189, 147);
            this.lbxInstalledPrinter.TabIndex = 1;
            // 
            // DefaultPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 439);
            this.Controls.Add(this.lbxInstalledPrinter);
            this.Name = "DefaultPrinter";
            this.Text = "DefaultPrinter";
            this.Load += new System.EventHandler(this.DefaultPrinter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxInstalledPrinter;
    }
}