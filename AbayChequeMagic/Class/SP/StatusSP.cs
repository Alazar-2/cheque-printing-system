using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for StatusSP    
//</summary>    
namespace AbayChequeMagic
{
    // Edited by Ansar. Signatory stamp added.
    class StatusSP : DBConnection
    {
        public void StatusAdd(StatusInfo statusinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@statusId", SqlDbType.Decimal);
                //sprmparam.Value = statusinfo.StatusId;
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = statusinfo.LeafId;
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
        public void StatusEdit(StatusInfo statusinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@statusId", SqlDbType.Decimal);
                sprmparam.Value = statusinfo.StatusId;
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = statusinfo.LeafId;
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
        public DataTable StatusViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("StatusViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public StatusInfo StatusView(decimal statusId)
        {
            StatusInfo statusinfo = new StatusInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@statusId", SqlDbType.Decimal);
                sprmparam.Value = statusId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    statusinfo.StatusId = decimal.Parse(sdrreader[0].ToString());
                    statusinfo.LeafId = decimal.Parse(sdrreader[1].ToString());
                    statusinfo.ForCompany = bool.Parse(sdrreader[2].ToString());
                    statusinfo.SignatoryName = bool.Parse(sdrreader[3].ToString());
                    statusinfo.AccountNumber = bool.Parse(sdrreader[4].ToString());
                    statusinfo.BearerStrike = bool.Parse(sdrreader[5].ToString());
                    statusinfo.AccountPayee = bool.Parse(sdrreader[6].ToString());
                    statusinfo.NonNegotiable = bool.Parse(sdrreader[7].ToString());
                    statusinfo.PayableAtPar = bool.Parse(sdrreader[8].ToString());
                    statusinfo.NotAbove = bool.Parse(sdrreader[9].ToString());
                    statusinfo.PayeeNameSuffix = bool.Parse(sdrreader[10].ToString());
                    statusinfo.AmountSuffix = bool.Parse(sdrreader[11].ToString());
                    statusinfo.AmountInWordsSuffix = bool.Parse(sdrreader[12].ToString());
                    statusinfo.AllowPostDatedCheque = bool.Parse(sdrreader[13].ToString());
                    statusinfo.AllowPreDatedCheque = bool.Parse(sdrreader[14].ToString());
                    statusinfo.AllowBlankAmountCheque = bool.Parse(sdrreader[15].ToString());
                    statusinfo.AllowBlankPayeeCheque = bool.Parse(sdrreader[16].ToString());
                    statusinfo.PayeeAccountDetails = bool.Parse(sdrreader[17].ToString());
                    statusinfo.AmountPrefix = bool.Parse(sdrreader[18].ToString());
                    statusinfo.PayeeLineTwo = bool.Parse(sdrreader[19].ToString());
                    statusinfo.AmountInWordsTwo = bool.Parse(sdrreader[20].ToString());
                    statusinfo.ExtraOne = sdrreader[21].ToString();
                    statusinfo.ExtraTwo = sdrreader[22].ToString();
                    statusinfo.SignatoryStamp = bool.Parse(sdrreader[23].ToString());
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
            return statusinfo;
        }
        public void StatusDelete(decimal StatusId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@statusId", SqlDbType.Decimal);
                sprmparam.Value = StatusId;
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
        public int StatusGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusMax", sqlcon);
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
        public StatusInfo StatusViewByLeafId(decimal statusId)
        {
            StatusInfo statusinfo = new StatusInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusViewByLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = statusId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    statusinfo.StatusId = decimal.Parse(sdrreader[0].ToString());
                    statusinfo.LeafId = decimal.Parse(sdrreader[1].ToString());
                    statusinfo.ForCompany = bool.Parse(sdrreader[2].ToString());
                    statusinfo.SignatoryName = bool.Parse(sdrreader[3].ToString());
                    statusinfo.AccountNumber = bool.Parse(sdrreader[4].ToString());
                    statusinfo.BearerStrike = bool.Parse(sdrreader[5].ToString());
                    statusinfo.AccountPayee = bool.Parse(sdrreader[6].ToString());
                    statusinfo.NonNegotiable = bool.Parse(sdrreader[7].ToString());
                    statusinfo.PayableAtPar = bool.Parse(sdrreader[8].ToString());
                    statusinfo.NotAbove = bool.Parse(sdrreader[9].ToString());
                    statusinfo.PayeeNameSuffix = bool.Parse(sdrreader[10].ToString());
                    statusinfo.AmountSuffix = bool.Parse(sdrreader[11].ToString());
                    statusinfo.AmountInWordsSuffix = bool.Parse(sdrreader[12].ToString());
                    statusinfo.AllowPostDatedCheque = bool.Parse(sdrreader[13].ToString());
                    statusinfo.AllowPreDatedCheque = bool.Parse(sdrreader[14].ToString());
                    statusinfo.AllowBlankAmountCheque = bool.Parse(sdrreader[15].ToString());
                    statusinfo.AllowBlankPayeeCheque = bool.Parse(sdrreader[16].ToString());
                    statusinfo.PayeeAccountDetails = bool.Parse(sdrreader[17].ToString());
                    statusinfo.AmountPrefix = bool.Parse(sdrreader[18].ToString());
                    statusinfo.PayeeLineTwo = bool.Parse(sdrreader[19].ToString());
                    statusinfo.AmountInWordsTwo = bool.Parse(sdrreader[20].ToString());
                    statusinfo.ExtraOne = sdrreader[21].ToString();
                    statusinfo.ExtraTwo = sdrreader[22].ToString();
                    statusinfo.SignatoryStamp = bool.Parse(sdrreader[23].ToString());
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
            return statusinfo;
        }
        public bool StatusEditWithLeafId(StatusInfo statusinfo)
        {
            bool IsUpdated = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusEditWithLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = statusinfo.LeafId;
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
                sprmparam = sccmd.Parameters.Add("@signatoryStamp", SqlDbType.Bit);
                sprmparam.Value = statusinfo.SignatoryStamp;
                sprmparam = sccmd.Parameters.Add("@amountPrefix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountPrefix;
                sprmparam = sccmd.Parameters.Add("@amountInWordsSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountInWordsSuffix;
                sprmparam = sccmd.Parameters.Add("@amountSuffix", SqlDbType.Bit);
                sprmparam.Value = statusinfo.AmountSuffix;
                IsUpdated = sccmd.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return IsUpdated;
        }
        public StatusInfo StatusViewWithLeafAndCheque(decimal decChequeBookId)
        {
            StatusInfo statusinfo = new StatusInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("StatusViewWithLeafAndCheque", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@chequeBookId", SqlDbType.Decimal);
                sprmparam.Value = decChequeBookId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    statusinfo.StatusId = decimal.Parse(sdrreader[0].ToString());
                    statusinfo.LeafId = decimal.Parse(sdrreader[1].ToString());
                    statusinfo.ForCompany = bool.Parse(sdrreader[2].ToString());
                    statusinfo.SignatoryName = bool.Parse(sdrreader[3].ToString());
                    statusinfo.AccountNumber = bool.Parse(sdrreader[4].ToString());
                    statusinfo.BearerStrike = bool.Parse(sdrreader[5].ToString());
                    statusinfo.AccountPayee = bool.Parse(sdrreader[6].ToString());
                    statusinfo.NonNegotiable = bool.Parse(sdrreader[7].ToString());
                    statusinfo.PayableAtPar = bool.Parse(sdrreader[8].ToString());
                    statusinfo.NotAbove = bool.Parse(sdrreader[9].ToString());
                    statusinfo.PayeeNameSuffix = bool.Parse(sdrreader[10].ToString());
                    statusinfo.AmountSuffix = bool.Parse(sdrreader[11].ToString());
                    statusinfo.AmountInWordsSuffix = bool.Parse(sdrreader[12].ToString());
                    statusinfo.AllowPostDatedCheque = bool.Parse(sdrreader[13].ToString());
                    statusinfo.AllowPreDatedCheque = bool.Parse(sdrreader[14].ToString());
                    statusinfo.AllowBlankAmountCheque = bool.Parse(sdrreader[15].ToString());
                    statusinfo.AllowBlankPayeeCheque = bool.Parse(sdrreader[16].ToString());
                    statusinfo.PayeeAccountDetails = bool.Parse(sdrreader[17].ToString());
                    statusinfo.AmountPrefix = bool.Parse(sdrreader[18].ToString());
                    statusinfo.PayeeLineTwo = bool.Parse(sdrreader[19].ToString());
                    statusinfo.AmountInWordsTwo = bool.Parse(sdrreader[20].ToString());
                    statusinfo.ExtraOne = sdrreader[21].ToString();
                    statusinfo.ExtraTwo = sdrreader[22].ToString();
                    statusinfo.SignatoryStamp = bool.Parse(sdrreader[23].ToString());
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
            return statusinfo;
        }
    }
}
