/***********************************************UC1 to create a Address Book service database****************************************************/

create database AddressBookDB
use AddressBookDB

/*******************************************UC2 create a PersonContacts table in theAddress Book service database********************************/

create table PersonContact(
Id int identity(1,1) NOT NULL PRIMARY KEY,
FirstName varchar(20) ,
LastName varchar(20),
Address varchar(200),
City varchar(20),
State varchar(20),
ZipCode varchar(10),
PhoneNumber varchar(20),
EmailId varchar(100)
);



/*****************************************************UC3 Insert New Contacts to Adress Book*****************************************************/

Insert into PersonContact(FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,EmailId) values 
('Roshni','Adatrao','S.T.Colony','Pune','Maharastra','123456','9999786747','roshni@mail.com'),
('Lavanya','Chaudhary','B.T.Colony','Pune','Karnataka','789123','9909258899','lavanya@mail.com'),
('Mahesh','Deshmukh','R.T.Colony','Mumbai','Maharastra','345678','8877927846','mahesh@mail.com'),
('Vivek','Patil','A.T.Colony','Chennai','Tamil Nadu','234517','9856112233','vivek@mail.com'),
('Priya','Kulkarni','H.T.Colony','Kolkata','West Bangal','908745','7775137805','priya@mail.com');

Select * from PersonContact;



/***************************************************UC4 Edit State and PinCode using name********************************************************/

UPDATE PersonContact set State='Andhra Pradesh' where FirstName='Lavanya' or FirstName='Priya'
UPDATE PersonContact set ZipCode='125643' where FirstName='Mahesh' or FirstName='Vivek'


 
/****************************************************UC5 Delete a person using Name**************************************************************/

Delete from PersonContact where FirstName = 'Priya';



/***********************************************UC6 Retrieve Person Contacts By City or State***************************************************/

select * from PersonContact where City = 'Pune' or State = 'Maharastra';
select * from PersonContact where City = 'Mumbai' 
select * from PersonContact where State = 'Tamil Nadu'



/***********************************************UC7 Size of Address Book by City and State*******************************************************/

Select count(City) from PersonContact;
Select COUNT(Address) From PersonContact Where City='Pune' 
Select count(State) from PersonContact;
Select COUNT(Address) From PersonContact Where State='Maharastra' 



/****************************************UC8 Retrieve Entries Sorted Alphabetically by Person’s name for a given city****************************/

Select* from PersonContact where city='Pune'order by FirstName Asc;



/**************************************************UC9 Identify Each Address Book with Name and Type*********************************************/

ALTER TABLE PersonContact ADD Type varchar(15);
UPDATE PersonContact set Type='Family' where FirstName='Roshni'
UPDATE PersonContact set Type='Profession' where FirstName='Mahesh';
UPDATE PersonContact set Type='Friend' where Firstname='Lavanya';
UPDATE PersonContact set Type='Family' where Firstname='Vivek';


Select * from PersonContact;



/***************************************************UC10 Get Number Of Contact Persons By Type***************************************************/

Select COUNT(Type) From PersonContact



/*****************************************************UC11 Add Person to both Friend and Family**************************************************/

Insert into PersonContact Values ('Vaishanvi','Chavan','M.T.Colony','Solapur','Maharastra','123498','9934566747','vaishanvi@mail.com','Family')
Insert into PersonContact Values ('Mangesh','Deshpande','N.T.Colony','Kolhapur','Maharastra','123456','9999876747','mangesh@mail.com','Friend')



/****************************************************UC12 ER Diagram for Address Book Service DB*************************************************/

Create table AddressBook(AddressBookId Int Identity(1,1) Primary Key, AddressBookName varchar(50));
Select * from AddressBook;

Create table PersonContacts( PersonId Int Identity(1,1) Primary Key,
							 AddressBookId Int Foreign Key References AddressBook(AddressBookId),
							 FirstName varchar(20),
							 LastName varchar(20),
							 Address varchar(200),
							 City varchar(20),
							 State varchar(20),
							 ZipCode varchar(10),
							 PhoneNumber varchar(20),
							 EmailId varchar(100));

Select * from PersonContacts;


Create table Types(TypeId Int Identity(1,1) Primary Key, Type varchar(20));
Select * from Types;


Create table PersonsDetailType(PersonId Int Foreign Key References PersonContacts(PersonId),
                               TypeId Int Foreign Key References Types(TypeId));

Select * from PersonsDetailType;


Create table Professional(PersonId Int Foreign Key References PersonContacts(PersonId),
						  Professional_PersonId Int,
						  ProfessionID int);

Select * from Professional;

Insert into AddressBook(AddressBookName) Values('Home'),('Tution'),('College'),('Profession');
Select * from AddressBook;

Insert into PersonContacts Values(1,'Roshni','Adatrao','S.T.Colony','Pune','Maharastra','123456','9999786747','roshni@mail.com');
Insert into PersonContacts Values(2,'Lavanya','Chaudhary','B.T.Colony','Pune','Karnataka','789123','9909258899','lavanya@mail.com');
Insert into PersonContacts Values(3,'Mahesh','Deshmukh','R.T.Colony','Mumbai','Maharastra','345678','8877927846','mahesh@mail.com');
Insert into PersonContacts Values(4,'Vivek','Patil','A.T.Colony','Chennai','Tamil Nadu','234517','9856112233','vivek@mail.com');
Insert into PersonContacts Values(5,'Priya','Kulkarni','H.T.Colony','Kolkata','West Bangal','908745','7775137805','priya@mail.com');

Select * from PersonContacts;

Insert into Types(Type) Values('Family'),('Friend'),('Classmate'),('Colleague');
Select * from Types;

Insert into PersonsDetailType(PersonId,TypeId)  Values(11,4),(12,3),(13,4),(14,1) ;
Select * from PersonsDetailType;

Insert into Professional(PersonId,Professional_PersonId,ProfessionID) Values(11,25,222),(12,35,333),(13,45,444),(14,55,555);

Select * from Professional;



/****************************************UC13 Ensure All Retrieve Queries done in UC 6, UC 7 , UC 8 and UC 10 ***********************************/

/*---------------------------------------------UC6-Retrieve Person belonging to city Or State---------------------------------------------------*/

SELECT Addressbook.AddressBookId,
       Addressbook.AddressBookName,
       Personcontacts.PersonId,
	   Personcontacts.FirstName,
	   Personcontacts.LastName,
	   Personcontacts.Address,
	   Personcontacts.City,
	   Personcontacts.State,
	   Personcontacts.ZipCode,
	   Personcontacts.PhoneNumber,
	   Personcontacts.EmailId,
	   type.Type,
	   type.TypeId
FROM AddressBook AS Addressbook 
INNER JOIN PersonContacts AS Personcontacts ON addressbook.AddressBookId = Personcontacts.AddressBookId
INNER JOIN PersonsDetailType as Personsdetailtype On Personsdetailtype.PersonId = Personcontacts.PersonId
INNER JOIN Types AS type ON type.TypeId = type.TypeId;



/*-------------------------------------------UC7-understand Size of AddressBook by city and state-----------------------------------------------*/

Select Count(*) As Count,State from PersonContacts Group By State;
Select Count(*) As Count,City from PersonContacts Group By City;

Select count(City) from PersonContacts;
Select count(State) from PersonContacts;

/*---------------------------------------------UC8-Retrieve entries sorted alphabetically by person name----------------------------------------*/
SELECT Addressbook.AddressBookId,
       Addressbook.AddressBookName,
       Personcontacts.PersonId,
	   Personcontacts.FirstName,
	   Personcontacts.LastName,
	   Personcontacts.Address,
	   Personcontacts.City,
	   Personcontacts.State,
	   Personcontacts.ZipCode,
	   Personcontacts.PhoneNumber,
	   Personcontacts.EmailId,
	   type.Type,
	   type.TypeId
FROM AddressBook AS Addressbook 
INNER JOIN PersonContacts AS Personcontacts ON addressbook.AddressBookId = Personcontacts.AddressBookId 
INNER JOIN PersonsDetailType as Personsdetailtype On Personsdetailtype.PersonId = Personcontacts.PersonId
INNER JOIN Types AS type ON type.TypeId = type.TypeId Order By FirstName;


/*---------------------------------UC_10_Retreive Number Of Persons Records Based On AddressBook Names------------------------------------------*/

Select Count(address.AddressBookId) As AddressBookCount,address.AddressBookName 
From AddressBook As address 
INNER JOIN PersonContacts AS Person ON Person.AddressBookId = address.AddressBookId Group By address.AddressBookName,Person.AddressBookId;
