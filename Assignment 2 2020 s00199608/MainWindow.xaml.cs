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
        ObservableCollection<Employee> first = new ObservableCollection<Employee>();
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


            first.Add(employee);
            first.Add(employee1);
            first.Add(employee2);
            first.Add(employee3);

            listBox.ItemsSource = first;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
