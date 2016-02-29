using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
namespace AbayChequeMagic
{
    //Created by fawas kasim on 15/09/2012
    class Common
    {

        #region  Variables
        private static string _leafId;
        private static decimal _payeeId;
        private static decimal _bankId;
        private static string _strPayeeName;
        private static string _strAmount;
        private static string _strIssuedDate;
        private static string _strExpense;
        private static string _strChequeNumber;
        private static string _strBankName;
        private static string _strAccount;
        private static string _strReportType;
        private static string _strLetterType;
        private static string _strPath;
        private static string _strCompanyId;
        public static string strCurrency = string.Empty;
        
        public static string strPath
        {
            get { return _strPath; }
            set { _strPath = value; }

        }

        public static string strCompanyId
        {
            get { return _strCompanyId; }
            set { _strCompanyId = value; }

        }

        public static string strPayeeName
        {
            get { return _strPayeeName; }
            set { _strPayeeName = value; }

        }

        public static string strAmount
        {
            get { return _strAmount; }
            set { _strAmount = value; }

        }

        public static string strIssuedDate
        {
            get { return _strIssuedDate; }
            set { _strIssuedDate = value; }

        }

        public static string strExpense
        {
            get { return _strExpense; }
            set { _strExpense = value; }

        }

        public static string strChequeNumber
        {
            get { return _strChequeNumber; }
            set { _strChequeNumber = value; }

        }

        public static string strBankName
        {
            get { return _strBankName; }
            set { _strBankName = value; }

        }

        public static string strLeafId
        {
             get { return _leafId; }    
             set { _leafId = value; }    
            
        }

        public static decimal decPayeeId
        {
            get { return _payeeId; }
            set { _payeeId = value; }

        }

        public static string strReportType
        {
            get { return _strReportType; }
            set { _strReportType = value; }

        }

        public static string strLetterType
        {
            get { return _strLetterType; }
            set { _strLetterType = value; }

        }

        public static string strAccount
        {
            get { return _strAccount; }
            set { _strAccount = value; }

        }

        public static decimal decBankId
        {
            get { return _bankId; }
            set { _bankId = value; }

        }

#endregion

        #region Functions
        public static void EnterKeyPress(object sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        public static void Amount(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            
        }

        public static void NumberOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127;
        }

        public static void NumberOnlyAndFloatingPoint(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127&& e.KeyChar!=46;
            if(txtBox.Text.Contains(".")&&e.KeyChar==46)
            {
                e.Handled = true;
            }
            if (e.KeyChar==46&&txtBox.Text.Trim() == string.Empty)
            {
                e.Handled = true;
            
            }
             
        }

        public static void NameValidation(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127 && !Char.IsWhiteSpace(e.KeyChar);
        }

        public static bool WebsiteValidation(TextBox txtWebsite)
        {
            string strWebsite=txtWebsite.Text;
            bool isOk = true;
            if (!(txtWebsite.Text.Contains("http://")))
            {
                strWebsite = "http://" + strWebsite;
            }
                Regex myRegex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled);
                if (txtWebsite.Text.Length > 0)
                {
                    if (!myRegex.IsMatch(strWebsite))
                    {
                        Messages.InformationMessage("Website format invalid");
                        txtWebsite.Focus();
                        isOk = false;
                    }
                }
            
            return isOk;
        }

        public static bool EmailValidation(TextBox txtEmail)
        {
            bool isOk=true;
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    Messages.InformationMessage("Enter a valid email id");
                    txtEmail.Focus();
                    isOk = false;
                }

            }

            return isOk;

           /* Regex rEMail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (strEmail.Length > 0)
            {
            * 
                if (!rEMail.IsMatch(strEmail))
                {

                    MessageBox.Show("Please provide valid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //strEmail.SelectAll();

                }
            }*/
        }

        public static void BankComboFill(ComboBox cmb)
        {
            BankSP spBank = new BankSP();
            DataTable dtbl = new DataTable();
            dtbl = spBank.ViewAllBankWithBranch();
            DataRow drow = dtbl.NewRow();
            drow["bankId"] = "0";
            drow["bankName"] = "--Select--";
            dtbl.Rows.InsertAt(drow, 0);
            cmb.ValueMember = "bankId";
            cmb.DisplayMember = "bankName";
            cmb.DataSource = dtbl;
        }

        public static void AccountComboFillWithBank(ComboBox cmb,decimal decBankId)
        {
            AccountSP spAccount = new AccountSP();
            DataTable dtbl = new DataTable();
            dtbl = spAccount.FilterAccountByBank(decBankId);
            DataRow drow = dtbl.NewRow();
            drow["accountId"] = "0";
            drow["accountNumber"] = "--Select--";
            dtbl.Rows.InsertAt(drow, 0);
            cmb.DataSource = dtbl;
            cmb.DisplayMember = "accountNumber";
            cmb.ValueMember = "accountId";
        }

        public static void PayeeComboFill(ComboBox cmb)
        {
            PayeeSP spPayee = new PayeeSP();
            DataTable dtbl = new DataTable();
            dtbl = spPayee.PayeeViewAll();
            DataRow drow = dtbl.NewRow();
            drow["payeeId"] = "0";
            drow["payeeName"] = "--Select--";
            dtbl.Rows.InsertAt(drow, 0);
            cmb.ValueMember = "payeeId";
            cmb.DisplayMember = "payeeName";
            cmb.DataSource = dtbl;
        }

        public static bool CheckIfEmpty(GroupBox gbx)
        {
            bool isOk = true;
            foreach (Control ctrl in gbx.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txt = (TextBox)ctrl;
                    if (txt.AccessibleName.Contains("Mand") && txt.Text == string.Empty)  // I had set the name of mandidatory field text box name as its field name+"Mand" to check wheather it is mandidatory
                    {
                        isOk = false;
                        Messages.InformationMessage("Please enter " + txt.AccessibleName.Substring(0, txt.AccessibleName.Length - 4));//show field name by replacing "Mand"
                        txt.Focus();
                        break;
                    }
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox cmb = (ComboBox)ctrl;
                    if (cmb.AccessibleName.Contains("Mand")&& (cmb.SelectedIndex==0))  // I had set the name of mandidatory field combobox name as its field name+"Mand" to check wheather it is mandidatory
                    {
                            isOk = false;
                            Messages.InformationMessage("Please select " + cmb.AccessibleName.Substring(0, cmb.AccessibleName.Length - 4));//show field name by replacing "Mand"
                            cmb.Focus();
                            break;
                    }
                }
            }
            return isOk;
        }

        public static Control FindControl(Form form, string name)
        {
            foreach (Control control in form.Controls)
            {
                Control result = FindControl(form, control, name);
                if (result != null)
                    return result;
            }
            return null;
        }

        private static Control FindControl(Form form, Control control, string name)
        {
            if (control.Name == name)
            {
                return control;
            }

            foreach (Control subControl in control.Controls)
            {
                Control result = FindControl(form, subControl, name);
                if (result != null)
                    return result;
            }
            return null;
        }

        #endregion 
    }
}
