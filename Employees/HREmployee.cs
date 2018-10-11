namespace Employees
{
    public class HREmployee : Employee
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="number">Employee Number</param>
        /// <param name="position">Current position</param>
        /// <param name="salary">base salary</param>
        public HREmployee(string name, int number, string position, int salary) : base (name, number, position, salary)
        {}

        /// <summary>
        /// Method MonthlySalary
        /// </summary>
        /// <returns>monthly salary based on salary and hourly rate</returns>
        public override float MonthlySalary()
        {
            return 20.8F * 8 * Salary;
        }
    }
}
