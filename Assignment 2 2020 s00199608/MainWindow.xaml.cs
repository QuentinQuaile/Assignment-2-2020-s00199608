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

namespace Assignment_2_2020_s00199608
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ObservableCollection<Employee> FTemploy = new ObservableCollection<Employee>();
        ObservableCollection<Employee> PTemploy = new ObservableCollection<Employee>();
        ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FullTime employee = new FullTime("Jess", "WALSH", 200);
            FullTime employee1 = new FullTime("Joe", "MURPHY", 300);
            PartTime employee2 = new PartTime("Jane", "JONES", 15, 10);
            PartTime employee3 = new PartTime("John", "SMITH", 20, 7);
            Employees.Add(employee);
            Employees.Add(employee1);
            Employees.Add(employee2);
            Employees.Add(employee3);

            FTemploy.Add(employee);
            FTemploy.Add(employee1);
            PTemploy.Add(employee2);
            PTemploy.Add(employee3);

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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

                if (selectedEmployee.Salary > 0)
                {
                    FT.IsChecked = true;
                }
                else
                {
                    PT.IsChecked = true;
                }

                decimal monthlyPay = selectedEmployee.CalculateMonthlyPay();
                MonthlyPay.Text = "€" + monthlyPay.ToString();
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //read details from screen
            string firstName = textBox.Text;
            string lastName = textBox1.Text;
            

            if(PT.IsChecked == true)
            {
                decimal hourRate;
                double hourWorked;

                hourRate = decimal.Parse(hourlyRatetxt.Text);
                hourWorked = double.Parse(hoursWorkedtxt.Text);
                PartTime employee = new PartTime(firstName, lastName, hourRate, hourWorked);
                PTemploy.Add(employee);
                Employees.Add(employee);
            }
            else if (FT.IsChecked == true)
            {
                decimal salary;
                salary = decimal.Parse(Salarytxt.Text);

                FullTime employee = new FullTime(firstName, lastName, salary);

                FTemploy.Add(employee);
                Employees.Add(employee);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = listBox.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                textBox.Text = null;
                textBox1.Text = null;
                Salarytxt.Text = null;
                hourlyRatetxt.Text = null;
                hoursWorkedtxt.Text = null;

                if (selectedEmployee.Salary > 0)
                {
                    FT.IsChecked = false;
                }
                else
                {
                    PT.IsChecked = false;
                }

                MonthlyPay.Text = null;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = listBox.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                if (selectedEmployee.Salary > 0)
                {
                    FTemploy.Remove(selectedEmployee);
                    Employees.Remove(selectedEmployee);
                }
                else
                {
                    PTemploy.Remove(selectedEmployee);
                    Employees.Remove(selectedEmployee);
                }
            }

        }

        private void CheckFT_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckFT.IsChecked == true && CheckPT.IsChecked == true)
            {
                listBox.ItemsSource = Employees;
            }
            else if(CheckFT.IsChecked == true)
            {
                listBox.ItemsSource = FTemploy;
            }
            else if (CheckPT.IsChecked == false && CheckFT.IsChecked == false)
            {
                listBox.ItemsSource = null;
            }
        }

        private void CheckPT_Checked(object sender, RoutedEventArgs e)
        {
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

        private void CheckFT_Unchecked(object sender, RoutedEventArgs e)
        {
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

        private void CheckPT_Unchecked(object sender, RoutedEventArgs e)
        {
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
    }
}
