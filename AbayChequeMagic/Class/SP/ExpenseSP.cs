using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for ExpenseSP    
//</summary>    
namespace AbayChequeMagic
{
    class ExpenseSP : DBConnection
    {
        public bool ExpenseAdd(ExpenseInfo expenseinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ExpenseAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@expenseId", SqlDbType.Decimal);
                //sprmparam.Value = expenseinfo.ExpenseId;
                sprmparam = sccmd.Parameters.Add("@expenseName", SqlDbType.VarChar);
                sprmparam.Value = expenseinfo.ExpenseName;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = expenseinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = expenseinfo.ExtraTwo;
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
        public bool ExpenseEdit(ExpenseInfo expenseinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ExpenseEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@expenseId", SqlDbType.Decimal);
                sprmparam.Value = expenseinfo.ExpenseId;
                sprmparam = sccmd.Parameters.Add("@expenseName", SqlDbType.VarChar);
                sprmparam.Value = expenseinfo.ExpenseName;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = expenseinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = expenseinfo.ExtraTwo;
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
        public DataTable ExpenseViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ExpenseViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public ExpenseInfo ExpenseView(decimal expenseId)
        {
            ExpenseInfo expenseinfo = new ExpenseInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ExpenseView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@expenseId", SqlDbType.Decimal);
                sprmparam.Value = expenseId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    expenseinfo.ExpenseId = decimal.Parse(sdrreader[0].ToString());
                    expenseinfo.ExpenseName = sdrreader[1].ToString();
                    expenseinfo.ExtraOne = sdrreader[2].ToString();
                    expenseinfo.ExtraTwo = sdrreader[3].ToString();
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
            return expenseinfo;
        }
        public void ExpenseDelete(decimal ExpenseId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ExpenseDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@expenseId", SqlDbType.Decimal);
                sprmparam.Value = ExpenseId;
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
        public int ExpenseGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ExpenseMax", sqlcon);
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
        public DataTable ExpenseViewAllAndSelect()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ExpenseViewAllAndSelect", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable ExpensceSearch(string strExpense)
        {
            DataTable dtblExpense = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ExpensceSearch", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@expenseName", SqlDbType.VarChar).Value = strExpense + "%";
                sdaadapter.Fill(dtblExpense);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblExpense;
        }
        public DataTable ExpenseWiseReport(decimal decExpense, string fromDate, string toDate)
        {
            DataTable dtblExpense = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ExpenseWiseReport", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@expenseId", SqlDbType.VarChar).Value = decExpense;
                sdaadapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = fromDate;
                sdaadapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = toDate;
                sdaadapter.Fill(dtblExpense);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlcon.Close();
            }
            return dtblExpense;
        }
    }
}
