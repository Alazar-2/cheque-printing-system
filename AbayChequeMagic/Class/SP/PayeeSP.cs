using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for PayeeSP    
//</summary>    
namespace AbayChequeMagic
{
    class PayeeSP : DBConnection
    {
        public void PayeeAdd(PayeeInfo payeeinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                //sprmparam.Value = payeeinfo.PayeeId;
                sprmparam = sccmd.Parameters.Add("@payeeName", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.PayeeName;
                sprmparam = sccmd.Parameters.Add("@printName", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.PrintName;
                sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Address;
                sprmparam = sccmd.Parameters.Add("@city", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.City;
                sprmparam = sccmd.Parameters.Add("@state", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.State;
                sprmparam = sccmd.Parameters.Add("@pincode", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Pincode;
                sprmparam = sccmd.Parameters.Add("@mobile", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Mobile;
                sprmparam = sccmd.Parameters.Add("@fax", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Fax;
                sprmparam = sccmd.Parameters.Add("@email", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Email;
                sprmparam = sccmd.Parameters.Add("@website", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Website;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.ExtraTwo;
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
        public void PayeeEdit(PayeeInfo payeeinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = payeeinfo.PayeeId;
                sprmparam = sccmd.Parameters.Add("@payeeName", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.PayeeName;
                sprmparam = sccmd.Parameters.Add("@printName", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.PrintName;
                sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Address;
                sprmparam = sccmd.Parameters.Add("@city", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.City;
                sprmparam = sccmd.Parameters.Add("@state", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.State;
                sprmparam = sccmd.Parameters.Add("@pincode", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Pincode;
                sprmparam = sccmd.Parameters.Add("@mobile", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Mobile;
                sprmparam = sccmd.Parameters.Add("@fax", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Fax;
                sprmparam = sccmd.Parameters.Add("@email", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Email;
                sprmparam = sccmd.Parameters.Add("@website", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.Website;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = payeeinfo.ExtraTwo;
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
        public DataTable PayeeViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PayeeViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public PayeeInfo PayeeView(decimal payeeId)
        {
            PayeeInfo payeeinfo = new PayeeInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = payeeId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    payeeinfo.PayeeId = decimal.Parse(sdrreader[0].ToString());
                    payeeinfo.PayeeName = sdrreader[1].ToString();
                    payeeinfo.PrintName = sdrreader[2].ToString();
                    payeeinfo.Address = sdrreader[3].ToString();
                    payeeinfo.City = sdrreader[4].ToString();
                    payeeinfo.State = sdrreader[5].ToString();
                    payeeinfo.Pincode = sdrreader[6].ToString();
                    payeeinfo.Mobile = sdrreader[7].ToString();
                    payeeinfo.Fax = sdrreader[8].ToString();
                    payeeinfo.Email = sdrreader[9].ToString();
                    payeeinfo.Website = sdrreader[10].ToString();
                    payeeinfo.ExtraOne = sdrreader[11].ToString();
                    payeeinfo.ExtraTwo = sdrreader[12].ToString();
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
            return payeeinfo;
        }
        public bool PayeeDelete(decimal PayeeId)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = PayeeId;
                int inExecute = sccmd.ExecuteNonQuery();
                if (inExecute > 0)
                {
                    isCheck = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return isCheck;
        }
        public int PayeeGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeMax", sqlcon);
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
        public DataTable SearchPayeeByName(string strPayeeName)
        {
            //Created By FAWAS KASIM on 13/09/2012//

            DataTable dtblPayee = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchPayeeByName", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@payeeName", SqlDbType.VarChar).Value = strPayeeName;
                sdaadapter.Fill(dtblPayee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblPayee;
        }
        public DataTable PayeeViewAndSelect()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PayeeViewAndSelect", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PayeeAccountGetPayeeWithAccountNumber()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PayeeAccountGetPayeeWithAccountNumber", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PayeeWiseReport(decimal decPayeeId, string strFromDate, string strToDate)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PayeeWiseReport", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@payeeId", SqlDbType.Decimal).Value = decPayeeId;
                sdaadapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = strFromDate;
                sdaadapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = strToDate;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable AllPayeeWiseReport(string strFromDate, string strToDate)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("AllPayeeWiseReport", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = strFromDate;
                sdaadapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = strToDate;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PayeeWiseReportIfNull(decimal decPayeeId, string strFromDate, string strToDate)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PayeeWiseReportIfNull", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@payeeId", SqlDbType.Decimal).Value = decPayeeId;
                sdaadapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = strFromDate;
                sdaadapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = strToDate;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable AllPayeeWiseReportIfNull(string strFromDate, string strToDate)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("AllPayeeWiseReportIfNull", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = strFromDate;
                sdaadapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = strToDate;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
    }
}
