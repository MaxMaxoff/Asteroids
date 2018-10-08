using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class HREmployee : Employee
    {
        public override float MonthlySalary()
        {
            return 20.8F * 8 * Salary;
        }
    }
}
