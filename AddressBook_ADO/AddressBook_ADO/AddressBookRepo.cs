using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO
{
    public class AddressBookADO
    {
        public void Create_Database()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =master; Integrated Security = True;");
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Create database AddressBookForADO;", Connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("AddressbookService Database created successfully!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured :" + e.Message + "\t");
            }
        }
        public void CreateTable()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =master; Integrated Security = True;");
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Create table PersonContact(ID int identity(1,1)primary key,FirstName varchar(200),LastName varchar(200),Address varchar(200), City varchar(200), State varchar(200), ZipCode varchar(200), PhoneNumber varchar(50), EmailId varchar(200)); ", Connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("AddressBook table is created!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t");
            }
        }
       
    }
    
}
