using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public EmployeeModel AddEmployee(EmployeeModel employeeModel);
        public IEnumerable<EmployeeModel> RetriveEmployees();
        public bool DeleteEmployee(int employeeId);
    }
}
