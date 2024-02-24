create table Car 
(
	CarId int primary key identity(1,1),
	Manufacturer nvarchar(20),
	Model nvarchar(20),
	LicensePlate nvarchar(20),
	Year int,
	Available bit
)

create table Customer
(
	CustomerId int primary key identity(1,1),
	Name nvarchar(20),
	DriverLicNo nvarchar(20)
)

create table Rental
(
	RentalId int primary key identity(1,1),
	CustomerId int foreign key references Customer(CustomerId),
	CarId int foreign key references Car(CarId),
	DateRented date,
	DateReturned date
)
