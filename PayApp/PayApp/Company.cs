using System;
using System.Collections.Generic;

namespace PayApp
{

    public class Company
    {
        // These default values for properties are only
        // supported for C#6 and above
        public double EmployeeBenefitCost { set; get; } = 1000;
        public double DependentBenefitCost { set; get; } = 500;
        public double NetDiscount { set; get; } = .9;
        public int NumChecksPerYear { set; get; } = 26;
        public string CompanyName {set; get;} = "MegaCorp";
        private List<EmployeeRecord> company = new List<EmployeeRecord>();

        // using auto-implemented properties 
        // so our default constructor will
        // take the above properties 
        // if we change the modifier to protected we 
        // can only set/get if we put them in the 
        // constructor
        public Company()
        {
        }
        public List<EmployeeRecord> GetCompanyList()
        {
            return company;
        }
            
    }
}
