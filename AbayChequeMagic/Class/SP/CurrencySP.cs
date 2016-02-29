using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace AbayChequeMagic
{
    class CurrencySP : DBConnection
    {
        public CurrencyInfo CurrencyView()
        {

            CurrencyInfo infoCurrency = new CurrencyInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("currencyView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    infoCurrency.currencyId = decimal.Parse(sdrreader[0].ToString());
                    infoCurrency.currencyName = sdrreader[1].ToString();
                    infoCurrency.fractionalPart = sdrreader[2].ToString();

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
            return infoCurrency;
        }

        public DataTable CurrencuyViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("CurrencyViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
            


    

