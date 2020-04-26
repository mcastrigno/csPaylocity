using System;
using System.Collections.Generic;

namespace PayApp
{

    public class Person
    {
        protected string firstName;
        protected string lastName;
        protected bool employeeType;
        protected bool dependentType;
        
        public string FirstName 
        {
            set { firstName = value; }
        } 
        public string LastName 
        {
            set { lastName = value; }
        }
        public bool EmployeeType
        {
            set { employeeType = value; }
        }
        public bool DependentType
        {
            set { dependentType = value; }
        }



        public Person()
        {

        }
        public override string ToString()
        {
            if (employeeType)
            {
                return "Employee " + firstName + " " + lastName;
            }
            return firstName + " " + lastName;
        }
    }
}
