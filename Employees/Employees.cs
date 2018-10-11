using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class Employees
    {
        List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// Default ctor
        /// </summary>
        public Employees()
        {
            
        }

        /// <summary>
        /// Method Add
        /// </summary>
        /// <param name="employee">Employee</param>
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        /// <summary>
        /// Method Remove
        /// </summary>
        /// <param name="employee">Employee</param>
        public void Remove(Employee employee)
        {
            _employees.RemoveAt(_employees.IndexOf(employee));
        }

        /// <summary>
        /// Method Get By Number
        /// </summary>
        /// <param name="number">Employee number</param>
        /// <returns>Employee</returns>
        public Employee GetByNumber(int number)
        {
            return _employees.Find(x => x.Number == number);
        }

        /// <summary>
        /// Method Get By Name
        /// </summary>
        /// <param name="name">Employee name</param>
        /// <returns>Employee</returns>
        public Employee GetByName(string name)
        {
            return _employees.Find(x => x.Name == name);
        }

        /// <summary>
        /// Method Find By Part Of Name
        /// </summary>
        /// <param name="partOfName">part of Employee name</param>
        /// <returns>list of Employees</returns>
        public List<Employee> FindByPartOfName(string partOfName)
        {
            return _employees.FindAll(x => x.Name.Contains(partOfName));
        }
    }
}
