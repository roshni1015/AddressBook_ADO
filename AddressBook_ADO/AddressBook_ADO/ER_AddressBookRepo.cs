using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO
{
    public class ER_AddressBookRepo
    {
        PersonDetail1 personDetail1 = new PersonDetail1();
        Address_Book1 address_Book1 = new Address_Book1();
        PersonTypes1 personTypes1 = new PersonTypes1();
        PersonsDetail_Type1 personsDetail_Type1 = new();
        Employee_Department1 employee_Department1 = new();
        private SqlConnection Connection;

      
        public void GetAllContactOf_PersonDetail1()
        {
            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"Select * from PersonDetail1";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            personDetail1.PersonId = datareader.GetInt32(0);
                            personDetail1.AddressBookId = datareader.GetInt32(1);
                            personDetail1.FirstName = datareader.GetString(2);
                            personDetail1.LastName = datareader.GetString(3);
                            personDetail1.Address = datareader.GetString(4);
                            personDetail1.City = datareader.GetString(5);
                            personDetail1.State = datareader.GetString(6);
                            personDetail1.Zip = datareader.GetInt32(7);
                            personDetail1.PhoneNumber = datareader.GetInt64(8);
                            personDetail1.Email_ID = datareader.GetString(9);

                            Console.WriteLine(personDetail1.FirstName + " " +
                                personDetail1.LastName + " " +
                                personDetail1.Address + " " +
                                personDetail1.City + " " +
                                personDetail1.State + " " +
                                personDetail1.Zip + " " +
                                personDetail1.PhoneNumber + " " +
                                personDetail1.Email_ID + " "
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       
        public void GetAllContactOf_Address_Book1()
        {
            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"Select * from Address_Book1";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            address_Book1.AddressBookId = datareader.GetInt32(0);
                            address_Book1.AddressBookName = datareader.GetString(1);

                            Console.WriteLine(address_Book1.AddressBookId + " " +
                                address_Book1.AddressBookName + " "
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public void GetAllContactOf_PersonTypes1()
        {
            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"Select * from PersonTypes1";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            personTypes1.PersonTypeId = datareader.GetInt32(0);
                            personTypes1.PersonType = datareader.GetString(1);

                            Console.WriteLine(personTypes1.PersonTypeId + " " +
                                personTypes1.PersonType + " "
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       
        public void GetAllContactOf_PersonsDetail_Type1()
        {
            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"Select * from PersonsDetail_Type1";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            personsDetail_Type1.PersonId = datareader.GetInt32(0);
                            personsDetail_Type1.PersonTypeId = datareader.GetInt32(1);

                            Console.WriteLine(personsDetail_Type1.PersonId + " " +
                                personsDetail_Type1.PersonTypeId + " "
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       
        public void GetAllContactOf_Employee_Department1()
        {
            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"Select * from Employee_Department1";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            employee_Department1.PersonId = datareader.GetInt32(0);
                            employee_Department1.EmployeeID = datareader.GetInt32(1);
                            employee_Department1.DepartmentID = datareader.GetInt32(2);


                            Console.WriteLine(employee_Department1.PersonId + " " +
                                employee_Department1.EmployeeID + " " +
                                employee_Department1.DepartmentID + " "
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetContactsBasedOnCityStateByJoins()
        {

            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"SELECT addressbook.AddressBookId,addressbook.AddressBookName,persondetail.PersonId,persondetail.FirstName,persondetail.LastName,persondetail.Address,persondetail.City,persondetail.State,persondetail.Zip,
                                    persondetail.PhoneNumber,persondetail.Email_ID,persontype.PersonType,persontype.PersonTypeId FROM
                                    Address_Book1 AS addressbook 
                                    INNER JOIN PersonDetail1 AS persondetail ON addressbook.AddressBookId = persondetail.AddressBookId AND (persondetail.City='Old Alwal' OR persondetail.State='Telangana')
                                    INNER JOIN PersonsDetail_Type1 as persontypedetail On persontypedetail.PersonId = persondetail.PersonId
                                    INNER JOIN PersonTypes1 AS persontype ON persontype.PersonTypeId = persontypedetail.PersonTypeId";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            address_Book1.AddressBookId = datareader.GetInt32(0);
                            address_Book1.AddressBookName = datareader.GetString(1);
                            personDetail1.PersonId = datareader.GetInt32(2);
                            personDetail1.FirstName = datareader.GetString(3);
                            personDetail1.LastName = datareader.GetString(4);
                            personDetail1.Address = datareader.GetString(5);
                            personDetail1.City = datareader.GetString(6);
                            personDetail1.State = datareader.GetString(7);
                            personDetail1.Zip = datareader.GetInt32(8);
                            personDetail1.PhoneNumber = datareader.GetInt64(9);
                            personDetail1.Email_ID = datareader.GetString(10);
                            personTypes1.PersonType = datareader.GetString(11);
                            personTypes1.PersonTypeId = datareader.GetInt32(12);

                            Console.WriteLine(personTypes1.PersonTypeId + " " +
                                personTypes1.PersonType + " " + personDetail1.FirstName + " " +
                                personDetail1.LastName + " " +
                                personDetail1.Address + " " +
                                personDetail1.City + " " +
                                personDetail1.State + " " +
                                personDetail1.Zip + " " +
                                personDetail1.PhoneNumber + " " +
                                personDetail1.Email_ID + " " + address_Book1.AddressBookId + " " +
                                address_Book1.AddressBookName + " "
                                );

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetCountOfContactsByCity_PersonDetail1()
        {
            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"Select Count(*) As count,City from PersonDetail1 Group By City;";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            personDetail1.count = datareader.GetInt32(0);
                            personDetail1.City = datareader.GetString(1);

                            Console.WriteLine(
                                personDetail1.count + " " +
                                personDetail1.City
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetContactsInAlphabeticalOrderOfFirstNameByJoins()
        {

            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query = @"SELECT addressbook.AddressBookId,addressbook.AddressBookName,persondetail.PersonId,persondetail.FirstName,persondetail.LastName,persondetail.Address,persondetail.City,persondetail.State,persondetail.Zip,
                                    persondetail.PhoneNumber,persondetail.Email_ID,persontype.PersonType,persontype.PersonTypeId FROM
                                    Address_Book1 AS addressbook 
                                    INNER JOIN PersonDetail1 AS persondetail ON addressbook.AddressBookId = persondetail.AddressBookId 
                                    INNER JOIN PersonsDetail_Type1 as persontypedetail On persontypedetail.PersonId = persondetail.PersonId
                                    INNER JOIN PersonTypes1 AS persontype ON persontype.PersonTypeId = persontypedetail.PersonTypeId Order By FirstName";
                    SqlCommand cmd = new SqlCommand(Query, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            address_Book1.AddressBookId = datareader.GetInt32(0);
                            address_Book1.AddressBookName = datareader.GetString(1);
                            personDetail1.PersonId = datareader.GetInt32(2);
                            personDetail1.FirstName = datareader.GetString(3);
                            personDetail1.LastName = datareader.GetString(4);
                            personDetail1.Address = datareader.GetString(5);
                            personDetail1.City = datareader.GetString(6);
                            personDetail1.State = datareader.GetString(7);
                            personDetail1.Zip = datareader.GetInt32(8);
                            personDetail1.PhoneNumber = datareader.GetInt64(9);
                            personDetail1.Email_ID = datareader.GetString(10);
                            personTypes1.PersonType = datareader.GetString(11);
                            personTypes1.PersonTypeId = datareader.GetInt32(12);

                            Console.WriteLine(personTypes1.PersonTypeId + " " + personDetail1.FirstName + " " +
                                personTypes1.PersonType + " " +
                                personDetail1.LastName + " " +
                                personDetail1.Address + " " +
                                personDetail1.City + " " +
                                personDetail1.State + " " +
                                personDetail1.Zip + " " +
                                personDetail1.PhoneNumber + " " +
                                personDetail1.Email_ID + " " + address_Book1.AddressBookId + " " +
                                address_Book1.AddressBookName + " "
                                );

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetCountOfContactsByTypeByJoins()
        {
            try
            {
                Connection = new SqlConnection(@"Data Source=LAPTOP-RLUTTHG1; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.Connection)
                {
                    string Query2 = @"Select Count(a.PersonTypeId) As PersonCount,b.PersonType From 
                                        PersonsDetail_Type1 As a 
                                        INNER JOIN PersonTypes1 AS b ON b.PersonTypeId = a.PersonTypeId
                                        INNER JOIN PersonDetail1 AS c ON c.PersonId = a.PersonId Group By a.PersonTypeId,b.PersonType;";
                    SqlCommand cmd = new SqlCommand(Query2, this.Connection);
                    this.Connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            personTypes1.PersonCount = datareader.GetInt32(0);
                            personTypes1.PersonType = datareader.GetString(1);

                            Console.WriteLine(personTypes1.PersonCount + " " + personTypes1.PersonType
                                );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

