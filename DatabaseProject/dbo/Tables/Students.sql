﻿CREATE TABLE [dbo].[Students]
(
	[Id]  INT IDENTITY PRIMARY KEY NOT NULL,
	[FName]  NVARCHAR (50) NOT NULL,
	[LName]  NVARCHAR (50) NOT NULL,
	[PhoneNumber]  NVARCHAR (15) NOT NULL,
	[Email]  NVARCHAR (256) NOT NULL,
	[Nationality]  NVARCHAR (50) NOT NULL,
	[AddressId] INT NOT NULL,


)
