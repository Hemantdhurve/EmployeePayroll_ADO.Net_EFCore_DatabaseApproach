using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public EmployeeModel AddEmployee(EmployeeModel employeeModel);
        public IEnumerable<EmployeeModel> RetriveEmployees();
        public bool DeleteEmployee(int employeeId);
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel, int employeeId);
    }
}
