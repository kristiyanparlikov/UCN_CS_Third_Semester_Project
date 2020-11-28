CREATE TABLE [dbo].[Students] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Email]            NVARCHAR (256) NOT NULL,
    [Password]         NVARCHAR (256) NOT NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [PhoneNumber]      NVARCHAR (15)  NOT NULL,
    [DateOfBirth]      DATE           NOT NULL,
    [Nationality]      NVARCHAR (50)  NOT NULL,
    [EducationEndDate] DATE           NOT NULL,
    [AddressId]        INT            ,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

