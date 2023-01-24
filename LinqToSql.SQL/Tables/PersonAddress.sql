CREATE TABLE [dbo].[PersonAddress]
(
	[PersonAddressId] INT NOT NULL PRIMARY KEY,
	[Address] NVARCHAR(255),
	[City] NVARCHAR(255),
	FOREIGN KEY(PersonAddressId) REFERENCES Persons(Id)
)
