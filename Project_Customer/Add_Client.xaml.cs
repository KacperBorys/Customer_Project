using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class Add_Client : Window
    {
        Clients_Base_Information clients_Base_Information = new Clients_Base_Information();
        public Add_Client()
        {
            InitializeComponent();
        }
        public Add_Client(Clients_Base_Information clients_Information) :this()
        {
            clients_Base_Information = clients_Information;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Clients_List objSecondWindow = new Clients_List(clients_Base_Information);
            objSecondWindow.Show();
            this.Close();
        }
        private void CreateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if((NameTextBox.Text == "") || (SurnameTextBox.Text == "") || (EmailTextBox.Text == "") || (VATTextBox.Text == "") || (AddressTextBox.Text == "") || (PhoneTextBox.Text == "") || (GenderComboBox.Text == "") || (CreationDatePicker.Text == ""))
            {
                MessageBox.Show("Fill the gaps!", "Error");
            }
            else
            {
                if (!EmailTextBox.Text.Contains("@"))
                    {
                        MessageBox.Show("Invalid e-mail!", "Error");
                    }
                else
                {
                    if (!Regex.IsMatch(PhoneTextBox.Text, @"^\d{9}$"))
                    {
                        MessageBox.Show("Invalid phone number!", "Error");
                    }
                    else
                    {
                        if (DateTime.Parse(CreationDatePicker.Text) > DateTime.Now.Date.AddDays(1))
                        {
                            MessageBox.Show("Invalid date!", "Error");
                        }
                        else
                        {
                            if (GenderComboBox.Text.ToString() == "Male")
                            {
                                Customer c = new Customer(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, VATTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, Gender.Male, DateTime.Parse(CreationDatePicker.Text));
                                clients_Base_Information.Add_Customer(c);
                            }
                            else if (GenderComboBox.Text.ToString() == "Female")
                            {
                                Customer c = new Customer(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, VATTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, Gender.Female, DateTime.Parse(CreationDatePicker.Text));
                                clients_Base_Information.Add_Customer(c);
                            }
                            else
                            {
                                Customer c = new Customer(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, VATTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, Gender.Other, DateTime.Parse(CreationDatePicker.Text));
                                clients_Base_Information.Add_Customer(c);
                            }
                            MessageBox.Show("Customer added successfully!", "Success");
                            Clients_List objSecondWindow = new Clients_List(clients_Base_Information);
                            objSecondWindow.Show();
                            this.Close();

                        }
                    }
                }   
            }
            
        }
    }
}
