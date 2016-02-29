using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for ChequeLayoutSP    
//</summary>    
namespace AbayChequeMagic
{
    class ChequeLayoutSP : DBConnection
    {
        //------------Edited by RINESH on 25/09/2012

        public decimal ChequeLayoutAdd(ChequeLayoutInfo chequelayoutinfo)
        {
            decimal decLastLayoutId = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeLayoutAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dateFormatId", SqlDbType.Decimal);
                sprmparam.Value = chequelayoutinfo.DateFormatId;
                sprmparam = sccmd.Parameters.Add("@layoutName", SqlDbType.VarChar);
                sprmparam.Value = chequelayoutinfo.LayoutName;
                sprmparam = sccmd.Parameters.Add("@imageLocation", SqlDbType.VarChar);
                sprmparam.Value = chequelayoutinfo.ImageLocation;
                sprmparam = sccmd.Parameters.Add("@dateSpacing", SqlDbType.VarChar);
                sprmparam.Value = chequelayoutinfo.DateSpacing;
                sprmparam = sccmd.Parameters.Add("@payeeLineTwo", SqlDbType.Bit);
                sprmparam.Value = chequelayoutinfo.PayeeLineTwo;
                sprmparam = sccmd.Parameters.Add("@amountInWordsTwo", SqlDbType.Bit);
                sprmparam.Value = chequelayoutinfo.AmountInWordsTwo;
                object obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    decLastLayoutId = decimal.Parse(obj.ToString());
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
            return decLastLayoutId;
        }
        public bool ChequeLayoutEdit(ChequeLayoutInfo chequelayoutinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeLayoutEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = chequelayoutinfo.LayoutId;
                sprmparam = sccmd.Parameters.Add("@dateFormatId", SqlDbType.Decimal);
                sprmparam.Value = chequelayoutinfo.DateFormatId;
                sprmparam = sccmd.Parameters.Add("@layoutName", SqlDbType.VarChar);
                sprmparam.Value = chequelayoutinfo.LayoutName;
                sprmparam = sccmd.Parameters.Add("@imageLocation", SqlDbType.VarChar);
                sprmparam.Value = chequelayoutinfo.ImageLocation;
                sprmparam = sccmd.Parameters.Add("@dateSpacing", SqlDbType.VarChar);
                sprmparam.Value = chequelayoutinfo.DateSpacing;
                sprmparam = sccmd.Parameters.Add("@payeeLineTwo", SqlDbType.Bit);
                sprmparam.Value = chequelayoutinfo.PayeeLineTwo;
                sprmparam = sccmd.Parameters.Add("@amountInWordsTwo", SqlDbType.Bit);
                sprmparam.Value = chequelayoutinfo.AmountInWordsTwo;
                int inUpdatedRows = sccmd.ExecuteNonQuery();
                if (inUpdatedRows > 0)
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
        public DataTable ChequeLayoutViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
               
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeLayoutViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtbl;
        }
        public ChequeLayoutInfo ChequeLayoutView(decimal layoutId)
        {
            ChequeLayoutInfo chequelayoutinfo = new ChequeLayoutInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeLayoutView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = layoutId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    chequelayoutinfo.LayoutId = decimal.Parse(sdrreader[0].ToString());
                    chequelayoutinfo.DateFormatId = decimal.Parse(sdrreader[1].ToString());
                    chequelayoutinfo.LayoutName = sdrreader[2].ToString();
                    chequelayoutinfo.ImageLocation = sdrreader[3].ToString();
                    chequelayoutinfo.DateSpacing = sdrreader[4].ToString();
                    chequelayoutinfo.PayeeLineTwo = bool.Parse(sdrreader[5].ToString());
                    chequelayoutinfo.AmountInWordsTwo = bool.Parse(sdrreader[6].ToString());
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
            return chequelayoutinfo;
        }
        public bool ChequeLayoutDelete(decimal LayoutId)
        {
            //Edited by RINESH on 25/09/2012
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeLayoutDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = LayoutId;
                int inDeletedRows = sccmd.ExecuteNonQuery();
                if (inDeletedRows > 0)
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
        public int ChequeLayoutGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ChequeLayoutMax", sqlcon);
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
        public string ImageLocaton(decimal layoutId)
        {
            string strLocation = string.Empty;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("SelectImageLocation", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = layoutId;
                strLocation = sccmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlcon.Close();
            }
            return strLocation;
        }
        public DataTable ViewAllImages()
        {
            DataTable dtbl = new DataTable();
            try
            {
                
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewAllImages", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtbl;
        }
        public DataTable ViewAllLayoutWithLayoutId()
        {
            DataTable dtbl = new DataTable();
            try
            {
                
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewAllLayoutWithLayoutId", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtbl;
        }
        public DataTable SearchLayout(string strLayoutName)
        {
            //Created By RINESH on 26/09/2012//

            DataTable dtblLayout = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeLayoutSearch", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@layoutName", SqlDbType.VarChar).Value = strLayoutName;
                sdaadapter.Fill(dtblLayout);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtblLayout;
        }
        //ChequeLayoutLayoutInfoFromLeafId
        public DataTable ChequeLayoutLayoutInfoFromLeafId(decimal decLeafId)
        {
            DataTable dtbl = new DataTable();
            try
            {
               
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ChequeLayoutLayoutInfoFromLeafId", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@leafId", SqlDbType.VarChar).Value = decLeafId;
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
