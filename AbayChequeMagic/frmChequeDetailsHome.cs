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
    public partial class frmChequeDetailsHome : Form
    {
        #region Variables

        public decimal decChequeBookId = 0;
        int inFirstNode = -1;
        int inSecondNode = -1;
        int inThirdNode = -1;
        public static bool isFromHome = false;
        public static decimal decBankId = 0;
        public static decimal decAccountId = 0;
        public static decimal decChequebookId = 0;
        public static frmChequeDetailsHome objCdh = new frmChequeDetailsHome();


        #endregion

        #region Functions

        public frmChequeDetailsHome()
        {
            InitializeComponent();
        }
        /***********************Populating TreeView*****************************/

        public void DatabindTreeView() //--------DataBinds TreeView Parent Node 
        {
            trvMain.Nodes.Clear();
            BankSP spBank = new BankSP();
            DataTable dtbl = new DataTable();
            dtbl = spBank.BankViewAll();
            PopulateNodes(dtbl, trvMain.Nodes); //---0
        }

        private void PopulateSubLevel(decimal parentid, TreeNode parentNode) //--------Populates level 1 child node
        {
            AccountSP spAccount = new AccountSP();
            DataTable dtblChild = new DataTable();
            dtblChild = spAccount.FilterAccountByBank(parentid);
            PopulateChildNodes(dtblChild, parentNode.Nodes);//---1

        }
        private void PopulateChildSubLevel(decimal parentid, TreeNode parentNode)//---------Populates level 2 child node
        {
            ChequeBookSP spChequeBook = new ChequeBookSP();
            DataTable dtblSubChild = new DataTable();
            dtblSubChild = spChequeBook.FilterChequeBookByAccountWithLeafs(parentid);
            PopulateSubChildNodes(dtblSubChild, parentNode.Nodes); //---2

        }

        private void PopulateNodes(DataTable dtbl, TreeNodeCollection nodes) //---0
        {
            foreach (DataRow dr in dtbl.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["bankName"].ToString();
                tn.Name = dr["bankId"].ToString();

                nodes.Add(tn);
                PopulateSubLevel(decimal.Parse(tn.Name.ToString()), tn);
            }
        }
        private void PopulateChildNodes(DataTable dtbl, TreeNodeCollection nodes)//---1
        {
            foreach (DataRow dr in dtbl.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["accountNumber"].ToString();
                tn.Name = dr["accountId"].ToString();
                tn.ImageIndex = 2;
                tn.SelectedImageIndex = 2;
                nodes.Add(tn);
                PopulateChildSubLevel(decimal.Parse(tn.Name.ToString()), tn);
            }
        }
        private void PopulateSubChildNodes(DataTable dtbl, TreeNodeCollection nodes) //---2
        {
            foreach (DataRow dr in dtbl.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["chequeBookName"].ToString();
                tn.Name = dr["chequeBookId"].ToString();
                tn.ImageIndex = 3;
                tn.SelectedImageIndex = 6;
                nodes.Add(tn);

            }
        }

        /************************************************************************/

        public void ExpandNode()
        {
            try
            {
                if (inFirstNode != -1)
                {
                    trvMain.Nodes[inFirstNode].Expand();
                    if (inSecondNode != -1)
                    {
                        trvMain.Nodes[inFirstNode].Nodes[inSecondNode].Expand();
                        if (inThirdNode != -1)
                        {
                            trvMain.Nodes[inFirstNode].Nodes[inSecondNode].Nodes[inThirdNode].Expand();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void FillGrid(decimal decChequeBookId)
        {
            LeafSP spLeaf = new LeafSP();
            dgvChequeDetails.DataSource = spLeaf.ChequeLeafWithPayeeDateAndAmount(decChequeBookId);
            dgvChequeDetails.Columns[0].Visible = false;
            if (dgvChequeDetails.Rows.Count > 0)
            {
                dgvChequeDetails.Rows[0].Selected = false;
            }
            Common.strLeafId = string.Empty;

        }
        public void LoadCompanyName()
        {
            CompanySP spCompany = new CompanySP();
            DataTable dtbl = spCompany.CompanyViewAll();
            lblCompanyName.Text = dtbl.Rows[0]["companyName"].ToString();
        }

        private void WriteCheque()
        {
            if (Common.strLeafId == string.Empty)
            {
                Messages.InformationMessage("Please select a cheque to write");
            }
            else
            {
                frmChequeEntry open = Application.OpenForms["frmChequeEntry"] as frmChequeEntry;
                if (open == null)
                {
                    CompanySP spCompany = new CompanySP();
                    if (spCompany.UserPrivilegeChecking(decimal.Parse(frmLogin.strLoginStatus), 15))
                    {
                        frmChequeEntry frmChequeEntry = new frmChequeEntry();
                        frmChequeEntry.MdiParent = this.MdiParent;
                        frmChequeEntry.Show();
                    }
                    else
                    {
                        Messages.NoPrivillageMessage();
                    }
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
        public void ViewChequStatus()
        {
            frmChequeStatus open = Application.OpenForms["frmChequeStatus"] as frmChequeStatus;
            if (open == null)
            {
                CompanySP spCompany = new CompanySP();
                if (spCompany.UserPrivilegeChecking(decimal.Parse(frmLogin.strLoginStatus), 18))
                {
                    frmChequeStatus frmChequeStatus = new frmChequeStatus();
                    frmChequeStatus.MdiParent = this.MdiParent;
                    frmChequeStatus.Show();
                }
                else
                {
                    Messages.NoPrivillageMessage();
                }
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

        private void ShowDetails(TreeNode node)
        {
            decChequeBookId = decimal.Parse(node.Name);
            FillGrid(decChequeBookId);
            dgvChequeDetails.Show();
            lblChequeBook.Text = node.Parent.Parent.Text + "-" + node.Parent.Text + "(" + node.Text + ")";
            lblChequeBook.Show();
            btnWriteCheque.Show();
            btnViewAllCheque.Show();
        }
        private void HideDetails()
        {
            dgvChequeDetails.DataSource = null;
            dgvChequeDetails.Hide();
            lblChequeBook.Hide();
            btnWriteCheque.Hide();
            btnViewAllCheque.Hide();
        }

        #endregion

        #region Events
        private void frmChequeDetailsHome_Load(object sender, EventArgs e)
        {
            try
            {
                objCdh = this;
                DatabindTreeView();
                LoadCompanyName();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmChequeDetailsHome_Resize(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }

        private void frmChequeDetailsHome_Activated(object sender, EventArgs e)
        {
            try
            {
                FillGrid(decChequeBookId);

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void trvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                inFirstNode = e.Node.Index;
                if (e.Node.Level == 1)
                {
                    inSecondNode = e.Node.Index;
                }
                if (e.Node.Level == 2)
                {
                    ShowDetails(e.Node);
                    decChequeBookId = decimal.Parse(e.Node.Name);
                    decAccountId = decimal.Parse(e.Node.Parent.Name);
                    decBankId = decimal.Parse(e.Node.Parent.Parent.Name);
                }
                else
                {
                    HideDetails();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void dgvChequeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChequeDetails.CurrentRow != null)
                {
                    if (dgvChequeDetails.CurrentRow.Cells[0].Value != null)
                    {
                        if (dgvChequeDetails.CurrentRow.Cells[0].Value.ToString() != string.Empty)
                        {

                            Common.strLeafId = dgvChequeDetails.CurrentRow.Cells["Leaf Id"].Value.ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void dgvChequeDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChequeDetails.CurrentRow != null)
                {
                    if (dgvChequeDetails.CurrentRow.Cells[0].Value != null)
                    {
                        if (dgvChequeDetails.CurrentRow.Cells[0].Value.ToString() != string.Empty)
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

        private void btnViewAllCheque_Click(object sender, EventArgs e)
        {
            try
            {
                isFromHome = true;
                ViewChequStatus();
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

        private void dgvChequeDetails_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                objCdh.SendToBack();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void pnlLeft_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                objCdh.SendToBack();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void trvMain_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                objCdh.SendToBack();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void dgvChequeDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvChequeDetails.ClearSelection();
                dgvChequeDetails.CurrentCell = null;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        private void pnlBottom_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                objCdh.SendToBack();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion
    }
}
