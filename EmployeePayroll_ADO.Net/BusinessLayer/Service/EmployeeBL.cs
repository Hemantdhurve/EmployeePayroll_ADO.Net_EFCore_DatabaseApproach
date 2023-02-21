using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL:IEmployeeBL
    {
        private readonly IEmployeeRL iemployeeRL;
        public EmployeeBL(IEmployeeRL iemployeeRL)
        {
            this.iemployeeRL = iemployeeRL;
        }
        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return iemployeeRL.AddEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<EmployeeModel> RetriveEmployees()
        {
            try
            {
                return iemployeeRL.RetriveEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
