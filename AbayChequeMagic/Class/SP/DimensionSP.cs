using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for DimensionSP    
//</summary>    
namespace AbayChequeMagic
{
    class DimensionSP : DBConnection
    {
        public void DimensionAdd(DimensionInfo dimensioninfo)
        {
            //Edited by rinesh on 25/09/2012

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DimensionAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@dimensionId", SqlDbType.Decimal);
                //sprmparam.Value = dimensioninfo.DimensionId;
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = dimensioninfo.LayoutId;
                sprmparam = sccmd.Parameters.Add("@fieldId", SqlDbType.Decimal);
                sprmparam.Value = dimensioninfo.FieldId;
                sprmparam = sccmd.Parameters.Add("@xAxis", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.XAxis;
                sprmparam = sccmd.Parameters.Add("@yAxis", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.YAxis;
                sprmparam = sccmd.Parameters.Add("@width", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.Width;
                sprmparam = sccmd.Parameters.Add("@height", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.Height;
                //sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                //sprmparam.Value = dimensioninfo.ExtraOne;
                //sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                //sprmparam.Value = dimensioninfo.ExtraTwo;
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
        public void DimensionEdit(DimensionInfo dimensioninfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DimensionEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dimensionId", SqlDbType.Decimal);
                sprmparam.Value = dimensioninfo.DimensionId;
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = dimensioninfo.LayoutId;
                sprmparam = sccmd.Parameters.Add("@fieldId", SqlDbType.Decimal);
                sprmparam.Value = dimensioninfo.FieldId;
                sprmparam = sccmd.Parameters.Add("@xAxis", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.XAxis;
                sprmparam = sccmd.Parameters.Add("@yAxis", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.YAxis;
                sprmparam = sccmd.Parameters.Add("@width", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.Width;
                sprmparam = sccmd.Parameters.Add("@height", SqlDbType.Float);
                sprmparam.Value = dimensioninfo.Height;
                //sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                //sprmparam.Value = dimensioninfo.ExtraOne;
                //sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                //sprmparam.Value = dimensioninfo.ExtraTwo;
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
        public DataTable DimensionViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("DimensionViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DimensionInfo DimensionView(decimal dimensionId)
        {
            DimensionInfo dimensioninfo = new DimensionInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DimensionView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dimensionId", SqlDbType.Decimal);
                sprmparam.Value = dimensionId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    dimensioninfo.DimensionId = decimal.Parse(sdrreader[0].ToString());
                    dimensioninfo.LayoutId = decimal.Parse(sdrreader[1].ToString());
                    dimensioninfo.FieldId = decimal.Parse(sdrreader[2].ToString());
                    dimensioninfo.XAxis = float.Parse(sdrreader[3].ToString());
                    dimensioninfo.YAxis = float.Parse(sdrreader[4].ToString());
                    dimensioninfo.Width = float.Parse(sdrreader[5].ToString());
                    dimensioninfo.Height = float.Parse(sdrreader[6].ToString());
                    //dimensioninfo.ExtraOne= sdrreader[7].ToString();
                    //dimensioninfo.ExtraTwo= sdrreader[8].ToString();
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
            return dimensioninfo;
        }
        public void DimensionDelete(decimal DimensionId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DimensionDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@dimensionId", SqlDbType.Decimal);
                sprmparam.Value = DimensionId;
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
        public int DimensionGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DimensionMax", sqlcon);
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
        public DataTable ViewDimensionsOfAllFieldForALayout(decimal decLayoutId)
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewDimensionsOfAllFieldForALayout", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@layoutId", SqlDbType.Decimal).Value = decLayoutId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public decimal GetDimensionIdForALayoutIdAndFeildId1(decimal layoutId)
        {
            decimal decDimensionId = 0;
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("GetDimensionIdForALayoutIdAndFeildId1", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@layoutId", SqlDbType.Decimal);
                sprmparam.Value = layoutId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    decDimensionId = decimal.Parse(sdrreader[0].ToString());

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
            return decDimensionId;
        }
    }
}
