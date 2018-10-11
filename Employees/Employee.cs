using System;
using System.Collections;

namespace Employees
{
    public abstract class Employee : IComparable<Employee>
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
        /// Override Method ToString
        /// </summary>
        /// <returns>Default string for Employee</returns>
        public override string ToString()
        {
            return $"Имя: {Name}; ТН {Number}; Должность: {Position}; ЗП: {MonthlySalary()}";
        }

        public int CompareTo(Employee obj)
        {
            return MonthlySalary() > obj.MonthlySalary() ? -1 : 1;
        }

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="number">Employee Number</param>
        /// <param name="position">Current position</param>
        /// <param name="salary">base salary</param>
        public Employee(string name, int number, string position, int salary)
        {
            Name = name;
            Number = number;
            Position = position;
            Salary = salary;
        }
    }
}
