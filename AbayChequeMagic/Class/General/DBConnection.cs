using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
//<summary>    
//Summary description for DBConnection    
//</summary>    
namespace AbayChequeMagic
{
    public class DBConnection
    {
        protected SqlConnection sqlcon;
        public DBConnection()
        {
            string path = Common.strPath + "\\DBAbayChequeMagic.mdf";
            string strServer = ".\\sqlExpress";
            if (File.Exists(Application.StartupPath + "\\sys.txt"))
            {
                strServer = File.ReadAllText(Application.StartupPath + "\\sys.txt"); // getting ip of server
            }
            sqlcon = new SqlConnection(@"Data Source=" + strServer + ";AttachDbFilename=" + path + ";Integrated Security=True;Connect Timeout=120;User Instance=True");
        }
    }
}
