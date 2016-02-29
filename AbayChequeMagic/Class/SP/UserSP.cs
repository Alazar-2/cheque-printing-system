using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for UserSP    
//</summary>    
namespace AbayChequeMagic
{
    class UserSP : DBConnection
    {
        public bool UserAdd(UserInfo userinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Username;
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = userinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@password", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Password;
                sprmparam = sccmd.Parameters.Add("@employeeId", SqlDbType.Decimal);
                sprmparam.Value = userinfo.EmployeeId;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraTwo;
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
        public bool UserEdit(UserInfo userinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Username;
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = userinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@password", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Password;
                sprmparam = sccmd.Parameters.Add("@employeeId", SqlDbType.Decimal);
                sprmparam.Value = userinfo.EmployeeId;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraTwo;
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
        public DataTable UserViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("UserViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public UserInfo UserView(string username)
        {
            UserInfo userinfo = new UserInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = username;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    userinfo.Username = sdrreader[0].ToString();
                    userinfo.UserTypeId = decimal.Parse(sdrreader[1].ToString());
                    userinfo.Password = sdrreader[2].ToString();
                    //userinfo.EmployeeId =decimal.Parse(sdrreader[3].ToString());    
                    userinfo.ExtraOne = sdrreader[4].ToString();
                    userinfo.ExtraTwo = sdrreader[5].ToString();
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
            return userinfo;
        }
        public UserInfo UserViewForChangePassword(string username)
        {
            UserInfo userinfo = new UserInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = username;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    userinfo.Username = sdrreader[0].ToString();
                    userinfo.UserTypeId = decimal.Parse(sdrreader[1].ToString());
                    userinfo.Password = sdrreader[2].ToString();
                    if (frmLogin.strLoginStatus != "1")
                    {
                        userinfo.EmployeeId = decimal.Parse(sdrreader[3].ToString());
                    }
                    userinfo.ExtraOne = sdrreader[4].ToString();
                    userinfo.ExtraTwo = sdrreader[5].ToString();
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
            return userinfo;
        }
        public UserInfo UserViewEdit(string username)
        {
            UserInfo userinfo = new UserInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserViewEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = username;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    userinfo.Username = sdrreader[0].ToString();
                    userinfo.UserTypeId = decimal.Parse(sdrreader[1].ToString());
                    userinfo.Password = sdrreader[2].ToString();
                    userinfo.EmployeeId = decimal.Parse(sdrreader[3].ToString());
                    userinfo.ExtraOne = sdrreader[4].ToString();
                    userinfo.ExtraTwo = sdrreader[5].ToString();
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
            return userinfo;
        }
        public void UserDelete(string Username)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = Username;
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
        public int UserGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserMax", sqlcon);
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
        public DataTable UserViewOnGridView()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("UserViewOnGridView", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
        public DataTable SearchUserByName(string strUserName)
        {
            DataTable dtblUser = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchUserByName", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = strUserName + "%";
                sdaadapter.Fill(dtblUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblUser;
        }
        public DataTable SearchByUserType(string strusertype)
        {
            DataTable dtblusertype = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchByUserType", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@userType", SqlDbType.VarChar).Value = strusertype + "%";
                sdaadapter.Fill(dtblusertype);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblusertype;
        }
        public DataTable SearchByEmployeeCode(string strEmpcode)
        {
            DataTable dtblEmpcode = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchByEmployeeCode", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@employeeCode", SqlDbType.VarChar).Value = strEmpcode + "%";
                sdaadapter.Fill(dtblEmpcode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblEmpcode;
        }
        public void CompanyCreationWithAdmin(UserInfo userinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanyCreationWithAdmin", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Username;
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = userinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@password", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Password;
                //sprmparam = sccmd.Parameters.Add("@employeeId", SqlDbType.Decimal);
                //sprmparam.Value = userinfo.EmployeeId;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraTwo;
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
        public bool UserEditForChagePassword(UserInfo userinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@username", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Username;
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = userinfo.UserTypeId;
                sprmparam = sccmd.Parameters.Add("@password", SqlDbType.VarChar);
                sprmparam.Value = userinfo.Password;
                sprmparam = sccmd.Parameters.Add("@employeeId", SqlDbType.Decimal);
                if (frmLogin.strLoginStatus == "1")
                {
                    sprmparam.Value = DBNull.Value;
                }
                else
                {
                    sprmparam.Value = userinfo.EmployeeId;
                }
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = userinfo.ExtraTwo;
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
    }
}
