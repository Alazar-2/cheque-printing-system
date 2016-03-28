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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int status = 0;
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            string amount=txtAmount.Text;
            
            lblAmountInWords1.Text = amount;
            if(amount.Length>70)
            {
                lblAmountInWords2.Text = amount.Substring(70);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Text Box: "+txtAmount.Size.ToString());
            MessageBox.Show("lbl size: " + lblAmountInWords1.Size + " lbl max size: " + lblAmountInWords1.MaximumSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string amount = txtAmount.Text;
            MessageBox.Show(amount.Length.ToString());
        }
    }
}
