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
    public partial class frmSelectCheque : Form
    {
        #region Variables
        public static bool isAdd = false;
        public static frmSelectCheque frmcheque = new frmSelectCheque();
        #endregion

        #region Functions
        public frmSelectCheque()
        {
            InitializeComponent();
        }
        private void FillGrid(decimal decChequeBookId)
        {
            LeafSP spLeaf = new LeafSP();
            dgvChequeLeaf.DataSource = spLeaf.ChequeLeafWithPayeeDateAndAmount(decChequeBookId);
            dgvChequeLeaf.Columns[0].Visible = false;
            if (dgvChequeLeaf.Rows.Count > 0)
            {
                dgvChequeLeaf.Rows[0].Selected = false;
            }
            Common.strLeafId = string.Empty;
        }
        public void FillChequebookCombo(decimal decAccountId)
        {
            ChequeBookSP spChequeBook = new ChequeBookSP();
            DataTable dtbl = new DataTable();
            dtbl = spChequeBook.FilterChequeBookByAccountWithLeafs(decAccountId);
            DataRow drow = dtbl.NewRow();
            drow["chequeBookId"] = "0";
            drow["chequeBookName"] = "--Select--";
            dtbl.Rows.InsertAt(drow, 0);
            cmbSelectChequeBook.DataSource = dtbl;
            cmbSelectChequeBook.DisplayMember = "chequeBookName";
            cmbSelectChequeBook.ValueMember = "chequeBookId";
        }
        private void WriteCheque()
        {
            if (cmbSelectBank.SelectedIndex == 0)
            {
                Messages.InformationMessage("Please select bank");
            }
            else if (cmbSelectAccount.SelectedIndex == 0)
            {
                Messages.InformationMessage("Please select account");
            }
            else if (cmbSelectChequeBook.SelectedIndex == 0)
            {
                Messages.InformationMessage("Please select chequebook");
            }
            else if (Common.strLeafId == string.Empty)
            {
                Messages.InformationMessage("Please select a cheque to write");
            }
            else
            {
                frmChequeEntry open = Application.OpenForms["frmChequeEntry"] as frmChequeEntry;
                if (open == null)
                {
                    frmChequeEntry frmChequeEntry = new frmChequeEntry();
                    frmChequeEntry.MdiParent = this.MdiParent;
                    frmChequeEntry.Show();
                }
                else
                {
                    if (open.WindowState == FormWindowState.Minimized)
                    {
                        open.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        open.Activate();
                    }
                }
            }
        }
        public void AddNewBank()
        {
            //frmBankCreation frmBankCreation = new frmBankCreation();
            //CompanySP spCompany = new CompanySP();
            //if (spCompany.UserPrivilegeChecking(decimal.Parse(frmLogin.strLoginStatus), decimal.Parse(frmBankCreation.AccessibleName)))
            //{
            //    frmBankCreation.MinimizeBox = false;
            //    frmBankCreation.ShowDialog();
            //}
            //else
            //{
            //    Messages.NoPrivillageMessage();
            //}
        }
        public void AddNewAccount()
        {
            //frmAccountCreation frmAccountCreation = new frmAccountCreation();
            //CompanySP spCompany = new CompanySP();
            //if (spCompany.UserPrivilegeChecking(decimal.Parse(frmLogin.strLoginStatus), decimal.Parse(frmAccountCreation.AccessibleName)))
            //{
            //    frmAccountCreation.MinimizeBox = false;
            //    frmAccountCreation.ShowDialog();
            //}
            //else
            //{
            //    Messages.NoPrivillageMessage();
            //}
        }
        private void AddNewChequBook()
        {
            //frmChequeBookCreation frmChequeBookCreation = new frmChequeBookCreation();
            //CompanySP spCompany = new CompanySP();
            //if (spCompany.UserPrivilegeChecking(decimal.Parse(frmLogin.strLoginStatus), decimal.Parse(frmChequeBookCreation.AccessibleName)))
            //{
            //    frmChequeBookCreation.MinimizeBox = false;
            //    frmChequeBookCreation.ShowDialog();
            //}
            //else
            //{
            //    Messages.NoPrivillageMessage();
            //}
        }
        #endregion

        #region Events
        private void frmSelectCheque_Load(object sender, EventArgs e)
        {
            try
            {
                frmcheque = this;
                Common.BankComboFill(cmbSelectBank);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cmbSelectBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSelectAccount.DataSource = null;
                if (cmbSelectBank.SelectedIndex > 0)
                {
                    Common.AccountComboFillWithBank(cmbSelectAccount, decimal.Parse(cmbSelectBank.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cmbSelectAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSelectChequeBook.DataSource = null;
                if (cmbSelectAccount.SelectedIndex > 0)
                {
                    FillChequebookCombo(decimal.Parse(cmbSelectAccount.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnWriteCheque_Click(object sender, EventArgs e)
        {
            try
            {
                WriteCheque();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnViewCheque_Click(object sender, EventArgs e)
        {
            try
            {
                frmChequeStatus open = Application.OpenForms["frmChequeStatus"] as frmChequeStatus;
                if (open == null)
                {
                    frmChequeStatus frmChequeStatus = new frmChequeStatus();
                    frmChequeStatus.MdiParent = this.MdiParent;
                    frmChequeStatus.Show();
                }
                else
                {
                    if (open.WindowState == FormWindowState.Minimized)
                    {
                        open.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        open.Activate();
                    }
                }
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
                Messages.CloseMessage(this);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnAddNewBank_Click(object sender, EventArgs e)
        {
            try
            {
                isAdd = true;
                AddNewBank();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            try
            {
                isAdd = true;
                AddNewAccount();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void btnAddNewChequeBook_Click(object sender, EventArgs e)
        {
            try
            {
                isAdd = true;
                AddNewChequBook();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void dgvChequeLeaf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChequeLeaf.CurrentRow != null)
                {
                    if (dgvChequeLeaf.CurrentRow.Cells[0].Value != null)
                    {
                        if (dgvChequeLeaf.CurrentRow.Cells[0].Value.ToString() != string.Empty)
                        {
                            Common.strLeafId = dgvChequeLeaf.CurrentRow.Cells["Leaf Id"].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void dgvChequeLeaf_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChequeLeaf.CurrentRow != null)
                {
                    if (dgvChequeLeaf.CurrentRow.Cells[0].Value != null)
                    {
                        if (dgvChequeLeaf.CurrentRow.Cells[0].Value.ToString() != string.Empty)
                        {
                            WriteCheque();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void cmbSelectChequeBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvChequeLeaf.DataSource = null;
                if (cmbSelectChequeBook.SelectedIndex > 0)
                {
                    FillGrid(decimal.Parse(cmbSelectChequeBook.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void frmSelectCheque_KeyDown(object sender, KeyEventArgs e)
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
        private void frmSelectCheque_Activated(object sender, EventArgs e)
        {
            try
            {
                Common.BankComboFill(cmbSelectBank);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion
    }
}
