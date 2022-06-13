// See https://aka.ms/new-console-template for more information
using AddressBook_ADO;

Console.WriteLine("Welcome To Address Book ADO");
AddressBookADO address = new();
while (true)
{
    Console.WriteLine("Choose the option :\n1)Create a Database\n2)Create table in DB\n3)Insert Values to Table\n4)Retrieve values from Table");
    int option = Convert.ToInt16(Console.ReadLine());
    switch (option)
    {
        case 1:
            address.Create_Database();
            break;
        case 2:
            address.CreateTable();
            break;
        case 3:
            AddressBookModel addressbook = new AddressBookModel();
            addressbook.FirstName = "Roshni";
            addressbook.LastName = "Adatrao";
            addressbook.Address = "S.T. Colony";
            addressbook.City = "Pune";
            addressbook.State = "Maharastra";
            addressbook.ZipCode = "411013";
            addressbook.PhoneNumber = "9988776655";
            addressbook.EmailId = "roshni@gmail.com";
            address.AddContact(addressbook);
            Console.WriteLine("Record Inserted successfully");
            break;
        case 4:
            address.GetAllContact();
            break;
        default:
            Console.WriteLine("Please choose correct option");
            break;
    }
}