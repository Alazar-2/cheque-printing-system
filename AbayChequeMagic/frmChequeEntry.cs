using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AbayChequeMagic
{
    public partial class frmChequeEntry : Form
    {
        public frmChequeEntry()
        {
            InitializeComponent();
        }

        #region public variables
        System.Drawing.Printing.PrintDocument pdc = new System.Drawing.Printing.PrintDocument();
        private int inHardMarginY = 10;
        private string strLeafId = string.Empty;
        private const int inPrintErrorFactor = 16;
        PaperSize psMatching = new PaperSize();
        DataTable dtblLayout = new DataTable();
        StatusInfo infoStatus;
        PayeeAccountDetailsSP SPPayeeAccountDetails = new PayeeAccountDetailsSP();
        DataTable dtblFieldStatus = new DataTable();
        DataTable dtblChequeLayout;
        public decimal decLeafId;
        int inNumberOfPrintableCharactres = 0;
        decimal decLeafDetailsId = 0;
        private string strAccountNumber = string.Empty;
        private decimal decCurrentBalance = 0;
        private decimal decchequeAmount = 0;
        private DateTime dtChequeDate;
        private string strCurrency = string.Empty;
        bool IsAmountInWordsLine2;
        bool IsPayeeLine2;
        bool IsPrintPayeeAccountNumber = false;
        bool IsAmountInWordsSuffix = false;
        bool IsAmountSuffix = false;
        bool IsamountPrefix = false;
        Label lblCombined = new Label();
        private string strFractionalPart = string.Empty;
        private Font font;
        private Brush brush;
        private string strPayeeAccountNumber = string.Empty;
        public static string strPrinterName = string.Empty;
        string strPaperSizeName = string.Empty;
        private string[] strComboItems = { "Payee", "Account Number", "Date", "Amount In Words", "For Company", "Authorized Signatory", "Siganture Stamp", "Amount In Words Suffix", "Amount Suffix", "Amount Prefix" };
        bool isPrintCanceled = false;
        #endregion

        #region functions
        
        private bool SetPaperSize()
        {
            int inIndex = 0;
            float flCSizeH = (float)((decimal)pnlCheque.Size.Width / 38) * 39.3701f;
            float flCsizeW = (float)((decimal)pnlCheque.Size.Height / 38) * 39.3701f;
            pd.DefaultPageSettings.Landscape = true;
            for (int inCount = 0; inCount < pd.PrinterSettings.PaperSizes.Count; inCount++)
            {
                if (pd.PrinterSettings.PaperSizes[inCount].Height < flCSizeH + 5 && pd.PrinterSettings.PaperSizes[inCount].Height > flCSizeH - 5
                    && pd.PrinterSettings.PaperSizes[inCount].Width < flCsizeW + 5 && pd.PrinterSettings.PaperSizes[inCount].Width > flCsizeW - 5
                    )
                {
                    inIndex = inCount;
                    pd.DefaultPageSettings.PaperSize = pd.PrinterSettings.PaperSizes[inIndex];
                    pd.DefaultPageSettings.Landscape = true;
                    return true;

                }
            }
            return MyMessageBox.ShowBox("Papersize of your cheque could not be found in your default printer.\"" +

            pd.DefaultPageSettings.PrinterSettings.PrinterName + "\". Add a custom papersize or click 'OK' to proceed", "Cheque Magic", MyMessageBox.Buttons.OKCancel, MyMessageBox.Icons.Exclamation) == MyMessageBox.Result.OK;

        }
        private bool SetPaperSize(int ink)
        {
            psMatching = new PaperSize();
            psMatching.Height = 0;
            int inHeightDifferenceOne = 10000;
            int inWidthDifferenceOne = 10000;
            int inHeightDifferenceTwo = 0;
            int inWidthDifferenceTwo = 0;
            int inH = pnlCheque.Size.Height;
            int inW = pnlCheque.Size.Width;
            Cursor = Cursors.WaitCursor;
            bool IsPaperSizeFound = false;
            for (int inCount = 0; inCount < pd.PrinterSettings.PaperSizes.Count; inCount++)
            {

                if (psMatching.Height == 0)
                {
                    psMatching = pd.PrinterSettings.PaperSizes[inCount];
                }
                else
                {
                    if (pd.PrinterSettings.PaperSizes[inCount].Height < (inW + 25) / 0.96 && pd.PrinterSettings.PaperSizes[inCount].Height > (inW - 25) / 0.96 &&
                        pd.PrinterSettings.PaperSizes[inCount].Width < (inH + 25) / 0.96 && pd.PrinterSettings.PaperSizes[inCount].Width > (inH - 25) / .96)
                    {
                        inHeightDifferenceTwo = int.Parse((pnlCheque.Size.Height - pd.PrinterSettings.PaperSizes[inCount].Height).ToString());
                        inWidthDifferenceTwo = int.Parse((pnlCheque.Size.Width - pd.PrinterSettings.PaperSizes[inCount].Width).ToString());
                        if (inHeightDifferenceTwo < 0)
                        {
                            inHeightDifferenceTwo = -1 * inHeightDifferenceTwo;
                        }
                        if (inWidthDifferenceTwo < 0)
                        {
                            inWidthDifferenceTwo = -1 * inWidthDifferenceTwo;
                        }
                        if (inHeightDifferenceTwo < inHeightDifferenceOne && inWidthDifferenceTwo < inWidthDifferenceOne)
                        {
                            psMatching = pd.PrinterSettings.PaperSizes[inCount];
                            inHeightDifferenceOne = inHeightDifferenceTwo;
                            inWidthDifferenceOne = inWidthDifferenceTwo;
                            psMatching = pd.PrinterSettings.PaperSizes[inCount];
                            IsPaperSizeFound = true;
                        }
                    }

                }
            }
            pd.DefaultPageSettings.PaperSize = psMatching;
            Cursor = Cursors.Default;
            return IsPaperSizeFound;
        }

        public void DoPrint()
        {
            inHardMarginY = (int)pd.PrinterSettings.DefaultPageSettings.HardMarginY;
            if (SetPaperSize())
            {
                if (!SetPaperSize(10))
                {
                    if (!Messages.QuestionMessage("The papersize of your cheque could not be found in your default printer \"" +
                        pd.DefaultPageSettings.PrinterSettings.PrinterName + "\". Add a custom papersize. " +
                        "Do you want to testprint with default settings?"))
                    {
                        return;
                    }
                    pd.DefaultPageSettings.Landscape = true;
                }
                pd.Print();
                isPrintCanceled = true;
            }
        }
        public void PrintcoveringLetter()
        {
            if (cbxPrintCoveringLetter.Checked)
            {
                new PrintCoveringLetter(strPrinterName);
            }
        }
        public void FillGrid()
        {
            frmChequeDetailsHome frmGrid;
            if ((frmGrid = (frmChequeDetailsHome)Application.OpenForms["frmChequeDetailsHome"]) != null)
            {
                if (frmGrid.decChequeBookId == new LeafSP().LeafGetChequeBookIdFromLeafId(decLeafId))
                {
                    frmGrid.FillGrid(frmGrid.decChequeBookId);
                }
            }
        }
        public void PopulateComboCustom()
        {
            string payeeName = txtPayee.Text;
            //int inIndex = int.Parse(cmbPayee.SelectedValue.ToString());
            //if (cbxPrintPayeeAccountNumber.Checked)
            //{
            //    cmbPayee.DataSource = new PayeeSP().PayeeAccountGetPayeeWithAccountNumber();
            //}
            //else
            //{
            //    cmbPayee.DataSource = new PayeeSP().PayeeViewAndSelect();
            //}
            //cmbPayee.SelectedValue = inIndex;
        }
        public void PrintPaymentVoucher()
        {
            if (cbxPrintPaymentVoucher.Checked)
            {
                CompanySP SPCompany = new CompanySP();
                DataTable dtblCompany = SPCompany.CompanyViewDetails();
                string strCompanyName = "";
                string strAddress = "";
                if (dtblCompany.Rows.Count > 0)
                {
                    strCompanyName = dtblCompany.Rows[0][0].ToString();
                    strAddress = dtblCompany.Rows[0][1].ToString();
                }
                DataTable dtblPaymentVocuher = new DataTable();
                DataColumn dc = new DataColumn("payeeNameLine1");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("payeeNameLine2");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("issuedDate");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("currentDate");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("amountInFigurs");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("amountInWordsLine1");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("amountInWordsLine2");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("accountPayeeonly");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("chequeNumber");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("bankname");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("currency");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("currencySymbol");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("companyName");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("address");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("extraOne");
                dtblPaymentVocuher.Columns.Add(dc);
                dc = new DataColumn("extraTwo");
                dtblPaymentVocuher.Columns.Add(dc);
                string strCheqleafNumber = new leafDetailsSP().LeafDetailsGetChequeNumberFromLeafId(decLeafId);
                string strBankName = new LeafSP().LeafGetBankNameFromLeafId(decLeafId);
                dtblPaymentVocuher.Rows.Add(new object[] { lblPayeeLine1.Text, lblPayeeLine2.Text, dtpDateOnCheque.Value.ToString("dd:MMM:yyy"), DateTime.Now.ToString("dd:MMM:yyy"), lblAmount.Text, lblAmountInWords1.Text, lblAmountInWords2.Text, "accountpayeeonly", strCheqleafNumber, strBankName, strCurrency, "", strCompanyName, strAddress, "", "" });
              //  crptPaymentVoucherPrint crptPaymentVoucherobj = new crptPaymentVoucherPrint();
             //   crptPaymentVoucherobj.Database.Tables["dtblPaymentVoucher"].SetDataSource(dtblPaymentVocuher);
             //   if ((strPrinterName = new CompanySP().CompanySelectPrinter()) != "")
              //  {
                  //  crptPaymentVoucherobj.PrintOptions.PrinterName = strPrinterName;
              //  }
               // crptPaymentVoucherobj.PrintToPrinter(1, false, 1, 1);

            }

        }
        public void GetPayeeAccountDetails()
        {


        }
        public void SetAmountInWords()
        {
            if (txtAmount.Text != string.Empty)
            {
                double dblAmount = double.Parse(txtAmount.Text);
                lblAmount.Text = String.Format("{0:n2}", dblAmount);
                decchequeAmount = decimal.Parse(string.Format("{0:n2}", dblAmount));
                string[] strAmount = lblAmount.Text.Split('.');
                string strAmountInWordsLeft = String.Empty;
                string strAmountInWordsRight = string.Empty;
                int inLeftPart;
                int inRightPart;
                if ((inLeftPart = int.Parse(strAmount[0].Replace(",", ""))) > 0)
                {
                    strAmountInWordsLeft = new FigursToWords().NumberToText(inLeftPart) + " " + strCurrency;
                }
                if ((inRightPart = int.Parse(strAmount[1].Replace(",", ""))) > 0)
                {
                    strAmountInWordsRight = new FigursToWords().NumberToText(inRightPart) + " " + strFractionalPart;
                    if (inLeftPart > 0)
                    {
                        strAmountInWordsRight = " And " + strAmountInWordsRight;
                    }
                }

                lblCombined.Text = strAmountInWordsLeft + strAmountInWordsRight + " Only";


                if (IsAmountInWordsSuffix)
                {

                    lblCombined.Text = "***" + lblCombined.Text;

                }
                if (IsAmountSuffix)
                {
                    lblAmount.Text = lblAmount.Text + "/-";
                }
                if (IsamountPrefix)
                {
                    lblAmount.Text = "***" + lblAmount.Text;
                }
                lblAmountInWords1.Text = lblCombined.Text.Substring(0, FindBreakPoint(GetNumberOfPrintableCharactres(lblCombined.Text, lblAmountInWords1), lblCombined));
                lblAmountInWords2.Text = lblCombined.Text.Substring(lblAmountInWords1.Text.Length);

            }
            else
            {
                lblAmount.Text = string.Empty;
                lblAmountInWords1.Text = string.Empty;
                lblAmountInWords2.Text = string.Empty;
            }
        }
        public void UpdateBalance()
        {
            decimal decTransactionId = new LeafSP().LeafGetTransactionId(decLeafId);
            if (decTransactionId != -1)
            {
                TransactionInfo InfoTransaction = new TransactionInfo();
                InfoTransaction.Amount = decchequeAmount;
                InfoTransaction.TransactionType = "Withdraw";
                InfoTransaction.TransactionId = decTransactionId;
             //   new TransactionSP().TransactionUpdateOnPrint(InfoTransaction);
            }
            else
            {
                TransactionInfo InfoTransaction = new TransactionInfo();
                InfoTransaction.Amount = decchequeAmount;
                InfoTransaction.TransactionType = "Withdraw";
             //   InfoTransaction.AccountId = new LeafSP().LeafGetAccountID(decLeafId);
             //   new TransactionSP().TransactionAddOnPrint(InfoTransaction);
             //   new LeafSP().LeafAddTrnasactionId(decLeafId);
            }
        }
        public void TransactionAdd()
        {
            TransactionSP SPTransaction = new TransactionSP();

        }
        public bool SaveChequeDetails()
        {
            if (ValidateForSave())
            {
                // update cheque details
                if (lblAmount.Text == String.Empty)
                {
                    decchequeAmount = 0;
                }
                else
                {
                    decchequeAmount = decimal.Parse(String.Format("{0:n2}", double.Parse(txtAmount.Text)));
                }
                leafDetailsInfo infoLeafDetails = new leafDetailsInfo();
                infoLeafDetails.LeafDetailsId = decLeafDetailsId;
                infoLeafDetails.LeafId = decLeafId;
                infoLeafDetails.Amount = decchequeAmount;
                if (cmbExpense.SelectedValue == null)
                {
                    infoLeafDetails.ExpenseId = 0;
                }
                if (cmbExpense.SelectedValue != null)
                {
                    infoLeafDetails.ExpenseId = decimal.Parse(cmbExpense.SelectedValue.ToString());
                }
                else
                {
                    infoLeafDetails.ExpenseId = 0;
                }
                infoLeafDetails.IssuedDate = dtpDateOnCheque.Value;
                //if (cmbPayee.SelectedValue == null)
                //{
                //    cmbPayee.SelectedValue = 0;
                //}
                infoLeafDetails.PayeeId = 1;// decimal.Parse(cmbPayee.SelectedValue.ToString());
                //if (cmbPayee.SelectedIndex == -1)
                //{
                //    infoLeafDetails.PayeeId = 0;
                //}
                if (cbxPrintPayeeAccountNumber.Checked)
                {
                    //if (((DataTable)(cmbPayee.DataSource)).Rows.Count > 2)
                    //{
                    //    infoLeafDetails.PayeeAccountDetailsd = decimal.Parse(((DataTable)(cmbPayee.DataSource)).Rows[cmbPayee.SelectedIndex][2].ToString());
                    //}
                    //else
                    //{
                    //    infoLeafDetails.PayeeAccountDetailsd = -1;
                    //}
                }
                else
                {
                    infoLeafDetails.PayeeAccountDetailsd = -1;
                }
                StatusInfo infoStatus = new StatusInfo();
                infoStatus.LeafId = decLeafId;
                infoStatus.AccountNumber = lblAccountNo.Visible;
                infoStatus.AccountPayee = pbxACPayeeOnly.Visible;
                infoStatus.BearerStrike = pbxBearerStrike.Visible;
                infoStatus.ForCompany = lblForCompany.Visible;
                infoStatus.NonNegotiable = pbxNotNegotiable.Visible;
                infoStatus.NotAbove = pbxNotAbove.Visible;
                infoStatus.PayableAtPar = pbxPayableAtPar.Visible;
                infoStatus.SignatoryName = lblAuthorizedSignatory.Visible;
                infoStatus.SignatoryStamp = pbxSignatoryStamp.Visible;
                infoStatus.AmountSuffix = IsAmountSuffix;
                infoStatus.AmountPrefix = IsamountPrefix;
                infoStatus.AmountInWordsSuffix = IsAmountInWordsSuffix;
             //   new leafDetailsSP().LeafDetailsUpdate(infoLeafDetails);
             //   new StatusSP().StatusEditWithLeafId(infoStatus);
                return true;

            }
            return false;
        }
        public void GetLeafDetails()
        {

            decLeafDetailsId = new leafDetailsSP().getLeafDetailsIdFromLeafId(decLeafId);
            dtblLayout = new LeafSP().ViewLayoutDetailsFromLeafId(decLeafId);
            infoStatus = new StatusSP().StatusViewByLeafId(decLeafId);
            PopulateCombos();
            setPayeeAccountId();
            CurrencyInfo infoCurrency = new CurrencySP().CurrencyView();
            strCurrency = infoCurrency.currencyName;
            strFractionalPart = infoCurrency.fractionalPart;
            //if (cmbPayee.Items.Count > 0)
            //{
            //    cmbPayee.SelectedIndex = 0;
            //}
            GetParticulars();
            SuspendLayout();
            pnlCheque.Visible = false;
            PositionLayout();
            setPayeeAccountId();
            ResumeLayout();
            pnlCheque.Visible = true;
        }
        private void GetParticulars()
        {
            leafDetailsSP spLeafDetails = new leafDetailsSP();
            DataTable dtblLeafDetails = spLeafDetails.getLeafDetails(decLeafDetailsId);
            dtblChequeLayout = new ChequeLayoutSP().ChequeLayoutLayoutInfoFromLeafId(decLeafId);
            if (dtblChequeLayout.Rows.Count == 0)
            {
                Messages.ErrorMessage("Cheque layout information could not be loaded. Please Cheque all details associated with your Cheque layout");
                btnPrint.Enabled = false;
                btnPrintPreview.Enabled = false;
                return;
            }
            IsPayeeLine2 = bool.Parse(dtblChequeLayout.Rows[0]["payeeLineTwo"].ToString());
            IsAmountInWordsLine2 = bool.Parse(dtblChequeLayout.Rows[0]["amountInWordsTwo"].ToString());
            if (dtblLeafDetails.Rows.Count > 0)
            {
                cmbExpense.SelectedValue = dtblLeafDetails.Rows[0]["expenseId"].ToString();
               // cmbPayee.SelectedValue = dtblLeafDetails.Rows[0]["payeeId"].ToString();
                dtpDateOnCheque.Value = DateTime.Parse(dtblLeafDetails.Rows[0]["issuedDate"].ToString());
                dtChequeDate = dtpDateOnCheque.Value;
                txtAmount.Text = dtblLeafDetails.Rows[0]["amount"].ToString();
                decchequeAmount = decimal.Parse("10");
            }
            else
            {
                Messages.ErrorMessage("ChequeBook information could not be loaded. Please Cheque all details associated with your Chequebook");
                btnPrint.Enabled = false;
                btnPrintPreview.Enabled = false;
                return;
            }

            DataTable dtblAccountDetails = new LeafSP().getAccountNumberAndCurrentBalanceFromLeafID(decLeafId);
            if (dtblAccountDetails.Rows.Count > 0)
            {

                strAccountNumber = dtblAccountDetails.Rows[0][0].ToString();
                lblAccountNo.Text = strAccountNumber.ToString();
                decCurrentBalance = decimal.Parse(dtblAccountDetails.Rows[0][1].ToString());
            }
            else
            {
                Messages.InformationMessage("Account number and current balance could not be loaded. Please cheque your account details");


            }

        }
        private int GetNumberOfPrintableCharactres(string str, Control cntrl)
        {
            int inIndex;
            string strSubstring = string.Empty;
            for (inIndex = 0; inIndex < str.Length; inIndex++)
            {

                strSubstring = strSubstring + str[inIndex];
                // For all printing, same font is used. That of cmbPayee. And all controls with printing text has this font.
                SizeF textSize = TextRenderer.MeasureText(strSubstring, new Font(font.FontFamily, font.Size, font.Style));
                if (textSize.Width > cntrl.Width)
                {
                    inNumberOfPrintableCharactres = inIndex;// Find break point will be called immediately after this
                    return inIndex;
                }
            }
            inNumberOfPrintableCharactres = inIndex;
            return inIndex;
        }
        private Control FindControl(string accessibleName)
        {
            foreach (Control cntrl in this.pnlCheque.Controls)
            {
                if (cntrl.AccessibleName == accessibleName)
                {
                    return cntrl;
                }
            }

            return null;
        }
        public void PopulateCombos()
        {
            cmbExpense.ValueMember = "expenseId";
            cmbExpense.DisplayMember = "expenseName";
            cmbExpense.DataSource = new ExpenseSP().ExpenseViewAllAndSelect();
            //cmbPayee.ValueMember = "payeeId";
            //cmbPayee.DisplayMember = "payeename";
            //cmbPayee.DataSource = new PayeeSP().PayeeViewAndSelect();
        }
        public void PopulateExpenseIdOnly()
        {
            cmbExpense.ValueMember = "expenseId";
            cmbExpense.DisplayMember = "expenseName";
            cmbExpense.DataSource = new ExpenseSP().ExpenseViewAllAndSelect();
        }
        public void setPayeeAccountId()
        {
            //if (cmbPayee.SelectedValue != null)
            //{
            //    if (decimal.Parse(cmbPayee.SelectedValue.ToString()) > 0)
            //    {
            //        decimal decSelectedValue = Convert.ToDecimal(cmbPayee.SelectedValue);
            //        decimal decAccountid = new leafDetailsSP().LeafDetailsIsAccountSelected(decLeafId);
            //        if (decAccountid > 0)
            //        {
            //            cbxPrintPayeeAccountNumber.Checked = true;

            //            int inCount = 0;
            //            foreach (DataRow dr in ((DataTable)(cmbPayee.DataSource)).Rows)
            //            {
            //                if (decimal.Parse(dr["payeeId"].ToString()) == decSelectedValue && decimal.Parse(dr["payeeAccountDetailsd"].ToString()) == decAccountid)
            //                {
            //                    cmbPayee.SelectedIndex = inCount;
            //                    break;
            //                }
            //                inCount++;
            //            }
            //        }
            //    }
            //}
        }
        private string getFormatedDateForCurrentLeafId(int dateSpace)
        {
            DataTable dtbl = new DataTable();   //LeafSP().LeafGetDateFormateIdAndSpacingFromLeafId(decLeafId);
            string strFormatId = "";
            string strFormatedDate = "";
            string strDummy = "              ";
            int dateSpacing = 0;
            if (dtbl.Rows.Count == 0)
            //{

            //    return dtpDateOnCheque.Value.ToString("dd:MMM-yyyy");
            //}
            //else
            //{
                dateSpacing = dateSpace;// int.Parse(dtbl.Rows[0][1].ToString());
                string strReplace = "";
                if (dateSpacing == 0)
                {
                    strReplace = "\\";
                }
                strFormatId = "1";
               // if ((strFormatId = dtbl.Rows[0][0].ToString()) == "1")//------ //DD/MM/YYYY
                if (strFormatId == "1")
                {
                    foreach (char ch in dtpDateOnCheque.Value.ToString("dd:MM:yyy").Replace(":", strReplace))
                    {
                        strFormatedDate = strFormatedDate + ch.ToString() + strDummy.Substring(0, dateSpacing);
                    }
                    strFormatedDate.Trim();
                    return strFormatedDate;

                }
                else if (strFormatId == "2")//--------MM/DD/YYYY
                {
                    foreach (char ch in dtpDateOnCheque.Value.ToString("MM:dd:yyy").Replace(":", strReplace))
                    {
                        strFormatedDate = strFormatedDate + ch.ToString() + strDummy.Substring(0, dateSpacing);
                    }
                    strFormatedDate.Trim();
                    return strFormatedDate;
                }
                else if (strFormatId == "3")//---------YYYY/MM/DD
                {
                    foreach (char ch in dtpDateOnCheque.Value.ToString("yyy:MM:dd").Replace(":", strReplace))
                    {
                        strFormatedDate = strFormatedDate + ch.ToString() + strDummy.Substring(0, dateSpacing);
                    }
                    strFormatedDate.Trim();
                    return strFormatedDate;
                }
                else
                {
                    return dtpDateOnCheque.Value.ToString("dd:MM:yyy");
                }

           // }
        }
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private int FindBreakPoint(int inIndex, Control cntrl)
        {
            if (cntrl.Text.Length > inNumberOfPrintableCharactres)//findNumberOfPrintableCharacters is called just before this which sets inNu.. appropriatley
            {
                int inBreakPoint = inIndex;
                for (int inCount = 0; inCount < inIndex; inCount++)
                {
                    if (cntrl.Text[inCount].ToString() == " ")
                    {
                        inBreakPoint = inCount;

                    }
                    if (inCount == inIndex)
                    {

                        break;
                    }
                }
                return inBreakPoint;
            }
            else
            {
                return inIndex;
            }
        }
        private void PositionLayout()
        {
            if (dtblLayout.Rows.Count == 0)
            {
                Messages.InformationMessage("This Chequebook does not have a layout associated with . Please create one to proceed");
                btnPrint.Enabled = false;
                btnPrintPreview.Enabled = false;
                return;
            }
            dtblLayout.PrimaryKey = new DataColumn[] { dtblLayout.Columns["fieldName"] };
            if (decLeafId != 0)
            {
                string strImageLocation;
                try // Try-Catch is required here, beacse if event's try-catch is relayed on , the rest of this method will not be executed
                {
                    if ((strImageLocation = new LeafSP().LeafGetImageLocationFromLeafId(decLeafId)) != string.Empty)
                    {
                        pnlCheque.BackgroundImage = Image.FromFile(Application.StartupPath + strImageLocation);

                    }
                }
                catch
                {
                    //do nothing
                }
                DataRow dr;
                pnlCheque.Size = new Size(int.Parse(dtblLayout.Rows.Find("chequeSize")["width"].ToString()), int.Parse(dtblLayout.Rows.Find("chequeSize")["height"].ToString()));
                cbxPrintPayeeAccountNumber.Checked = infoStatus.PayeeAccountDetails;
                dr = dtblLayout.Rows.Find("accountPayeeOnly");
                pbxACPayeeOnly.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                pbxACPayeeOnly.Width = int.Parse(dr["width"].ToString());
                pbxACPayeeOnly.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("nonNegotiable");
                pbxNotNegotiable.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                pbxNotNegotiable.Width = int.Parse(dr["width"].ToString());
                pbxNotNegotiable.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("date"); //3.
                lblDate.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblDate.Visible = true;
                lblDate.Width = int.Parse(dr["width"].ToString());
                lblDate.Height = int.Parse(dr["height"].ToString());
               // ccbSelectField.SetItemChecked(2, true);
                dr = dtblLayout.Rows.Find("payeeLineTwo");
                lblPayeeLine2.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblPayeeLine2.Width = int.Parse(dr["width"].ToString());
                lblPayeeLine2.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("accountNumber");
                lblAccountNo.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblAccountNo.Width = int.Parse(dr["width"].ToString());
                lblAccountNo.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("forCompany");
                lblForCompany.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblForCompany.Width = int.Parse(dr["width"].ToString());
                lblForCompany.Height = int.Parse(dr["height"].ToString());
                string strCmp = new CompanySP().CompanyViewAll().Rows[0][1].ToString();
                dr = dtblLayout.Rows.Find("payableAtPar");
                pbxPayableAtPar.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                pbxPayableAtPar.Width = int.Parse(dr["width"].ToString());
                pbxPayableAtPar.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("notAbove");
                pbxNotAbove.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                pbxNotAbove.Width = int.Parse(dr["width"].ToString());
                pbxNotAbove.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("notAboveAmount");
                lblNotAboveAmount.Width = int.Parse(dr["width"].ToString());
                lblNotAboveAmount.Height = int.Parse(dr["height"].ToString());
                lblNotAboveAmount.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                dr = dtblLayout.Rows.Find("authorizedSignatoryName");
                lblAuthorizedSignatory.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblAuthorizedSignatory.Width = int.Parse(dr["width"].ToString());
                lblAuthorizedSignatory.Height = int.Parse(dr["height"].ToString());
                lblAuthorizedSignatory.Text = new AuthorizedSignatorySP().authorizedSignatoryGetName();
                dr = dtblLayout.Rows.Find("payeeLineOne"); //4.
                lblPayeeLine1.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblPayeeLine1.Width = int.Parse(dr["width"].ToString());
                lblPayeeLine1.Height = int.Parse(dr["height"].ToString());
                lblPayeeLine1.Visible = true;
               // ccbSelectField.SetItemChecked(0, true);
                dr = dtblLayout.Rows.Find("bearerStrike");
                pbxBearerStrike.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                pbxBearerStrike.Width = int.Parse(dr["width"].ToString());
                pbxBearerStrike.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("signatoryStamp");
                pbxSignatoryStamp.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                pbxSignatoryStamp.Width = int.Parse(dr["width"].ToString());
                pbxSignatoryStamp.Height = int.Parse(dr["height"].ToString());
                dr = dtblLayout.Rows.Find("amountInWordsLine1");  //7.
                lblAmountInWords1.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblAmountInWords1.Visible = true;
                lblAmountInWords1.Width = int.Parse(dr["width"].ToString());
                lblAmountInWords1.Height = int.Parse(dr["height"].ToString());
               // ccbSelectField.SetItemChecked(3, true);
                dr = dtblLayout.Rows.Find("amount"); //9.
                lblAmount.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                lblAmount.Visible = true;
                lblAmount.Width = int.Parse(dr["width"].ToString());
                lblAmount.Height = int.Parse(dr["height"].ToString());
                if (strCmp != string.Empty)
                {
                    lblForCompany.Text = "For " + strCmp;
                }
                if (infoStatus.AccountPayee)
                {
                    cbxAccountPayeeOnly.Checked = true;

                }
                if (infoStatus.NonNegotiable)
                {
                    cbxNotNegotiable.Checked = true;

                }

                if (IsPayeeLine2)
                {
                    lblPayeeLine2.Visible = true;
                }

                if (infoStatus.BearerStrike)
                {
                    cbxBearerStrike.Checked = true;

                }
                if (IsAmountInWordsLine2)
                {
                    lblAmountInWords2.Visible = true;
                    dr = dtblLayout.Rows.Find("amountInWordsLine2");  //8.
                    lblAmountInWords2.Location = new Point(int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()));
                    lblAmountInWords2.Width = int.Parse(dr["width"].ToString());
                    lblAmountInWords2.Height = int.Parse(dr["height"].ToString());
                }
                if (infoStatus.AccountNumber)
                {

                   // ccbSelectField.SetItemChecked(1, true);
                }
                if (infoStatus.ForCompany)
                {
                   // ccbSelectField.SetItemChecked(4, true);

                }
                if (infoStatus.SignatoryName)
                {

                   // ccbSelectField.SetItemChecked(5, true);
                }

                if (infoStatus.AmountInWordsSuffix)
                {
                   // ccbSelectField.SetItemChecked(7, true);

                }
                else
                {
                   // ccbSelectField.SetItemChecked(7, false);
                }
                if (infoStatus.AmountSuffix)
                {
                   // ccbSelectField.SetItemChecked(8, true);

                }
                else
                {
                  //  ccbSelectField.SetItemChecked(8, false);

                }
                if (infoStatus.AmountPrefix)
                {
                   // ccbSelectField.SetItemChecked(9, true);

                }
                else
                {
                   // ccbSelectField.SetItemChecked(9, false);
                }
                if (infoStatus.SignatoryStamp)
                {
                    pbxSignatoryStamp.Visible = true;
                   // ccbSelectField.SetItemChecked(6, true);
                }
                try
                {
                    byte[] arrImage = new AuthorizedSignatorySP().AuthorizedSignatoryViewImage();
                    if (arrImage != null)
                    {
                        pbxSignatoryStamp.Image = ByteArrayToImage(arrImage);
                        pbxACPayeeOnly.BackColor = System.Drawing.Color.Transparent;

                    }
                }
                catch (Exception ex)
                {
                    // do nothing
                }

                if (infoStatus.PayableAtPar)
                {
                    cbxPayableAtPar.Checked = true;
                    pbxPayableAtPar.Visible = true;
                }
                if (infoStatus.NotAbove)
                {

                    cbxNotAbove.Checked = true;

                }

            }
        }
        private bool ValidateFields()
        {
            //if (!infoStatus.AllowBlankAmountCheque && lblAmount.Text == string.Empty)
            //{
            //    if (!Messages.QuestionMessage("By default, blank amount cheque is not allowed for this Chequebook. Do you want to proceed anyway?"))
            //    {
            //        return false;
            //    }
            //}
            //if (!infoStatus.AllowPostDatedCheque && (dtpDateOnCheque.Value.Date > DateTime.Now.Date))
            //{
            //    if (!Messages.QuestionMessage("By default, post dated cheque is not allowed for this Chequebook. Do you want to proceed anyway?"))
            //    {
            //        return false;
            //    }
            //}
            //if (!infoStatus.AllowPreDatedCheque && (dtpDateOnCheque.Value.Date < DateTime.Now.Date))
            //{
            //    if (!Messages.QuestionMessage("By default, pre-dated cheque is not allowed for this Chequebook. Do you want to proceed anyway?"))
            //    {
            //        return false;
            //    }
            //}
            return true;
        }
        private bool ValidateForSave()
        {
            try
            {
                //if (cmbPayee.SelectedIndex == 0 || cmbPayee.SelectedIndex == -1)
                if(txtPayee.Text=="")
                {
                    Messages.InformationMessage("Please select payee");
                   // cmbPayee.Focus();
                    txtPayee.Focus();
                    return false;
                }
                if (cmbExpense.SelectedIndex == 0 || cmbExpense.SelectedIndex == -1)
                {
                    Messages.InformationMessage("Please select expense");
                    cmbExpense.Focus();
                    return false;
                }
                else if (lblDate.Text.Trim() == string.Empty)
                {
                    Messages.WarningMessage("Please select date");
                    return false;
                }
                //else if (decchequeAmount > decCurrentBalance && txtAmount.Text != string.Empty && decimal.Parse(txtAmount.Text) != 0)
                //{

                //    if (!Messages.QuestionMessage("This account does not have sufficient balance. Do you want to proceed?"))
                //    {
                //        return false;
                //    }
                //}
                if (!ValidateFields())
                {
                    return false;
                }

                return true;
            }
            catch (FormatException ex)
            {
                Messages.WarningMessage("Invalid Amount!");
                return false;
            }

        }
        private void ChangeFont()
        {
            this.SuspendLayout();
            foreach (Control cntrl in pnlCheque.Controls)
            {
                if (cntrl.Name != "lblDate")
                {
                    cntrl.Font = font;
                }


            }
            this.ResumeLayout();
        }
        public void addItemsToCheckedCombobox()
        {

            for (int i = 0; i < strComboItems.Length; i++)
            {
                CheckedComboBoxItem item = new CheckedComboBoxItem(strComboItems[i], i);
               // ccbSelectField.Items.Add(item);
            }
            // If more then 5 items, add a scroll bar to the dropdown.
            //ccbSelectField.MaxDropDownItems = 12;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            //ccbSelectField.DisplayMember = "Name";
            //ccbSelectField.ValueSeparator = ",  ";
            // Check the first 2 items
        }
        #endregion functions

        #region events
        private void frmChequeEntry_Load(object sender, EventArgs e)
        {
            //PrinterResolution pkResolution;
            //pkResolution = pd.DefaultPageSettings.PrinterResolution;
            //MessageBox.Show(pkResolution.ToString());
            //int cnt = pd.PrinterSettings.PrinterResolutions.Count;
            //MessageBox.Show(cnt.ToString());
            rb600.Checked = true;
            try
            {
                pdc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pdc_PrintPage);
                font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
                ChangeFont();
                brush = new SolidBrush(Color.Black);
                addItemsToCheckedCombobox();
                dateSpaceCustome = 6;
                lblDate.Text = getFormatedDateForCurrentLeafId(dateSpaceCustome);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }
        private void btnAddPayee_Click(object sender, EventArgs e)
        {
           // try
           // {
               // frmPayeeCreation frmPayeeCreation = new frmPayeeCreation();
                CompanySP spCompany = new CompanySP();
            //    if (spCompany.UserPrivilegeChecking(decimal.Parse(frmLogin.strLoginStatus), decimal.Parse(frmPayeeCreation.AccessibleName)))
            //    {
            //        //frmPayeeCreation.MinimizeBox = false;
            //        //frmPayeeCreation open = Application.OpenForms["frmPayeeCreation"] as frmPayeeCreation;
            //        if (open == null)
            //        {
            //           // frmPayeeCreation.ShowDialog();
            //        }
            //        else
            //        {
            //            //if (open.WindowState == FormWindowState.Minimized)
            //            //{
            //            //    open.WindowState = FormWindowState.Normal;
            //            //}
            //            //else
            //            //{
            //            //    open.Activate();
            //            //}
            //        }
            //    }
            //    else
            //    {
            //        Messages.NoPrivillageMessage();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Messages.ExceptionMessage(ex.Message);
            //}
        }
        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            try
            {
                //frmExpenseType frmExpenseType = new frmExpenseType();
                //CompanySP spCompany = new CompanySP();
                //if (spCompany.UserPrivilegeChecking(decimal.Parse(frmLogin.strLoginStatus), decimal.Parse(frmExpenseType.AccessibleName)))
                //{

                //    frmExpenseType.MinimizeBox = false;
                //    frmExpenseType open = Application.OpenForms["frmExpenseType"] as frmExpenseType;
                //    if (open == null)
                //    {
                //        frmExpenseType.ShowDialog();
                //    }
                //    else
                //    {
                //        if (open.WindowState == FormWindowState.Minimized)
                //        {
                //            open.WindowState = FormWindowState.Normal;
                //        }
                //        else
                //        {
                //            open.Activate();
                //        }
                //    }
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Messages.CloseMessage())
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveChequeDetails())
                {
                    UpdateBalance();
                    decimal decL = decLeafId;
                    FillGrid();
                    Common.strLeafId = decL.ToString();
                    Messages.SavedMessage();
                }

            }
            catch (FormatException ex)
            {
                Messages.WarningMessage("Invalid Amount");
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }
        private void frmChequeEntry_Activated(object sender, System.EventArgs e)
        {
            try
            {
                btnPrint.Enabled = true;
                btnPrintPreview.Enabled = true;
                if (Common.strLeafId == string.Empty)
                {
                    decLeafId = decimal.Parse(strLeafId);
                }
                else
                {
                    decLeafId = decimal.Parse(Common.strLeafId);
                }
                GetLeafDetails();

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {

                int inHardy = inHardMarginY;
                ppd.Document = pd;
                ppd.ShowDialog();
                inHardMarginY = inHardy;
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.Message);
            }
        }
        private void cbxBearerStrike_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxBearerStrike.Checked)
                {
                    pbxBearerStrike.Visible = true;
                }
                else
                {
                    pbxBearerStrike.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cbxAccountPayeeOnly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxAccountPayeeOnly.Checked)
                {
                    pbxACPayeeOnly.Visible = true;
                }
                else
                {
                    pbxACPayeeOnly.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cbxPayableAtPar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxPayableAtPar.Checked)
                {
                    pbxPayableAtPar.Visible = true;
                }
                else
                {
                    pbxPayableAtPar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cbxNotNegotiable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxNotNegotiable.Checked)
                {
                    pbxNotNegotiable.Visible = true;
                }
                else
                {
                    pbxNotNegotiable.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetAmountInWords();
                if (txtAmount.Text.Trim() != string.Empty)
                {
                    if (decimal.Parse(txtAmount.Text) == 0)
                    {
                        lblAmountInWords1.Text = string.Empty;
                        lblAmountInWords2.Text = string.Empty;
                    }
                }
                else
                {
                    lblAmountInWords1.Text = string.Empty;
                    lblAmountInWords2.Text = string.Empty;
                }
            }
            catch (OverflowException ex)
            {
                lblAmount.Text = "";
                lblAmountInWords1.Text = "";
                lblAmountInWords2.Text = "";
                //lblAmount.Text.Remove(10);
                //do nothing
            }
            catch (FormatException ex)
            {
                //Messages.ExceptionMessage(ex.Message);

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);

            }
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Common.NumberOnlyAndFloatingPoint(txtAmount, e);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            #region printcode of cheque magic
            try
            {
               // if (cmbPayee.SelectedValue != null)
                if(txtPayee.Text!="")
                {
                    Common.decPayeeId = 1;// decimal.Parse(cmbPayee.SelectedValue.ToString());
                    Common.strPayeeName = txtPayee.Text;
                }               
                if (cmbExpense.SelectedItem != null )
                {
                    Common.strExpense = cmbExpense.SelectedItem.ToString();
                }
                Common.strCurrency = strCurrency;
                Common.strIssuedDate = dtpDateOnCheque.Value.ToString("dd:MMM:yyyy");
                Common.strAmount = decchequeAmount.ToString();
                if (SaveChequeDetails())
                {
                  //  UpdateBalance();
                 //   strPrinterName = "";
                 //   strPrinterName = new CompanySP().CompanySelectPrinter();
                    //if ((strPrinterName = new CompanySP().CompanySelectPrinter()) != "")
                    //{
                    //    pd.PrinterSettings.PrinterName = '';
                    //inHardMarginY = (int)(pd.PrinterSettings.DefaultPageSettings.HardMarginY);

                    //}
                    //LeafSP SPleaf = new LeafSP();
                    //if (SPleaf.LeafIsPrinted(decLeafId) && !Messages.QuestionMessage("This cheque has already been printed. Do you want to reprint it?"))
                    //{
                    //    return;
                    //}
                    DataTable dtbl = dtblLayout;
                    DoPrint();
                    //if (isPrintCanceled)
                    //{
                    //    SPleaf.LeafSetAsPrinted(decLeafId);//sets both IsPrinted and ChequeStatus
                    //}
                 //   decimal decLeafIdOld = decLeafId;
                    FillGrid();
                  //  Common.strLeafId = decLeafIdOld.ToString();
                    PrintcoveringLetter();
                    PrintPaymentVoucher();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
#endregion

            //CaptureScreen();
            //pd.Print();
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void ccbSelectField_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                CheckedComboBoxItem item = new CheckedComboBoxItem(); // ccbSelectField.Items[e.Index] as CheckedComboBoxItem;
                string str = item.Name;
                if (item.Name == "Siganture Stamp")
                {
                    pbxSignatoryStamp.Visible = e.NewValue == CheckState.Checked;
                }
                else if (item.Name == "Payee")
                {
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        lblPayeeLine1.Visible = lblPayeeLine2.Visible = false;
                    }
                    else
                    {
                        lblPayeeLine1.Visible = true;
                    }
                }
                else if (item.Name == "Account Number")
                {
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        lblAccountNo.Visible = false;
                    }
                    else
                    {
                        lblAccountNo.Visible = true;
                    }
                }
                else if (item.Name == "Amount In Words")
                {
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        lblAmountInWords1.Visible = lblAmountInWords2.Visible = false;
                    }
                    else
                    {
                        lblAmountInWords1.Visible = true;
                    }
                }
                else if (item.Name == "Not Above")
                {
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        lblNotAboveAmount.Visible = false;
                        pbxNotAbove.Visible = false;
                    }
                    else
                    {
                        lblNotAboveAmount.Text = lblAmount.Text;
                        lblNotAboveAmount.Visible = true;
                        pbxNotAbove.Visible = true;
                    }
                }
                else if (item.Name == "Print payee account number with payee name")
                {
                    IsPrintPayeeAccountNumber = e.NewValue == CheckState.Checked;

                }



                else if (item.Name == "Amount In Words Suffix")
                {
                    IsAmountInWordsSuffix = (e.NewValue == CheckState.Checked);
                    txtAmount_TextChanged(null, null);
                }

                else if (item.Name == "Amount Suffix")
                {
                    IsAmountSuffix = (e.NewValue == CheckState.Checked);
                    txtAmount_TextChanged(null, null);
                }
                else if (item.Name == "Amount Prefix")
                {
                    IsamountPrefix = (e.NewValue == CheckState.Checked);
                    txtAmount_TextChanged(null, null);
                }
                else
                {

                    Control aControl = FindControl(str);
                    if (aControl != null)
                    {
                        if (e.NewValue == CheckState.Unchecked)
                        {
                            aControl.Visible = false;
                        }
                        else
                        {
                            aControl.Visible = true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cbxNotAbove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxNotAbove.Checked)
                {
                    lblNotAboveAmount.Visible = true;
                    pbxNotAbove.Visible = true;
                }
                else
                {
                    lblNotAboveAmount.Visible = false;
                    pbxNotAbove.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void dtpDateOnCheque_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = getFormatedDateForCurrentLeafId(dateSpaceCustome);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnCoveringLetter_Click(object sender, EventArgs e)
        {

            try
            {
                Common.decPayeeId = 1;// decimal.Parse(cmbPayee.SelectedValue.ToString());
                if (txtPayee.Text != null)
                {
                    Common.decPayeeId = 1;// decimal.Parse(cmbPayee.SelectedValue.ToString());
                    Common.strPayeeName = txtPayee.Text;
                }
                Common.strIssuedDate = dtpDateOnCheque.Value.ToString("dd:MMM:yyyy");
                Common.strAmount = decchequeAmount.ToString();
                if (cmbExpense.SelectedValue != null)
                {
                    Common.strExpense = cmbExpense.SelectedText;

                }
                //frmCoveringLetter frmCoveringLetterobj = new frmCoveringLetter();
                //frmCoveringLetter open = Application.OpenForms["frmCoveringLetter"] as frmCoveringLetter;
                //if (open == null)
                //{
                //    frmCoveringLetterobj.MdiParent = this.MdiParent;
                //    frmCoveringLetterobj.Show();
                //}
                //else
                //{
                //    frmCoveringLetterobj.MdiParent = this.MdiParent;
                //    if (open.WindowState == FormWindowState.Minimized)
                //    {
                //        open.WindowState = FormWindowState.Normal;
                //    }
                //    else
                //    {
                //        open.Activate();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Messages.InformationMessage(ex.Message);
            }

        }
        private void cmbExpense_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbExpense.SelectedValue != null)
                {
                    Common.decPayeeId = 1;// decimal.Parse(cmbPayee.SelectedValue.ToString());
                    Common.strPayeeName = cmbExpense.SelectedText;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void lblAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblNotAboveAmount.Text = lblAmount.Text;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cbxPrintPayeeAccountNumber_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateComboCustom();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog pdlga = new PrintDialog();
                pdlga.Document = pdc;
                if (pdlga.ShowDialog() == DialogResult.OK)
                {
                    pdc.Print();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        void pdc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
        private void frmChequeEntry_Deactivate(object sender, EventArgs e)
        {
            try
            {
                strLeafId = decLeafId.ToString();
                Common.strLeafId = strLeafId;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion events 


        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void txtPayee_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPayee_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtPayee.Text.Length > 0)
                {
                    if (txtPayee.Text != null)
                    {

                        lblPayeeLine1.Text = txtPayee.Text.Substring(0, FindBreakPoint(GetNumberOfPrintableCharactres(txtPayee.Text, lblPayeeLine1), txtPayee));
                        if (IsPayeeLine2)
                        {
                            lblPayeeLine2.Text = txtPayee.Text.Substring(lblPayeeLine1.Text.Length);
                            if (lblPayeeLine2.Text.Length > 0)
                            {
                                if (IsPayeeLine2)
                                {
                                    lblPayeeLine2.Visible = true;
                                }
                            }
                        }
                    }
                }

                else
                {
                    lblPayeeLine1.Text = string.Empty;
                    lblPayeeLine2.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Messages.InformationMessage(ex.Message);
            }
        }
        private int dateSpaceCustome = 4;
        private void btnNarrowSpace_Click(object sender, EventArgs e)
        {
            if(dateSpaceCustome>1)
            {
                dateSpaceCustome=dateSpaceCustome-1;
            }
            lblDate.Text = getFormatedDateForCurrentLeafId(dateSpaceCustome);
        }

        private void btnIncreaseSpace_Click(object sender, EventArgs e)
        {
            if (dateSpaceCustome > 0)
            {
                dateSpaceCustome = dateSpaceCustome + 1;
            }
            lblDate.Text = getFormatedDateForCurrentLeafId(dateSpaceCustome);

        }

        private void txtAmount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)8 && e.KeyChar != (char)46)
                {
                    MessageBox.Show("you pressed: " + e.KeyChar + "\n please enter number only");
                    e.KeyChar = (char)0;
                }
            }
        }

        private void btnSelectPrnt_Click(object sender, EventArgs e)
        {
            Add_printer ce = new Add_printer();
          //  ce.WindowState = FormWindowState.Maximized;
          //  Application.Run(ce);
            ce.Show();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if(rb300.Checked)
            {
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 300;
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 300;
            }
            else if(rb600.Checked)
            {
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 600;
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 600;
            }
            else if(rb900.Checked)
            {
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 900;
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 900;
            }
            else
            {
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 600;
                pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 600;
            }
             try
            {
                using (Graphics g = e.Graphics)
                {
                    SolidBrush brush = new SolidBrush(Color.Black);
                    foreach (Control cntrl in pnlCheque.Controls)
                    {
                        if (cntrl.Visible)
                        {
                            if (cntrl is PictureBox)
                            {
                                if (cntrl.Name == "pbxBearerStrike")
                                {
                                    g.DrawImage(((PictureBox)cntrl).Image, cntrl.Location.X , cntrl.Location.Y , cntrl.Width, cntrl.Height);
                                }
                                else if (((PictureBox)(cntrl)).Image != null)
                                {
                                    g.DrawImage(((PictureBox)cntrl).Image, cntrl.Location.X, cntrl.Location.Y , cntrl.Width, cntrl.Height);
                                }
                            }
                            else if (cntrl is Label)
                            {
                                if (cntrl.Name == "lblDate")
                                {
                                    g.DrawString(cntrl.Text, new Font("Comic Sans MS", 7.25F, System.Drawing.FontStyle.Regular), brush, cntrl.Location.X+200 , cntrl.Location.Y+136);
                                }
                                else if (cntrl.Name == "lblAmount")
                                {
                                    g.DrawString(cntrl.Text, font, brush, cntrl.Location.X+200 , cntrl.Location.Y+136);
                                }
                                else if (cntrl.Name == "lblPayeeLine1")
                                {
                                    g.DrawString(cntrl.Text, font, brush, cntrl.Location.X+200 , cntrl.Location.Y+136);
                                }
                                else if (cntrl.Name == "lblAmountInWords1")
                                {
                                    g.DrawString(cntrl.Text, font, brush, cntrl.Location.X+200 , cntrl.Location.Y+136);
                                } 
                                else
                                {
                                    g.DrawString(cntrl.Text, font, brush, cntrl.Location.X, cntrl.Location.Y);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message + " this exceprin");
            }
        }

       
        Point temp;// = new Point(0, 0);
        private void btnDateUp_Click(object sender, EventArgs e)
        {
            int xVal = lblDate.Location.X;
            int yVal = lblDate.Location.Y;
            yVal = yVal - 1;
            temp = new Point(xVal, yVal);
            lblDate.Location = temp;
        }
      
        private void btnDateDown_Click(object sender, EventArgs e)
        {
            int xVal = lblDate.Location.X;
            int yVal = lblDate.Location.Y;
            yVal = yVal + 1;
            temp = new Point(xVal, yVal);
            lblDate.Location = temp;
        }

        private void btnDateRight_Click(object sender, EventArgs e)
        {
            int xVal = lblDate.Location.X;
            int yVal = lblDate.Location.Y;
            xVal = xVal + 1;
            temp = new Point(xVal, yVal);
            lblDate.Location = temp;
        }

        private void btnDateLeft_Click(object sender, EventArgs e)
        {
            int xVal = lblDate.Location.X;
            int yVal = lblDate.Location.Y;
            xVal = xVal - 1;
            temp = new Point(xVal, yVal);
            lblDate.Location = temp;
        }

        private void btnAmountUp_Click(object sender, EventArgs e)
        {
            int xVal = lblAmount.Location.X;
            int yVal = lblAmount.Location.Y;
            yVal = yVal - 1;
            temp = new Point(xVal, yVal);
            lblAmount.Location = temp;
        }

        private void btnAmountDown_Click(object sender, EventArgs e)
        {
            int xVal = lblAmount.Location.X;
            int yVal = lblAmount.Location.Y;
            yVal = yVal + 1;
            temp = new Point(xVal, yVal);
            lblAmount.Location = temp;
        }

        private void btnAmountLeft_Click(object sender, EventArgs e)
        {
            int xVal = lblAmount.Location.X;
            int yVal = lblAmount.Location.Y;
            xVal = xVal - 1;
            temp = new Point(xVal, yVal);
            lblAmount.Location = temp;
        }

        private void btnAmountRight_Click(object sender, EventArgs e)
        {
            int xVal = lblAmount.Location.X;
            int yVal = lblAmount.Location.Y;
            xVal = xVal + 1;
            temp = new Point(xVal, yVal);
            lblAmount.Location = temp;
        }

        private void btnPayeeUp_Click(object sender, EventArgs e)
        {
            int xVal = lblPayeeLine1.Location.X;
            int yVal = lblPayeeLine1.Location.Y;
            yVal = yVal - 1;
            temp = new Point(xVal, yVal);
            lblPayeeLine1.Location = temp;
        }

        private void btnPayeeDown_Click(object sender, EventArgs e)
        {
            int xVal = lblPayeeLine1.Location.X;
            int yVal = lblPayeeLine1.Location.Y;
            yVal = yVal + 1;
            temp = new Point(xVal, yVal);
            lblPayeeLine1.Location = temp;
        }

        private void btnPayeeLeft_Click(object sender, EventArgs e)
        {
            int xVal = lblPayeeLine1.Location.X;
            int yVal = lblPayeeLine1.Location.Y;
            xVal = xVal - 1;
            temp = new Point(xVal, yVal);
            lblPayeeLine1.Location = temp;
        }

        private void btnPayeeRight_Click(object sender, EventArgs e)
        {
            int xVal = lblPayeeLine1.Location.X;
            int yVal = lblPayeeLine1.Location.Y;
            xVal = xVal + 1;
            temp = new Point(xVal, yVal);
            lblPayeeLine1.Location = temp;
        }
    }
}
