﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class MREmployee : Employee
    {
        public override float MonthlySalary()
        {
            return Salary;
        }
    }
}
