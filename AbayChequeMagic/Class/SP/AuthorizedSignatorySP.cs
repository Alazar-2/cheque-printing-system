using System;    
using System.Collections.Generic;    
using System.Text;    
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
    
//<summary>    
//Summary description for AuthorizedSignatorySP    
//</summary>    
namespace AbayChequeMagic    
{    
class AuthorizedSignatorySP:DBConnection    
{    
    public void AuthorizedSignatoryAdd(AuthorizedSignatoryInfo authorizedsignatoryinfo)
    {
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sccmd = new SqlCommand("AuthorizedSignatoryAdd", sqlcon);
            sccmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sprmparam = new SqlParameter();
            //sprmparam = sccmd.Parameters.Add("@authorizedSignatoryId", SqlDbType.Decimal);
            //sprmparam.Value = authorizedsignatoryinfo.AuthorizedSignatoryId;
            sprmparam = sccmd.Parameters.Add("@signatoryDesignation", SqlDbType.VarChar);
            sprmparam.Value = authorizedsignatoryinfo.SignatoryDesignation;
            sprmparam = sccmd.Parameters.Add("@signatureName", SqlDbType.VarChar);
            sprmparam.Value = authorizedsignatoryinfo.SignatureName;
            sprmparam = sccmd.Parameters.Add("@signatureStamp", SqlDbType.Image);
            sprmparam.Value = authorizedsignatoryinfo.SignatureStamp;
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
    public void AuthorizedSignatoryEdit(AuthorizedSignatoryInfo authorizedsignatoryinfo)
    {
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sccmd = new SqlCommand("AuthorizedSignatoryEdit", sqlcon);
            sccmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sprmparam = new SqlParameter();
            sprmparam = sccmd.Parameters.Add("@authorizedSignatoryId", SqlDbType.Decimal);
            sprmparam.Value = authorizedsignatoryinfo.AuthorizedSignatoryId;
            sprmparam = sccmd.Parameters.Add("@signatoryDesignation", SqlDbType.VarChar);
            sprmparam.Value = authorizedsignatoryinfo.SignatoryDesignation;
            sprmparam = sccmd.Parameters.Add("@signatureName", SqlDbType.VarChar);
            sprmparam.Value = authorizedsignatoryinfo.SignatureName;
            sprmparam = sccmd.Parameters.Add("@signatureStamp", SqlDbType.Image);
            sprmparam.Value = authorizedsignatoryinfo.SignatureStamp;
            sprmparam = sccmd.Parameters.Add("@extraOne", SqlDbType.VarChar);
            sprmparam.Value = authorizedsignatoryinfo.ExtraOne;
            sprmparam = sccmd.Parameters.Add("@extraTwo", SqlDbType.VarChar);
            sprmparam.Value = authorizedsignatoryinfo.ExtraTwo;
            sccmd.ExecuteNonQuery();        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

        finally
        {
            sqlcon.Close();
        }

    }
    public DataTable AuthorizedSignatoryViewAll()
    {
        DataTable dtbl = new DataTable();
        try
        {
          
            SqlDataAdapter sdaadapter = new SqlDataAdapter("AuthorizedSignatoryViewAll", sqlcon);
            sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sdaadapter.Fill(dtbl);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
       
        return dtbl;
    }
    public AuthorizedSignatoryInfo AuthorizedSignatoryView(decimal authorizedSignatoryId )
    {
        AuthorizedSignatoryInfo authorizedsignatoryinfo =new AuthorizedSignatoryInfo();
        SqlDataReader sdrreader =null;
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sccmd = new SqlCommand("AuthorizedSignatoryView", sqlcon);
            sccmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sprmparam = new SqlParameter();
            sprmparam = sccmd.Parameters.Add("@authorizedSignatoryId", SqlDbType.Decimal);
            sprmparam.Value = authorizedSignatoryId;
             sdrreader = sccmd.ExecuteReader();
            while (sdrreader.Read())
            {
                authorizedsignatoryinfo.AuthorizedSignatoryId=decimal.Parse(sdrreader[0].ToString());
                authorizedsignatoryinfo.SignatoryDesignation= sdrreader[1].ToString();
                authorizedsignatoryinfo.SignatureName= sdrreader[2].ToString();
                authorizedsignatoryinfo.SignatureStamp = (byte[])sdrreader[3];
                authorizedsignatoryinfo.ExtraOne= sdrreader[4].ToString();
                authorizedsignatoryinfo.ExtraTwo= sdrreader[5].ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {           sdrreader.Close(); 
            sqlcon.Close();
        }
        return authorizedsignatoryinfo;
    }
    public void AuthorizedSignatoryDelete(decimal AuthorizedSignatoryId)
    {
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sccmd = new SqlCommand("AuthorizedSignatoryDelete", sqlcon);
            sccmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sprmparam = new SqlParameter();
            sprmparam = sccmd.Parameters.Add("@authorizedSignatoryId", SqlDbType.Decimal);
            sprmparam.Value = AuthorizedSignatoryId;
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
    public int AuthorizedSignatoryGetMax()
    {
        int max = 0;
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sccmd = new SqlCommand("AuthorizedSignatoryMax", sqlcon);
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

    public byte[] AuthorizedSignatoryViewImage()
    {
        byte[] arrImage = new byte[0];
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sccmd = new SqlCommand("AuthorizedSignatoryViewImage", sqlcon);
            sccmd.CommandType = CommandType.StoredProcedure;
            arrImage = (byte[])sccmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

        finally
        {
            sqlcon.Close();
        }
        return arrImage;
    }

    public void AuthorizesImageEdit(AuthorizedSignatoryInfo authorizedsignatoryinfo)
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

    }//
    public string authorizedSignatoryGetName()
    {
        object obj = null;
        string strName = string.Empty;
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sccmd = new SqlCommand("authorizedSignatoryGetName", sqlcon);
            sccmd.CommandType = CommandType.StoredProcedure;
            obj = sccmd.ExecuteScalar();
            if (obj != null)
            {
                strName = obj.ToString();
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
        return strName;
    }

}
}
