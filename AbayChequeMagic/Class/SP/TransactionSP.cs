using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for TransactionSP    
//</summary>    
namespace AbayChequeMagic
{
    class TransactionSP : DBConnection
    {
        public void TransactionAdd(TransactionInfo transactioninfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@transactionId", SqlDbType.Decimal);
                //sprmparam.Value = transactioninfo.TransactionId;
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.AccountId;
                sprmparam = sccmd.Parameters.Add("@transactionNumber", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.TransactionNumber;
                sprmparam = sccmd.Parameters.Add("@transactionDate", SqlDbType.DateTime);
                sprmparam.Value = transactioninfo.TransactionDate;
                sprmparam = sccmd.Parameters.Add("@amount", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.Amount;
                sprmparam = sccmd.Parameters.Add("@transactionType", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.TransactionType;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.ExtraTwo;
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
        public void TransactionEdit(TransactionInfo transactioninfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@transactionId", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.TransactionId;
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.AccountId;
                sprmparam = sccmd.Parameters.Add("@transactionNumber", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.TransactionNumber;
                sprmparam = sccmd.Parameters.Add("@transactionDate", SqlDbType.DateTime);
                sprmparam.Value = transactioninfo.TransactionDate;
                sprmparam = sccmd.Parameters.Add("@amount", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.Amount;
                sprmparam = sccmd.Parameters.Add("@transactionType", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.TransactionType;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.ExtraTwo;
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
        public DataTable TransactionViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("TransactionViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public TransactionInfo TransactionView(decimal transactionId)
        {
            TransactionInfo transactioninfo = new TransactionInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@transactionId", SqlDbType.Decimal);
                sprmparam.Value = transactionId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    transactioninfo.TransactionId = decimal.Parse(sdrreader[0].ToString());
                    transactioninfo.AccountId = decimal.Parse(sdrreader[1].ToString());
                    transactioninfo.TransactionNumber = sdrreader[2].ToString();
                    string str = sdrreader[3].ToString();
                    if (str != string.Empty)
                    {
                        transactioninfo.TransactionDate = DateTime.Parse(sdrreader[3].ToString());
                    }
                    else
                    {
                        transactioninfo.TransactionDate = DateTime.Parse(DateTime.Now.ToString("dd MMM yyyy"));
                    }
                    transactioninfo.Amount = decimal.Parse(sdrreader[4].ToString());
                    transactioninfo.TransactionType = sdrreader[5].ToString();
                    transactioninfo.ExtraOne = sdrreader[6].ToString();
                    transactioninfo.ExtraTwo = sdrreader[7].ToString();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
            finally
            {
                sdrreader.Close();
                sqlcon.Close();
            }
            return transactioninfo;
        }
        public void TransactionDelete(decimal TransactionId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@transactionId", SqlDbType.Decimal);
                sprmparam.Value = TransactionId;
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
        public int TransactionGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionMax", sqlcon);
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
        public DataTable TransactionViewAllDetails()
        {
            //Created by Fawas Kasim on 19/09/2012
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("TransactionViewAllDetails", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable SearchTransaction(string strSearch)
        {
            //Created By FAWAS KASIM on 24/09/2012//
            DataTable dtblTransaction = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchTransaction", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.VarChar).Value = strSearch;
                sdaadapter.Fill(dtblTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblTransaction;
        }
        public DataTable SearchTransactionByAmount(string strSearch)
        {
            //Created By FAWAS KASIM on 24/09/2012//

            DataTable dtblTransaction = new DataTable();
            try
            {
                if (strSearch != string.Empty)
                {
                    SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchTransactionByAmount", sqlcon);
                    sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.Decimal).Value = decimal.Parse(strSearch);
                    sdaadapter.Fill(dtblTransaction);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblTransaction;
        }
        public DataTable SearchTransactionByDate(string strSearch)
        {
            //Created By FAWAS KASIM on 24/09/2012//

            DataTable dtblTransaction = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchTransactionByDate", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.DateTime).Value = DateTime.Parse(strSearch);
                sdaadapter.Fill(dtblTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblTransaction;
        }
        public DataTable SearchTransactionByBank(string strSearch)
        {
            //Created By FAWAS KASIM on 24/09/2012//
            DataTable dtblTransaction = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchTransactionByBank", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.VarChar).Value = strSearch;
                sdaadapter.Fill(dtblTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblTransaction;
        }
        public DataTable SearchTransactionByAccountNumber(string strSearch)
        {
            //Created By FAWAS KASIM on 24/09/2012//

            DataTable dtblTransaction = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchTransactionByAccountNumber", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.VarChar).Value = strSearch;
                sdaadapter.Fill(dtblTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblTransaction;
        }
        public DataTable SearchTransactionByTransactionType(string strSearch)
        {
            //Created By FAWAS KASIM on 24/09/2012//

            DataTable dtblTransaction = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchTransactionByTransactionType", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.VarChar).Value = strSearch;
                sdaadapter.Fill(dtblTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblTransaction;
        }
        public DataTable SearchTransactionByType(string strSearch)
        {
            //Created By FAWAS KASIM on 24/09/2012//

            DataTable dtblTransaction = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchTransactionByBank", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@search", SqlDbType.Decimal).Value = strSearch;
                sdaadapter.Fill(dtblTransaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblTransaction;
        }
        public void TransactionAddOnPrint(TransactionInfo transactioninfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionAddOnPrint", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.AccountId;
                sprmparam = sccmd.Parameters.Add("@amount", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.Amount;
                sprmparam = sccmd.Parameters.Add("@transactionType", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.TransactionType;
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
        public void TransactionUpdateOnPrint(TransactionInfo transactioninfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionUpdateOnPrint", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@transactionId", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.TransactionId;
                sprmparam = sccmd.Parameters.Add("@amount", SqlDbType.Decimal);
                sprmparam.Value = transactioninfo.Amount;
                sprmparam = sccmd.Parameters.Add("@transactionType", SqlDbType.VarChar);
                sprmparam.Value = transactioninfo.TransactionType;
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
        public void TransactionUpdtateOnStatusUpdate(decimal decLeafId, string strStatus)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("TransactionUpdtateOnStatusUpdate", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("@leafId", SqlDbType.VarChar).Value = decLeafId;
                sccmd.Parameters.Add("@status", SqlDbType.VarChar).Value = strStatus;
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
