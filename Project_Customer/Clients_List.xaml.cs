using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace Project_Customer
{

    public partial class Clients_List : Window
    {
        Clients_Base_Information clients_Base_Information = new Clients_Base_Information();

        public Clients_List()
        {
            InitializeComponent();
            clients_Base_Information.Customers_List = new List<Customer> { new Customer("Jan", "Kowalski", "kowalskijan8375@gmail.com", "BE380139842091", "Lubicz 29", "572093749", Gender.Male, DateTime.Parse("23.02.2023")), new Customer("Ania", "Wolak", "wolak-ania@wp.pl", "FE380139572091", "Sienkiewicza 110", "784264555", Gender.Female, DateTime.Parse("04.03.2023")), new Customer("Adam", "Nowak", "nowak.adam@gmail.com", "PL11234341", "Marszałkowska 1", "123456789", Gender.Male, DateTime.Parse("01.04.2023")) };
            Clients_List_Box.ItemsSource = clients_Base_Information.Customers_List;
        }
        public Clients_List(Clients_Base_Information clients_Information) :this()
        {
            clients_Base_Information = clients_Information;
            Clients_List_Box.ItemsSource = clients_Information.Customers_List;
        }             

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Client objSecondWindow = new Add_Client(clients_Base_Information);
            objSecondWindow.Show();
            this.Close();
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Clients_List_Box.SelectedIndex;
            if (selectedIndex != -1)
            {
                Customer customer = clients_Base_Information.Customers_List[selectedIndex];
                Edit_Client objSecondWindow = new Edit_Client(clients_Base_Information, customer);
                objSecondWindow.Show();
                this.Close();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = Clients_List_Box.SelectedIndex;
            if (selectedIndex != -1)
            {
                clients_Base_Information.Remove_Customer((Customer)Clients_List_Box.SelectedItem);
                MessageBox.Show("Customer deleted successfully!", "Success");
                Clients_List objSecondWindow = new Clients_List(clients_Base_Information);
                objSecondWindow.Show();
                this.Close();
            }
        }
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                clients_Base_Information.ZapiszDC(filename);
            }
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                clients_Base_Information = Clients_Base_Information.OdczytDC(filename);
                Clients_List objSecondWindow = new Clients_List(clients_Base_Information);
                objSecondWindow.Show();
                this.Close();

            }
        }
    }
}
