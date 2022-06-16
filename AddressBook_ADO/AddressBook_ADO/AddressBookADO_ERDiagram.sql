use AddressBookForADO
select * from PersonContact
Create table Address_Book1(AddressBookId Int Identity(1,1) Primary Key,
						  AddressBookName varchar(100));

select *from Address_Book1;

Create table PersonDetail1(   PersonId Int Identity(1,1) Primary Key,
							 AddressBookId Int Foreign Key References Address_Book1(AddressBookId),
							 FirstName varchar(50),
							 LastName varchar(50),
							 Address varchar(100),
							 City varchar(50),
							 State varchar(50),
							 Zip int,
							 PhoneNumber bigint,
							 Email_ID varchar(50)    );

select *from PersonDetail1;


CREATE table PersonTypes1(	 PersonTypeId Int Identity(1,1) Primary Key,
							 PersonType varchar(50), );

select *from PersonTypes1;

CREATE table PersonsDetail_Type1(PersonId Int Foreign Key References PersonDetail1(PersonId),
								PersonTypeId Int Foreign Key References PersonTypes1(PersonTypeId)  );

select *from PersonsDetail_Type1;


CREATE table Employee_Department1(PersonId Int Foreign Key References PersonDetail1(PersonId),
								EmployeeID Int  ,
								DepartmentID int,);
				
select *from Employee_Department1;

INSERT INTO Address_Book1(AddressBookName) Values('Home'),('school'),('college'),(' office');
select *from Address_Book1;

---------Inserting values into persontype--------------
INSERT INTO PersonTypes1(PersonType) VALUES('Family'),('schoolFriend'),('Friend'),('Colleague');
select *from PersonTypes1;

-----------Insert values in person detail table-------------
Insert INTO PersonDetail1 VALUES(1,'Roshni','Adatrao','AC Colony','Pune','Maharastra',123456,9998877665,'roshni@gmail.com'),
								(2,'Mahesh','Kulkarni','AC Colony','Pune','Maharastra',654321,8877665544,'mahesh@gmail.com'),
								(3,'Vivek','Adatrao','XY Colony','Mumbai','Maharastra',789065,9887766565,'vivek@gamil.com'),
								(4,'Pradnya','Patil','PQ Colony','Banglore','Karnataka',456321,9776875654,'pradnya@gmail.com');
select *from PersonDetail1;
-----------Insert values in person detail type-------------
INSERT INTO PersonsDetail_Type1(PersonId,PersonTypeId) VALUES(1,1),(2,3),(3,4),(4,2);
select *from PersonsDetail_Type1;

-----------Insert values in Employee_Department1 table-------------
INSERT INTO Employee_Department1 VALUES(1,153,918),(2,556,17812),(3,589,4902),(4,344,123815)

select *from Employee_Department1;
