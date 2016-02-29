using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbayChequeMagic
{
    public partial class frmChequeStatus : Form
    {
        #region public variables
        LeafSP SPleaf = new LeafSP();
        BankSP SPBank = new BankSP();
        AccountSP SPaccount = new AccountSP();
        leafDetailsSP SPLeafDetails = new leafDetailsSP();
        #endregion

        #region functions
        public void UpdateBalance(int inRow)
        {
            decimal decTransactionId = new LeafSP().LeafGetTransactionId(decimal.Parse(dgvCheques.Rows[inRow].Cells[0].Value.ToString()));
            if (decTransactionId != -1)
            {
                TransactionInfo InfoTransaction = new TransactionInfo();
                InfoTransaction.Amount = decimal.Parse(dgvCheques.Rows[inRow].Cells[2].Value.ToString());
                InfoTransaction.TransactionType = "Withdraw";
                InfoTransaction.TransactionId = decTransactionId;
                new TransactionSP().TransactionUpdateOnPrint(InfoTransaction);
            }
            else
            {
                TransactionInfo InfoTransaction = new TransactionInfo();
                InfoTransaction.Amount = decimal.Parse(dgvCheques.Rows[inRow].Cells[2].Value.ToString());
                InfoTransaction.TransactionType = "Withdraw";
                InfoTransaction.AccountId = new LeafSP().LeafGetAccountID(decimal.Parse(dgvCheques.Rows[inRow].Cells[2].Value.ToString()));
                new TransactionSP().TransactionAddOnPrint(InfoTransaction);
                new LeafSP().LeafAddTrnasactionId(decimal.Parse(dgvCheques.Rows[inRow].Cells[2].Value.ToString()));
            }
        }
        public frmChequeStatus()
        {
            InitializeComponent();
        }
        private void UpdateTransactions()
        {
            TransactionSP SPTransaction = new TransactionSP();
            for (int inCount = 0; inCount < dgvCheques.Rows.Count; inCount++)
            {

                SPTransaction.TransactionUpdtateOnStatusUpdate(Convert.ToDecimal(dgvCheques.Rows[inCount].Cells[0].Value), dgvCheques.Rows[inCount].Cells[5].Value.ToString());
            }
        }
        public void FillComboAccount()
        {
            cmbAccount.ValueMember = "accountId";
            cmbAccount.DisplayMember = "accountNumber";
            DataTable dtblAccount = SPaccount.FilterAccountByBank(decimal.Parse(cmbBank.SelectedValue.ToString()));
            DataRow dr = dtblAccount.NewRow();
            dr["accountId"] = 0;
            dr["accountNumber"] = "--Select--";
            dtblAccount.Rows.InsertAt(dr, 0);
            cmbAccount.DataSource = dtblAccount;

        }
        public void FillComboBank()
        {
            cmbBank.ValueMember = "bankId";
            cmbBank.DisplayMember = "bankName";
            DataTable dtblBanks = new DataTable();
            dtblBanks = SPBank.BankViewAll();
            DataRow dr = dtblBanks.NewRow();
            dr["bankId"] = 0;
            dr["bankName"] = "--Select--";
            dtblBanks.Rows.InsertAt(dr, 0);
            cmbBank.DataSource = dtblBanks;
            if (frmChequeDetailsHome.isFromHome == true)
            {
                cmbBank.SelectedValue = frmChequeDetailsHome.decBankId;
            }
        }
        public void FillGridFiltered()
        {
            if (cmbAccount.SelectedValue != null && cmbAccount.SelectedIndex > 0)
            {
                dgvCheques.DataSource = SPaccount.GetChequeStatusFilterByAccountId(Convert.ToDecimal(cmbAccount.SelectedValue));
            }
            else
            {
                Messages.WarningMessage("No account selected");
            }
        }
        public void UpdateStatus()
        {
            LeafInfo InfoLeaf = new LeafInfo();
            for (int inCount = 0; inCount < dgvCheques.Rows.Count; inCount++)
            {
                InfoLeaf.LeafId = Convert.ToDecimal(dgvCheques.Rows[inCount].Cells[0].Value);
                InfoLeaf.ChequeStatus = dgvCheques.Rows[inCount].Cells[5].Value.ToString();
                SPleaf.UpdateChequeStatus(InfoLeaf);
            }
            Messages.UpdatedMessage();
        }
        public void FillGrid()
        {
            dgvCheques.AutoGenerateColumns = false;
            dgvCheques.DataSource = SPLeafDetails.LeafDetailsGetChequeStatus();
        }
        #endregion functions

        #region events
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCheques.Rows.Count > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    UpdateTransactions();
                    Cursor = Cursors.Default;
                    Messages.UpdatedMessage();
                }
                else
                {
                    Messages.WarningMessage("No Cheque selected!");
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }
        private void frmChequeStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Common.EnterKeyPress(sender, e);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void frmChequeStatus_Activated(object sender, EventArgs e)
        {
            if (frmChequeDetailsHome.isFromHome && cmbAccount.SelectedIndex != 0 && cmbBank.SelectedIndex != 0)
            {
                btnView.PerformClick();
                frmChequeDetailsHome.isFromHome = false;
            }
        }
        private void frmChequeStatus_Load(object sender, EventArgs e)
        {
            try
            {

                FillComboBank();
                cmbAccount.SelectedIndex = 0;
                cmbAccount.SelectedIndex = 0;
                if (frmChequeDetailsHome.isFromHome == true)
                {
                    cmbAccount.SelectedValue = frmChequeDetailsHome.decAccountId;
                }
                FillGrid();
                if (cmbBank.SelectedIndex == 0)
                {
                    dgvCheques.DataSource = new DataTable();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }
        private void cmbAccount_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                FillComboAccount();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbAccount.SelectedIndex = 0;
                dgvCheques.DataSource = new DataTable();
                FillComboAccount();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                FillGridFiltered();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void dgvCheques_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCheques.ClearSelection();
                dgvCheques.CurrentCell = null;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        #endregion
    }
}
