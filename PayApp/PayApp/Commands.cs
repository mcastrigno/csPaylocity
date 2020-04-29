using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;

namespace PayApp
{
    public class Commands
    {

        static public void Adde(Company OneCompany)
        {
            String addCommand = "";
            Person newEmployee = new Person();
            newEmployee.EmployeeType = true;
            Console.WriteLine("Please enter the employee's first name: ");
            newEmployee.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter the employee's last name: ");
            newEmployee.LastName = Console.ReadLine();
            //Company is recorded to EmployeeRecord and Company's list of EmployeeRecord
            //This supports have more than one employer, but would require another EmployeeRecord for that Person
            EmployeeRecord employeeRecord = new EmployeeRecord(newEmployee, OneCompany);
            OneCompany.GetCompanyList().Add(employeeRecord);
            Console.WriteLine("New " + employeeRecord.Company.CompanyName + " Employee Record created for: " + employeeRecord.Employee.ToString());
            Console.WriteLine("Do you want to add a dependent for " + employeeRecord.Employee.ToString() + "?, y or n ?");

            bool adding = true;
            while (adding)
            {
                addCommand = Console.ReadLine();
                switch(addCommand)
                {
                    case "y":
                        Person dependentPerson = new Person();
                        Console.WriteLine("Please enter the dependent's first name: ");
                        dependentPerson.FirstName = Console.ReadLine();
                        Console.WriteLine("Please enter the dependent's last name: ");
                        dependentPerson.LastName = Console.ReadLine();
                        dependentPerson.DependentType = true;
                        employeeRecord.addDependent(dependentPerson);
                        Console.WriteLine("Do you want to add another dependent for " + employeeRecord.Employee.ToString() + "?, y or n ?");
                        break;
                    case "n":
                        adding = false;
                        break;
                    default:
                        Console.WriteLine("Do you want to add another dependent for " + employeeRecord.Employee.ToString() + "?, y or n ?");
                        break;

                }

            }
            Console.WriteLine("New " + employeeRecord.Company.CompanyName + " employee record created for: " + employeeRecord.Employee.ToString());
            if (employeeRecord.getDependentList().Count != 0)
            {
                Console.WriteLine("With dependents: ");
                foreach (var dependent in employeeRecord.getDependentList())
                {
                    Console.WriteLine("  " + dependent.ToString());
                }
            }
            //String.Format("{0:0,0.0}", 12345.67);     // "12,345.7"
            //String.Format("{0,6:0.00}", 123.4567);

            //Console.WriteLine("Cost of benefits to employee per pay period: $" +  String.Format("{0,6:0,0.00}",CalcPay.GetEmployeeCostPerCheck(employeeRecord)));
            Console.WriteLine("Cost of benefits to employee per pay period: {0:C2}.",   CalcPay.GetEmployeeCostPerCheck(employeeRecord));
            Console.WriteLine("");
        }
        static public void Check(Company company)
        {
            double weeklyBenefitCost = 0;
            double weeklyWageCost = 0;
            foreach (var employeeRecord in company.GetCompanyList())
            {
                weeklyBenefitCost += CalcPay.GetEmployeeCostPerCheck(employeeRecord);
                weeklyWageCost += employeeRecord.Employee.GetPay;
            }
            //Console.WriteLine("The total weekly benefit cost to all employees is: "+ String.Format("{0,9:0,0.00}", weeklyBenefitCost));
            //Console.WriteLine("The total weekly wage cost for all employees is:   "+ String.Format("{0,9:0,0.00}", weeklyWageCost));
            Console.WriteLine("The total weekly benefit cost to all employees is: "+ String.Format("{0,9:C2}", weeklyBenefitCost));
            Console.WriteLine("The total weekly wage cost for all employees is:   "+ String.Format("{0,9:C2}", weeklyWageCost));
            Console.WriteLine("");

        }
        static public void List(Company company)
        {
            foreach (var employeeRecord in company.GetCompanyList())
            {
                Console.WriteLine("Employee: " + employeeRecord.Employee.ToString());
                Console.WriteLine("Dependents of " + employeeRecord.Employee.ToString() + ":");
                foreach (var dependent in employeeRecord.getDependentList())
                {
                    Console.WriteLine("    " + dependent.ToString());
                }
                Console.WriteLine("Cost of benefits to employee per pay period:   " 
                    + String.Format("{0,9:C2}",CalcPay.GetEmployeeCostPerCheck(employeeRecord)));
                Console.WriteLine("The net check for the employee per pay period: "
                    + String.Format("{0,9:C2}",employeeRecord.Employee.GetPay - CalcPay.GetEmployeeCostPerCheck(employeeRecord)));
                Console.WriteLine("");
            }
            Console.WriteLine("");

        }
        static public void Annual(Company company)
        {
            Console.WriteLine("The total annual Salary cost to the company  is:          "
                + String.Format("{0,11:C2}",CalcPay.GetCompanyCostPerYear(company)));
            Console.WriteLine("The total annual cost to employee portion of benefits is: "
                + String.Format("{0,11:C2}",CalcPay.GetCompanyEmployeeCostPerYear(company)));
            Console.WriteLine("");

        }
        static public void Addd(EmployeeRecord employeeRecord, Person person) 
        {
            employeeRecord.addDependent(person);    
        }
    }
}
