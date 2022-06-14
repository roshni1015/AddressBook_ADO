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
        public const string ConnFile = @"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;";
        SqlConnection connection = new SqlConnection(ConnFile);
        public bool AddContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddressBook", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@EmailId", model.EmailId);
                    this.connection.Open();

                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        public void GetAllContact()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                using (this.connection)
                {
                    string Query = @"Select * from PersonContact";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.AddressBookId = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.ZipCode = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.EmailId = datareader.GetString(8);


                            Console.WriteLine("AddressBookId : " + addressmodel.AddressBookId);
                            Console.WriteLine("FirstName : " + addressmodel.FirstName);
                            Console.WriteLine("LastName : " + addressmodel.LastName);
                            Console.WriteLine("Address : " + addressmodel.Address);
                            Console.WriteLine("City : " + addressmodel.City);
                            Console.WriteLine("State : " + addressmodel.State);
                            Console.WriteLine("ZipCode : " + addressmodel.ZipCode);
                            Console.WriteLine("PhoneNumber : " + addressmodel.PhoneNumber);
                            Console.WriteLine("EmailId : " + addressmodel.EmailId);
                            Console.WriteLine();                       
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool UpdateContact(AddressBookModel model)
        {
            try
            {

                SqlConnection Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =master; Integrated Security = True;");

                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddressBookEditUpdate", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@Zip", model.ZipCode);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", model.EmailId);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
       
        public string UpdateEmployeeDetails()
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=LAPTOP-2UH1FDRP\MSSQLSERVER01; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            SqlCommand command = new SqlCommand("Update PersonContact set Address='H.T. Colony' where FirstName='Roshni'", connection);
            AddressBookModel addressmodel = new AddressBookModel();
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                string query = @"Select Address from PersonContact where FirstName='Roshni';";
                SqlCommand cmd = new SqlCommand(query, connection);
                object res = cmd.ExecuteScalar();
                connection.Close();
                addressmodel.Address = (string)res;
            }
            connection.Close();
            return (addressmodel.Address);
        }
        public bool DeleteContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("[SpAddressBook_Delete]", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

    }
}

