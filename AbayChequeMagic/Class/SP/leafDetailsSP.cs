using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

//<summary>    
//Summary description for leafDetailsSP    
//</summary>    
namespace AbayChequeMagic
{
    class leafDetailsSP : DBConnection
    {
        public void leafDetailsAdd(leafDetailsInfo leafdetailsinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("leafDetailsAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@leafDetailsId", SqlDbType.Decimal);
                //sprmparam.Value = leafdetailsinfo.LeafDetailsId;
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.LeafId;
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.PayeeId;
                sprmparam = sccmd.Parameters.Add("@expenseId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.ExpenseId;
                sprmparam = sccmd.Parameters.Add("@chequeLeafNumber", SqlDbType.VarChar);
                sprmparam.Value = leafdetailsinfo.ChequeLeafNumber;
                sprmparam = sccmd.Parameters.Add("@issuedDate", SqlDbType.DateTime);
                sprmparam.Value = leafdetailsinfo.IssuedDate;
                sprmparam = sccmd.Parameters.Add("@amount", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.Amount;
                sprmparam = sccmd.Parameters.Add("@currentDate", SqlDbType.DateTime);
                sprmparam.Value = leafdetailsinfo.CurrentDate;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = leafdetailsinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = leafdetailsinfo.ExtraTwo;
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
        public void leafDetailsEdit(leafDetailsInfo leafdetailsinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("leafDetailsEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafDetailsId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.LeafDetailsId;
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.LeafId;
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.PayeeId;
                sprmparam = sccmd.Parameters.Add("@expenseId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.ExpenseId;
                sprmparam = sccmd.Parameters.Add("@chequeLeafNumber", SqlDbType.VarChar);
                sprmparam.Value = leafdetailsinfo.ChequeLeafNumber;
                sprmparam = sccmd.Parameters.Add("@issuedDate", SqlDbType.DateTime);
                sprmparam.Value = leafdetailsinfo.IssuedDate;
                sprmparam = sccmd.Parameters.Add("@amount", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.Amount;
                sprmparam = sccmd.Parameters.Add("@currentDate", SqlDbType.DateTime);
                sprmparam.Value = leafdetailsinfo.CurrentDate;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = leafdetailsinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = leafdetailsinfo.ExtraTwo;
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
        public DataTable leafDetailsViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("leafDetailsViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public leafDetailsInfo leafDetailsView(decimal leafDetailsId)
        {
            leafDetailsInfo leafdetailsinfo = new leafDetailsInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("leafDetailsView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafDetailsId", SqlDbType.Decimal);
                sprmparam.Value = leafDetailsId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    leafdetailsinfo.LeafDetailsId = decimal.Parse(sdrreader[0].ToString());
                    leafdetailsinfo.LeafId = decimal.Parse(sdrreader[1].ToString());
                    leafdetailsinfo.PayeeId = decimal.Parse(sdrreader[2].ToString());
                    leafdetailsinfo.ExpenseId = decimal.Parse(sdrreader[3].ToString());
                    leafdetailsinfo.ChequeLeafNumber = sdrreader[4].ToString();
                    leafdetailsinfo.IssuedDate = DateTime.Parse(sdrreader[5].ToString());
                    leafdetailsinfo.Amount = decimal.Parse(sdrreader[6].ToString());
                    leafdetailsinfo.CurrentDate = DateTime.Parse(sdrreader[7].ToString());
                    leafdetailsinfo.ExtraOne = sdrreader[8].ToString();
                    leafdetailsinfo.ExtraTwo = sdrreader[9].ToString();
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
            return leafdetailsinfo;
        }
        public void leafDetailsDelete(decimal LeafDetailsId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("leafDetailsDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafDetailsId", SqlDbType.Decimal);
                sprmparam.Value = LeafDetailsId;
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
        public int leafDetailsGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("leafDetailsMax", sqlcon);
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
        public DataTable Savedleaf(decimal decChequeBookId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewSavedChequeLeafDeatils", sqlcon);

                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = decChequeBookId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PrintedChequeLeafs(decimal decChequeBookId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewAllPrintedChequeLeafsDatails", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = decChequeBookId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public bool LeafDetailsUpdate(leafDetailsInfo leafdetailsinfo)
        {
            bool IsUpdated = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafDetailsUpdate", sqlcon);
                SqlParameter sprmparam = new SqlParameter();
                sccmd.CommandType = CommandType.StoredProcedure;
                sprmparam = sccmd.Parameters.Add("@leafDetailsId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.LeafDetailsId;
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.LeafId;
                sprmparam = sccmd.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.PayeeId;
                sprmparam = sccmd.Parameters.Add("@expenseId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.ExpenseId;
                sprmparam = sccmd.Parameters.Add("@issuedDate", SqlDbType.DateTime);
                sprmparam.Value = leafdetailsinfo.IssuedDate;
                sprmparam = sccmd.Parameters.Add("@amount", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.Amount;
                sprmparam = sccmd.Parameters.Add("@payeeAccountDetailsd", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.PayeeAccountDetailsd;
                IsUpdated = sccmd.ExecuteNonQuery() > 0;
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
            return IsUpdated;
        }
        public DataTable PrintedChequeLeafsByPayee(decimal decChequeBookId, string strPayee)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchPrintedChequeByName", sqlcon);

                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = decChequeBookId;
                sdaadapter.SelectCommand.Parameters.Add("@payeeName", SqlDbType.VarChar).Value = strPayee + "%";
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PrintedChequeLeafsByDate(decimal decChequeBookId, DateTime dtDate)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchPrintedChequeByDate", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = decChequeBookId;
                sdaadapter.SelectCommand.Parameters.Add("@Date", SqlDbType.VarChar).Value = dtDate;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PrintedChequeLeafsByLeafNumber(decimal decChequeBookId, string strLeafNo)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchPrinedChequeByLeafNumber", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@chequeBookId", SqlDbType.Decimal).Value = decChequeBookId;
                sdaadapter.SelectCommand.Parameters.Add("@LeafNumber", SqlDbType.VarChar).Value = strLeafNo + "%";
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public decimal getLeafDetailsIdFromLeafId(decimal leafId)
        {
            decimal decLeafDetailsId = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("getLeafDetailsIdFromLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("@leafId", SqlDbType.Decimal).Value = leafId;
                decLeafDetailsId = decimal.Parse(sccmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlcon.Close();
            }
            return decLeafDetailsId;
        }
        public DataTable getLeafDetails(decimal leafDetailsId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("getLeafDetails", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("leafDetailsId", SqlDbType.Decimal).Value = leafDetailsId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public void ChequeBookCreation(leafDetailsInfo leafdetailsinfo)
        {
            //Created by fawas kasim on 24/09/2012
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeBookCreation", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@leafId", SqlDbType.Decimal);
                sprmparam.Value = leafdetailsinfo.LeafId;
                sprmparam = sccmd.Parameters.Add("@chequeLeafNumber", SqlDbType.VarChar);
                sprmparam.Value = leafdetailsinfo.ChequeLeafNumber;
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
        public string LeafDetailsGetChequeNumberFromLeafId(decimal decLeafId)
        {
            string strChequeLeafNumber = "";
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafDetailsGetChequeNumberFromLeafId", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("leafId", SqlDbType.Decimal).Value = decLeafId;
                strChequeLeafNumber = sccmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return strChequeLeafNumber;
        }
        public DataTable LeafDetailsGetLeafDetailsFromLeafId(decimal decLeafId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("LeafDetailsGetLeafDetailsFromLeafId", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("leafId", SqlDbType.Decimal).Value = decLeafId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable LeafDetailsGetChequeStatus()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("LeafDettailsGetChequeStatus", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public decimal LeafDetailsIsAccountSelected(decimal decLeafId)
        {
            decimal decPayeeAccountDetailsd = -1;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LeafDetailsIsAccountSelected", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("leafId", SqlDbType.Decimal).Value = decLeafId;
                decPayeeAccountDetailsd = decimal.Parse(sccmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return decPayeeAccountDetailsd;
        }
        //GetPayeeAccountNumberSelected()
        public string GetPayeeAccountNumberSelected(decimal decPayeeAccountDetailsd)
        {
            string strAccountNumberSelected = string.Empty;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("GetPayeeAccountNumberSelected", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sccmd.Parameters.Add("@payeeAccountDetailsd", SqlDbType.Decimal).Value = decPayeeAccountDetailsd;
                object obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    strAccountNumberSelected = obj.ToString();
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
            return strAccountNumberSelected;
        }
    }
}
