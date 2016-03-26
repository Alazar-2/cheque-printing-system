namespace AbayChequeMagic
{
    partial class frmChequeEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChequeEntry));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxAddOrRemoveFields = new System.Windows.Forms.GroupBox();

            this.btnAddPrinter = new System.Windows.Forms.Button();

            this.btnInstallPrinter = new System.Windows.Forms.Button();
            this.rb900 = new System.Windows.Forms.RadioButton();
            this.rb600 = new System.Windows.Forms.RadioButton();
            this.rb300 = new System.Windows.Forms.RadioButton();
            this.btnPayeeDown = new System.Windows.Forms.Button();
            this.btnPayeeUp = new System.Windows.Forms.Button();
            this.btnPayeeRight = new System.Windows.Forms.Button();
            this.btnPayeeLeft = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAmountDown = new System.Windows.Forms.Button();
            this.btnAmountUp = new System.Windows.Forms.Button();
            this.btnAmountRight = new System.Windows.Forms.Button();
            this.btnAmountLeft = new System.Windows.Forms.Button();
            this.btnDateDown = new System.Windows.Forms.Button();
            this.btnDateUp = new System.Windows.Forms.Button();
            this.btnDateRight = new System.Windows.Forms.Button();
            this.btnDateLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectPrnt = new System.Windows.Forms.Button();
            this.btnNarrowSpace = new System.Windows.Forms.Button();
            this.btnIncreaseSpace = new System.Windows.Forms.Button();
            this.DateSpace = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlWorkSpace = new System.Windows.Forms.Panel();
            this.pnlCheque = new System.Windows.Forms.Panel();
            this.pbxBearerStrike = new System.Windows.Forms.PictureBox();
            this.pbxSignatoryStamp = new System.Windows.Forms.PictureBox();
            this.lblNotAboveAmount = new System.Windows.Forms.Label();
            this.pbxNotNegotiable = new System.Windows.Forms.PictureBox();
            this.pbxNotAbove = new System.Windows.Forms.PictureBox();
            this.pbxPayableAtPar = new System.Windows.Forms.PictureBox();
            this.pbxACPayeeOnly = new System.Windows.Forms.PictureBox();
            this.lblAuthorizedSignatory = new System.Windows.Forms.Label();
            this.lblForCompany = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountInWords2 = new System.Windows.Forms.Label();
            this.lblAmountInWords1 = new System.Windows.Forms.Label();
            this.lblPayeeLine2 = new System.Windows.Forms.Label();
            this.lblPayeeLine1 = new System.Windows.Forms.Label();
            this.gbxOptional = new System.Windows.Forms.GroupBox();
            this.cbxPrintCoveringLetter = new System.Windows.Forms.CheckBox();
            this.cbxPrintPaymentVoucher = new System.Windows.Forms.CheckBox();
            this.gbxCrossing = new System.Windows.Forms.GroupBox();
            this.cbxNotNegotiable = new System.Windows.Forms.CheckBox();
            this.cbxAccountPayeeOnly = new System.Windows.Forms.CheckBox();
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.cbxNotAbove = new System.Windows.Forms.CheckBox();
            this.cbxPayableAtPar = new System.Windows.Forms.CheckBox();
            this.cbxBearerStrike = new System.Windows.Forms.CheckBox();
            this.gbxChequeDetails = new System.Windows.Forms.GroupBox();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.cbxPrintPayeeAccountNumber = new System.Windows.Forms.CheckBox();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.cmbExpense = new System.Windows.Forms.ComboBox();
            this.lblExpense = new System.Windows.Forms.Label();
            this.lblSelectDate = new System.Windows.Forms.Label();
            this.lblAmountNotforPrinting = new System.Windows.Forms.Label();
            this.lblPayee = new System.Windows.Forms.Label();
            this.dtpDateOnCheque = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.pd = new System.Drawing.Printing.PrintDocument();
            this.ppd = new System.Windows.Forms.PrintPreviewDialog();
            this.pdl = new System.Windows.Forms.PrintDialog();
            this.psd = new System.Windows.Forms.PageSetupDialog();
            this.pnlBody.SuspendLayout();
            this.gbxAddOrRemoveFields.SuspendLayout();
            this.pnlWorkSpace.SuspendLayout();
            this.pnlCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBearerStrike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSignatoryStamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotNegotiable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotAbove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPayableAtPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxACPayeeOnly)).BeginInit();
            this.gbxOptional.SuspendLayout();
            this.gbxCrossing.SuspendLayout();
            this.gbxOptions.SuspendLayout();
            this.gbxChequeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1013, 62);
            this.pnlHeader.TabIndex = 9;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.btnPrintPreview);
            this.pnlBody.Controls.Add(this.btnClose);
            this.pnlBody.Controls.Add(this.gbxAddOrRemoveFields);
            this.pnlBody.Controls.Add(this.btnPrint);
            this.pnlBody.Controls.Add(this.btnSave);
            this.pnlBody.Controls.Add(this.pnlWorkSpace);
            this.pnlBody.Controls.Add(this.gbxOptional);
            this.pnlBody.Controls.Add(this.gbxCrossing);
            this.pnlBody.Controls.Add(this.gbxOptions);
            this.pnlBody.Controls.Add(this.gbxChequeDetails);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 62);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBody.Size = new System.Drawing.Size(1013, 671);
            this.pnlBody.TabIndex = 10;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnPrintPreview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnPrintPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreview.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnPrintPreview.ForeColor = System.Drawing.Color.White;
            this.btnPrintPreview.Location = new System.Drawing.Point(14, 610);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(94, 25);
            this.btnPrintPreview.TabIndex = 6;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(849, 610);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbxAddOrRemoveFields
            // 

            this.gbxAddOrRemoveFields.Controls.Add(this.btnAddPrinter);

            this.gbxAddOrRemoveFields.Controls.Add(this.btnInstallPrinter);
            this.gbxAddOrRemoveFields.Controls.Add(this.rb900);
            this.gbxAddOrRemoveFields.Controls.Add(this.rb600);
            this.gbxAddOrRemoveFields.Controls.Add(this.rb300);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnPayeeDown);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnPayeeUp);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnPayeeRight);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnPayeeLeft);
            this.gbxAddOrRemoveFields.Controls.Add(this.label3);
            this.gbxAddOrRemoveFields.Controls.Add(this.label2);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnAmountDown);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnAmountUp);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnAmountRight);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnAmountLeft);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnDateDown);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnDateUp);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnDateRight);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnDateLeft);
            this.gbxAddOrRemoveFields.Controls.Add(this.label1);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnSelectPrnt);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnNarrowSpace);
            this.gbxAddOrRemoveFields.Controls.Add(this.btnIncreaseSpace);
            this.gbxAddOrRemoveFields.Controls.Add(this.DateSpace);
            this.gbxAddOrRemoveFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddOrRemoveFields.Location = new System.Drawing.Point(16, 99);
            this.gbxAddOrRemoveFields.Name = "gbxAddOrRemoveFields";
            this.gbxAddOrRemoveFields.Size = new System.Drawing.Size(984, 76);
            this.gbxAddOrRemoveFields.TabIndex = 4;
            this.gbxAddOrRemoveFields.TabStop = false;
            this.gbxAddOrRemoveFields.Text = "Adjust labels";
            // 

            // btnAddPrinter
            // 
            this.btnAddPrinter.Location = new System.Drawing.Point(867, 39);
            this.btnAddPrinter.Name = "btnAddPrinter";
            this.btnAddPrinter.Size = new System.Drawing.Size(95, 25);
            this.btnAddPrinter.TabIndex = 31;
            this.btnAddPrinter.Text = "Add Printer";
            this.btnAddPrinter.UseVisualStyleBackColor = true;
            this.btnAddPrinter.Visible = false;
            this.btnAddPrinter.Click += new System.EventHandler(this.btnAddPrinter_Click);
            // 

            // btnInstallPrinter
            // 
            this.btnInstallPrinter.Location = new System.Drawing.Point(518, 50);
            this.btnInstallPrinter.Name = "btnInstallPrinter";
            this.btnInstallPrinter.Size = new System.Drawing.Size(95, 25);
            this.btnInstallPrinter.TabIndex = 30;
            this.btnInstallPrinter.Text = "Install Printer";
            this.btnInstallPrinter.UseVisualStyleBackColor = true;
            this.btnInstallPrinter.Click += new System.EventHandler(this.btnInstallPrinter_Click);
            // 
            // rb900
            // 
            this.rb900.AutoSize = true;
            this.rb900.Location = new System.Drawing.Point(785, 44);
            this.rb900.Name = "rb900";
            this.rb900.Size = new System.Drawing.Size(76, 20);
            this.rb900.TabIndex = 29;
            this.rb900.TabStop = true;
            this.rb900.Text = "900 dpi";
            this.rb900.UseVisualStyleBackColor = true;
            // 
            // rb600
            // 
            this.rb600.AutoSize = true;
            this.rb600.Location = new System.Drawing.Point(701, 44);
            this.rb600.Name = "rb600";
            this.rb600.Size = new System.Drawing.Size(76, 20);
            this.rb600.TabIndex = 28;
            this.rb600.TabStop = true;
            this.rb600.Text = "600 dpi";
            this.rb600.UseVisualStyleBackColor = true;
            // 
            // rb300
            // 
            this.rb300.AutoSize = true;
            this.rb300.Location = new System.Drawing.Point(619, 44);
            this.rb300.Name = "rb300";
            this.rb300.Size = new System.Drawing.Size(76, 20);
            this.rb300.TabIndex = 27;
            this.rb300.TabStop = true;
            this.rb300.Text = "300 dpi";
            this.rb300.UseVisualStyleBackColor = true;
            // 
            // btnPayeeDown
            // 
            this.btnPayeeDown.Location = new System.Drawing.Point(485, 51);
            this.btnPayeeDown.Name = "btnPayeeDown";
            this.btnPayeeDown.Size = new System.Drawing.Size(20, 20);
            this.btnPayeeDown.TabIndex = 26;
            this.btnPayeeDown.Text = "˅";
            this.btnPayeeDown.UseVisualStyleBackColor = true;
            this.btnPayeeDown.Click += new System.EventHandler(this.btnPayeeDown_Click);
            // 
            // btnPayeeUp
            // 
            this.btnPayeeUp.Location = new System.Drawing.Point(485, 5);
            this.btnPayeeUp.Name = "btnPayeeUp";
            this.btnPayeeUp.Size = new System.Drawing.Size(20, 20);
            this.btnPayeeUp.TabIndex = 25;
            this.btnPayeeUp.Text = "˄";
            this.btnPayeeUp.UseVisualStyleBackColor = true;
            this.btnPayeeUp.Click += new System.EventHandler(this.btnPayeeUp_Click);
            // 
            // btnPayeeRight
            // 
            this.btnPayeeRight.Location = new System.Drawing.Point(503, 29);
            this.btnPayeeRight.Name = "btnPayeeRight";
            this.btnPayeeRight.Size = new System.Drawing.Size(20, 20);
            this.btnPayeeRight.TabIndex = 24;
            this.btnPayeeRight.Text = ">";
            this.btnPayeeRight.UseVisualStyleBackColor = true;
            this.btnPayeeRight.Click += new System.EventHandler(this.btnPayeeRight_Click);
            // 
            // btnPayeeLeft
            // 
            this.btnPayeeLeft.Location = new System.Drawing.Point(477, 29);
            this.btnPayeeLeft.Name = "btnPayeeLeft";
            this.btnPayeeLeft.Size = new System.Drawing.Size(20, 20);
            this.btnPayeeLeft.TabIndex = 23;
            this.btnPayeeLeft.Text = "<";
            this.btnPayeeLeft.UseVisualStyleBackColor = true;
            this.btnPayeeLeft.Click += new System.EventHandler(this.btnPayeeLeft_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Adjust Payee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Adjust Amnt";
            // 
            // btnAmountDown
            // 
            this.btnAmountDown.Location = new System.Drawing.Point(308, 51);
            this.btnAmountDown.Name = "btnAmountDown";
            this.btnAmountDown.Size = new System.Drawing.Size(20, 20);
            this.btnAmountDown.TabIndex = 20;
            this.btnAmountDown.Text = "˅";
            this.btnAmountDown.UseVisualStyleBackColor = true;
            this.btnAmountDown.Click += new System.EventHandler(this.btnAmountDown_Click);
            // 
            // btnAmountUp
            // 
            this.btnAmountUp.Location = new System.Drawing.Point(308, 3);
            this.btnAmountUp.Name = "btnAmountUp";
            this.btnAmountUp.Size = new System.Drawing.Size(20, 20);
            this.btnAmountUp.TabIndex = 19;
            this.btnAmountUp.Text = "˄";
            this.btnAmountUp.UseVisualStyleBackColor = true;
            this.btnAmountUp.Click += new System.EventHandler(this.btnAmountUp_Click);
            // 
            // btnAmountRight
            // 
            this.btnAmountRight.Location = new System.Drawing.Point(319, 25);
            this.btnAmountRight.Name = "btnAmountRight";
            this.btnAmountRight.Size = new System.Drawing.Size(20, 20);
            this.btnAmountRight.TabIndex = 18;
            this.btnAmountRight.Text = ">";
            this.btnAmountRight.UseVisualStyleBackColor = true;
            this.btnAmountRight.Click += new System.EventHandler(this.btnAmountRight_Click);
            // 
            // btnAmountLeft
            // 
            this.btnAmountLeft.Location = new System.Drawing.Point(293, 25);
            this.btnAmountLeft.Name = "btnAmountLeft";
            this.btnAmountLeft.Size = new System.Drawing.Size(20, 20);
            this.btnAmountLeft.TabIndex = 17;
            this.btnAmountLeft.Text = "<";
            this.btnAmountLeft.UseVisualStyleBackColor = true;
            this.btnAmountLeft.Click += new System.EventHandler(this.btnAmountLeft_Click);
            // 
            // btnDateDown
            // 
            this.btnDateDown.Location = new System.Drawing.Point(140, 51);
            this.btnDateDown.Name = "btnDateDown";
            this.btnDateDown.Size = new System.Drawing.Size(20, 20);
            this.btnDateDown.TabIndex = 16;
            this.btnDateDown.Text = "˅";
            this.btnDateDown.UseVisualStyleBackColor = true;
            this.btnDateDown.Click += new System.EventHandler(this.btnDateDown_Click);
            // 
            // btnDateUp
            // 
            this.btnDateUp.Location = new System.Drawing.Point(140, 3);
            this.btnDateUp.Name = "btnDateUp";
            this.btnDateUp.Size = new System.Drawing.Size(20, 20);
            this.btnDateUp.TabIndex = 15;
            this.btnDateUp.Text = "˄";
            this.btnDateUp.UseVisualStyleBackColor = true;
            this.btnDateUp.Click += new System.EventHandler(this.btnDateUp_Click);
            // 
            // btnDateRight
            // 
            this.btnDateRight.Location = new System.Drawing.Point(154, 25);
            this.btnDateRight.Name = "btnDateRight";
            this.btnDateRight.Size = new System.Drawing.Size(20, 20);
            this.btnDateRight.TabIndex = 14;
            this.btnDateRight.Text = ">";
            this.btnDateRight.UseVisualStyleBackColor = true;
            this.btnDateRight.Click += new System.EventHandler(this.btnDateRight_Click);
            // 
            // btnDateLeft
            // 
            this.btnDateLeft.Location = new System.Drawing.Point(128, 25);
            this.btnDateLeft.Name = "btnDateLeft";
            this.btnDateLeft.Size = new System.Drawing.Size(20, 20);
            this.btnDateLeft.TabIndex = 13;
            this.btnDateLeft.Text = "<";
            this.btnDateLeft.UseVisualStyleBackColor = true;
            this.btnDateLeft.Click += new System.EventHandler(this.btnDateLeft_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Adjust Date";
            // 
            // btnSelectPrnt
            // 
            this.btnSelectPrnt.Location = new System.Drawing.Point(582, 12);
            this.btnSelectPrnt.Name = "btnSelectPrnt";
            this.btnSelectPrnt.Size = new System.Drawing.Size(118, 25);
            this.btnSelectPrnt.TabIndex = 11;
            this.btnSelectPrnt.Text = "Printer setting";
            this.btnSelectPrnt.UseVisualStyleBackColor = true;
            this.btnSelectPrnt.Click += new System.EventHandler(this.btnSelectPrnt_Click);
            // 
            // btnNarrowSpace
            // 
            this.btnNarrowSpace.Location = new System.Drawing.Point(826, 12);
            this.btnNarrowSpace.Name = "btnNarrowSpace";
            this.btnNarrowSpace.Size = new System.Drawing.Size(20, 20);
            this.btnNarrowSpace.TabIndex = 10;
            this.btnNarrowSpace.Text = "<<";
            this.btnNarrowSpace.UseVisualStyleBackColor = true;
            this.btnNarrowSpace.Click += new System.EventHandler(this.btnNarrowSpace_Click);
            // 
            // btnIncreaseSpace
            // 
            this.btnIncreaseSpace.Location = new System.Drawing.Point(852, 12);
            this.btnIncreaseSpace.Name = "btnIncreaseSpace";
            this.btnIncreaseSpace.Size = new System.Drawing.Size(20, 20);
            this.btnIncreaseSpace.TabIndex = 9;
            this.btnIncreaseSpace.Text = ">>";
            this.btnIncreaseSpace.UseVisualStyleBackColor = true;
            this.btnIncreaseSpace.Click += new System.EventHandler(this.btnIncreaseSpace_Click);
            // 
            // DateSpace
            // 
            this.DateSpace.AutoSize = true;
            this.DateSpace.Location = new System.Drawing.Point(713, 21);
            this.DateSpace.Name = "DateSpace";
            this.DateSpace.Size = new System.Drawing.Size(90, 16);
            this.DateSpace.TabIndex = 8;
            this.DateSpace.Text = "Date Space";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(769, 610);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(689, 610);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlWorkSpace
            // 
            this.pnlWorkSpace.AutoScroll = true;
            this.pnlWorkSpace.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlWorkSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWorkSpace.Controls.Add(this.pnlCheque);
            this.pnlWorkSpace.Location = new System.Drawing.Point(10, 180);
            this.pnlWorkSpace.Name = "pnlWorkSpace";
            this.pnlWorkSpace.Size = new System.Drawing.Size(909, 425);
            this.pnlWorkSpace.TabIndex = 18;
            // 
            // pnlCheque
            // 
            this.pnlCheque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCheque.BackColor = System.Drawing.Color.White;
            this.pnlCheque.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCheque.BackgroundImage")));
            this.pnlCheque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCheque.Controls.Add(this.pbxBearerStrike);
            this.pnlCheque.Controls.Add(this.pbxSignatoryStamp);
            this.pnlCheque.Controls.Add(this.lblNotAboveAmount);
            this.pnlCheque.Controls.Add(this.pbxNotNegotiable);
            this.pnlCheque.Controls.Add(this.pbxNotAbove);
            this.pnlCheque.Controls.Add(this.pbxPayableAtPar);
            this.pnlCheque.Controls.Add(this.pbxACPayeeOnly);
            this.pnlCheque.Controls.Add(this.lblAuthorizedSignatory);
            this.pnlCheque.Controls.Add(this.lblForCompany);
            this.pnlCheque.Controls.Add(this.lblDate);
            this.pnlCheque.Controls.Add(this.lblAccountNo);
            this.pnlCheque.Controls.Add(this.lblAmount);
            this.pnlCheque.Controls.Add(this.lblAmountInWords2);
            this.pnlCheque.Controls.Add(this.lblAmountInWords1);
            this.pnlCheque.Controls.Add(this.lblPayeeLine2);
            this.pnlCheque.Controls.Add(this.lblPayeeLine1);
            this.pnlCheque.Location = new System.Drawing.Point(61, 4);
            this.pnlCheque.Name = "pnlCheque";
            this.pnlCheque.Size = new System.Drawing.Size(805, 398);
            this.pnlCheque.TabIndex = 0;
            // 
            // pbxBearerStrike
            // 
            this.pbxBearerStrike.BackColor = System.Drawing.Color.Transparent;
            this.pbxBearerStrike.InitialImage = null;
            this.pbxBearerStrike.Location = new System.Drawing.Point(376, 15);
            this.pbxBearerStrike.Name = "pbxBearerStrike";
            this.pbxBearerStrike.Size = new System.Drawing.Size(300, 19);
            this.pbxBearerStrike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBearerStrike.TabIndex = 19;
            this.pbxBearerStrike.TabStop = false;
            this.pbxBearerStrike.Visible = false;
            // 
            // pbxSignatoryStamp
            // 
            this.pbxSignatoryStamp.AccessibleDescription = "Siganture Stamp";
            this.pbxSignatoryStamp.BackColor = System.Drawing.Color.Transparent;
            this.pbxSignatoryStamp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxSignatoryStamp.Location = new System.Drawing.Point(324, 276);
            this.pbxSignatoryStamp.Name = "pbxSignatoryStamp";
            this.pbxSignatoryStamp.Size = new System.Drawing.Size(100, 49);
            this.pbxSignatoryStamp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSignatoryStamp.TabIndex = 18;
            this.pbxSignatoryStamp.TabStop = false;
            this.pbxSignatoryStamp.Visible = false;
            // 
            // lblNotAboveAmount
            // 
            this.lblNotAboveAmount.AutoSize = true;
            this.lblNotAboveAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblNotAboveAmount.Location = new System.Drawing.Point(164, 255);
            this.lblNotAboveAmount.Name = "lblNotAboveAmount";
            this.lblNotAboveAmount.Size = new System.Drawing.Size(0, 13);
            this.lblNotAboveAmount.TabIndex = 17;
            this.lblNotAboveAmount.Visible = false;
            // 
            // pbxNotNegotiable
            // 
            this.pbxNotNegotiable.AccessibleName = "Non negotiable";
            this.pbxNotNegotiable.BackColor = System.Drawing.Color.Transparent;
            this.pbxNotNegotiable.Location = new System.Drawing.Point(190, 15);
            this.pbxNotNegotiable.Name = "pbxNotNegotiable";
            this.pbxNotNegotiable.Size = new System.Drawing.Size(143, 28);
            this.pbxNotNegotiable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxNotNegotiable.TabIndex = 15;
            this.pbxNotNegotiable.TabStop = false;
            this.pbxNotNegotiable.Visible = false;
            // 
            // pbxNotAbove
            // 
            this.pbxNotAbove.AccessibleDescription = "NotAbove";
            this.pbxNotAbove.BackColor = System.Drawing.Color.Transparent;
            this.pbxNotAbove.Image = ((System.Drawing.Image)(resources.GetObject("pbxNotAbove.Image")));
            this.pbxNotAbove.Location = new System.Drawing.Point(46, 225);
            this.pbxNotAbove.Name = "pbxNotAbove";
            this.pbxNotAbove.Size = new System.Drawing.Size(149, 28);
            this.pbxNotAbove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxNotAbove.TabIndex = 14;
            this.pbxNotAbove.TabStop = false;
            this.pbxNotAbove.Visible = false;
            // 
            // pbxPayableAtPar
            // 
            this.pbxPayableAtPar.BackColor = System.Drawing.Color.Transparent;
            this.pbxPayableAtPar.Image = ((System.Drawing.Image)(resources.GetObject("pbxPayableAtPar.Image")));
            this.pbxPayableAtPar.Location = new System.Drawing.Point(307, 225);
            this.pbxPayableAtPar.Name = "pbxPayableAtPar";
            this.pbxPayableAtPar.Size = new System.Drawing.Size(143, 28);
            this.pbxPayableAtPar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPayableAtPar.TabIndex = 13;
            this.pbxPayableAtPar.TabStop = false;
            this.pbxPayableAtPar.Visible = false;
            // 
            // pbxACPayeeOnly
            // 
            this.pbxACPayeeOnly.AccessibleName = "A/C payee only";
            this.pbxACPayeeOnly.BackColor = System.Drawing.Color.Transparent;
            this.pbxACPayeeOnly.Image = ((System.Drawing.Image)(resources.GetObject("pbxACPayeeOnly.Image")));
            this.pbxACPayeeOnly.Location = new System.Drawing.Point(574, 315);
            this.pbxACPayeeOnly.Name = "pbxACPayeeOnly";
            this.pbxACPayeeOnly.Size = new System.Drawing.Size(143, 28);
            this.pbxACPayeeOnly.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxACPayeeOnly.TabIndex = 12;
            this.pbxACPayeeOnly.TabStop = false;
            this.pbxACPayeeOnly.Visible = false;
            // 
            // lblAuthorizedSignatory
            // 
            this.lblAuthorizedSignatory.AccessibleName = "Authorized Signatory";
            this.lblAuthorizedSignatory.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthorizedSignatory.Location = new System.Drawing.Point(291, 265);
            this.lblAuthorizedSignatory.Name = "lblAuthorizedSignatory";
            this.lblAuthorizedSignatory.Size = new System.Drawing.Size(150, 18);
            this.lblAuthorizedSignatory.TabIndex = 10;
            this.lblAuthorizedSignatory.Visible = false;
            // 
            // lblForCompany
            // 
            this.lblForCompany.AccessibleName = "For Company";
            this.lblForCompany.AutoSize = true;
            this.lblForCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblForCompany.Location = new System.Drawing.Point(522, 265);
            this.lblForCompany.Name = "lblForCompany";
            this.lblForCompany.Size = new System.Drawing.Size(0, 13);
            this.lblForCompany.TabIndex = 9;
            this.lblForCompany.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AccessibleName = "Date";
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Comic Sans MS", 8F);
            this.lblDate.Location = new System.Drawing.Point(577, 84);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(195, 20);
            this.lblDate.TabIndex = 8;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AccessibleName = "Account Number";
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.Location = new System.Drawing.Point(455, 37);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(0, 13);
            this.lblAccountNo.TabIndex = 6;
            this.lblAccountNo.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AccessibleName = "Amount in figure";
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Location = new System.Drawing.Point(587, 211);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(192, 26);
            this.lblAmount.TabIndex = 5;
            // 
            // lblAmountInWords2
            // 
            this.lblAmountInWords2.AccessibleName = "Amount in words line 2";
            this.lblAmountInWords2.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountInWords2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWords2.Location = new System.Drawing.Point(38, 196);
            this.lblAmountInWords2.Name = "lblAmountInWords2";
            this.lblAmountInWords2.Size = new System.Drawing.Size(474, 22);
            this.lblAmountInWords2.TabIndex = 4;
            this.lblAmountInWords2.Visible = false;
            // 
            // lblAmountInWords1
            // 
            this.lblAmountInWords1.AccessibleName = "Amount In Words";
            this.lblAmountInWords1.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountInWords1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWords1.Location = new System.Drawing.Point(48, 169);
            this.lblAmountInWords1.Name = "lblAmountInWords1";
            this.lblAmountInWords1.Size = new System.Drawing.Size(534, 21);
            this.lblAmountInWords1.TabIndex = 3;
            // 
            // lblPayeeLine2
            // 
            this.lblPayeeLine2.AccessibleName = "Payee Line 2";
            this.lblPayeeLine2.BackColor = System.Drawing.Color.Transparent;
            this.lblPayeeLine2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayeeLine2.Location = new System.Drawing.Point(672, 104);
            this.lblPayeeLine2.Name = "lblPayeeLine2";
            this.lblPayeeLine2.Size = new System.Drawing.Size(56, 18);
            this.lblPayeeLine2.TabIndex = 2;
            this.lblPayeeLine2.Visible = false;
            // 
            // lblPayeeLine1
            // 
            this.lblPayeeLine1.AccessibleName = "Payee";
            this.lblPayeeLine1.BackColor = System.Drawing.Color.Transparent;
            this.lblPayeeLine1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayeeLine1.Location = new System.Drawing.Point(48, 142);
            this.lblPayeeLine1.Name = "lblPayeeLine1";
            this.lblPayeeLine1.Size = new System.Drawing.Size(620, 20);
            this.lblPayeeLine1.TabIndex = 0;
            // 
            // gbxOptional
            // 
            this.gbxOptional.Controls.Add(this.cbxPrintCoveringLetter);
            this.gbxOptional.Controls.Add(this.cbxPrintPaymentVoucher);
            this.gbxOptional.Location = new System.Drawing.Point(599, 65);
            this.gbxOptional.Name = "gbxOptional";
            this.gbxOptional.Size = new System.Drawing.Size(325, 34);
            this.gbxOptional.TabIndex = 3;
            this.gbxOptional.TabStop = false;
            this.gbxOptional.Text = "Optional";
            this.gbxOptional.Visible = false;
            // 
            // cbxPrintCoveringLetter
            // 
            this.cbxPrintCoveringLetter.AutoSize = true;
            this.cbxPrintCoveringLetter.Location = new System.Drawing.Point(188, 13);
            this.cbxPrintCoveringLetter.Name = "cbxPrintCoveringLetter";
            this.cbxPrintCoveringLetter.Size = new System.Drawing.Size(122, 17);
            this.cbxPrintCoveringLetter.TabIndex = 2;
            this.cbxPrintCoveringLetter.Text = "Print Covering Letter";
            this.cbxPrintCoveringLetter.UseVisualStyleBackColor = true;
            // 
            // cbxPrintPaymentVoucher
            // 
            this.cbxPrintPaymentVoucher.AutoSize = true;
            this.cbxPrintPaymentVoucher.Location = new System.Drawing.Point(36, 13);
            this.cbxPrintPaymentVoucher.Name = "cbxPrintPaymentVoucher";
            this.cbxPrintPaymentVoucher.Size = new System.Drawing.Size(134, 17);
            this.cbxPrintPaymentVoucher.TabIndex = 1;
            this.cbxPrintPaymentVoucher.Text = "Print Payment Voucher";
            this.cbxPrintPaymentVoucher.UseVisualStyleBackColor = true;
            // 
            // gbxCrossing
            // 
            this.gbxCrossing.Controls.Add(this.cbxNotNegotiable);
            this.gbxCrossing.Controls.Add(this.cbxAccountPayeeOnly);
            this.gbxCrossing.Location = new System.Drawing.Point(16, 65);
            this.gbxCrossing.Name = "gbxCrossing";
            this.gbxCrossing.Size = new System.Drawing.Size(257, 34);
            this.gbxCrossing.TabIndex = 1;
            this.gbxCrossing.TabStop = false;
            this.gbxCrossing.Text = "Crossing";
            this.gbxCrossing.Visible = false;
            // 
            // cbxNotNegotiable
            // 
            this.cbxNotNegotiable.AutoSize = true;
            this.cbxNotNegotiable.Location = new System.Drawing.Point(154, 14);
            this.cbxNotNegotiable.Name = "cbxNotNegotiable";
            this.cbxNotNegotiable.Size = new System.Drawing.Size(97, 17);
            this.cbxNotNegotiable.TabIndex = 2;
            this.cbxNotNegotiable.Text = "Not Negotiable";
            this.cbxNotNegotiable.UseVisualStyleBackColor = true;
            this.cbxNotNegotiable.CheckedChanged += new System.EventHandler(this.cbxNotNegotiable_CheckedChanged);
            // 
            // cbxAccountPayeeOnly
            // 
            this.cbxAccountPayeeOnly.AutoSize = true;
            this.cbxAccountPayeeOnly.Location = new System.Drawing.Point(16, 14);
            this.cbxAccountPayeeOnly.Name = "cbxAccountPayeeOnly";
            this.cbxAccountPayeeOnly.Size = new System.Drawing.Size(123, 17);
            this.cbxAccountPayeeOnly.TabIndex = 1;
            this.cbxAccountPayeeOnly.Text = "Account Payee Only";
            this.cbxAccountPayeeOnly.UseVisualStyleBackColor = true;
            this.cbxAccountPayeeOnly.CheckedChanged += new System.EventHandler(this.cbxAccountPayeeOnly_CheckedChanged);
            // 
            // gbxOptions
            // 
            this.gbxOptions.Controls.Add(this.cbxNotAbove);
            this.gbxOptions.Controls.Add(this.cbxPayableAtPar);
            this.gbxOptions.Controls.Add(this.cbxBearerStrike);
            this.gbxOptions.Location = new System.Drawing.Point(285, 65);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(302, 34);
            this.gbxOptions.TabIndex = 2;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Options";
            this.gbxOptions.Visible = false;
            // 
            // cbxNotAbove
            // 
            this.cbxNotAbove.AutoSize = true;
            this.cbxNotAbove.Location = new System.Drawing.Point(218, 13);
            this.cbxNotAbove.Name = "cbxNotAbove";
            this.cbxNotAbove.Size = new System.Drawing.Size(77, 17);
            this.cbxNotAbove.TabIndex = 3;
            this.cbxNotAbove.Text = "Not Above";
            this.cbxNotAbove.UseVisualStyleBackColor = true;
            this.cbxNotAbove.CheckedChanged += new System.EventHandler(this.cbxNotAbove_CheckedChanged);
            // 
            // cbxPayableAtPar
            // 
            this.cbxPayableAtPar.AutoSize = true;
            this.cbxPayableAtPar.Location = new System.Drawing.Point(115, 14);
            this.cbxPayableAtPar.Name = "cbxPayableAtPar";
            this.cbxPayableAtPar.Size = new System.Drawing.Size(96, 17);
            this.cbxPayableAtPar.TabIndex = 2;
            this.cbxPayableAtPar.Text = "Payable At Par";
            this.cbxPayableAtPar.UseVisualStyleBackColor = true;
            this.cbxPayableAtPar.CheckedChanged += new System.EventHandler(this.cbxPayableAtPar_CheckedChanged);
            // 
            // cbxBearerStrike
            // 
            this.cbxBearerStrike.AutoSize = true;
            this.cbxBearerStrike.Location = new System.Drawing.Point(21, 14);
            this.cbxBearerStrike.Name = "cbxBearerStrike";
            this.cbxBearerStrike.Size = new System.Drawing.Size(87, 17);
            this.cbxBearerStrike.TabIndex = 1;
            this.cbxBearerStrike.Text = "Bearer Strike";
            this.cbxBearerStrike.UseVisualStyleBackColor = true;
            this.cbxBearerStrike.CheckedChanged += new System.EventHandler(this.cbxBearerStrike_CheckedChanged);
            // 
            // gbxChequeDetails
            // 
            this.gbxChequeDetails.Controls.Add(this.txtPayee);
            this.gbxChequeDetails.Controls.Add(this.cbxPrintPayeeAccountNumber);
            this.gbxChequeDetails.Controls.Add(this.btnAddExpense);
            this.gbxChequeDetails.Controls.Add(this.cmbExpense);
            this.gbxChequeDetails.Controls.Add(this.lblExpense);
            this.gbxChequeDetails.Controls.Add(this.lblSelectDate);
            this.gbxChequeDetails.Controls.Add(this.lblAmountNotforPrinting);
            this.gbxChequeDetails.Controls.Add(this.lblPayee);
            this.gbxChequeDetails.Controls.Add(this.dtpDateOnCheque);
            this.gbxChequeDetails.Controls.Add(this.txtAmount);
            this.gbxChequeDetails.Location = new System.Drawing.Point(16, -1);
            this.gbxChequeDetails.Name = "gbxChequeDetails";
            this.gbxChequeDetails.Size = new System.Drawing.Size(984, 65);
            this.gbxChequeDetails.TabIndex = 0;
            this.gbxChequeDetails.TabStop = false;
            this.gbxChequeDetails.Text = "Cheque Details";
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(123, 6);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(240, 20);
            this.txtPayee.TabIndex = 11;
            this.txtPayee.TextChanged += new System.EventHandler(this.txtPayee_TextChanged);
            this.txtPayee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayee_KeyPress);
            // 
            // cbxPrintPayeeAccountNumber
            // 
            this.cbxPrintPayeeAccountNumber.AutoSize = true;
            this.cbxPrintPayeeAccountNumber.Location = new System.Drawing.Point(369, 40);
            this.cbxPrintPayeeAccountNumber.Name = "cbxPrintPayeeAccountNumber";
            this.cbxPrintPayeeAccountNumber.Size = new System.Drawing.Size(163, 17);
            this.cbxPrintPayeeAccountNumber.TabIndex = 10;
            this.cbxPrintPayeeAccountNumber.Text = "Print Payee Account Number";
            this.cbxPrintPayeeAccountNumber.UseVisualStyleBackColor = true;
            this.cbxPrintPayeeAccountNumber.CheckedChanged += new System.EventHandler(this.cbxPrintPayeeAccountNumber_CheckedChanged);
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.btnAddExpense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddExpense.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.btnAddExpense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnAddExpense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnAddExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExpense.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnAddExpense.Location = new System.Drawing.Point(882, 35);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(22, 20);
            this.btnAddExpense.TabIndex = 5;
            this.btnAddExpense.UseVisualStyleBackColor = false;
            // 
            // cmbExpense
            // 
            this.cmbExpense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpense.FormattingEnabled = true;
            this.cmbExpense.Items.AddRange(new object[] {
            "Personal",
            "Octrai",
            "Factory Expense",
            "Manufacturing",
            "Inward",
            "Imapard",
            "Tax",
            "Wages",
            "Freight",
            "Carriage",
            "Royality on Production",
            "Factory depreciation",
            "Fuel",
            "Office expenses",
            "Sales",
            "Advertising",
            "Administrative expenses",
            "Interest on loan",
            "Commisions",
            "Telehone bill",
            "Electricity bill",
            ""});
            this.cmbExpense.Location = new System.Drawing.Point(636, 37);
            this.cmbExpense.Name = "cmbExpense";
            this.cmbExpense.Size = new System.Drawing.Size(240, 21);
            this.cmbExpense.TabIndex = 4;
            // 
            // lblExpense
            // 
            this.lblExpense.AutoSize = true;
            this.lblExpense.Location = new System.Drawing.Point(549, 40);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.Size = new System.Drawing.Size(81, 13);
            this.lblExpense.TabIndex = 9;
            this.lblExpense.Text = "Select Expense";
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.AutoSize = true;
            this.lblSelectDate.Location = new System.Drawing.Point(558, 13);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(63, 13);
            this.lblSelectDate.TabIndex = 8;
            this.lblSelectDate.Text = "Select Date";
            // 
            // lblAmountNotforPrinting
            // 
            this.lblAmountNotforPrinting.Location = new System.Drawing.Point(7, 39);
            this.lblAmountNotforPrinting.Name = "lblAmountNotforPrinting";
            this.lblAmountNotforPrinting.Size = new System.Drawing.Size(110, 15);
            this.lblAmountNotforPrinting.TabIndex = 7;
            this.lblAmountNotforPrinting.Text = "Amount";
            // 
            // lblPayee
            // 
            this.lblPayee.Location = new System.Drawing.Point(7, 15);
            this.lblPayee.Name = "lblPayee";
            this.lblPayee.Size = new System.Drawing.Size(110, 15);
            this.lblPayee.TabIndex = 6;
            this.lblPayee.Text = "Select Payee";
            // 
            // dtpDateOnCheque
            // 
            this.dtpDateOnCheque.CustomFormat = "dd MMM yyyy";
            this.dtpDateOnCheque.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOnCheque.Location = new System.Drawing.Point(636, 12);
            this.dtpDateOnCheque.Name = "dtpDateOnCheque";
            this.dtpDateOnCheque.Size = new System.Drawing.Size(240, 20);
            this.dtpDateOnCheque.TabIndex = 2;
            this.dtpDateOnCheque.ValueChanged += new System.EventHandler(this.dtpDateOnCheque_ValueChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(123, 37);
            this.txtAmount.MaxLength = 12;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(240, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress_1);
            // 
            // pd
            // 
            this.pd.OriginAtMargins = true;
            this.pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            // 
            // ppd
            // 
            this.ppd.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppd.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppd.ClientSize = new System.Drawing.Size(400, 300);
            this.ppd.Enabled = true;
            this.ppd.Icon = ((System.Drawing.Icon)(resources.GetObject("ppd.Icon")));
            this.ppd.Name = "ppd";
            this.ppd.Visible = false;
            // 
            // pdl
            // 
            this.pdl.UseEXDialog = true;
            // 
            // frmChequeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 733);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmChequeEntry";
            this.Text = "frmChequeEntry";
            this.Load += new System.EventHandler(this.frmChequeEntry_Load);
            this.pnlBody.ResumeLayout(false);
            this.gbxAddOrRemoveFields.ResumeLayout(false);
            this.gbxAddOrRemoveFields.PerformLayout();
            this.pnlWorkSpace.ResumeLayout(false);
            this.pnlCheque.ResumeLayout(false);
            this.pnlCheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBearerStrike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSignatoryStamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotNegotiable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotAbove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPayableAtPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxACPayeeOnly)).EndInit();
            this.gbxOptional.ResumeLayout(false);
            this.gbxOptional.PerformLayout();
            this.gbxCrossing.ResumeLayout(false);
            this.gbxCrossing.PerformLayout();
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            this.gbxChequeDetails.ResumeLayout(false);
            this.gbxChequeDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbxAddOrRemoveFields;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlWorkSpace;
        private System.Windows.Forms.Panel pnlCheque;
        private System.Windows.Forms.PictureBox pbxBearerStrike;
        private System.Windows.Forms.PictureBox pbxSignatoryStamp;
        private System.Windows.Forms.Label lblNotAboveAmount;
        private System.Windows.Forms.PictureBox pbxNotNegotiable;
        private System.Windows.Forms.PictureBox pbxNotAbove;
        private System.Windows.Forms.PictureBox pbxPayableAtPar;
        private System.Windows.Forms.PictureBox pbxACPayeeOnly;
        private System.Windows.Forms.Label lblAuthorizedSignatory;
        private System.Windows.Forms.Label lblForCompany;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountInWords2;
        private System.Windows.Forms.Label lblAmountInWords1;
        private System.Windows.Forms.Label lblPayeeLine2;
        private System.Windows.Forms.Label lblPayeeLine1;
        private System.Windows.Forms.GroupBox gbxOptional;
        private System.Windows.Forms.CheckBox cbxPrintCoveringLetter;
        private System.Windows.Forms.CheckBox cbxPrintPaymentVoucher;
        private System.Windows.Forms.GroupBox gbxCrossing;
        private System.Windows.Forms.CheckBox cbxNotNegotiable;
        private System.Windows.Forms.CheckBox cbxAccountPayeeOnly;
        private System.Windows.Forms.GroupBox gbxOptions;
        private System.Windows.Forms.CheckBox cbxNotAbove;
        private System.Windows.Forms.CheckBox cbxPayableAtPar;
        private System.Windows.Forms.CheckBox cbxBearerStrike;
        private System.Windows.Forms.GroupBox gbxChequeDetails;
        public System.Windows.Forms.CheckBox cbxPrintPayeeAccountNumber;
        private System.Windows.Forms.Button btnAddExpense;
        private System.Windows.Forms.ComboBox cmbExpense;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblSelectDate;
        private System.Windows.Forms.Label lblAmountNotforPrinting;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.DateTimePicker dtpDateOnCheque;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Drawing.Printing.PrintDocument pd;
        private System.Windows.Forms.PrintPreviewDialog ppd;
        private System.Windows.Forms.PrintDialog pdl;
        private System.Windows.Forms.PageSetupDialog psd;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label DateSpace;
        private System.Windows.Forms.Button btnNarrowSpace;
        private System.Windows.Forms.Button btnIncreaseSpace;
        private System.Windows.Forms.Button btnSelectPrnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDateDown;
        private System.Windows.Forms.Button btnDateUp;
        private System.Windows.Forms.Button btnDateRight;
        private System.Windows.Forms.Button btnDateLeft;
        private System.Windows.Forms.Button btnAmountDown;
        private System.Windows.Forms.Button btnAmountUp;
        private System.Windows.Forms.Button btnAmountRight;
        private System.Windows.Forms.Button btnAmountLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPayeeDown;
        private System.Windows.Forms.Button btnPayeeUp;
        private System.Windows.Forms.Button btnPayeeRight;
        private System.Windows.Forms.Button btnPayeeLeft;
        private System.Windows.Forms.RadioButton rb900;
        private System.Windows.Forms.RadioButton rb600;
        private System.Windows.Forms.RadioButton rb300;
        private System.Windows.Forms.Button btnInstallPrinter;
        private System.Windows.Forms.Button btnAddPrinter;
    }
}