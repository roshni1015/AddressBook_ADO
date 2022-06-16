use AddressBookForADO
select * from PersonContact;
Insert into PersonContact(FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,EmailId) values 
('Lavanya','Chaudhary','B.T.Colony','Pune','Karnataka','789123','9909258899','lavanya@mail.com'),
('Vivek','Patil','A.T.Colony','Chennai','Tamil Nadu','234517','9856112233','vivek@mail.com'),
('Priya','Kulkarni','H.T.Colony','Kolkata','West Bangal','908745','7775137805','priya@mail.com');
update PersonContact set AddressBookName ='School',Type='Friend' where ID=5; 
update PersonContact set AddressBookName ='Relative',Type='Cousin' where ID=4; 
update PersonContact set AddressBookName ='Profession',Type='Colleague' where ID=2; 
update PersonContact set AddressBookName ='Self',Type='Self' where ID=1; 