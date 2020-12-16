using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_2020_s00199608
{
    public abstract class Employee
    {
        string fName { get; set; }
        string lName { get; set; }
            
        public abstract decimal CalculateMonthlyPay(); 
    }
    public class FullTime : Employee
    {
        public decimal salary { get; set; }

        override public decimal CalculateMonthlyPay()
        {
            decimal monthlyPay;
            monthlyPay = salary / 12;
            return monthlyPay;
        }
    }
    public class PartTime : Employee
    {
        decimal hourlyRate { get; set; }
        double hoursWorked { get; set; }

        override public decimal CalculateMonthlyPay()
        {
            return (decimal)((double)hourlyRate * hoursWorked);
        }
    }
}
