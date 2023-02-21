using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRL:IEmployeeRL
    {
        private readonly IConfiguration iconfiguration;

        public EmployeeRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        public SqlConnection con= new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayrollADO;Integrated Security=True;");

        //public EmployeeModel employeeModel= new EmployeeModel();

        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@ProfileImg", employeeModel.ProfileImg);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                    con.Open();
                    var result= cmd.ExecuteNonQuery();
                    if (result != null)
                    {
                        return employeeModel;
                    }
                    else
                    {
                        return null;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

    }
}
