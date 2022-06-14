use AddressBookForADO;
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
go
Alter procedure [SpAddressBookEditUpdate]
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
Update  PersonContact set FirstName=@FirstName,LastName=@LastName,Address=@Address,City=@City,State=@State,@ZipCode=@ZipCode,
PhoneNumber=@PhoneNumber,@EmailId=@EmailId where FirstName=@FirstName;
SET NOCOUNT ON;
SELECT FirstName,LastName,Address,City,State,@ZipCode,PhoneNumber,@EmailId from PersonContact
END
GO

Alter procedure [SpAddressBook_Delete]
(
	@FirstName varchar(50)
)
as
begin
Delete from PersonContact where FirstName = @FirstName;
End