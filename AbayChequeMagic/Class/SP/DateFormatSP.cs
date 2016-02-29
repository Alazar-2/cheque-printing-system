using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for DateFormatSP    
//</summary>    
namespace AbayChequeMagic
{
    class DateFormatSP : DBConnection
    {
        public void DateFormatAdd(DateFormatInfo dateformatinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DateFormatAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dateFormatId", SqlDbType.Decimal);
                sprmparam.Value = dateformatinfo.DateFormatId;
                sprmparam = sccmd.Parameters.Add("@dateFormat", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.DateFormat;
                sprmparam = sccmd.Parameters.Add("@dateFormatName", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.DateFormatName;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.ExtraTwo;
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
        public void DateFormatEdit(DateFormatInfo dateformatinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DateFormatEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dateFormatId", SqlDbType.Decimal);
                sprmparam.Value = dateformatinfo.DateFormatId;
                sprmparam = sccmd.Parameters.Add("@dateFormat", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.DateFormat;
                sprmparam = sccmd.Parameters.Add("@dateFormatName", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.DateFormatName;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = dateformatinfo.ExtraTwo;
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
        public DataTable DateFormatViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("DateFormatViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DateFormatInfo DateFormatView(decimal dateFormatId)
        {
            DateFormatInfo dateformatinfo = new DateFormatInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DateFormatView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dateFormatId", SqlDbType.Decimal);
                sprmparam.Value = dateFormatId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    dateformatinfo.DateFormatId = decimal.Parse(sdrreader[0].ToString());
                    dateformatinfo.DateFormat = sdrreader[1].ToString();
                    dateformatinfo.DateFormatName = sdrreader[2].ToString();
                    dateformatinfo.ExtraOne = sdrreader[3].ToString();
                    dateformatinfo.ExtraTwo = sdrreader[4].ToString();
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
            return dateformatinfo;
        }
        public void DateFormatDelete(decimal DateFormatId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DateFormatDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dateFormatId", SqlDbType.Decimal);
                sprmparam.Value = DateFormatId;
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
        public int DateFormatGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DateFormatMax", sqlcon);
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
    }
}
