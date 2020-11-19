CREATE TABLE [dbo].[Students]
(
	 [Id]          INT  PRIMARY KEY    IDENTITY (1, 1) NOT NULL,
	[AuthId]      NVARCHAR (128) NOT NULL,
    [FirstName]       NVARCHAR (50)  NOT NULL,
    [LastName]       NVARCHAR (50)  NOT NULL,
    [PhoneNumber] NVARCHAR (15)  NOT NULL,
    [Email]       NVARCHAR (256) NOT NULL,
    [DateOfBirth] DATE NOT NULL,
    [Nationality] NVARCHAR (50)  NOT NULL,
    [EducationEndDate] Date NOT NULL,
    [AddressId]   INT            NOT NULL,
)
