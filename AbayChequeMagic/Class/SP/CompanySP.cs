using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    //<Changed by ashina 13-09-2012 3:18 pm>
//<summary>    
//Summary description for CompanySP    
//</summary>    
namespace AbayChequeMagic
{
    class CompanySP : DBConnection
    {
        public bool CompanyAdd(CompanyInfo companyinfo)
        {
            bool isCkheck = false;

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanyAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@companyCode", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.CompanyCode;
                sprmparam = sccmd.Parameters.Add("@companyName", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.CompanyName;
                sprmparam = sccmd.Parameters.Add("@division", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Division;
                sprmparam = sccmd.Parameters.Add("@building", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Building;
                sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Address;
                sprmparam = sccmd.Parameters.Add("@city", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.City;
                sprmparam = sccmd.Parameters.Add("@state", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.State;
                sprmparam = sccmd.Parameters.Add("@country", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Country;
                sprmparam = sccmd.Parameters.Add("@pincode", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Pincode;
                sprmparam = sccmd.Parameters.Add("@phone", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Phone;
                sprmparam = sccmd.Parameters.Add("@mobile", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Mobile;
                sprmparam = sccmd.Parameters.Add("@fax", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Fax;
                sprmparam = sccmd.Parameters.Add("@email", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Email;
                sprmparam = sccmd.Parameters.Add("@website", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Website;
                sprmparam = sccmd.Parameters.Add("@companyLogo", SqlDbType.Image);
                sprmparam.Value = companyinfo.CompanyLogo;
                sprmparam = sccmd.Parameters.Add("@currency", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Currency;
                sprmparam = sccmd.Parameters.Add("@companyCreationDate", SqlDbType.DateTime);
                sprmparam.Value = companyinfo.CompanyCreationDate;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.ExtraTwo;
                int Execute = sccmd.ExecuteNonQuery();

                if (Execute > 0)
                {
                    isCkheck = true;
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
            return isCkheck;
        }
        public void CompanyEdit(CompanyInfo companyinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanyEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@companyCode", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.CompanyCode;
                sprmparam = sccmd.Parameters.Add("@companyName", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.CompanyName;
                sprmparam = sccmd.Parameters.Add("@division", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Division;
                sprmparam = sccmd.Parameters.Add("@building", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Building;
                sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Address;
                sprmparam = sccmd.Parameters.Add("@city", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.City;
                sprmparam = sccmd.Parameters.Add("@state", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.State;
                sprmparam = sccmd.Parameters.Add("@country", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Country;
                sprmparam = sccmd.Parameters.Add("@pincode", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Pincode;
                sprmparam = sccmd.Parameters.Add("@phone", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Phone;
                sprmparam = sccmd.Parameters.Add("@mobile", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Mobile;
                sprmparam = sccmd.Parameters.Add("@fax", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Fax;
                sprmparam = sccmd.Parameters.Add("@email", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Email;
                sprmparam = sccmd.Parameters.Add("@website", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Website;
                sprmparam = sccmd.Parameters.Add("@companyLogo", SqlDbType.Image);
                sprmparam.Value = companyinfo.CompanyLogo;
                sprmparam = sccmd.Parameters.Add("@currency", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.Currency;
                sprmparam = sccmd.Parameters.Add("@companyCreationDate", SqlDbType.DateTime);
                sprmparam.Value = companyinfo.CompanyCreationDate;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.ExtraTwo;
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
        public DataTable CompanyViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {
               
                SqlDataAdapter sdaadapter = new SqlDataAdapter("CompanyViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return dtbl;
        }
        public CompanyInfo CompanyView(string companyCode)
        {
            CompanyInfo companyinfo = new CompanyInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanyView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@companyCode", SqlDbType.VarChar);
                sprmparam.Value = companyCode;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    companyinfo.CompanyCode = sdrreader[0].ToString();
                    companyinfo.CompanyName = sdrreader[1].ToString();
                    companyinfo.Division = sdrreader[2].ToString();
                    companyinfo.Building = sdrreader[3].ToString();
                    companyinfo.Address = sdrreader[4].ToString();
                    companyinfo.City = sdrreader[5].ToString();
                    companyinfo.State = sdrreader[6].ToString();
                    companyinfo.Country = sdrreader[7].ToString();
                    companyinfo.Pincode = sdrreader[8].ToString();
                    companyinfo.Phone = sdrreader[9].ToString();
                    companyinfo.Mobile = sdrreader[10].ToString();
                    companyinfo.Fax = sdrreader[11].ToString();
                    companyinfo.Email = sdrreader[12].ToString();
                    companyinfo.Website = sdrreader[13].ToString();
                    companyinfo.CompanyLogo = (byte[])sdrreader[14];
                    companyinfo.Currency = sdrreader[15].ToString();
                    companyinfo.CompanyCreationDate = DateTime.Parse(sdrreader[16].ToString());
                    companyinfo.ExtraOne = sdrreader[17].ToString();
                    companyinfo.ExtraTwo = sdrreader[18].ToString();
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
            return companyinfo;
        }
        public void CompanyDelete(string CompanyCode)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanyDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@companyCode", SqlDbType.VarChar);
                sprmparam.Value = CompanyCode;
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
        public int CompanyGetMax()
        {
            int max = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanyMax", sqlcon);
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
        public bool CompanySetDefaultPrinter(CompanyInfo companyinfo)
        {
            bool IsUpdated = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanySetDefaultPrinter", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = companyinfo.ExtraTwo;
                IsUpdated = sccmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

            finally
            {
                sqlcon.Close();
            }
            return IsUpdated;
        }
        public string CompanySelectPrinter()
        {
            object obj = "";
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("CompanySelectPrinter", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    sqlcon.Close();
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

            finally
            {
                sqlcon.Close();
            }
            return "";
        }
        public DataTable CompanyViewDetails()
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("CompanyViewDetails", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlcon.Close();
            }
            return dtbl;
        }
        public DataTable CompanyDateWiseReport(string strDate)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("DateWiseReport", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@Date", SqlDbType.VarChar).Value = strDate;
                sdaadapter.Fill(dtbl);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
            return dtbl;
        }
        public bool UserPrivilegeChecking(decimal decUserTypeId, decimal decRightId)
        {
            bool isPrivillaged = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("UserPrivilageChecking", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@userTypeId", SqlDbType.Decimal);
                sprmparam.Value = decUserTypeId;
                sprmparam = sccmd.Parameters.Add("@rightId", SqlDbType.Decimal);
                sprmparam.Value = decRightId;
                if (sccmd.ExecuteScalar() != null)
                {
                    isPrivillaged = true;
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
            return isPrivillaged;
        }

    }
}
