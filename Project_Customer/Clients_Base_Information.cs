using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project_Customer
{
    [DataContract]
    public class Clients_Base_Information
    {
        [DataMember]
        List<Customer> customers_List = new List<Customer>();
        public List<Customer> Customers_List { get => customers_List; set => customers_List = value; }
        public Clients_Base_Information() { }
        public Clients_Base_Information(List<Customer> customers) : this()
        {
            customers_List = customers;
        }
        public void Add_Customer(Customer customer)
        {
            Customers_List.Add(customer);
        }
        public void Remove_Customer(Customer customer)
        {
            Customers_List.Remove(customer);
        }
        public List<Customer> List_Customers()
        {
            return Customers_List;
        }
        public void ZapiszDC(string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Create);
            DataContractSerializer dc = new DataContractSerializer(typeof(Clients_Base_Information));
            dc.WriteObject(fs, this);
            fs.Close();
        }
        public static Clients_Base_Information OdczytDC(string fname)
        {
            if (!File.Exists(fname)) { return null; }
            FileStream fs = new FileStream(fname, FileMode.Open);
            DataContractSerializer dc = new DataContractSerializer(typeof(Clients_Base_Information));
            Clients_Base_Information customers = (Clients_Base_Information)dc.ReadObject(fs);
            fs.Close();
            return customers;
        }
    }
}
