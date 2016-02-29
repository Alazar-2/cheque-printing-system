using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for UserTypeSP    
//</summary>    
namespace AbayChequeMagic
{
    class UserTypeSP : DBConnection
    {
        public bool UserTypeAdd(UserTypeInfo usertypeinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserTypeAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                //sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                //sprmparam.Value = usertypeinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@userType", SqlDbType.VarChar);
                sprmparam.Value = usertypeinfo.UserType;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = usertypeinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = usertypeinfo.ExtraTwo;
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
        public bool UserTypeEdit(UserTypeInfo usertypeinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserTypeEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = usertypeinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@userType", SqlDbType.VarChar);
                sprmparam.Value = usertypeinfo.UserType;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = usertypeinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = usertypeinfo.ExtraTwo;
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
        public DataTable UserTypeViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("UserTypeViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable ViewAllUsers()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("ViewAllUsers", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public UserTypeInfo UserTypeView(decimal userTypeId)
        {
            UserTypeInfo usertypeinfo = new UserTypeInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserTypeView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = userTypeId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    usertypeinfo.UserTypeId = decimal.Parse(sdrreader[0].ToString());
                    usertypeinfo.UserType = sdrreader[1].ToString();
                    usertypeinfo.ExtraOne = sdrreader[2].ToString();
                    usertypeinfo.ExtraTwo = sdrreader[3].ToString();
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
            return usertypeinfo;
        }
        public int UserTypeGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserTypeMax", sqlcon);
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
        public DataTable SearchByUsertypeInUserType(string strUserType)
        {
            DataTable dtblUser = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchByUsertypeInUserType", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@userType", SqlDbType.VarChar).Value = strUserType + "%";
                sdaadapter.Fill(dtblUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblUser;
        }
        public bool UserTypeDelete(decimal UserTypeId)
        {
            bool isCheck = false;

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserTypeDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("userTypeId", SqlDbType.Decimal);
                sprmparam.Value = UserTypeId;
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

    }
}
