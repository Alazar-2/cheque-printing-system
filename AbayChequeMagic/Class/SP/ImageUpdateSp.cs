using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AbayChequeMagic
{
    class ImageUpdateSp:DBConnection
    {
        public void ImageEdit(CompanyInfo companyinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("ImageEdit", sqlcon);
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
    }
}
