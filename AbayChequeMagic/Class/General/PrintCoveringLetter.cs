using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using AbayChequeMagic.CrystalReports;
namespace AbayChequeMagic
{
    class PrintCoveringLetter
    {
        public string strCompanyName = string.Empty;
        public string strFromAddress = string.Empty;
        public PrintCoveringLetter(string strPrinterName)
        {
            
            //crptCoveringLetter crpt = new crptCoveringLetter();
            //crpt.Database.Tables["prepareLetter"].SetDataSource(CreateDataTable());
            //crpt.PrintOptions.PrinterName = strPrinterName;
            //crpt.PrintToPrinter(1, false, 1, 1);
        }
        private DataTable CreateDataTable()
        {
            CompanySP spCompany = new CompanySP();
            DataTable dtblCompany = new DataTable();
            dtblCompany = spCompany.CompanyViewAll();
            string strDesgnation, strCompany, strBuildig, strState, strCountry, strPincode;
            if (dtblCompany.Rows.Count != 0)
            {
                // dtbl = spCompany.CompanyViewAll();
                strCompanyName = dtblCompany.Rows[0]["companyName"].ToString();
                strDesgnation = dtblCompany.Rows[0]["building"].ToString();
                strCompany = dtblCompany.Rows[0]["address"].ToString();
                strBuildig = dtblCompany.Rows[0]["city"].ToString();
                strState = dtblCompany.Rows[0]["state"].ToString();
                strCountry = dtblCompany.Rows[0]["country"].ToString();
                strPincode = dtblCompany.Rows[0]["pincode"].ToString();
                strFromAddress = strDesgnation + Environment.NewLine + strCompany + Environment.NewLine + strBuildig+ Environment.NewLine + strState +Environment.NewLine + strCountry + Environment.NewLine + strPincode;

            }
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Payee Name");
            dtbl.Columns.Add("Payee Address");
            dtbl.Columns.Add("Company Name");
            dtbl.Columns.Add("Company Address");
            dtbl.Columns.Add("Subject");
            dtbl.Columns.Add("Letter Body");
            dtbl.Columns.Add("Signatory Name");
            dtbl.Columns.Add("Signatory Designation");
            dtbl.Columns.Add("Signature Stamp", typeof(byte[]));
            dtbl.Rows.Add();
            dtbl.Rows[0]["Payee Name"] = Common.strPayeeName;
            dtbl.Rows[0]["Payee Address"] = LoadToAddress(Common.decPayeeId);
            dtbl.Rows[0]["Company Name"] = strCompanyName;
            dtbl.Rows[0]["Company Address"] = strFromAddress;
            dtbl.Rows[0]["Subject"] = "Covering Letter";
            dtbl.Rows[0]["Letter Body"] ="     Please find enclosed cheque dated " + Common.strIssuedDate + " for "+Common.strCurrency+". " + Common.strAmount + " drawn in favour of "+Common.strPayeeName +" in payment towards " + Common.strExpense + Environment.NewLine + Environment.NewLine + "Please acknowledge the receipt of the same";
            LetterSP spLetter = new LetterSP();
            DataTable dtblSignatory = new DataTable();
            dtblSignatory = spLetter.SelectSignatoryDetailsForLetters();
            if (dtblSignatory.Rows.Count > 0)
            {
                dtbl.Rows[0]["Signatory Name"] = dtblSignatory.Rows[0]["letterSignatoryName"];
                dtbl.Rows[0]["Signatory Designation"] = dtblSignatory.Rows[0]["signatoryDesignation"];
                dtbl.Rows[0]["Signature Stamp"] = dtblSignatory.Rows[0]["letterSignatoryStamp"];
            }
            return dtbl;
        }

        private string LoadToAddress(decimal decPayeeId)
        {
            PayeeSP spPayee = new PayeeSP();
            PayeeInfo infoPayee = new PayeeInfo();
            string strAddress, strCity, strState, strPincode;
            infoPayee = spPayee.PayeeView(decPayeeId);
            strAddress = infoPayee.Address.ToString();
            strCity = infoPayee.City.ToString();
            strState = infoPayee.State.ToString();
            strPincode = infoPayee.Pincode.ToString();
            return strAddress + Environment.NewLine + strCity + Environment.NewLine + strState + Environment.NewLine + strPincode;

        }
      
    
    }
}
