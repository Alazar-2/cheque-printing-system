using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

//<summary>    
//Summary description for ChequeBookSP    
//</summary>    
namespace AbayChequeMagic
{
    class ChequeBookSP : DBConnection
    {
        public bool ChequeBookAdd(ChequeBookInfo chequebookinfo)
        {
            //Edited by fawas on 25/09/2012
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@chequeBookName", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.ChequeBookName;
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.AccountId;
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.LayoutId;
                sprmparam = sccmd.Parameters.Add("@numberOfChequeLeaves", SqlDbType.Int);
                sprmparam.Value = chequebookinfo.NumberOfChequeLeaves;
                sprmparam = sccmd.Parameters.Add("@startNumber", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.StartNumber;
                sprmparam = sccmd.Parameters.Add("@endNumber", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.EndNumber;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.ExtraTwo;
                int Execute = sccmd.ExecuteNonQuery();
                if (Execute > 0)
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
        public void ChequeBookEdit(ChequeBookInfo chequebookinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@chequeBookId", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.ChequeBookId;
                sprmparam = sccmd.Parameters.Add("@chequeBookName", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.ChequeBookName;
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.AccountId;
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.LayoutId;
                sprmparam = sccmd.Parameters.Add("@numberOfChequeLeaves", SqlDbType.Int);
                sprmparam.Value = chequebookinfo.NumberOfChequeLeaves;
                sprmparam = sccmd.Parameters.Add("@startNumber", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.StartNumber;
                sprmparam = sccmd.Parameters.Add("@endNumber", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.EndNumber;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.ExtraTwo;
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
        public DataTable ChequeBookViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeBookViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public ChequeBookInfo ChequeBookView(decimal chequeBookId)
        {
            ChequeBookInfo chequebookinfo = new ChequeBookInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@chequeBookId", SqlDbType.Decimal);
                sprmparam.Value = chequeBookId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    chequebookinfo.ChequeBookId = decimal.Parse(sdrreader[0].ToString());
                    chequebookinfo.AccountId = decimal.Parse(sdrreader[1].ToString());
                    chequebookinfo.LayoutId = decimal.Parse(sdrreader[2].ToString());
                    chequebookinfo.NumberOfChequeLeaves = int.Parse(sdrreader[3].ToString());
                    chequebookinfo.StartNumber = sdrreader[4].ToString();
                    chequebookinfo.EndNumber = sdrreader[5].ToString();
                    chequebookinfo.ExtraOne = sdrreader[6].ToString();
                    chequebookinfo.ExtraTwo = sdrreader[7].ToString();
                    chequebookinfo.ChequeBookName = sdrreader[8].ToString();
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
            return chequebookinfo;
        }
        public bool ChequeBookDelete(decimal ChequeBookId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@chequeBookId", SqlDbType.Decimal);
                sprmparam.Value = ChequeBookId;
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
        public int ChequeBookGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookMax", sqlcon);
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
        public DataTable FilterChequeBookByAccount(decimal decAccountId)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("FilterChequeBookByAccount", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@accountId", SqlDbType.Decimal).Value = decAccountId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable FilterChequeBookByBank(decimal decBankId)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("FilterChequeBookByBank", sqlcon);
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
        public DataTable ChequeBookWiseReport(decimal chequeBookId, string fromDate, string toDate)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeBookWiseReport", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = chequeBookId;
                sdaadapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = fromDate;
                sdaadapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = toDate;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable ChequeBookWiseReportIfNull(decimal chequeBookId)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeBookWiseReportIfNull", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = chequeBookId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable ViewChequeBookByBank(decimal decAccountId)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeBookListView", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@accountId", SqlDbType.Decimal).Value = decAccountId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable ChequebookSearch(string strChequebookName, decimal decAccountId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequebookSearch", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@accountId", SqlDbType.Decimal).Value = decAccountId;
                sdaadapter.SelectCommand.Parameters.Add("@chequebookName", SqlDbType.VarChar).Value = strChequebookName + "%";
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public string ChequeBookCreationWithLeaf(ChequeBookInfo chequebookinfo, StatusInfo statusinfo)
        {
            //Edited by fawas on 29/09/2012

            string strExist = "NoBook";
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookCreationWithLeaf", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@chequeBookName", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.ChequeBookName;
                sprmparam = sccmd.Parameters.Add("@accountId", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.AccountId;
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = chequebookinfo.LayoutId;
                sprmparam = sccmd.Parameters.Add("@numberOfChequeLeaves", SqlDbType.Int);
                sprmparam.Value = chequebookinfo.NumberOfChequeLeaves;
                sprmparam = sccmd.Parameters.Add("@startNumber", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.StartNumber;
                sprmparam = sccmd.Parameters.Add("@endNumber", SqlDbType.VarChar);
                sprmparam.Value = chequebookinfo.EndNumber;
                sprmparam = sccmd.Parameters.Add("@forCompany", SqlDbType.Bit);
                sprmparam.Value = statusinfo.ForCompany;
                sprmparam = sccmd.Parameters.Add("@signatoryName", SqlDbType.Bit);
                sprmparam.Value = statusinfo.SignatoryName;
                sprmparam = sccmd.Parameters.Add("@accountNumber", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AccountNumber;
                sprmparam = sccmd.Parameters.Add("@bearerStrike", SqlDbType.Bit);
                sprmparam.Value = statusinfo.BearerStrike;
                sprmparam = sccmd.Parameters.Add("@accountPayee", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AccountPayee;
                sprmparam = sccmd.Parameters.Add("@nonNegotiable", SqlDbType.Bit);
                sprmparam.Value = statusinfo.NonNegotiable;
                sprmparam = sccmd.Parameters.Add("@payableAtPar", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayableAtPar;
                sprmparam = sccmd.Parameters.Add("@notAbove", SqlDbType.Bit);
                sprmparam.Value = statusinfo.NotAbove;
                sprmparam = sccmd.Parameters.Add("@payeeNameSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayeeNameSuffix;
                sprmparam = sccmd.Parameters.Add("@amountSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountSuffix;
                sprmparam = sccmd.Parameters.Add("@amountInWordsSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountInWordsSuffix;
                sprmparam = sccmd.Parameters.Add("@allowPostDatedCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowPostDatedCheque;
                sprmparam = sccmd.Parameters.Add("@allowPreDatedCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowPreDatedCheque;
                sprmparam = sccmd.Parameters.Add("@allowBlankAmountCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowBlankAmountCheque;
                sprmparam = sccmd.Parameters.Add("@allowBlankPayeeCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowBlankPayeeCheque;
                sprmparam = sccmd.Parameters.Add("@payeeAccountDetails", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayeeAccountDetails;
                sprmparam = sccmd.Parameters.Add("@amountPrefix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountPrefix;
                sprmparam = sccmd.Parameters.Add("@payeeLineTwo", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayeeLineTwo;
                sprmparam = sccmd.Parameters.Add("@amountInWordsTwo", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountInWordsTwo;
                sprmparam = sccmd.Parameters.Add("@signatoryStamp", SqlDbType.Bit);
                sprmparam.Value = statusinfo.SignatoryStamp;
                strExist = sccmd.ExecuteScalar().ToString();
                //object obj = sccmd.ExecuteScalar();
                //if (obj != null)
                //{
                //    strExist = obj.ToString();
                //}
                //int Execute = sccmd.ExecuteNonQuery();
                //if (Execute > 0)
                //{
                //    isCheck = true;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlcon.Close();
            }
            //return isCheck;
            return strExist;
        }
        public DataTable FilterChequeBookByAccountWithLeafs(decimal decAccountId)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("FilterChequeBookByAccountWithLeafs", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@accountId", SqlDbType.Decimal).Value = decAccountId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public void ChequeBookEditWithStatus(StatusInfo statusinfo, decimal decChequebookId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookEditWithStatus", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@chequeBookId", SqlDbType.Decimal);
                sprmparam.Value = decChequebookId;
                sprmparam = sccmd.Parameters.Add("@forCompany", SqlDbType.Bit);
                sprmparam.Value = statusinfo.ForCompany;
                sprmparam = sccmd.Parameters.Add("@signatoryName", SqlDbType.Bit);
                sprmparam.Value = statusinfo.SignatoryName;
                sprmparam = sccmd.Parameters.Add("@accountNumber", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AccountNumber;
                sprmparam = sccmd.Parameters.Add("@bearerStrike", SqlDbType.Bit);
                sprmparam.Value = statusinfo.BearerStrike;
                sprmparam = sccmd.Parameters.Add("@accountPayee", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AccountPayee;
                sprmparam = sccmd.Parameters.Add("@nonNegotiable", SqlDbType.Bit);
                sprmparam.Value = statusinfo.NonNegotiable;
                sprmparam = sccmd.Parameters.Add("@payableAtPar", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayableAtPar;
                sprmparam = sccmd.Parameters.Add("@notAbove", SqlDbType.Bit);
                sprmparam.Value = statusinfo.NotAbove;
                sprmparam = sccmd.Parameters.Add("@payeeNameSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayeeNameSuffix;
                sprmparam = sccmd.Parameters.Add("@amountSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountSuffix;
                sprmparam = sccmd.Parameters.Add("@amountInWordsSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountInWordsSuffix;
                sprmparam = sccmd.Parameters.Add("@allowPostDatedCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowPostDatedCheque;
                sprmparam = sccmd.Parameters.Add("@allowPreDatedCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowPreDatedCheque;
                sprmparam = sccmd.Parameters.Add("@allowBlankAmountCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowBlankAmountCheque;
                sprmparam = sccmd.Parameters.Add("@allowBlankPayeeCheque", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AllowBlankPayeeCheque;
                sprmparam = sccmd.Parameters.Add("@payeeAccountDetails", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayeeAccountDetails;
                sprmparam = sccmd.Parameters.Add("@amountPrefix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountPrefix;
                sprmparam = sccmd.Parameters.Add("@payeeLineTwo", SqlDbType.Bit);
                sprmparam.Value = statusinfo.PayeeLineTwo;
                sprmparam = sccmd.Parameters.Add("@amountInWordsTwo", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountInWordsTwo;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = statusinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = statusinfo.ExtraTwo;
                sprmparam = sccmd.Parameters.Add("@signatoryStamp", SqlDbType.Bit);
                sprmparam.Value = statusinfo.SignatoryStamp;

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
