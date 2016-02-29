using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace AbayChequeMagic
{
    public partial class frmLogin : Form
    {
        #region Variables
        public static string strLoginStatus = null;
        public static string strUsername;
        public static frmLogin objLogin = new frmLogin();


        #endregion

        #region Functions

        public frmLogin()
        {
            InitializeComponent();
        }
        public void checkprivillage(decimal decUserType)
        {
            //Form frm = (Form)this.MdiParent;
            MenuStrip ms = (MenuStrip)frmMDI.objMdi.Controls["msMainMenu"];
            DataTable dtbl = new DataTable();
            UserRightSP spUserRight = new UserRightSP();
            dtbl = spUserRight.UserRightViewAllByUserType(decUserType);
            foreach (ToolStripMenuItem tmm in ms.Items)
            {
                foreach (ToolStripMenuItem tmi in tmm.DropDownItems)
                {
                    //tmm.Enabled = tmi.AccessibleName == "logout" || tmi.AccessibleName == "change password";
                    for (int inI = 0; inI < dtbl.Rows.Count; inI++)
                    {
                        if (tmi.AccessibleName == dtbl.Rows[inI]["rightId"].ToString())
                        {
                            tmi.Enabled = true;
                        }
                    }
                    if (tmi.AccessibleName == "logout" || tmi.AccessibleName == "change password")
                    {
                        tmi.Enabled = true;
                    }
                    if (tmi.AccessibleName == "Create Company" || tmi.AccessibleName == "Select Company")
                    {
                        tmi.Enabled = false;
                    }
                }
            }
        }

        private void Login()
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                Messages.InformationMessage("Please enter username");
                txtUsername.Focus();
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                Messages.InformationMessage("Please enter password");
                txtPassword.Focus();
            }
            else
            {
                UserSP spUser = new UserSP();
                UserInfo infoUser = new UserInfo();
                infoUser = spUser.UserView(txtUsername.Text.Trim());
                if (infoUser.Username != txtUsername.Text || infoUser.Password != txtPassword.Text)
                {
                    Messages.ErrorMessage("Invalid username or password");
                    Clear();
                }
                else
                {
                    if (frmMDI.isDelete == true)
                    {
                        if (Messages.DeleteMessage())
                        {
                            XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\CompanyDetails.xml"); //path of xml file.
                            string tagName = "";
                            int inNodeCount = -1, inId = 0;
                            while (xmlreader.Read())
                            {
                                switch (xmlreader.NodeType)
                                {
                                    case XmlNodeType.Element:
                                        tagName = xmlreader.Name;
                                        if (tagName == "Company")
                                            inNodeCount++;
                                        break;
                                    case XmlNodeType.Text:
                                        switch (tagName)
                                        {
                                            case "Id":
                                                if (Common.strCompanyId == xmlreader.Value)
                                                {
                                                    inId = inNodeCount;
                                                }
                                                break;
                                        }
                                        break;
                                }
                            }
                            xmlreader.Close();
                            FileStream fs = new FileStream(Application.StartupPath + "\\CompanyDetails.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            XmlDocument xmldoc = new XmlDocument();
                            xmldoc.Load(fs);
                            fs.Close();
                            xmldoc.DocumentElement.RemoveChild(xmldoc.DocumentElement.ChildNodes[inId]);
                            FileStream WRITER = new FileStream(Application.StartupPath + "\\CompanyDetails.xml", FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                            xmldoc.Save(WRITER);
                            WRITER.Close();

                            Application.Restart();
                            Messages.DeletedMessage();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        strLoginStatus = infoUser.UserTypeId.ToString();
                        strUsername = infoUser.Username;
                        checkprivillage(decimal.Parse(strLoginStatus));
                        ShowChequeDetails();
                        ResizeChilForms();
                        this.Close();
                    }
                }
            }
        }

        private void ShowChequeDetails()
        {
            frmChequeDetailsHome frm = Application.OpenForms["frmChequeDetailsHome"] as frmChequeDetailsHome;
            frmChequeDetailsHome frmCdh = new frmChequeDetailsHome();
            frmCdh.MdiParent = this.MdiParent;
            frmCdh.Top = this.MdiParent.Height;
            frmCdh.Show();
            frmCdh.Top = 83;
            if (frm != null)
            {
                frm.Close();
            }
            frmCdh.SendToBack();
        }
        private void ResizeChilForms()
        {
            frmMdiHeader frmHeader = (frmMdiHeader)Application.OpenForms["frmMdiHeader"];
            if (frmHeader != null)
            {
                if (this.MdiParent.WindowState != FormWindowState.Minimized)
                {
                    frmHeader.Width = this.MdiParent.Width - 12;
                }
            }
            frmChequeDetailsHome frmChequeDetails = (frmChequeDetailsHome)Application.OpenForms["frmChequeDetailsHome"];
            if (frmChequeDetails != null)
            {
                if (this.MdiParent.WindowState != FormWindowState.Minimized)
                {
                    frmChequeDetails.Width = this.MdiParent.Width - 12;
                    frmChequeDetails.Height = this.MdiParent.Height - 145;
                    //frmChequeDetails.btnWriteCheque.Location = new Point(frmChequeDetails.Width - 368, frmChequeDetails.Height - 45);
                    //frmChequeDetails.btnViewAllCheque.Location = new Point(frmChequeDetails.Width - 476, frmChequeDetails.Height - 45);
                }
            }
        }
        private void Clear()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }
        #endregion

        #region events
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                objLogin = this;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
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

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
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
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frmMDI.isDelete = false;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion

    }
}
