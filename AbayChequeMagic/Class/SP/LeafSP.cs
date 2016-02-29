using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for LeafSP    
//</summary>    
namespace AbayChequeMagic
{
    class LeafSP : DBConnection
    {
        public void LeafAdd(LeafInfo leafinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                //sprmparam.Value = leafinfo.LeafId;
                sprmparam = sccmd.Parameters.Add("@chequeBookId", SqlDbType.Decimal);
                sprmparam.Value = leafinfo.ChequeBookId;
                sprmparam = sccmd.Parameters.Add("@chequeStatus", SqlDbType.VarChar);
                sprmparam.Value = leafinfo.ChequeStatus;
                sprmparam = sccmd.Parameters.Add("@isPrinted", SqlDbType.Bit);
                sprmparam.Value = leafinfo.IsPrinted;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = leafinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = leafinfo.ExtraTwo;
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
        public void LeafEdit(LeafInfo leafinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = leafinfo.LeafId;
                sprmparam = sccmd.Parameters.Add("@chequeBookId", SqlDbType.Decimal);
                sprmparam.Value = leafinfo.ChequeBookId;
                sprmparam = sccmd.Parameters.Add("@chequeStatus", SqlDbType.VarChar);
                sprmparam.Value = leafinfo.ChequeStatus;
                sprmparam = sccmd.Parameters.Add("@isPrinted", SqlDbType.Bit);
                sprmparam.Value = leafinfo.IsPrinted;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = leafinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = leafinfo.ExtraTwo;
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
        public DataTable LeafViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("LeafViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public LeafInfo LeafView(decimal leafId)
        {
            LeafInfo leafinfo = new LeafInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = leafId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    leafinfo.LeafId = decimal.Parse(sdrreader[0].ToString());
                    leafinfo.ChequeBookId = decimal.Parse(sdrreader[1].ToString());
                    leafinfo.ChequeStatus = sdrreader[2].ToString();
                    leafinfo.IsPrinted = bool.Parse(sdrreader[3].ToString());
                    leafinfo.ExtraOne = sdrreader[4].ToString();
                    leafinfo.ExtraTwo = sdrreader[5].ToString();
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
            return leafinfo;
        }
        public void LeafDelete(decimal LeafId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = LeafId;
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
        public int LeafGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafMax", sqlcon);
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
        public DataTable ChequeLeafWithPayeeDateAndAmount(decimal decChequBookId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeLeafWithPayeeDateAndAmount", sqlcon);
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = decChequBookId;

                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable ViewLayoutDetailsFromLeafId(decimal decleafId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewLayoutDetailsFromLeafId", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@leafId", SqlDbType.Decimal).Value = decleafId;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        //LeafGetLayoutIdFromLeafId
        public string LeafGetImageLocationFromLeafId(decimal leafId)
        {
            string strImageLocation = string.Empty;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafGetImageLocationFromLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("@leafId", SqlDbType.Decimal).Value = leafId;
                strImageLocation = sccmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return strImageLocation;
        }
        public DataTable LeafGetDateFormateIdAndSpacingFromLeafId(decimal leafId)
        {

            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("LeafGetDateFormateIdAndSpacingFromLeafId", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@leafId", SqlDbType.Decimal).Value = leafId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable getAccountNumberAndCurrentBalanceFromLeafID(decimal decleafId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("getAccountNumberAndCurrentBalanceFromLeafID", sqlcon); //'cb=cb-minimum balance
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@leafId", SqlDbType.Decimal).Value = decleafId;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable ViewBankAnkChequeNumber(string leafId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeNumberAndBankNameForLetter", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@leafId", SqlDbType.Decimal).Value = leafId;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PrintedChequeLeafWithPayeeDateAndAmount(decimal decChequBookId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PrintedChequeLeafWithPayeeDateAndAmount", sqlcon);
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = decChequBookId;
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public decimal LeafGetTransactionId(decimal leafId)
        {
            object obj;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafGetTransactionId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("@leafId", SqlDbType.Decimal).Value = leafId;
                obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    if (obj.ToString() != string.Empty)
                    {
                        sqlcon.Close();
                        return decimal.Parse(obj.ToString());
                    }
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
            return -1;
        }//LeafGetChequeBookId
        public decimal LeafGetAccountID(decimal decleafId)
        {
            object obj;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafGetAccountID", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("@leafId", SqlDbType.Decimal).Value = decleafId;
                obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    sqlcon.Close();
                    return decimal.Parse(obj.ToString());
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
            return -1;
        }//LeafGetChequeBookId
        public void LeafAddTrnasactionId(decimal decLeafId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafAddTrnasactionId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = decLeafId;
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
        //LeafGetBankNameFromLeafId
        public string LeafGetBankNameFromLeafId(decimal decLeafId)
        {
            string strBankname = "";
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafGetBankNameFromLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = decLeafId;
                strBankname = sccmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return strBankname;
        }
        //LeatSetAsPrinted
        public void LeafSetAsPrinted(decimal decLeafId)
        {

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafSetAsPrinted", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("leafId", SqlDbType.Decimal).Value = decLeafId;
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
        public bool LeafIsPrinted(decimal decLeafId)
        {
            bool IsPrinted = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafIsprinted", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = decLeafId;
                IsPrinted = bool.Parse(sccmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return IsPrinted;
        }
        public decimal LeafGetLayoutIdFromLeafId(decimal decLeafId)
        {
            object obj = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafGetLayoutIdFromLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = decLeafId;
                obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    sqlcon.Close();
                    return decimal.Parse(obj.ToString());
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
            return -1;
        }
        public void UpdateChequeStatus(LeafInfo InfoLeaf)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UpdateChequeStatus", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = InfoLeaf.LeafId;
                sprmparam = sccmd.Parameters.Add("@Status", SqlDbType.VarChar);
                sprmparam.Value = InfoLeaf.ChequeStatus;
                sccmd.ExecuteScalar();
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
        public decimal LeafGetChequeBookIdFromLeafId(decimal decLeafId)
        {
            object obj = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafGetChequeBookIdFromLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = decLeafId;
                obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    sqlcon.Close();
                    return decimal.Parse(obj.ToString());
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
            return -1;
        }
    }
}
