using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AbayChequeMagic
{
    class LetterImageSp:DBConnection
    {

        public void LetterImageEdit(LetterImageInfo lettersignatoryinfo)
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


    }
}
