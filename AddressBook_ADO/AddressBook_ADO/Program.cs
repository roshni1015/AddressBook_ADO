// See https://aka.ms/new-console-template for more information
using AddressBook_ADO;

Console.WriteLine("Welcome To Address Book ADO");
AddressBookADO address = new();
while (true)
{
    Console.WriteLine("Choose the option :\n1)Create a Database\n2)Create table in DB");
    int option = Convert.ToInt16(Console.ReadLine());
    switch (option)
    {
        case 1:
            address.Create_Database();
            break;
        case 2:
            address.CreateTable();
            break;
        default:
            Console.WriteLine("Please choose correct option");
            break;
         
    }
}

