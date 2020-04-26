using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PayApp
{
    public class Commands
    {

        static public void Adde(Company OneCompany)
        {
            Person newEmployee = new Person();
            newEmployee.EmployeeType = true;
            Console.WriteLine("Please enter the employee's first name: ");
            newEmployee.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter the employee's last name: ");
            newEmployee.LastName = Console.ReadLine();
            EmployeeRecord employeeRecord = new EmployeeRecord(newEmployee, OneCompany);
            //Console.WriteLine("New " + company.CompanyName + " " + employeeRecord.company + " Employee Record created for company" + employeeRecord.Employee);
            Console.WriteLine("New Employee Record created for company" + employeeRecord.Employee);
            //bool adding = true;

        }
        static public void Check()
        {

        }
        static public void List()
        {

        }
        static public void Annual()
        {

        }
        static public void Addd() 
        {

        }
    }
}
