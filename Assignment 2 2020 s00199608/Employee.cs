using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_2020_s00199608
{
    public abstract class Employee
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public Employee()
        {

        }

        public Employee(string first, string last)
        {
            fName = first;
            lName = last.ToUpper();

        }


        public abstract decimal CalculateMonthlyPay(); 
    }
    public class FullTime : Employee
    {
        

        public FullTime()
        {

        }

        public FullTime(string first, string last, decimal salary) : base(first,last)
        {
            Salary = salary;
        }

        override public decimal CalculateMonthlyPay()
        {
            return (decimal)(Salary / 12);
        }
        public override string ToString()
        {
            return fName + ", " + lName + "- Full Time";
        }
    }
    public class PartTime : Employee
    {
        public PartTime()
        {
            
        }

        public PartTime(string first, string last, decimal hourlyRate, double hoursWorked): base(first, last)
        {
            HourlyRate = hourlyRate;

            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return lName + ", " + fName + "- Part Time";
        }
        override public decimal CalculateMonthlyPay()
        {
            return (decimal)((double)HourlyRate * HoursWorked);
        }
    }
}
