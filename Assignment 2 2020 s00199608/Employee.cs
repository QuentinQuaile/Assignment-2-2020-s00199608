using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_2020_s00199608
{
    /*
 * Student number: s00199608
 * Description: CA2
 * Github Link: https://github.com/QuentinQuaile/Assignment-2-2020-s00199608
 * */

    //Creating abstract employee class
    public abstract class Employee
    {

        //properties
        public string fName { get; set; }
        public string lName { get; set; }
        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        //constructor
        public Employee(string first, string last)
        {
            fName = first;
            lName = last.ToUpper();

        }

        //method
        public abstract decimal CalculateMonthlyPay(); 
    }
    public class FullTime : Employee //FullTime employee class
    {
        //Constructor
        public FullTime(string first, string last, decimal salary) : base(first,last)
        {
            Salary = salary;
        }
        //Method to return monthly pay by dividing salary by 12
        override public decimal CalculateMonthlyPay()
        {
            return (decimal)(Salary / 12);
        }
        //Displaying Name of employee
        public override string ToString()
        {
            return lName + ", " + fName + "- Full Time";
        }
    }
    public class PartTime : Employee//PartTime employee class
    {
        //Constructor
        public PartTime(string first, string last, decimal hourlyRate, double hoursWorked): base(first, last)
        {
            HourlyRate = hourlyRate;

            HoursWorked = hoursWorked;
        }
        //Displaying Name of employee
        public override string ToString()
        {
            return lName + ", " + fName + "- Part Time";
        }
        //Method to return monthly pay by multiplying hourly rate by hours worked
        override public decimal CalculateMonthlyPay()
        {
            return (decimal)((double)HourlyRate * HoursWorked);
        }
    }
}
