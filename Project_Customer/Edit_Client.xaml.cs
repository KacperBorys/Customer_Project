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
using System.Windows.Shapes;

namespace Project_Customer
{
    public partial class Edit_Client : Window
    {
        Customer customer;
        Clients_Base_Information clients_Base_Information = new Clients_Base_Information();
        public Edit_Client()
        {
            customer= new Customer();
            InitializeComponent();
        }
        public Edit_Client(Clients_Base_Information clients_Information, Customer customer_to_edit) :this()
        {
            clients_Base_Information = clients_Information;
            customer = customer_to_edit;
            NameTextBox.Text = customer_to_edit.Name;
            SurnameTextBox.Text = customer_to_edit.Surname;
            EmailTextBox.Text = customer_to_edit.E_mail;
            VATTextBox.Text = customer_to_edit.VAT_Identification_Number;
            AddressTextBox.Text = customer_to_edit.Address;
            PhoneTextBox.Text = customer_to_edit.Phone_Number;
            GenderComboBox.Text = customer_to_edit.Gender.ToString();
            CreationDatePicker.Text = customer_to_edit.Creation_date.ToString();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int index = clients_Base_Information.Customers_List.IndexOf(customer);
            clients_Base_Information.Remove_Customer(customer);
            if ((NameTextBox.Text == "") || (SurnameTextBox.Text == "") || (EmailTextBox.Text == "") || (VATTextBox.Text == "") || (AddressTextBox.Text == "") || (PhoneTextBox.Text == "") || (GenderComboBox.Text == "") || (CreationDatePicker.Text == ""))
            {
                MessageBox.Show("Fill the gaps!", "Error");
            }
            else
            {
                if (GenderComboBox.Text.ToString() == "Male")
                {
                    customer = new Customer(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, VATTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, Gender.Male, DateTime.Parse(CreationDatePicker.Text));
                }
                else if (GenderComboBox.Text.ToString() == "Female")
                {
                    customer = new Customer(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, VATTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, Gender.Female, DateTime.Parse(CreationDatePicker.Text));
                }
                else
                {
                    customer = new Customer(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, VATTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, Gender.Other, DateTime.Parse(CreationDatePicker.Text));
                }
                clients_Base_Information.Customers_List.Insert(index, customer);
                MessageBox.Show("Customer's informations eddited successfully!", "Success");
                Clients_List objSecondWindow = new Clients_List(clients_Base_Information);
                objSecondWindow.Show();
                this.Close();
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Clients_List objSecondWindow = new Clients_List(clients_Base_Information);
            objSecondWindow.Show();
            this.Close();
        }
    }
}
