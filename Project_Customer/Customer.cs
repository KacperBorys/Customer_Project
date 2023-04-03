using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Customer
{
    public enum Gender { Male, Female, Other }
    [DataContract]
    public class Customer
    {
        [DataMember]
        string name;
        [DataMember]
        string surname;
        [DataMember]
        string e_mail;
        [DataMember]
        string VAT_identification_number;
        [DataMember]
        string address;
        [DataMember]
        string phone_Number;
        [DataMember]
        Gender gender;
        [DataMember]
        DateTime creation_date;
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string E_mail
        {
            get => e_mail;
            set
            {
                if (!value.Contains("@"))
                {
                    MessageBox.Show("Invalid e-mail", "Error");
                }
                else
                {
                    e_mail = value;
                }
            }
        }
        public string VAT_Identification_Number { get => VAT_identification_number; set => VAT_identification_number = value; }
        public string Address { get => address; set => address = value; }
        public string Phone_Number
        {
            get => phone_Number;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{9}$"))
                {
                    MessageBox.Show("Invalid phone number!", "Success");
                }
                else
                {
                    phone_Number = value;
                }
            }
        }
        public Gender Gender { get => gender; set => gender = value; }
        public DateTime Creation_date
        {
            get => creation_date;
            set
            {
                if (value  > DateTime.Now.Date.AddDays(1))
                {
                    MessageBox.Show("Invalid date!", "Success");
                }
                else
                {
                    creation_date = value;
                }
            }
        }
        public Customer() { }
        public Customer(string name, string surname, string e_mail, string VAT_identification_number, string address, string phone_Number, Gender gender, DateTime creation_date) : this()
        {
            Name = name;
            Surname = surname;
            E_mail = e_mail;
            VAT_Identification_Number = VAT_identification_number;
            Address = address;
            Phone_Number = phone_Number;
            Gender = gender;
            Creation_date = creation_date;
        }
        public override string ToString()
        {
            return ($"{Name} {Surname} {Gender}\n{Phone_Number}\n{E_mail}\n{VAT_Identification_Number}\n{Creation_date.ToString("dd-MM-yyyy")}");
        }
    }




}
