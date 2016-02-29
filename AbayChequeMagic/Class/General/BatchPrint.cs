using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
//using AbayChequeMagic.CrystalReports;

//Created by Ansar on 28th September,2012
namespace AbayChequeMagic
{
    class Print
    {
        #region public variables
        public decimal decLeafId = -1;
        private int inHardMarginY = 0;
        public PrintingTypes printingType = new PrintingTypes();
        private string strPayeeLine1 = string.Empty;
        private string strPayeeLine2 = string.Empty;
        private string strAmountInWordsLine1 = string.Empty;
        private string strAmountInWordsLine2 = string.Empty;
        private string strAmount;
        private string strCompanyName = string.Empty;
        private string strAuthirizedSignatoryName = string.Empty;
        private string strCurrencyDecimalPart = string.Empty;
        private string strCurrencyFractionalPart = string.Empty;
        private string strCurrencySymbol = string.Empty;
        private string strPrintingAmount = string.Empty;
        private string strPayeeLineTwoSupposed = string.Empty;
        private string strPayeeAccountNumber = string.Empty;
        private string strCurrencyName = string.Empty;
        private string strAmountInWordsCombined = string.Empty;
        private string strDateToPrint = string.Empty;
        private string strPayeeAccountNumberChoosen = string.Empty;
        DateTime dtIssuedDate;
        private string strAccountNumber = string.Empty;
        private string strPayee = string.Empty;
        public PrintDocument pd = new PrintDocument();
        decimal decLayoutId = 0;
        decimal decPayeeId = 0;
        decimal decLeafDetailsId = 0;
        decimal decExpenseId = 0;
        decimal decCurrentBalance = 0;
        decimal decAmount = 0;
        int inPayeeLine1Length = 0;
        int inPayeeLine2Length = 0;
        DataTable dtblLayout;
        DataTable dtblLeafDetails;
        StatusInfo infoStatus = new StatusInfo();
        CurrencyInfo infoCurrency = new CurrencySP().CurrencyView();
        ChequeLayoutInfo InfoChequeLayout;
        LeafSP SPLeaf = new LeafSP();
        ChequeLayoutSP SPChequeLayout = new ChequeLayoutSP();
        leafDetailsSP SPLeafDetails = new leafDetailsSP();
        PayeeSP SPPayee = new PayeeSP();
        ExpenseInfo InfoExpense;
        PayeeInfo InfoPayee;
        ExpenseSP SPExpense = new ExpenseSP();
        AuthorizedSignatorySP SPAuthorizedSignatory = new AuthorizedSignatorySP();
        DataTable dtblAccountDetails;
        StatusSP SPStatus = new StatusSP();
        DataRow dr;
        Font font;
        Brush brush;
        public bool IsPrintPayementVoucher = false;
        Image imgSignatureStamp;
        public int inCSizeH = 0;
        public int inCSizeW = 0;
        #endregion

        #region functions
        public Print()
        {
            font = font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            brush = new SolidBrush(Color.Black);
            this.pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        }
        private int GetNumberOfPrintableCharactres(string str, int inLength)
        {
            int inIndex;
            string strSubstring = string.Empty;
            for (inIndex = 0; inIndex < str.Length; inIndex++)
            {
                strSubstring = strSubstring + str[inIndex];
                SizeF textSize = TextRenderer.MeasureText(strSubstring, new Font(font.FontFamily, font.Size, font.Style));
                if (textSize.Width > inLength)
                {
                    return inIndex;
                }
            }
            return inIndex;
        }
        private bool ValidateForPrint()
        {
            if (decCurrentBalance < decimal.Parse(strAmount))
            {
                return Messages.QuestionMessage("The account" + strAccountNumber + " does not have sufficient balance. Do you want to print?");
            }
            return true;
        }
        private string GetFormatedAmount(decimal decAmount)
        {
            return string.Format("{0:n2}", (double)decAmount);
        }
        private void SetAmountInWords(decimal decAmount)
        {
            string strLeftPart = string.Empty;
            string strRightPart = string.Empty;
            string[] strCombinedAmount = decAmount.ToString().Split('.');
            if (strCombinedAmount.Length > 1)
            {
                FigursToWords fw = new FigursToWords();
                strLeftPart = fw.NumberToText(int.Parse(strCombinedAmount[0]));
                strRightPart = fw.NumberToText(int.Parse(strCombinedAmount[1]));
            }
        }
        public void SetNumberToWords()
        {
            try
            {
                strAmount = string.Format("{0:n2}", double.Parse(strAmount));
                string[] strAmountArray = strAmount.Split('.');
                string strAmountInWordsLeft = String.Empty;
                string strAmountInWordsRight = string.Empty;
                int inLeftPart;
                int inRightPart;
                if ((inLeftPart = int.Parse(strAmountArray[0].Replace(",", ""))) > 0)
                {
                    strAmountInWordsLeft = new FigursToWords().NumberToText(inLeftPart) + " " + strCurrencyDecimalPart;
                }
                if ((inRightPart = int.Parse(strAmountArray[1].Replace(",", ""))) > 0)
                {
                    strAmountInWordsRight = new FigursToWords().NumberToText(inRightPart) + " " + strCurrencyFractionalPart;
                    if (inLeftPart > 0)
                    {
                        strAmountInWordsRight = " And " + strAmountInWordsRight;
                    }
                }
                strAmountInWordsCombined = strAmountInWordsLeft + strAmountInWordsRight + " Only";
                if (infoStatus.AmountInWordsSuffix)
                {
                    strAmountInWordsCombined = "***" + strAmountInWordsCombined;
                }
                if (infoStatus.AmountSuffix)
                {
                    strPrintingAmount = strPrintingAmount + "/-";
                }
                if (infoStatus.AmountPrefix)
                {
                    strPrintingAmount = "***" + strPrintingAmount;
                }
                int inNumberOfPrintableCharacters = GetNumberOfPrintableCharactres(strAmountInWordsCombined, inPayeeLine1Length);
                if (strAmountInWordsCombined.Length > inNumberOfPrintableCharacters)
                {
                    strAmountInWordsLine1 = strAmountInWordsCombined.Substring(0, FindBreakPoint(strAmountInWordsCombined, inNumberOfPrintableCharacters));
                    strAmountInWordsLine2 = strAmountInWordsCombined.Substring(strAmountInWordsLine1.Length);
                }
                else
                {
                    strAmountInWordsLine1 = strAmountInWordsCombined;
                }
            }
            catch (OverflowException ex)
            {
            }
            catch (FormatException ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);

            }
        }
        private void SetCurrencyInfo()
        {
            strCurrencyName = infoCurrency.currencyName;
            strCurrencyFractionalPart = infoCurrency.fractionalPart;
        }
        private static int FindBreakPoint(string strText, int inNumberOfPrintableChars)
        {
            if (strText.Length < inNumberOfPrintableChars || strText[inNumberOfPrintableChars].ToString() == " ")
            {
                return inNumberOfPrintableChars;
            }
            else
            {
                int inBreakPoint = inNumberOfPrintableChars;
                for (int inCount = 0; inCount < inNumberOfPrintableChars; inCount++)
                {
                    if (strText[inCount].ToString() == " ")
                    {
                        inBreakPoint = inCount;
                    }
                    if (inCount >= inNumberOfPrintableChars)
                    {
                        return inBreakPoint;
                    }
                }
                return inBreakPoint;
            }
        }
        private void GetParticulars()
        {
            //Get all details
            decLayoutId = SPLeaf.LeafGetLayoutIdFromLeafId(decLeafId); //layout details
            // P.payeeId payeeId,leafDetailsId,ISNULL(payeeName,''),ISNULL(amount,0),chequeLeafNumber,issuedDate,currentDate,expenseId
            dtblLeafDetails = SPLeafDetails.LeafDetailsGetLeafDetailsFromLeafId(decLeafId);
            //SELECT  L.leafId,C.layoutId,F.fieldId,F.fieldName,xAxis,yAxis,width,height FROM tbl_Dimension D
            dtblLayout = SPLeaf.ViewLayoutDetailsFromLeafId(decLeafId);//
            dtblLayout.PrimaryKey = new DataColumn[] { dtblLayout.Columns["fieldName"] };
            infoStatus = SPStatus.StatusViewByLeafId(decLeafId); //status for all fields
            InfoChequeLayout = SPChequeLayout.ChequeLayoutView(decLayoutId); //dimensions
            //SELECT ISNULL(accountNumber,0) accountNumber,ISNULL(currentBalance,0) currentBalance FROM tbl_Account
            dtblAccountDetails = new LeafSP().getAccountNumberAndCurrentBalanceFromLeafID(decLeafId); //account number and current balance
            //Keep all Ids and other details for updates after print
            strAmount = dtblLeafDetails.Rows[0]["amount"].ToString();
            decAmount = decimal.Parse(strAmount);
            decLeafDetailsId = decimal.Parse(dtblLeafDetails.Rows[0]["leafDetailsId"].ToString());
            decPayeeId = decimal.Parse(dtblLeafDetails.Rows[0]["payeeId"].ToString());
            strPayee = dtblLeafDetails.Rows[0]["payeeName"].ToString();
            dtIssuedDate = DateTime.Parse(dtblLeafDetails.Rows[0]["issuedDate"].ToString());
            SetFormatedDate();
            strCompanyName = new CompanySP().CompanyViewAll().Rows[0][1].ToString();
            strAccountNumber = dtblAccountDetails.Rows[0]["accountNumber"].ToString();
            decCurrentBalance = Convert.ToDecimal(dtblAccountDetails.Rows[0]["currentBalance"]);
            decExpenseId = Convert.ToDecimal(dtblLeafDetails.Rows[0]["expenseId"]);
            InfoPayee = SPPayee.PayeeView(decPayeeId);
            InfoExpense = SPExpense.ExpenseView(decExpenseId);
            InfoPayee = SPPayee.PayeeView(decPayeeId);
            infoCurrency = new CurrencySP().CurrencyView();
            strCurrencyDecimalPart = infoCurrency.currencyName;
            strCurrencyFractionalPart = infoCurrency.fractionalPart;
            LeafInfo InfoLeaf = SPLeaf.LeafView(decLeafId);
            decimal decPayeeAccoountDetailsd = SPLeafDetails.LeafDetailsIsAccountSelected(decLeafId);
            inCSizeH = int.Parse(dtblLayout.Rows.Find("ChequeSize")["height"].ToString());
            inCSizeW = int.Parse(dtblLayout.Rows.Find("ChequeSize")["width"].ToString());
            if (decPayeeAccoountDetailsd > 0)
            {
                strPayeeAccountNumber = SPLeafDetails.GetPayeeAccountNumberSelected(decPayeeAccoountDetailsd);
            }
            //Set all details
            if (infoStatus.SignatoryName)
            {
                strAuthirizedSignatoryName = SPAuthorizedSignatory.authorizedSignatoryGetName();
            }
            if (infoStatus.SignatoryStamp)
            {
                try
                {
                    imgSignatureStamp = Image.FromStream(new MemoryStream((SPAuthorizedSignatory.AuthorizedSignatoryViewImage())));
                }
                catch { }
            }
            if (dtblLeafDetails.Rows.Count > 0)
            {
                strPayee = dtblLeafDetails.Rows[0]["payeename"].ToString();
                if (strPayeeAccountNumber != string.Empty)
                {
                    strPayee = strPayee + "--" + strPayeeAccountNumber;
                }
                inPayeeLine1Length = int.Parse(dtblLayout.Rows.Find("payeeLineOne")["width"].ToString());
                strPayeeLine1 = strPayee.Substring(0, GetNumberOfPrintableCharactres(strPayee, inPayeeLine1Length));
                if (InfoChequeLayout.PayeeLineTwo)
                {
                    inPayeeLine2Length = int.Parse(dtblLayout.Rows.Find("payeeLineTwo")["width"].ToString());
                    strPayeeLineTwoSupposed = strPayee.Substring(strPayeeLine1.Length);
                    strPayeeLine2 = strPayeeLineTwoSupposed.Substring(GetNumberOfPrintableCharactres(strPayeeLineTwoSupposed, inPayeeLine2Length));
                }
                strAmount = dtblLeafDetails.Rows[0]["amount"].ToString();
                SetAmountInWords(decAmount);
                SetNumberToWords();
            }
            if (dtblAccountDetails.Rows.Count > 0)
            {
                strAccountNumber = dtblAccountDetails.Rows[0][0].ToString();
                decCurrentBalance = decimal.Parse(dtblAccountDetails.Rows[0][1].ToString());
            }
        }
        private void SetFormatedDate()//receiveds date in formate dd:MM:yyy
        {
            //SELECT C.dateFormatId,dateSpacing
            DataTable dtblDateFormat = SPLeaf.LeafGetDateFormateIdAndSpacingFromLeafId(decLeafId);
            if (dtblDateFormat.Rows.Count > 0)
            {
                strDateToPrint = GetFormatedDate(dtIssuedDate, dtblDateFormat.Rows[0]["dateFormat"].ToString(), int.Parse(dtblDateFormat.Rows[0]["dateSpacing"].ToString()));
            }
        }
        public string GetFormatedDate(DateTime dtUnFormatedDate, string strDateFormat, int inDateSpacing)
        {
            string strFormatedDate = string.Empty;
            string strDate = string.Empty;
            string strChar = string.Empty;
            if (inDateSpacing < 1)
            {
                strChar = "\\";
            }
            if (strDateFormat == "101")
            {
                strDate = dtUnFormatedDate.ToString("dd:MM:yyy").Replace(":", strChar);
            }
            else if (strDateFormat == "102")
            {
                strDate = dtUnFormatedDate.ToString("MM:dd:yyy").Replace(":", strChar);
            }
            else
            {
                strDate = dtUnFormatedDate.ToString("yyy:MM:dd").Replace(":", strChar);
            }
            foreach (char ch in strDate)
            {
                strFormatedDate = strFormatedDate + ch.ToString() + "         ".Substring(0, inDateSpacing);
            }
            return strFormatedDate;
        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                if (infoStatus.AccountPayee) //1.
                {
                    dr = dtblLayout.Rows.Find("accountPayeeOnly");
                 //   g.DrawImage(global::AbayChequeMagic.Properties.Resources.AccountPayee, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY,
                   //int.Parse(dr["width"].ToString()),
                   //int.Parse(dr["height"].ToString()));
                }
                if (infoStatus.NonNegotiable) //2.
                {
                    dr = dtblLayout.Rows.Find("nonNegotiable");
                 //   g.DrawImage(global::AbayChequeMagic.Properties.Resources.notNegotiable, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY,
                    //int.Parse(dr["width"].ToString()),
                    //int.Parse(dr["height"].ToString()));
                }
                if (infoStatus.BearerStrike) //2.
                {
                    dr = dtblLayout.Rows.Find("bearerStrike");
                  //  g.DrawImage(global::AbayChequeMagic.Properties.Resources.Question, int.Parse(dr["xAxis"].ToString()) + 7, int.Parse(dr["yAxis"].ToString()) - inHardMarginY,
                    //int.Parse(dr["width"].ToString()),
                    //int.Parse(dr["height"].ToString()));
                }
                if (infoStatus.PayableAtPar) //2.
                {
                    dr = dtblLayout.Rows.Find("payableAtPar");
                  //  g.DrawImage(global::AbayChequeMagic.Properties.Resources.payableAtPar, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY,
                    //int.Parse(dr["width"].ToString()),
                    //int.Parse(dr["height"].ToString()));
                }
                dr = dtblLayout.Rows.Find("amount");
                strPrintingAmount = strAmount;
                if (infoStatus.AmountPrefix)
                {
                    strPrintingAmount = "***" + strPrintingAmount;
                }
                if (infoStatus.AmountSuffix)
                {
                    strPrintingAmount = strPrintingAmount + "\\--";
                }
                g.DrawString(strPrintingAmount, font, brush, int.Parse(dr["xAxis"].ToString()) + 7, int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                dr = dtblLayout.Rows.Find("Date");
                g.DrawString(strDateToPrint, new Font("Comic Sans MS", 7.25F, System.Drawing.FontStyle.Regular), brush, int.Parse(dr["xAxis"].ToString()) + 7, int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                if (infoStatus.NotAbove) //2.
                {
                    dr = dtblLayout.Rows.Find("notAbove");
                  //  g.DrawImage(global::AbayChequeMagic.Properties.Resources.notAbove, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()),
                    //int.Parse(dr["width"].ToString()),
                    //int.Parse(dr["height"].ToString()));
                    dr = dtblLayout.Rows.Find("notAboveamount");
                    g.DrawString(strPrintingAmount, font, brush, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                }
                dr = dtblLayout.Rows.Find("payeeLineOne"); //4.
                g.DrawString(strPayeeLine1, font, brush, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                if (InfoChequeLayout.PayeeLineTwo)
                {
                    dr = dtblLayout.Rows.Find("payeeLineTwo");
                    g.DrawString(strPayeeLine2, font, brush, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                }
                dr = dtblLayout.Rows.Find("AmountInWordsLine1");
                g.DrawString(strAmountInWordsLine1, font, brush, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                if (InfoChequeLayout.AmountInWordsTwo)
                {
                    dr = dtblLayout.Rows.Find("AmountInWordsLine2");
                    g.DrawString(strAmountInWordsLine2, font, brush, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                }
                if (infoStatus.SignatoryStamp && imgSignatureStamp != null)
                {
                    if (imgSignatureStamp != null)
                    {
                        dr = dtblLayout.Rows.Find("signatoryStamp");
                        g.DrawImage(imgSignatureStamp, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY,
                        int.Parse(dr["width"].ToString()),
                        int.Parse(dr["height"].ToString()));
                    }
                }
                if (infoStatus.ForCompany)
                {
                    if (strCompanyName != string.Empty)
                    {
                        dr = dtblLayout.Rows.Find("forCompany");
                        g.DrawString("For " + strCompanyName, font, brush, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                    }
                }
                if (infoStatus.SignatoryName)
                {
                    dr = dtblLayout.Rows.Find("authorizedSignatoryName");
                    g.DrawString(strAuthirizedSignatoryName, font, brush, int.Parse(dr["xAxis"].ToString()), int.Parse(dr["yAxis"].ToString()) - inHardMarginY);
                }
            }
        }
        public void SetParticulars(decimal leafId, bool IsWarningMessageForInSufficientBalance)
        {
            decLeafId = leafId;
            if (decLeafId != -1)
            {
                GetParticulars();
            }
            else
            {
                throw new Exception("Leaf id not provided");
            }
        }
        public void DoPrint()
        {
            inHardMarginY = (int)pd.DefaultPageSettings.HardMarginY;
            //SetParticulars(leafId,IsWarningMessageForInSufficientBalance);
            pd.Print();
            if (printingType == PrintingTypes.BatchPrint)
            {
                SPLeaf.LeafSetAsPrinted(decLeafId);
            }
        }
        public void PrintPaymentVoucher(decimal leafId, bool IsWarningMessageForInSufficientBalance, string strPrinterNameforPV)
        {
            SetParticulars(leafId, IsWarningMessageForInSufficientBalance);
            CompanySP SPCompany = new CompanySP();
            DataTable dtblCompany = SPCompany.CompanyViewDetails();
            string strCompanyName = string.Empty;
            string strAddress = string.Empty;
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
      //      string strCheqleafNumber = SPLeafDetails.LeafDetailsGetChequeNumberFromLeafId(decLeafId);
      //      string strBankName = SPLeaf.LeafGetBankNameFromLeafId(decLeafId);
            dtblPaymentVocuher.Rows.Add(new object[] { strPayeeLine1, strPayeeLine2, dtIssuedDate.ToString("dd:MM:yyyy"), DateTime.Now.ToString("dd:MMM:yyy"), strAmount, strAmountInWordsLine1, strAmountInWordsLine2, "accountpayeeonly", "strCheqleafNumber", "strBankName", strCurrencyName, "", strCompanyName, strAddress, "", "" });
           // crptPaymentVoucherPrint crptPaymentVoucherobj = new crptPaymentVoucherPrint();
            //crptPaymentVoucherobj.Database.Tables["dtblPaymentVoucher"].SetDataSource(dtblPaymentVocuher);
            //crptPaymentVoucherobj.PrintOptions.PrinterName = strPrinterNameforPV;
            //crptPaymentVoucherobj.PrintToPrinter(1, false, 1, 1);
        }
        #endregion functions
    }
}
          
    


