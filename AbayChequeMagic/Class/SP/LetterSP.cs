using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for LetterSP    
//</summary>    
namespace AbayChequeMagic
{
    class LetterSP : DBConnection
    {
        public void LetterAdd(LetterInfo letterinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@letterId", SqlDbType.Decimal);
                //sprmparam.Value = letterinfo.LetterId;
                sprmparam = sccmd.Parameters.Add("@description", SqlDbType.VarChar);
                sprmparam.Value = letterinfo.Description;
                sprmparam = sccmd.Parameters.Add("@letterType", SqlDbType.VarChar);
                sprmparam.Value = letterinfo.LetterType;
                //sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                //sprmparam.Value = letterinfo.ExtraOne;
                //sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                //sprmparam.Value = letterinfo.ExtraTwo;
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
        public void LetterEdit(LetterInfo letterinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@letterId", SqlDbType.Decimal);
                sprmparam.Value = letterinfo.LetterId;
                sprmparam = sccmd.Parameters.Add("@description", SqlDbType.VarChar);
                sprmparam.Value = letterinfo.Description;
                sprmparam = sccmd.Parameters.Add("@letterType", SqlDbType.VarChar);
                sprmparam.Value = letterinfo.LetterType;
                //sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                //sprmparam.Value = letterinfo.ExtraOne;
                //sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                //sprmparam.Value = letterinfo.ExtraTwo;
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
        public DataTable LetterViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("LetterViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public LetterInfo LetterView(decimal letterId)
        {
            LetterInfo letterinfo = new LetterInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@letterId", SqlDbType.Decimal);
                sprmparam.Value = letterId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    letterinfo.LetterId = decimal.Parse(sdrreader[0].ToString());
                    letterinfo.Description = sdrreader[1].ToString();
                    letterinfo.LetterType = sdrreader[2].ToString();
                    letterinfo.ExtraOne = sdrreader[3].ToString();
                    letterinfo.ExtraTwo = sdrreader[4].ToString();
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
            return letterinfo;
        }
        public void LetterDelete(decimal LetterId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@letterId", SqlDbType.Decimal);
                sprmparam.Value = LetterId;
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
        public int LetterGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterMax", sqlcon);
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
        public DataTable SelectSignatoryDetailsForLetters()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SelectSignatoryDetailsForLetters", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable PrepareLetter(decimal payeeId, string letterType)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("PrepareLetter", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sdaadapter.SelectCommand.Parameters.Add("@payeeId", SqlDbType.Decimal);
                sprmparam.Value = payeeId;
                sprmparam = sdaadapter.SelectCommand.Parameters.Add("@letterType", SqlDbType.VarChar);
                sprmparam.Value = letterType;
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
