using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for UserRightSP    
//</summary>    
namespace AbayChequeMagic
{
    class UserRightSP : DBConnection
    {
        public void UserRightAdd(UserRightInfo userrightinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserRightAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = userrightinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@rightId", SqlDbType.Decimal);
                sprmparam.Value = userrightinfo.RightId;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = userrightinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = userrightinfo.ExtraTwo;
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
        public void UserRightEdit(UserRightInfo userrightinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserRightEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userRightId", SqlDbType.Decimal);
                sprmparam.Value = userrightinfo.UserRightId;
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = userrightinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@rightId", SqlDbType.Decimal);
                sprmparam.Value = userrightinfo.RightId;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = userrightinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = userrightinfo.ExtraTwo;
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
        public DataTable UserRightViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("UserRightViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public UserRightInfo UserRightView(decimal userRightId)
        {
            UserRightInfo userrightinfo = new UserRightInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserRightView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userRightId", SqlDbType.Decimal);
                sprmparam.Value = userRightId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    userrightinfo.UserRightId = decimal.Parse(sdrreader[0].ToString());
                    userrightinfo.UserTypeId = decimal.Parse(sdrreader[1].ToString());
                    userrightinfo.RightId = decimal.Parse(sdrreader[2].ToString());
                    userrightinfo.ExtraOne = sdrreader[3].ToString();
                    userrightinfo.ExtraTwo = sdrreader[4].ToString();
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
            return userrightinfo;
        }
        public void UserRightDelete(decimal UserRightId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserRightDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userRightId", SqlDbType.Decimal);
                sprmparam.Value = UserRightId;
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
        public int UserRightGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserRightMax", sqlcon);
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
        public void DeleteUserRights(decimal UserTypeId)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("DeleteUserRights", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = UserTypeId;
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
        public DataTable UserRightViewAllByUserType(decimal decUserTypeId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("UserRightViewAllByUserType", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@userTypeId", SqlDbType.Decimal).Value = decUserTypeId;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable UserRightViewAllByID(decimal decUserTypeId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("UserRightViewAllByID", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@userTypeId", SqlDbType.Decimal).Value = decUserTypeId;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable RightsShowOnListBox(decimal decUserTypeId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("RightsShowOnListBox", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@userTypeId", SqlDbType.Decimal).Value = decUserTypeId;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable ViewRightName(decimal decUserTypeId)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewRightName", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@userTypeId", SqlDbType.Decimal).Value = decUserTypeId;
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
