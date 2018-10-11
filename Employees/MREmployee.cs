namespace Employees
{
    public class MREmployee : Employee
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="number">Employee Number</param>
        /// <param name="position">Current position</param>
        /// <param name="salary">base salary</param>
        public MREmployee(string name, int number, string position, int salary) : base (name, number, position, salary)
        {}

        /// <summary>
        /// Method MonthlySalary
        /// </summary>
        /// <returns>monthly salary based on salary</returns>
        public override float MonthlySalary()
        {
            return Salary;
        }
    }
}
