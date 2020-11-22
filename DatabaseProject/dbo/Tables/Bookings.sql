CREATE TABLE [dbo].[Bookings]
(
	[Id] INT IDENTITY PRIMARY KEY NOT NULL,
	[CreationDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [MoveInDate] DATE NOT NULL, 
    [MoveOutDate] DATE NOT NULL, 
    [Status] NCHAR(10) NOT NULL,
    [RoomId] INT  

)
