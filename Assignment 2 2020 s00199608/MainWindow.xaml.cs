using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

/*
 * Student number: s00199608
 * Description: CA2
 * Github Link: https://github.com/QuentinQuaile/Assignment-2-2020-s00199608
 * */

namespace Assignment_2_2020_s00199608
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creating ObservableCollections so that the visuals will update in real time instead of waiting for a refresh
        ObservableCollection<Employee> FTemploy = new ObservableCollection<Employee>();
        ObservableCollection<Employee> PTemploy = new ObservableCollection<Employee>();
        ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) //when the window is loaded
        {
            //creating base employees
            FullTime employee = new FullTime("Jess", "WALSH", 200);
            FullTime employee1 = new FullTime("Joe", "MURPHY", 300);
            PartTime employee2 = new PartTime("Jane", "JONES", 15, 10);
            PartTime employee3 = new PartTime("John", "SMITH", 20, 7);
            //adding employees to ObservableCollection
            Employees.Add(employee);
            Employees.Add(employee1);
            Employees.Add(employee2);
            Employees.Add(employee3);

            //adding employees to ObservableCollection
            FTemploy.Add(employee);
            FTemploy.Add(employee1);
            PTemploy.Add(employee2);
            PTemploy.Add(employee3);

            //Used to filter the list box by FullTime or PartTime employees
            if (CheckFT.IsChecked == true && CheckPT.IsChecked == true)
            {
                listBox.ItemsSource = Employees;
            }
            else if (CheckFT.IsChecked == true)
            {
                listBox.ItemsSource = FTemploy;
            }
            else if (CheckPT.IsChecked == true)
            {
                listBox.ItemsSource = PTemploy;
            }
            else
            {
                listBox.ItemsSource = null;
            }
        }

        //Method for when you select an employee in the list box
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selection of the employee
            Employee selectedEmployee = listBox.SelectedItem as Employee;

            //ensure it is not null
            if (selectedEmployee != null)
            {
                //take action - update the display
                textBox.Text = selectedEmployee.fName;
                textBox1.Text = selectedEmployee.lName;
                Salarytxt.Text = selectedEmployee.Salary.ToString();
                hourlyRatetxt.Text = selectedEmployee.HourlyRate.ToString();
                hoursWorkedtxt.Text = selectedEmployee.HoursWorked.ToString();

                //checking if PT or FT radio buttion is chosen
                if (selectedEmployee.Salary > 0)
                {
                    FT.IsChecked = true;
                }
                else
                {
                    PT.IsChecked = true;
                }

                decimal monthlyPay = selectedEmployee.CalculateMonthlyPay(); //Calculating monthly pay
                MonthlyPay.Text = "€" + monthlyPay.ToString();
                Check(); //Making it so PT options are only available when PT is chosen and the same for FT options.
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e) //This is the method for the Add button, to add a new employee
        {
            //read details from screen
            string firstName = textBox.Text;
            string lastName = textBox1.Text;
            

            if(PT.IsChecked == true) //Checks if PT is slected
            {
                decimal hourRate;
                double hourWorked;

                hourRate = decimal.Parse(hourlyRatetxt.Text); //Changes from string to Decimal
                hourWorked = double.Parse(hoursWorkedtxt.Text);//Changes from string to Double
                PartTime employee = new PartTime(firstName, lastName, hourRate, hourWorked); //create new PartTime employee
                PTemploy.Add(employee); //add to ObservableCollection
                Employees.Add(employee);//add to ObservableCollection
            }
            else if (FT.IsChecked == true) //checks if FT is selected
            {
                decimal salary;
                salary = decimal.Parse(Salarytxt.Text); //changed from string to decimal

                FullTime employee = new FullTime(firstName, lastName, salary); //create a new fulltime employee

                FTemploy.Add(employee); //add to ObservableCollection
                Employees.Add(employee); //add to ObservableCollection
            }

        }

        private void button_Click(object sender, RoutedEventArgs e) //This method is for the Clear button
        {
            Employee selectedEmployee = listBox.SelectedItem as Employee; //List box slection
            if (selectedEmployee != null) //checks if null
            {

                //Updates the display to clear all options
                textBox.Text = null;
                textBox1.Text = null;
                Salarytxt.Text = null;
                hourlyRatetxt.Text = null;
                hoursWorkedtxt.Text = null;

                    FT.IsChecked = false; //Changes both radio button options to false
                    PT.IsChecked = false;

                MonthlyPay.Text = null;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)//method for delete button
        {
            Employee selectedEmployee = listBox.SelectedItem as Employee;//selected Employee from list box

            if (selectedEmployee != null) //checks if null
            {
                if (selectedEmployee.Salary != 0) // if salary is greater than 0 it has to be a FullTime Employee
                {
                    FTemploy.Remove(selectedEmployee); //removes from FT and Employee ObservableCollection
                    Employees.Remove(selectedEmployee);
                }
                else //If it isnt a FullTime employee it must be a PartTime employee
                {
                    PTemploy.Remove(selectedEmployee); //removes from PT and Employee ObservableCollection
                    Employees.Remove(selectedEmployee);
                }
            }

        }

        private void CheckFT_Checked(object sender, RoutedEventArgs e) //If FT checkBox gets checked
        {
            if (CheckFT.IsChecked == true && CheckPT.IsChecked == true) //If both boxes are selected displays all
            {
                listBox.ItemsSource = Employees;
            }
            else if(CheckFT.IsChecked == true) //If only FT is selected display Fulltime Employees
            {
                listBox.ItemsSource = FTemploy;
            }
            else if (CheckPT.IsChecked == false && CheckFT.IsChecked == false) //If neither are selected Display none
            {
                listBox.ItemsSource = null;
            }
        }

        private void CheckPT_Checked(object sender, RoutedEventArgs e) //If PT checkBox gets checked
        {
            if (CheckFT.IsChecked == true && CheckPT.IsChecked == true) //If both boxes are selected displays all
            {
                listBox.ItemsSource = Employees;
            }
            else if (CheckPT.IsChecked == true)//If only PT is selected display Parttime Employees
            {
                listBox.ItemsSource = PTemploy;
            }
            else if (CheckPT.IsChecked == false && CheckFT.IsChecked == false)//If neither are selected Display none
            {
                listBox.ItemsSource = null;
            }
        }

        private void CheckFT_Unchecked(object sender, RoutedEventArgs e)//If FT CheckBox gets unchecked
        {

            //Same funciton as if the PT box gets checked
            if (CheckFT.IsChecked == true && CheckPT.IsChecked == true)
            {
                listBox.ItemsSource = Employees;
            }
            else if (CheckPT.IsChecked == true)
            {
                listBox.ItemsSource = PTemploy;
            }
            else if (CheckPT.IsChecked == false && CheckFT.IsChecked == false)
            {
                listBox.ItemsSource = null;
            }
        }

        private void CheckPT_Unchecked(object sender, RoutedEventArgs e)//If PT CheckBox gets unchecked
        {

            //Same funciton as if the FT box gets checked
            if (CheckFT.IsChecked == true && CheckPT.IsChecked == true)
            {
                listBox.ItemsSource = Employees;
            }
            else if (CheckFT.IsChecked == true)
            {
                listBox.ItemsSource = PTemploy;
            }
            else if (CheckPT.IsChecked == false && CheckFT.IsChecked == false)
            {
                listBox.ItemsSource = null;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e) //Method for the Update Button
        {
            Employee selectedEmployee = listBox.SelectedItem as Employee; //slected employee from list box

            if (selectedEmployee != null) //checks if slection is null
            {
                string fName = textBox.Text, lName = textBox1.Text; //Sets all the variables in boxs

                decimal Salary = decimal.Parse(Salarytxt.Text); //Converts all boxs from String to decimal or int
                decimal hourlyRate = decimal.Parse(hourlyRatetxt.Text);
                int hoursWorked = int.Parse(hoursWorkedtxt.Text);

                if(Salarytxt != null && FT.IsChecked == true) //checks if it is fulltime or part time
                {
                    FullTime employee = new FullTime(fName, lName, Salary); //creates updated employee

                    FTemploy.Add(employee); //adds the new updated employee to observableCollection
                    Employees.Add(employee);
                    FTemploy.Remove(selectedEmployee);//REmoves the old employee
                    Employees.Remove(selectedEmployee);
                }
                else if(hourlyRatetxt != null && hoursWorkedtxt != null && PT.IsChecked == true) //checks if it is fulltime or part time
                {
                    PartTime employee = new PartTime(fName, lName, hourlyRate, hoursWorked); //creates updated employee

                    PTemploy.Add(employee);//adds the new updated employee to observableCollection
                    Employees.Add(employee);
                    PTemploy.Remove(selectedEmployee);//removes old employee
                    Employees.Remove(selectedEmployee);
                }
            }
        }
        public void Check() //checks if ft or pt radio buttons are presses and disables text boxes based on which
        {
            if (FT.IsChecked == true) //If FT is checked, only allows Salary to be edited
            {
                Salarytxt.IsEnabled = true;
                hoursWorkedtxt.IsEnabled = false;
                hourlyRatetxt.IsEnabled = false;
            }
            else if (PT.IsChecked == true) //If PT is checked only allows hoursWorked and hourly rate to be edited
            {
                Salarytxt.IsEnabled = false;
                hoursWorkedtxt.IsEnabled = true;
                hourlyRatetxt.IsEnabled = true;
            }
            else //If neither are checked can edit any
            {
                Salarytxt.IsEnabled = true;
                hoursWorkedtxt.IsEnabled = true;
                hourlyRatetxt.IsEnabled = true;
            }
        }

        private void FT_Click(object sender, RoutedEventArgs e) //when FT clicked check what can be used
        {
            Check();
        }

        private void PT_Click(object sender, RoutedEventArgs e) //when PT clicked check what can be used
        {
            Check();
        }
    }
}
