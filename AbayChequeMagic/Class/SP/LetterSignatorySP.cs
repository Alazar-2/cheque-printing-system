using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for LetterSignatorySP    
//</summary>    
namespace AbayChequeMagic
{
    class LetterSignatorySP : DBConnection
    {
        public void LetterSignatoryAdd(LetterSignatoryInfo lettersignatoryinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterSignatoryAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@letterSignatoryId", SqlDbType.Decimal);
                //sprmparam.Value = lettersignatoryinfo.LetterSignatoryId;
                sprmparam = sccmd.Parameters.Add("@signatoryDesignation", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.SignatoryDesignation;
                sprmparam = sccmd.Parameters.Add("@letterSignatoryName", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.LetterSignatoryName;
                sprmparam = sccmd.Parameters.Add("@letterSignatoryStamp", SqlDbType.Image);
                sprmparam.Value = lettersignatoryinfo.LetterSignatoryStamp;
                sprmparam = sccmd.Parameters.Add("@printLetterSignatory", SqlDbType.Bit);
                sprmparam.Value = lettersignatoryinfo.PrintLetterSignatory;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.ExtraTwo;
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
        public void LetterSignatoryEdit(LetterSignatoryInfo lettersignatoryinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterSignatoryEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@letterSignatoryId", SqlDbType.Decimal);
                sprmparam.Value = lettersignatoryinfo.LetterSignatoryId;
                sprmparam = sccmd.Parameters.Add("@signatoryDesignation", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.SignatoryDesignation;
                sprmparam = sccmd.Parameters.Add("@letterSignatoryName", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.LetterSignatoryName;
                sprmparam = sccmd.Parameters.Add("@letterSignatoryStamp", SqlDbType.Image);
                sprmparam.Value = lettersignatoryinfo.LetterSignatoryStamp;
                sprmparam = sccmd.Parameters.Add("@printLetterSignatory", SqlDbType.Bit);
                sprmparam.Value = lettersignatoryinfo.PrintLetterSignatory;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.ExtraTwo;
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
        public DataTable LetterSignatoryViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("LetterSignatoryViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public LetterSignatoryInfo LetterSignatoryView(decimal letterSignatoryId)
        {
            LetterSignatoryInfo lettersignatoryinfo = new LetterSignatoryInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterSignatoryView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@letterSignatoryId", SqlDbType.Decimal);
                sprmparam.Value = letterSignatoryId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    lettersignatoryinfo.LetterSignatoryId = decimal.Parse(sdrreader[0].ToString());
                    lettersignatoryinfo.SignatoryDesignation = sdrreader[1].ToString();
                    lettersignatoryinfo.LetterSignatoryName = sdrreader[2].ToString();
                    lettersignatoryinfo.LetterSignatoryStamp = (byte[])sdrreader[3];
                    lettersignatoryinfo.PrintLetterSignatory = bool.Parse(sdrreader[4].ToString());
                    lettersignatoryinfo.ExtraOne = sdrreader[5].ToString();
                    lettersignatoryinfo.ExtraTwo = sdrreader[6].ToString();
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
            return lettersignatoryinfo;
        }
        public void LetterSignatoryDelete(decimal LetterSignatoryId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterSignatoryDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@letterSignatoryId", SqlDbType.Decimal);
                sprmparam.Value = LetterSignatoryId;
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
        public int LetterSignatoryGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterSignatoryMax", sqlcon);
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
        public void LetterImageEdit(LetterSignatoryInfo lettersignatoryinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("LetterImageEdit ", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@letterSignatoryId", SqlDbType.Decimal);
                sprmparam.Value = lettersignatoryinfo.LetterSignatoryId;
                sprmparam = sccmd.Parameters.Add("@signatoryDesignation", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.SignatoryDesignation;
                sprmparam = sccmd.Parameters.Add("@letterSignatoryName", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.LetterSignatoryName;
                sprmparam = sccmd.Parameters.Add("@printLetterSignatory", SqlDbType.Bit);
                sprmparam.Value = lettersignatoryinfo.PrintLetterSignatory;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = lettersignatoryinfo.ExtraTwo;
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
        public LetterSignatoryInfo LetterSignatoryView()
        {
            LetterSignatoryInfo lettersignatoryinfo = new LetterSignatoryInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("SelectSignatoryDetailsForLetters", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    lettersignatoryinfo.SignatoryDesignation = sdrreader[1].ToString();
                    lettersignatoryinfo.LetterSignatoryName = sdrreader[2].ToString();
                    lettersignatoryinfo.LetterSignatoryStamp = (byte[])sdrreader[3];

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
            return lettersignatoryinfo;
        }
    }
}
