create table Products 
(
    Id serial primary key,
    Name varchar(50),
    Quantity int,
    StockId int references Stocks(Id)
);

insert into Products(Name,Quantity,StockId)
			  values('IPoone 15 pro max',170,2),
			  		('IPoone 15 pro',170,2),
					('IPoone 14 pro max',140,2),
			  		('IPoone 14 pro',120,2),
					('IPoone 13 pro max',100,2),
			  		('IPoone 13 pro',80,2),
					('IPoone 12 pro max',70,2),
			  		('IPoone 12 pro',50,2),
					('IPoone 11 pro max',50,2),
			  		('IPoone 11 pro',40,2),
					('IPoone XS max',35,2),
			  		('IPoone X',30,2),
					('IPoone 15 pro max',170,3),
			  		('IPoone 15 pro',170,3),
					('IPoone 14 pro max',140,3),
			  		('IPoone 14 pro',120,3),
					('IPoone 13 pro max',100,3),
			  		('IPoone 13 pro',80,3),
					('IPoone 12 pro max',70,3),
			  		('IPoone 12 pro',50,3),
					('IPoone 11 pro max',50,3),
			  		('IPoone 11 pro',40,3),
					('IPoone XS max',35,3),
			  		('IPoone X',30,3),
					('IPoone 15 pro max',170,4),
			  		('IPoone 15 pro',170,4),
					('IPoone 14 pro max',140,4),
			  		('IPoone 14 pro',120,4),
					('IPoone 13 pro max',100,4),
			  		('IPoone 13 pro',80,4),
					('IPoone 12 pro max',70,4),
			  		('IPoone 12 pro',50,4),
					('IPoone 11 pro max',50,4),
			  		('IPoone 11 pro',40,4),
					('IPoone XS max',35,4),
			  		('IPoone X',30,4)



update Products set Quantity = Quantity - 10, StockId = @stockId where Id = 1 and StockId = 1


update Products set Quantity = Quantity + 10 where StockId = 1 limit(1)

select * from Products
order by id

create table Stocks 
(
    Id serial primary key,
    Name varchar(50),
    Address varchar(100)
);

insert into Stocks(Name,Address)values('StockDushanbe','Dushanbe'),
									  ('StockBokhtar','Bokhtar'),
									  ('StockKhujand','Khujand'),
									  ('StockPomir','Pomir')

create table Movements (
    Id serial  primary key,
    ProductID int references Products(Id),
    FromStock int references Stocks(Id),
    Tostock int references Stocks(Id),
    Quantity int,
    MovementDate date
);
