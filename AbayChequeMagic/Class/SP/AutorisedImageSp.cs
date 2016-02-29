using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace AbayChequeMagic
{
    class AutorisedImageSp:DBConnection
    {
        public void AuthorizesImageEdit(AutorisedImageInfo authorizedsignatoryinfo)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("AuthorizesImageEdit", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@authorizedSignatoryId", SqlDbType.Decimal);
                sprmparam.Value = authorizedsignatoryinfo.AuthorizedSignatoryId;
                sprmparam = sccmd.Parameters.Add("@signatoryDesignation", SqlDbType.VarChar);
                sprmparam.Value = authorizedsignatoryinfo.SignatoryDesignation;
                sprmparam = sccmd.Parameters.Add("@signatureName", SqlDbType.VarChar);
                sprmparam.Value = authorizedsignatoryinfo.SignatureName;
                sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
                sprmparam.Value = authorizedsignatoryinfo.ExtraOne;
                sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
                sprmparam.Value = authorizedsignatoryinfo.ExtraTwo;
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
