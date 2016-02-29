using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for PrinterSP    
//</summary>    
namespace AbayChequeMagic
{
    class PrinterSP : DBConnection
    {
        public bool PrinterAdd(PrinterInfo printerinfo)
        {
            int inRowCount = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PrinterAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@printerName", SqlDbType.VarChar);
                sprmparam.Value = printerinfo.PrinterName;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = printerinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = printerinfo.ExtraTwo;
                inRowCount = sccmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return inRowCount > 0;
        }
        public void PrinterEdit(PrinterInfo printerinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PrinterEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@printerId", SqlDbType.Decimal);
                sprmparam.Value = printerinfo.PrinterId;
                sprmparam = sccmd.Parameters.Add("@printerName", SqlDbType.VarChar);
                sprmparam.Value = printerinfo.PrinterName;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = printerinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = printerinfo.ExtraTwo;
                sccmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }

        }
        public DataTable PrinterViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PrinterViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public PrinterInfo PrinterView(decimal printerId)
        {
            PrinterInfo printerinfo = new PrinterInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PrinterView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@printerId", SqlDbType.Decimal);
                sprmparam.Value = printerId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    printerinfo.PrinterId = decimal.Parse(sdrreader[0].ToString());
                    printerinfo.PrinterName = sdrreader[1].ToString();
                    printerinfo.ExtraOne = sdrreader[2].ToString();
                    printerinfo.ExtraTwo = sdrreader[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sdrreader.Close();
                sqlcon.Close();
            }
            return printerinfo;
        }
        public void PrinterDelete(decimal PrinterId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PrinterDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@printerId", SqlDbType.Decimal);
                sprmparam.Value = PrinterId;
                sccmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
        }
        public int PrinterGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PrinterMax", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                max = int.Parse(sccmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return max;
        }
        public void PrinterDeleteAll()
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PrinterDeleteAll", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
        }


    }
}
