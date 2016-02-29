using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for PayeeAccountDetailsSP    
//</summary>    
namespace AbayChequeMagic
{
    class PayeeAccountDetailsSP : DBConnection
    {
        public bool PayeeAccountDetailsAdd(PayeeAccountDetailsInfo payeeaccountdetailsinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAccountDetailsAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@payeeAccountDetailsd", SqlDbType.Decimal);
                //sprmparam.Value = payeeaccountdetailsinfo.PayeeAccountDetailsd;
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = payeeaccountdetailsinfo.PayeeId;
                sprmparam = sccmd.Parameters.Add("@bank", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.Bank;
                sprmparam = sccmd.Parameters.Add("@branch", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.Branch;
                sprmparam = sccmd.Parameters.Add("@accountNumber", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.AccountNumber;
                sprmparam = sccmd.Parameters.Add("@accountType", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.AccountType;
                sprmparam = sccmd.Parameters.Add("@contactNumber", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.ContactNumber;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.ExtraTwo;
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
        public bool PayeeAccountDetailsEdit(PayeeAccountDetailsInfo payeeaccountdetailsinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAccountDetailsEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@payeeAccountDetailsd", SqlDbType.Decimal);
                sprmparam.Value = payeeaccountdetailsinfo.PayeeAccountDetailsd;
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = payeeaccountdetailsinfo.PayeeId;
                sprmparam = sccmd.Parameters.Add("@bank", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.Bank;
                sprmparam = sccmd.Parameters.Add("@branch", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.Branch;
                sprmparam = sccmd.Parameters.Add("@accountNumber", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.AccountNumber;
                sprmparam = sccmd.Parameters.Add("@accountType", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.AccountType;
                sprmparam = sccmd.Parameters.Add("@contactNumber", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.ContactNumber;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = payeeaccountdetailsinfo.ExtraTwo;
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
        public DataTable PayeeAccountDetailsViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PayeeAccountDetailsViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public PayeeAccountDetailsInfo PayeeAccountDetailsView(decimal payeeAccountDetailsd)
        {
            PayeeAccountDetailsInfo payeeaccountdetailsinfo = new PayeeAccountDetailsInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAccountDetailsView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@payeeAccountDetailsd", SqlDbType.Decimal);
                sprmparam.Value = payeeAccountDetailsd;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    payeeaccountdetailsinfo.PayeeAccountDetailsd = decimal.Parse(sdrreader[0].ToString());
                    payeeaccountdetailsinfo.PayeeId = decimal.Parse(sdrreader[1].ToString());
                    payeeaccountdetailsinfo.Bank = sdrreader[2].ToString();
                    payeeaccountdetailsinfo.Branch = sdrreader[3].ToString();
                    payeeaccountdetailsinfo.AccountNumber = sdrreader[4].ToString();
                    payeeaccountdetailsinfo.AccountType = sdrreader[5].ToString();
                    payeeaccountdetailsinfo.ContactNumber = sdrreader[6].ToString();
                    payeeaccountdetailsinfo.ExtraOne = sdrreader[7].ToString();
                    payeeaccountdetailsinfo.ExtraTwo = sdrreader[8].ToString();
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
            return payeeaccountdetailsinfo;
        }
        public void PayeeAccountDetailsDelete(decimal PayeeAccountDetailsd)
        {

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAccountDetailsDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@payeeAccountDetailsd", SqlDbType.Decimal);
                sprmparam.Value = PayeeAccountDetailsd;
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
        public int PayeeAccountDetailsGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAccountDetailsMax", sqlcon);
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
        public DataTable SearchPayeeAccountByName(string strPayeeName)
        {
            //Created By FAWAS KASIM on 14/09/2012//

            DataTable dtblPayeeAccount = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchPayeeAccountByName", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@payeeName", SqlDbType.VarChar).Value = strPayeeName;
                sdaadapter.Fill(dtblPayeeAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblPayeeAccount;
        }
        public PayeeAccountDetailsInfo PayeeAccountDetailsViewFromPayeeId(decimal payeeAccountDetailsd)
        {
            PayeeAccountDetailsInfo payeeaccountdetailsinfo = new PayeeAccountDetailsInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAccountDetailsViewFromPayeeId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = payeeAccountDetailsd;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    payeeaccountdetailsinfo.PayeeAccountDetailsd = decimal.Parse(sdrreader[0].ToString());
                    payeeaccountdetailsinfo.PayeeId = decimal.Parse(sdrreader[1].ToString());
                    payeeaccountdetailsinfo.Bank = sdrreader[2].ToString();
                    payeeaccountdetailsinfo.Branch = sdrreader[3].ToString();
                    payeeaccountdetailsinfo.AccountNumber = sdrreader[4].ToString();
                    payeeaccountdetailsinfo.AccountType = sdrreader[5].ToString();
                    payeeaccountdetailsinfo.ContactNumber = sdrreader[6].ToString();
                    payeeaccountdetailsinfo.ExtraOne = sdrreader[7].ToString();
                    payeeaccountdetailsinfo.ExtraTwo = sdrreader[8].ToString();
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
            return payeeaccountdetailsinfo;
        }
        public DataTable PayeeAccountNumberFromPayeeId(decimal decPayeeId)
        {
            DataTable dtblPayeeAccount = new DataTable();
            try
            {
                SqlDataAdapter sqlda = new SqlDataAdapter("PayeeAccountNumberFromPayeeId", sqlcon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.Add("@payeeId", SqlDbType.Decimal).Value = decPayeeId;
                sqlda.Fill(dtblPayeeAccount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblPayeeAccount;
        }
        public int PayeeAccountCount()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("PayeeAccountCount", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                max = int.Parse(sccmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

            finally
            {
                sqlcon.Close();
            }
            return max;
        }
    }
}
