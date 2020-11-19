CREATE TABLE [dbo].[Students]
(
	 [Id]          INT  PRIMARY KEY    IDENTITY (1, 1) NOT NULL,
	[AuthId]      NVARCHAR (128) NOT NULL,
    [FName]       NVARCHAR (50)  NOT NULL,
    [LName]       NVARCHAR (50)  NOT NULL,
    [PhoneNumber] NVARCHAR (15)  NOT NULL,
    [Email]       NVARCHAR (256) NOT NULL,
    [Nationality] NVARCHAR (50)  NOT NULL,
    [AddressId]   INT            NOT NULL,
)
