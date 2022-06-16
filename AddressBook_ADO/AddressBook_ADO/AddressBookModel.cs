using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO
{
    public class AddressBookModel
    {
        public int AddressBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string AddressbookName { get; set; }
        public string Type { get; set; }
    }
   
    public class Address_Book1
    {
        //Table Name - Address_Book1
        public int AddressBookId { get; set; }
        public string AddressBookName { get; set; }
    }
    public class PersonDetail1
    {
        public int count { get; set; }
        public int PersonId { get; set; }
        public int AddressBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        //is in bigint
        public string Email_ID { get; set; }
    }

    public class PersonTypes1
    {
        public int PersonTypeId { get; set; }
        public string PersonType { get; set; }
        public int AddressBookCount { get; set; }
        public int PersonCount { get; set; }

    }
    public class PersonsDetail_Type1
    {
        public int PersonId { get; set; }
        public int PersonTypeId { get; set; }
        public int PersonCount { get; set; }
    }
    public class Employee_Department1
    {
        public int PersonId { get; set; }
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
    }
}
