Create procedure[dbo].[SpAddressBook] 
 (
 @FirstName varchar(50),
 @LastName varchar(50),
 @Address varchar(50),
 @City varchar(50),
 @State varchar(50),
 @ZipCode varchar(50),
 @PhoneNumber varchar(50),
 @EmailId varchar(50)
 )
 as
 begin
  Insert into PersonContact(FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,EmailId)
 values(@FirstName,@LastName, @Address, @City, @State, @ZipCode, @PhoneNumber, @EmailId)
SET NOCOUNT ON;
select * from PersonContact
 End