CREATE TABLE Customer (
	ID int IDENTITY(0,1) NOT NULL,
	FirstName nvarchar(255) NOT NULL,
	LastName nvarchar(255) NOT NULL,
	Age int NOT NULL,
	Email nvarchar(500) NULL,
	Phone nvarchar(13) NOT NULL,
	Active bit NOT NULL,
	CONSTRAINT Customer_PK PRIMARY KEY (ID)
) GO

CREATE TABLE Account (
	ID int IDENTITY(0,1) NOT NULL,
	[Type] nvarchar(255) NOT NULL,
	MonthlyFee float NOT NULL,
	CONSTRAINT Account_PK PRIMARY KEY (ID)
) GO

CREATE TABLE Customer_Account (
	Customer_ID int NOT NULL,
	Account_ID int NOT NULL,
	[Name] nvarchar(255) NOT NULL,
	Balance float NOT NULL,
	CONSTRAINT Customer_Account_PK PRIMARY KEY (Customer_ID,Account_ID),
	CONSTRAINT Customer_Account_FK FOREIGN KEY (Customer_ID) REFERENCES Customer(ID),
	CONSTRAINT Customer_Account_FK_1 FOREIGN KEY (Account_ID) REFERENCES Account(ID)
) GO

CREATE TABLE [Transaction] (
	ID int IDENTITY(0,1) NOT NULL,
	Customer_ID int NOT NULL,
    Account_ID int NOT NULL,
	Amount float NOT NULL,
	Reference nvarchar(255) NOT NULL,
	[Date] datetime NOT NULL,
	[Type] nvarchar(2) NOT NULL,
	CONSTRAINT Transaction_PK PRIMARY KEY (ID),
	CONSTRAINT Transaction_FK FOREIGN KEY (Customer_ID) REFERENCES Customer(ID),
    CONSTRAINT Transaction_FK_1 FOREIGN KEY (Account_ID) REFERENCES Account(ID)
) GO