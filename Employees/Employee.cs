using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public abstract class Employee
    {
        /// <summary>
        /// Properties Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Properties BirthDay
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Properties Sex: false (0) - female, true (1) - male
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// Properties Employee Number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Properties Start work date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Properties End work date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Properties Position
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Properties Salary size
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Abstract Method FixSalary
        /// </summary>
        /// <returns>Total Salary depends on type of Employee</returns>
        public abstract float MonthlySalary();

        /// <summary>
        /// Default ctor
        /// </summary>
        public Employee()
        {
            
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="birthday">Employee Birthday</param>
        /// <param name="sex">Sex: false (0) - female, true (1) - male</param>
        /// <param name="number">Employee Number</param>
        /// <param name="startDate">Start work date</param>
        /// <param name="position">Current position</param>
        public Employee(string name, DateTime birthday, bool sex, int number, DateTime startDate, string position)
        {
            Name = name;
            Birthday = birthday;
            Sex = sex;
            Number = number;
            StartDate = startDate;
            Position = position;
        }
    }
}
