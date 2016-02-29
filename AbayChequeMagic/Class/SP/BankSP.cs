using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for BankSP    
//</summary>    
namespace AbayChequeMagic
{
    class BankSP : DBConnection
    {
        public bool BankAdd(BankInfo bankinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("BankIsNotExistAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@bankCode", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.BankCode;
                sprmparam = sccmd.Parameters.Add("@bankName", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.BankName;
                sprmparam = sccmd.Parameters.Add("@branch", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Branch;
                sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Address;
                sprmparam = sccmd.Parameters.Add("@city", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.City;
                sprmparam = sccmd.Parameters.Add("@state", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.State;
                sprmparam = sccmd.Parameters.Add("@pincode", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Pincode;
                sprmparam = sccmd.Parameters.Add("@phone", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Phone;
                sprmparam = sccmd.Parameters.Add("@mobile", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Mobile;
                sprmparam = sccmd.Parameters.Add("@email", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Email;
                sprmparam = sccmd.Parameters.Add("@website", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Website;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.ExtraTwo;
                int inEffectedRow= sccmd.ExecuteNonQuery();
                if (inEffectedRow > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                sqlcon.Close();
            }
        }
        public bool BankEdit(BankInfo bankinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("BankEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@bankId", SqlDbType.Decimal);
                sprmparam.Value = bankinfo.BankId;
                sprmparam = sccmd.Parameters.Add("@bankCode", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.BankCode;
                sprmparam = sccmd.Parameters.Add("@bankName", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.BankName;
                sprmparam = sccmd.Parameters.Add("@branch", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Branch;
                sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Address;
                sprmparam = sccmd.Parameters.Add("@city", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.City;
                sprmparam = sccmd.Parameters.Add("@state", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.State;
                sprmparam = sccmd.Parameters.Add("@pincode", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Pincode;
                sprmparam = sccmd.Parameters.Add("@phone", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Phone;
                sprmparam = sccmd.Parameters.Add("@mobile", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Mobile;
                sprmparam = sccmd.Parameters.Add("@email", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Email;
                sprmparam = sccmd.Parameters.Add("@website", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.Website;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = bankinfo.ExtraTwo;
                int inEffectedRow= sccmd.ExecuteNonQuery();
                if (inEffectedRow > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            finally
            {
                sqlcon.Close();
            }
        }
        public DataTable BankViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
               
                SqlDataAdapter sdaadapter = new SqlDataAdapter("BankViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtbl;
        }
        public BankInfo BankView(decimal bankId)
        {
            BankInfo bankinfo = new BankInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("BankView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@bankId", SqlDbType.Decimal);
                sprmparam.Value = bankId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    bankinfo.BankId = decimal.Parse(sdrreader[0].ToString());
                    bankinfo.BankCode = sdrreader[1].ToString();
                    bankinfo.BankName = sdrreader[2].ToString();
                    bankinfo.Branch = sdrreader[3].ToString();
                    bankinfo.Address = sdrreader[4].ToString();
                    bankinfo.City = sdrreader[5].ToString();
                    bankinfo.State = sdrreader[6].ToString();
                    bankinfo.Pincode = sdrreader[7].ToString();
                    bankinfo.Phone = sdrreader[8].ToString();
                    bankinfo.Mobile = sdrreader[9].ToString();
                    bankinfo.Email = sdrreader[10].ToString();
                    bankinfo.Website = sdrreader[11].ToString();
                    bankinfo.ExtraOne = sdrreader[12].ToString();
                    bankinfo.ExtraTwo = sdrreader[13].ToString();
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
            return bankinfo;
        }
        public bool BankDelete(decimal BankId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("BankDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@bankId", SqlDbType.Decimal);
                sprmparam.Value = BankId;
                int inEffectedRow = sccmd.ExecuteNonQuery();
                if (inEffectedRow > 0)
                {
                   return true;
                }
                else
                {
                   return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            finally
            {
                sqlcon.Close();
            }
        }
        public int BankGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("BankMax", sqlcon);
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
        public DataTable BankViewInGride()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("BankViewInGride", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable BankSearch(string strBank)
        {
            DataTable dtbl = new DataTable();
            try
            {
                
                SqlDataAdapter sdaadapter = new SqlDataAdapter("BankSearch", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@bankName", SqlDbType.VarChar).Value = strBank + "%";
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtbl;
        }
        public DataTable ViewAllBankWithBranch()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewAllBankWithBranch", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable BankWisereport(decimal decBankId,string strFromDate,string strToDate )
        {
            DataTable dtbl = new DataTable();
            try
            {
               
                SqlDataAdapter sdaadapter = new SqlDataAdapter("BankWisereport", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@bankId", SqlDbType.VarChar).Value = decBankId;
                sdaadapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = strFromDate;
                sdaadapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = strToDate;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
            return dtbl;
        }
        public DataTable BankWisereportIfNull(decimal decBankId)
        {
            DataTable dtbl = new DataTable();
            try
            {
               
                SqlDataAdapter sdaadapter = new SqlDataAdapter("BankWisereportifNull", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@bankId", SqlDbType.VarChar).Value = decBankId;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
            return dtbl;
        }
    }
}