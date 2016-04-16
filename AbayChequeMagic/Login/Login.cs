using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbayChequeMagic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AbayChequeMagic.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          int status = connectionToDataBase();
               if(status==1)
               {
                    Application.EnableVisualStyles();
                   // Application.SetCompatibleTextRenderingDefault(false);
                    frmChequeEntry ce = new frmChequeEntry();
                    ce.WindowState = FormWindowState.Maximized;
                    //Application.Run(ce);
                    ce.Show();
                 //  this.Close();
               }
               //else
               //{
               //    errorPage ep = new errorPage();
               //    ep.Show();
               //}
        }

    private int connectionToDataBase()
        {
            string uname = txtUserName.Text;
            string groupname = "CPO";

            using (MySqlConnection conn = new MySqlConnection())
            {
              
                conn.ConnectionString = "Server=localhost;user id=root;Database=hr;";
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM viewusergroup WHERE username = @0 and groupName=@1", conn);
              
                command.Parameters.Add(new MySqlParameter("0", uname));
               // command.Parameters.Add(new MySqlParameter("0", passwd));
                command.Parameters.Add(new MySqlParameter("1", groupname));

              
                bool isUserexisted = false;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    while (reader.Read())
                    {
                        isUserexisted = true;
                        return 1;
                    }
                }
                if(isUserexisted)
                {
                    MessageBox.Show("user existed");
                    return 1;
                }
                else
                {
                    MessageBox.Show("CPO Authorization is not given for current user. please contact IT administrators");
                    return 0;
                }               
            }
        }
    }
}
