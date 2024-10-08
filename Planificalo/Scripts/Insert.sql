﻿

DELETE FROm Users;
DELETE FROM ProductQuotes;
DELETE FROM ServiceQuotes;
DELETE FROM Quotes;
DELETE FROM ServiceProviders;
DELETE FROM ProductProviders;
DELETE FROM Providers
DELETE FROM Guests;
DELETE FROM Services;
DELETE FROM EventTypes;
DELETE FROM Events;
DELETE FROM GuestEvents;
DELETE FROM Invitations;




DELETE FROM EventTypes;
DELETE FROM Products;


SET IDENTITY_INSERT Users ON;


INSERT INTO Users (Id, DocumentType, IdentityDocument, Name, Email, Phone, UserStatus, BirthDate, AccountCreationDate) VALUES
(1, 'Cedula', 123456789, 'John Doe', 'johndoe@example.com', '1234567890', 'Active', '1990-01-01', GETDATE()),
(2, 'Cedula', 987654321, 'Jane Smith', 'janesmith@example.com', '0987654321', 'Inactive', '1992-02-02', GETDATE()),
(3, 'Cedula', 112233445, 'Alice Johnson', 'alicejohnson@example.com', '1231231234', 'Active', '1985-03-03', GETDATE()),
(4, 'Cedula', 556677889, 'Bob Brown', 'bobbrown@example.com', '3213214321', 'Inactive', '1988-04-04', GETDATE()),
(5, 'Cedula', 998877665, 'Charlie Davis', 'charliedavis@example.com', '4564564567', 'Active', '1991-05-05', GETDATE()),
(6, 'Cedula', 111222333, 'David Harris', 'davidharris@example.com', '1112223333', 'Active', '1993-06-06', GETDATE()),
(7, 'Cedula', 444555666, 'Eva Green', 'evagreen@example.com', '4445556666', 'Inactive', '1994-07-07', GETDATE()),
(8, 'Cedula', 777888999, 'Frank White', 'frankwhite@example.com', '7778889999', 'Active', '1995-08-08', GETDATE()),
(9, 'Cedula', 101010101, 'Grace Black', 'graceblack@example.com', '1010101010', 'Inactive', '1996-09-09', GETDATE()),
(10, 'Cedula', 202020202, 'Henry Blue', 'henryblue@example.com', '2020202020', 'Active', '1997-10-10', GETDATE()),
(11, 'Cedula', 303030303, 'Ivy Brown', 'ivybrown@example.com', '3030303030', 'Inactive', '1998-11-11', GETDATE()),
(12, 'Cedula', 404040404, 'Jack Green', 'jackgreen@example.com', '4040404040', 'Active', '1999-12-12', GETDATE()),
(13, 'Cedula', 505050505, 'Karen White', 'karenwhite@example.com', '5050505050', 'Inactive', '2000-01-13', GETDATE()),
(14, 'Cedula', 606060606, 'Leo Black', 'leoblack@example.com', '6060606060', 'Active', '2001-02-14', GETDATE()),
(15, 'Cedula', 707070707, 'Mia Blue', 'miablue@example.com', '7070707070', 'Inactive', '2002-03-15', GETDATE()),
(16, 'Cedula', 808080808, 'Noah Brown', 'noahbrown@example.com', '8080808080', 'Active', '2003-04-16', GETDATE()),
(17, 'Cedula', 909090909, 'Olivia Green', 'oliviagreen@example.com', '9090909090', 'Inactive', '2004-05-17', GETDATE()),
(18, 'Cedula', 111111111, 'Paul White', 'paulwhite@example.com', '1111111111', 'Active', '2005-06-18', GETDATE()),
(19, 'Cedula', 222222222, 'Quinn Black', 'quinnblack@example.com', '2222222222', 'Inactive', '2006-07-19', GETDATE()),
(20, 'Cedula', 333333333, 'Rachel Blue', 'rachelblue@example.com', '3333333333', 'Active', '2007-08-20', GETDATE());

SET IDENTITY_INSERT Users OFF;

SET IDENTITY_INSERT Providers ON;


INSERT INTO Providers (Id, Name, Country, Department, City, Address, Email, ContactPhone, IsNaturalPerson, Status, DocumentType, IdentityDocument) VALUES
(1, 'Provider One', 'Country One', 'Department One', 'City One', 'Address One', 'providerone@example.com', '1234567890', 1, 'Active', 'Cedula', 123456789),
(2, 'Provider Two', 'Country Two', 'Department Two', 'City Two', 'Address Two', 'providertwo@example.com', '0987654321', 0, 'Inactive', 'Cedula', 987654321),
(3, 'Provider Three', 'Country Three', 'Department Three', 'City Three', 'Address Three', 'providerthree@example.com', '09875465465', 0, 'Inactive', 'Cedula', 5456465456),
(4, 'Provider Four', 'Country Four', 'Department Four', 'City Four', 'Address Four', 'providerfour@example.com', '1231231234', 1, 'Active', 'Cedula', 112233445),
(5, 'Provider Five', 'Country Five', 'Department Five', 'City Five', 'Address Five', 'providerfive@example.com', '3213214321', 0, 'Inactive', 'Cedula', 556677889);

SET IDENTITY_INSERT Providers OFF;

SET IDENTITY_INSERT Events ON;

INSERT INTO Events (Id, Title, UserId, Location, EventTypeId, Date, IsPrivate) VALUES
(1, 'Event One', 1, 'Location One', 1, GETDATE(), 0),
(2, 'Event Two', 2, 'Location Two', 2, DATEADD(day, 1, GETDATE()), 1),
(3, 'Event Three', 3, 'Location Three', 1, DATEADD(day, 2, GETDATE()), 0),
(4, 'Event Four', 4, 'Location Four', 2, DATEADD(day, 3, GETDATE()), 1),
(5, 'Event Five', 5, 'Location Five', 1, DATEADD(day, 4, GETDATE()), 0);

SET IDENTITY_INSERT Events OFF
SET IDENTITY_INSERT EventTypes ON;;
INSERT INTO EventTypes (Id, Name) VALUES
(1, 'Conference'),
(2, 'Workshop'),
(3, 'Seminar'),
(4, 'Meetup'),
(5, 'Webinar');

SET IDENTITY_INSERT EventTypes OFF;;

SET IDENTITY_INSERT Services ON;



INSERT INTO Services (Id, ServiceType, Price, Quantity, Description) VALUES
(1, 'Catering', 100.00, '10', 'Catering Service'),
(2, 'Photography', 200.00, '5', 'Photography Service'),
(3, 'Security', 150.00, '8', 'Security Service'),
(4, 'Decoration', 300.00, '12', 'Decoration Service'),
(5, 'Transport', 250.00, '6', 'Transport Service');
SET IDENTITY_INSERT Services OFF;

SET IDENTITY_INSERT Products ON;

INSERT INTO Products (Id, ProductType, Price, Amount, Description) VALUES
(1, 'Chair', 10.00, 100, 'Plastic Chair'),
(2, 'Table', 20.00, 50, 'Wooden Table'),
(3, 'Tent', 150.00, 10, 'Large Tent'),
(4, 'Sound System', 500.00, 5, 'High-Quality Sound System'),
(5, 'Lighting', 200.00, 20, 'LED Lighting'),
(6, 'Projector', 300.00, 7, 'HD Projector'),
(7, 'Microphone', 50.00, 30, 'Wireless Microphone'),
(8, 'Stage', 1000.00, 2, 'Portable Stage'),
(9, 'Banner', 25.00, 40, 'Event Banner'),
(10, 'Speaker', 150.00, 15, 'Bluetooth Speaker'),
(11, 'Podium', 200.00, 3, 'Wooden Podium'),
(12, 'Screen', 400.00, 5, 'Projection Screen'),
(13, 'Laptop', 800.00, 10, 'Event Laptop'),
(14, 'Tablet', 300.00, 20, 'Event Tablet'),
(15, 'Camera', 600.00, 8, 'DSLR Camera'),
(16, 'Tripod', 75.00, 25, 'Camera Tripod'),
(17, 'Backdrop', 150.00, 10, 'Photo Backdrop'),
(18, 'Flower Arrangement', 50.00, 50, 'Event Flower Arrangement'),
(19, 'Tablecloth', 20.00, 100, 'Event Tablecloth'),
(20, 'Chair Cover', 10.00, 100, 'Event Chair Cover'),
(21, 'Cutlery Set', 15.00, 200, 'Event Cutlery Set'),
(22, 'Glassware', 10.00, 150, 'Event Glassware'),
(23, 'Plate Set', 20.00, 150, 'Event Plate Set'),
(24, 'Napkin', 5.00, 300, 'Event Napkin'),
(25, 'Centerpiece', 30.00, 50, 'Event Centerpiece'),
(26, 'Lighting Rig', 500.00, 3, 'Event Lighting Rig'),
(27, 'Sound Mixer', 700.00, 4, 'Event Sound Mixer'),
(28, 'DJ Equipment', 1000.00, 2, 'Event DJ Equipment'),
(29, 'Dance Floor', 1500.00, 1, 'Portable Dance Floor'),
(30, 'Tent Heater', 200.00, 10, 'Event Tent Heater');


SET IDENTITY_INSERT Products OFF;

SET IDENTITY_INSERT Quotes ON;
INSERT INTO Quotes (Id, EventId, ProviderId, Quantity, Total, QuoteDate, QuoteStatus, Notes) VALUES
(1, 1, 1, 10, 1000.00, GETDATE(), 'Pending', 'Initial quote for Event One'),
(2, 2, 2, 5, 500.00, GETDATE(), 'Confirmed', 'Initial quote for Event Two'),
(3, 3, 3, 8, 800.00, GETDATE(), 'Pending', 'Initial quote for Event Three'),
(4, 4, 4, 12, 1200.00, GETDATE(), 'Confirmed', 'Initial quote for Event Four'),
(5, 5, 5, 6, 600.00, GETDATE(), 'Pending', 'Initial quote for Event Five');

SET IDENTITY_INSERT Quotes OFF;


INSERT INTO ProductQuotes (QuoteId, ProductId, Amount, UnitPrice) VALUES
(1, 1, 10, 500),
(2, 2, 5, 600),
(3, 3, 8, 700),
(4, 4, 12, 900),
(5, 5, 6, 2000);


INSERT INTO ServiceQuotes (QuoteId, ServiceId, Quantity, UnitPrice) VALUES
(1, 1, 10, 800),
(2, 2, 5, 15000),
(3, 3, 8, 450000),
(4, 4, 12, 90000),
(5, 5, 6, 250000);


SET IDENTITY_INSERT Guests ON;
INSERT INTO Guests (Id, Name, GuestStatus, Email) VALUES
(1, 'Guest One', 'ACTIVO', 'guestone@example.com'),
(2, 'Guest Two', 'INACTIVO', 'guesttwo@example.com'),
(3, 'Guest Three','ACTIVO', 'guestthree@example.com'),
(4, 'Guest Four', 'INACTIVO', 'guestfour@example.com'),
(5, 'Guest Five', 'ACTIVO', 'guestfive@example.com');
SET IDENTITY_INSERT Guests OFF;


INSERT INTO GuestEvents (EventId, GuestId) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);



SET IDENTITY_INSERT Invitations ON;
INSERT INTO Invitations (Id, EventId, GuestId, SendDate, InvitationStatus) VALUES
(1, 1, 1, GETDATE(), 1),
(2, 2, 2, DATEADD(day, 1, GETDATE()), 0),
(3, 3, 3, DATEADD(day, 2, GETDATE()), 1),
(4, 4, 4, DATEADD(day, 3, GETDATE()), 0),
(5, 5, 5, DATEADD(day, 4, GETDATE()), 1);
SET IDENTITY_INSERT Invitations OFF;


INSERT INTO ProductProviders (ProviderId, ProductId) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);



INSERT INTO ServiceProviders (ProviderId, ServiceId) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);
