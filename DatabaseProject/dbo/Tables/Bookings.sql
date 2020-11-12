CREATE TABLE [dbo].[Bookings]
(
	[Id] INT IDENTITY PRIMARY KEY NOT NULL,
	[CreationDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [MoveInDate] DATETIME2 NOT NULL, 
    [MoveOutDate] DATETIME2 NOT NULL, 
    [Status] NCHAR(10) NOT NULL,

)
