using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for AccountSP    
//</summary>    
namespace AbayChequeMagic
{
    class AccountSP : DBConnection
    {
        public bool AccountAdd(AccountInfo accountinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("AccountAddIfNotExist", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@bankId", SqlDbType.Decimal);
                sprmparam.Value = accountinfo.BankId;
                sprmparam = sccmd.Parameters.Add("@accountType", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.AccountType;
                sprmparam = sccmd.Parameters.Add("@currentBalance", SqlDbType.Decimal);
                sprmparam.Value = accountinfo.CurrentBalance;
                sprmparam = sccmd.Parameters.Add("@minimumBalance", SqlDbType.Decimal);
                sprmparam.Value = accountinfo.MinimumBalance;
                sprmparam = sccmd.Parameters.Add("@accountHolderName", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.AccountHolderName;
                sprmparam = sccmd.Parameters.Add("@accountNumber", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.AccountNumber;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.ExtraTwo;
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
        public bool AccountEdit(AccountInfo accountinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("AccountEditIfNotExist", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = accountinfo.AccountId;
                sprmparam = sccmd.Parameters.Add("@bankId", SqlDbType.Decimal);
                sprmparam.Value = accountinfo.BankId;
                sprmparam = sccmd.Parameters.Add("@accountType", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.AccountType;
                sprmparam = sccmd.Parameters.Add("@currentBalance", SqlDbType.Decimal);
                sprmparam.Value = accountinfo.CurrentBalance;
                sprmparam = sccmd.Parameters.Add("@minimumBalance", SqlDbType.Decimal);
                sprmparam.Value = accountinfo.MinimumBalance;
                sprmparam = sccmd.Parameters.Add("@accountHolderName", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.AccountHolderName;
                sprmparam = sccmd.Parameters.Add("@accountNumber", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.AccountNumber;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = accountinfo.ExtraTwo;
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
        public DataTable AccountViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("AccountViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public AccountInfo AccountView(decimal accountId)
        {
            AccountInfo accountinfo = new AccountInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("AccountView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = accountId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    accountinfo.AccountId = decimal.Parse(sdrreader[0].ToString());
                    accountinfo.BankId = decimal.Parse(sdrreader[1].ToString());
                    accountinfo.AccountType = sdrreader[2].ToString();
                    accountinfo.CurrentBalance = decimal.Parse(sdrreader[3].ToString());
                    accountinfo.MinimumBalance = decimal.Parse(sdrreader[4].ToString());
                    accountinfo.AccountHolderName = sdrreader[5].ToString();
                    accountinfo.CreatedDate = DateTime.Parse(sdrreader[6].ToString());
                    accountinfo.AccountNumber = sdrreader[7].ToString();
                    accountinfo.ExtraOne = sdrreader[8].ToString();
                    accountinfo.ExtraTwo = sdrreader[9].ToString();
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
            return accountinfo;
        }
        public bool AccountDelete(decimal AccountId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("AccountDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = AccountId;
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
        public int AccountGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("AccountMax", sqlcon);
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

        public DataTable FilterAccountByBank(decimal decBankId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("FilterAccountByBank", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@bankId", SqlDbType.Decimal).Value = decBankId;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }

        public DataTable AccountViewInGrid()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("AccountViewInGride", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable AccountSearch(string strAccount)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("AccountSearch", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.VarChar).Value = strAccount + "%";
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable GetChequeStatusFilterByAccountId(decimal decAccountId)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("LeafDettailsGetChequeStatusFilterByAccountId", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@accountId", SqlDbType.VarChar).Value = decAccountId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }//AccountPayeeAccountNumberFromLeafDetailsID
        public string AccountPayeeAccountNumberFromLeafDetailsID(decimal decLeafDetailsId)
        {
            string  strPayeeAccountNumber="";
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("AccountPayeeAccountNumberFromLeafDetailsID", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("@leafDetailsId", SqlDbType.Decimal).Value = decLeafDetailsId;
                strPayeeAccountNumber=sccmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                
            }

            finally
            {
                sqlcon.Close();
            }
            return strPayeeAccountNumber;
        }

    }
}

