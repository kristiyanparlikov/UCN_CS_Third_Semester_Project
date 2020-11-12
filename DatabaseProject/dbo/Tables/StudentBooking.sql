CREATE TABLE [dbo].[StudentBooking]
(
	[StudentId] INT  NOT NULL, 
    [BookingId] INT  NOT NULL,
	CONSTRAINT FK_StudentBooking_Students FOREIGN KEY ([StudentId])
    REFERENCES Students([Id]),
	CONSTRAINT FK_StudentBooking_Booking FOREIGN KEY ([BookingId])
	REFERENCES Bookings([Id]),
	CONSTRAINT PK_StudentBooking PRIMARY KEY (StudentId,BookingId)
 )
