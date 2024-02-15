using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

// Composite pattern is a partitioning design pattern and describes a group of objects that is treated the same way as a single
// instance of the same type of object. The intent of a composite is to “compose” objects into tree structures to represent
// part-whole hierarchies. It allows you to have a tree structure and ask each node in the tree structure to perform a task.

// By applying the Composite design pattern, you can address these challenges, allowing you to treat both individual employees
// and groups uniformly, simplifying your code, and providing a more consistent and scalable solution.

// A common interface for all employees which all employee classes implement.
// This interface includes a method ShowEmployeeDetails to display the details of an employee.
namespace DesignPatterns101.Structural_Patterns
{
    interface IEmployee
    {
        void ShowEmployeeDetails(ILogger log);
    }

    // Concrete implementation of employees with specific attributes such as employee ID, name, and position.
    class Developer : IEmployee
    {
        private long empId;
        private string name;
        private string position;

        public Developer(long empId, string name, string position)
        {
            this.empId = empId;
            this.name = name;
            this.position = position;
        }

        public void ShowEmployeeDetails(ILogger log)
        {
            log.LogWarning($"{empId} - {name} - {position}");
        }
    }

    // Concrete implementation of employees with specific attributes such as employee ID, name, and position.
    class Manager : IEmployee
    {
        private long empId;
        private string name;
        private string position;

        public Manager(long empId, string name, string position)
        {
            this.empId = empId;
            this.name = name;
            this.position = position;
        }

        public void ShowEmployeeDetails(ILogger log)
        {
            log.LogWarning($"{empId} - {name} - {position}");
        }
    }

    // Class used to get Employee List and do the operations like add or remove Employee 
    // The CompanyDirectory class serves as a composite, representing a group of employees. It implements the IEmployee interface,
    // allowing both individual employees and groups of employees to be treated uniformly. It can contain a list of IEmployee objects,
    // which can be either individual employees or subgroups (other instances of CompanyDirectory).
    class CompanyDirectory : IEmployee
    {
        private List<IEmployee> employeeList = new List<IEmployee>();

        public void ShowEmployeeDetails(ILogger log)
        {
            foreach (IEmployee emp in employeeList)
            {
                emp.ShowEmployeeDetails(log);
            }
        }

        public void AddEmployee(IEmployee emp)
        {
            employeeList.Add(emp);
        }

        public void RemoveEmployee(IEmployee emp)
        {
            employeeList.Remove(emp);
        }
    }
}