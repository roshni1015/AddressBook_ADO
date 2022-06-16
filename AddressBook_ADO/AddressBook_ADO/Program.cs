// See https://aka.ms/new-console-template for more information
using AddressBook_ADO;

Console.WriteLine("Welcome To Address Book ADO");
AddressBookADO address = new();
AddressBookModel addressbook = new AddressBookModel();
ER_AddressBookRepo repo = new ER_AddressBookRepo();

while (true)
{
    Console.WriteLine("Choose the option :\n1)Create a Database\n2)Create table in DB\n3)Insert Values to Table\n4)Retrieve values from Table\n6)Update details of Contact\n7)Delete Contacts\n8)Count Of Records by City or State\n9)Get Records by City\n10)Get Records by State\n11)Alphabetically Sorted for given city\n12)Adding AddressBookName and AddressBookType\n13)Get contact by Type\n14)Count By AddressBookType\n15)Add Same person as Friend and Family" +
        "\n16)Display of PersonDetail1\n17)Display of Address_Book1\n18)Display of PersonTypes1" +
        "\n19)Display of PersonsDetail_Type1\n20)Display of Employee_Department1");
    int option = Convert.ToInt16(Console.ReadLine());
    switch (option)
    {
        case 1:
            address.Create_Database();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 2:
            address.CreateTable();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 3:
            AddressBookModel addressbook1 = new AddressBookModel();
            addressbook1.FirstName = "Roshni";
            addressbook1.LastName = "Adatrao";
            addressbook1.Address = "S.T. Colony";
            addressbook1.City = "Pune";
            addressbook1.State = "Maharastra";
            addressbook1.ZipCode = "411013";
            addressbook1.PhoneNumber = "9988776655";
            addressbook1.EmailId = "roshni@gmail.com";
            address.AddContact(addressbook1);
            Console.WriteLine("Record Inserted successfully");
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 4:
            address.GetAllContact();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 5:
            AddressBookModel addressbook2 = new AddressBookModel();
            addressbook2.FirstName = "Roshni";
            addressbook2.LastName = "Adatrao";
            addressbook2.Address = "S.T. Colony";
            addressbook2.City = "Pune";
            addressbook2.State = "Maharastra";
            addressbook2.ZipCode = "411013";
            addressbook2.PhoneNumber = "9988776655";
            addressbook2.EmailId = "roshni@gmail.com";
            address.UpdateContact(addressbook2);
            Console.WriteLine("Record Updated successfully");
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 6:
            string UpdatedAddress = address.UpdateEmployeeDetails();
            Console.WriteLine(UpdatedAddress);
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 7:
            AddressBookModel addressbook3 = new AddressBookModel();
            addressbook3.FirstName = "Priya";
            address.DeleteContact(addressbook3);
            Console.WriteLine("Record Deleted successfully");
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 8:
            int countCity = address.CountOfEmployeeDetailsByCity();
            Console.WriteLine("Count of Records by City= Pune :" + countCity);
            Console.WriteLine("-----------------------------------------------------------------------------------");
            int CountState = address.CountOfEmployeeDetailsByState();
            Console.WriteLine("Count of Records by State= Maharastra :" + CountState);
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 9:
            Console.WriteLine("Get Contacts by City name");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            address.GetAllContactByCity();
            Console.WriteLine();
            break;
        case 10:
            Console.WriteLine("Get Contacts by State name");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            address.GetAllContactByState();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 11:
            Console.WriteLine("Get Contacts by City name in Alphabetical Order");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            address.GetAllContactsInAlphbeticalOrderByCity();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 12:
            Console.WriteLine("Adding Two Columns AddressBookName and AddressBookType");
            address.AddAddressBookNameAndType();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
            //Don't Need To Run
        case 13:
            address.GetContactsBYAddressBookType();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 14:
            int countByType = address.CountOfEmployeeDetailsByType();
            Console.WriteLine("Count of Records by Type= Family :" + countByType);
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 15:
            address.AddContactAsFriendAndFamily();
            Console.WriteLine();
            Console.WriteLine("********************************************************************************************************");
            break;
        case 16:
            Console.WriteLine("Display of PersonDetail1");
            repo.GetAllContactOf_PersonDetail1();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            break;
        case 17:
            Console.WriteLine("Display of Address_Book1");
            repo.GetAllContactOf_Address_Book1();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            break;
        case 18:
            Console.WriteLine("Display of PersonTypes1");
            repo.GetAllContactOf_PersonTypes1();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            break;
        case 19:
            Console.WriteLine("Display of PersonsDetail_Type1");
            repo.GetAllContactOf_PersonsDetail_Type1();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            break;
        case 20:
            Console.WriteLine("Display of Employee_Department1");
            repo.GetAllContactOf_Employee_Department1();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            break;
        default:
            Console.WriteLine("Please choose correct option");
            break;
    }
}