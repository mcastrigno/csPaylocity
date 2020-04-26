using System;
using System.Collections.Generic;
using System.Reflection;

namespace PayApp
{

    public class EmployeeRecord
    {
        private Person employee;
        public Person Employee
        {
            get => employee;
            set 
            {
                employee = value; 
            } 
        }

        private Company company;
        public Company Company
        {
            get => company;
            set
            {
                company = value;
            }
        }
        private List<Person> Dependents = new List<Person>();


        public EmployeeRecord(Person person, Company company)
        {
            this.employee = person;
            this.company = company;
        }

        public void addDependent(Person dependent)
        {
            Dependents.Add(dependent);
        }
        public List<Person> getDependentList()
        {
            return Dependents;
        }
    }
}
