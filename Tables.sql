create table Product
(
	Id int primary key,
	Name nvarchar(200)
)

create table Category
(
	Id int primary key,
	Name nvarchar(100)
)

create table ProductCategory
(
	ProductId int foreign key references dbo.Product(Id),
	CategoryId int foreign key references dbo.Category(Id)
)

insert into dbo.Product(Id, Name) values (1, 'P1'), (2, 'P2'), (3, 'P3')
insert into dbo.Category(Id, Name) values (1, 'C1'), (2, 'C2'), (3, 'C3')
insert into dbo.ProductCategory(ProductId, CategoryId) values (1,1), (2,2), (1,2)
