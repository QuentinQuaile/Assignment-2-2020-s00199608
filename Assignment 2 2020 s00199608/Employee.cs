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
            
        public abstract double CalculateMonthlyPay(decimal Money); 
    }
    public class FullTime : Employee
    {
        decimal salary { get; set; }
    }
    public class PartTime : Employee
    {
        decimal hourlyRate { get; set; }
        double hoursWorked { get; set; }
    }
}
