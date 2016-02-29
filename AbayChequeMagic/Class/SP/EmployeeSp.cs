using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AbayChequeMagic
{
    class EmployeeSp : DBConnection
    {
        public bool EmployeeAdd(EmployeeInfo employeeinfo)
        {
            bool isCheck = false;

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("EmployeeAdd", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@employeeCode", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.EmployeeCode;
                sprmparam = sccmd.Parameters.Add("@employeeName", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.EmployeeName;
                sprmparam = sccmd.Parameters.Add("@designation", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.Designation;
                sprmparam = sccmd.Parameters.Add("@contactNumber", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.ContactNumber;
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
        public bool EmployeeEdit(EmployeeInfo employeeinfo)
        {
            bool isCheck = false;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("EmployeeEdit ", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@employeeId", SqlDbType.Decimal);
                sprmparam.Value = employeeinfo.EmployeeId;
                sprmparam = sccmd.Parameters.Add("@employeeCode", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.EmployeeCode;
                sprmparam = sccmd.Parameters.Add("@employeeName", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.EmployeeName;
                sprmparam = sccmd.Parameters.Add("@designation", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.Designation;
                sprmparam = sccmd.Parameters.Add("@contactNumber", SqlDbType.VarChar);
                sprmparam.Value = employeeinfo.ContactNumber;
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
        public DataTable EmployeeViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("EmployeeViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable EmployeeGridViewAll()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("EmployeeGridViewAll", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public bool EmployeeDelete(decimal EmployeeId)
        {
            bool isCheck = false;

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("EmployeeDelete", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@employeeId", SqlDbType.Decimal);
                sprmparam.Value = EmployeeId;
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
        public EmployeeInfo EmployeeView(decimal empId)
        {

            EmployeeInfo infoemployee = new EmployeeInfo();
            SqlDataReader sdrreader = null;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                SqlCommand sccmd = new SqlCommand("EmployeeView", sqlcon);
                sccmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sprmparam = new SqlParameter();
                sprmparam = sccmd.Parameters.Add("@employeeId", SqlDbType.Decimal);
                sprmparam.Value = empId;
                sdrreader = sccmd.ExecuteReader();
                while (sdrreader.Read())
                {
                    infoemployee.EmployeeId = decimal.Parse(sdrreader[0].ToString());
                    infoemployee.EmployeeCode = sdrreader[1].ToString();
                    infoemployee.EmployeeName = sdrreader[2].ToString();
                    infoemployee.Designation = sdrreader[3].ToString();
                    infoemployee.ContactNumber = sdrreader[4].ToString();
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
            return infoemployee;
        }
        public DataTable SearchByEmployeeCodeOnEmployee(string strEmployeeCode)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchByEmployeeCodeOnEmployee", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@employeeCode", SqlDbType.VarChar).Value = strEmployeeCode + "%";
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable SearchByEmployeeName(string strEmployeeName)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchByEmployeeName", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@employeeName", SqlDbType.VarChar).Value = strEmployeeName + "%";
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable SearchByEmployeeDesignation(string strEmployeeDesignation)
        {
            DataTable dtbl = new DataTable();
            try
            {
                SqlDataAdapter sdaadapter = new SqlDataAdapter("SearchByEmployeeDesignation", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("@designation", SqlDbType.VarChar).Value = strEmployeeDesignation + "%";
                sdaadapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dtbl;
        }
        public DataTable AppendEmpCodeAndEmpName()
        {
            DataTable dtbl = new DataTable();
            try
            {

                SqlDataAdapter sdaadapter = new SqlDataAdapter("AppendEmpCodeAndEmpName", sqlcon);
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
