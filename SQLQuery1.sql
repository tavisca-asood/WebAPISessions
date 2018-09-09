create Database ProductsDatabase
use ProductsDatabase

create table AirProducts(ID int identity(1,1),Name varchar(50), Price float, Departure date,Arrival date, Booked bit NOT NULL,PRIMARY KEY (ID))
create table ActivityProducts(ID int identity(1,1),Name varchar(50), Price float, StartTime time, Booked bit NOT NULL,PRIMARY KEY (ID))
create table HotelProducts(ID int identity(1,1),Name varchar(50), Address varchar(100),Rating float, Price float, Booked bit NOT NULL,PRIMARY KEY (ID))
create table CarProducts(ID int identity(1,1),Name varchar(50), Price float, Booked bit NOT NULL,PRIMARY KEY (ID))

insert into AirProducts values('Air India', 5000, '2018-09-07', '2018-09-08',0)
insert into AirProducts values('Jet Airways',5500, '2018-09-08', '2018-09-08', 0)
insert into AirProducts values('Emirates',6000, '2018-09-10', '2018-09-11', 0)
insert into AirProducts values('Air Asia',6500, '2018-09-08', '2018-09-09', 0)
insert into AirProducts values('Vistara',8000, '2018-09-11', '2018-09-12', 0)

insert into CarProducts values('Phantom',450000,0)
insert into CarProducts values('Aventador',393695,0)
insert into CarProducts values('M5',104000,0)
insert into CarProducts values('911',100000,0)
insert into CarProducts values('AMG',300000,0)

insert into ActivityProducts values('Movie',300,'17:00:00',0)
insert into ActivityProducts values('Theatre',500,'21:00:00',0)
insert into ActivityProducts values('StandUp',1000,'15:00:00',0)
insert into ActivityProducts values('ThemePark',700,'11:00:00',0)
insert into ActivityProducts values('Party',1500,'23:00:00',0)

insert into HotelProducts values('Hyatt Regency','Viman Nagar',4.8,10000,0)
insert into HotelProducts values('Novotel','Nagar Road',4.5,8000,0)
insert into HotelProducts values('IBIS','Kharadi',4.2,5000,0)
insert into HotelProducts values('The Taj','Amanaora',4.9,12000,0)
insert into HotelProducts values('Trident','Vadgaon',4.7,11000,0)

alter table ActivityProducts Add Saved bit NOT NULL DEFAULT(0)
alter table AirProducts Add Saved bit NOT NULL DEFAULT(0)
alter table CarProducts Add Saved bit NOT NULL DEFAULT(0)
alter table HotelProducts Add Saved bit NOT NULL DEFAULT(0)


--select * from AirProducts
--select * from ActivityProducts
--select * from CarProducts
--select * from HotelProducts

--USE master;  
--GO  
--ALTER DATABASE ProductsDatabase  
--Modify Name = InventoryDatabase ;  
--GO  