CREATE TABLE [dbo].[Administrators] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
	[AuthId]         NVARCHAR (128) NOT NULL,
    [EmployeeNumber] NVARCHAR (50)  NOT NULL,
    [FName]          NVARCHAR (50)  NOT NULL,
    [LName]          NVARCHAR (50)  NOT NULL,
    [PhoneNumber]    NVARCHAR (15)  NOT NULL,
    [Email]          NVARCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

