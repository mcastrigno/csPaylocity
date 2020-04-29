using PayApp;
using System;
public static class ExtensionMethods
{
    public static double cents(this double value)
    {

        return Math.Round(value, 2, MidpointRounding.ToEven);
    }
}
public class CalcPay
{
    public static double GetEmployeeCostPerCheck(EmployeeRecord employeeRecord)
    {
        double biWeeklyCost = 0;
        {
            if (DiscountApplies(employeeRecord.Employee))
            {
               biWeeklyCost += ((employeeRecord.Company.EmployeeBenefitCost * employeeRecord.Company.NetDiscount)/
                               (employeeRecord.Company.NumChecksPerYear)).cents();
            }
            else
            {
               biWeeklyCost += ((employeeRecord.Company.EmployeeBenefitCost)/
                               (employeeRecord.Company.NumChecksPerYear)).cents();
            }

            foreach (var dependent in employeeRecord.getDependentList())
            {
                if (DiscountApplies(dependent))
                {
                    biWeeklyCost += ((employeeRecord.Company.DependentBenefitCost * employeeRecord.Company.NetDiscount)/
                                     (employeeRecord.Company.NumChecksPerYear)).cents();
                }
                else
                {
                  biWeeklyCost  += ((employeeRecord.Company.DependentBenefitCost)/
                                    (employeeRecord.Company.NumChecksPerYear)).cents();
                }
            }
        }
        return biWeeklyCost;
    }

    // This is the company wide total cost to employees
    public static double GetCompanyEmployeeCostPerYear(Company company)
    {
        double annualEmployeeCostPerYear = 0;
        foreach (var employeeRecord in company.GetCompanyList())
        {
            if (DiscountApplies(employeeRecord.Employee))
            {
                annualEmployeeCostPerYear += (employeeRecord.Company.EmployeeBenefitCost * employeeRecord.Company.NetDiscount).cents();
            }
            else
            {
                annualEmployeeCostPerYear += (employeeRecord.Company.EmployeeBenefitCost).cents();
            }
            foreach (var dependent in employeeRecord.getDependentList())
            {
                if (DiscountApplies(employeeRecord.Employee))
                {
                    annualEmployeeCostPerYear += (employeeRecord.Company.DependentBenefitCost * employeeRecord.Company.NetDiscount).cents();
                }
                else
                {
                    annualEmployeeCostPerYear += (employeeRecord.Company.DependentBenefitCost).cents();
                }
            }
        }

        return annualEmployeeCostPerYear;
    }
    public static double GetCompanyCostPerYear(Company company)
    {
        double annualCompanyCost = 0;
        foreach (var employeeRecord in company.GetCompanyList())
        {
            annualCompanyCost += employeeRecord.Employee.GetPay;
        }
        return annualCompanyCost * company.NumChecksPerYear;
    }
    static bool DiscountApplies(Person person)
    {
        if (person.FirstName.ToLower().StartsWith("a")
            || person.LastName.ToLower().StartsWith("a"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
