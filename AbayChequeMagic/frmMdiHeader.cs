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
    public partial class frmMdiHeader : Form
    {
        #region Functions

        public frmMdiHeader()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmMdiHeader_Activated(object sender, EventArgs e)
        {
            try
            {
                this.SendToBack();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmMdiHeader_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                frmChequeDetailsHome.objCdh.SendToBack();

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion

        private void frmMdiHeader_Load(object sender, EventArgs e)
        {

        }
    }
}
