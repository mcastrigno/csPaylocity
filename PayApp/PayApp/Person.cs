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
        private double pay = 2000; 
        public string FirstName 
        {
            get => firstName;
            set { firstName = value; }
        } 
        public string LastName 
        {
            get => lastName;
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
        public double GetPay
        {
            get => pay;
        }



        public Person()
        {

        }
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
