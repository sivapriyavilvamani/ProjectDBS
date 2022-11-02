create database DBS_service
use DBS_service
go

create table ERegistration
( ExecID int identity(1,1),
ExecName varchar(30),
Age int,
Designation varchar(50),
Department varchar(50),
Experience int,
Phone bigint,
Password varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
emailID varchar(100),
PRIMARY KEY (ExecId),
)

insert into ERegistration values('Dhanmayii',25,'DataAnalyst','IT',5,9638527410,'Dhan@123','Dhang@gmail.com')
select * from ERegistration






create table CRegistration
( CustID int identity(1,1),
FirstName varchar(30),
LastName varchar(30),
Age int,
Address varchar(100),
Phone bigint,
Password varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
emailID varchar(100),
PRIMARY KEY (CustId),
)
insert into CRegistration values('Lithesh','Adithya',26,'No 5,Gurusamy Nagar,Sembakkam',9638527410,'Lith@123','Lith@gmail.com')
select * from CRegistration



create table Booking
(
OrderID int identity(1,1),
CustID int,
ExecID int,
Source varchar(50),
Destination varchar(50),
DelivaryDate DATE,
PicKupTime dateTime,
Weight float,
Price float,
PRIMARY KEY (OrderID),
)

select * from Booking
insert into Booking values (1,1,'T.Nagar','Adayar','2/11/2022','15:20',7,200,1)

alter table Booking add PriceID int


create table Pricechart
(
PriceID int identity(1,1),
WeightInKg varchar(30),
PriceKg float,
DistanceInKm varchar(30),
PriceKm float,
PRIMARY KEY (PriceID),
)

insert into Pricechart values('8-12',100,'10-25',200)
select * from Pricechart

create table History
(
CancelationID int identity(1,1),
CustID int,
ExecID int,
Source varchar(50),
Destination varchar(50),
DelivaryDate DATE,
PicKupTime dateTime,
Weight float,
Price float,
PRIMARY KEY (CancelationID),
)
insert into Booking values (1,1,'T.Nagar','Adayar','2/11/2022','15:20',7,200,1)