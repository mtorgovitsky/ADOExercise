use Northwind

--Procedure for Annual Report
go
create proc GetAnnualReport as
select
	year(O.OrderDate),
	count(distinct OD.OrderID) 'Number of Orders',
	sum(OD.Quantity * OD.UnitPrice) 'Total Cost'
from
	Orders O,
	[Order Details] OD
where
	O.OrderID = OD.OrderID
group by
	year(O.OrderDate)
order by
	year(O.OrderDate)
go

--Procedure for Year deriviation
go
create proc GetCurrentYear(@currYear int) as
select
	OD.OrderID,
	cast(O.OrderDate as date) 'Order Date',
	C.ContactName,
	E.FirstName + ' ' + E.LastName 'Employee Name',
	sum(OD.Quantity * OD.UnitPrice) 'Total Price'
from
	Orders O,
	[Order Details] OD,
	Customers C,
	Employees E
where
	O.OrderID = OD.OrderID
	and E.EmployeeID = O.EmployeeID
	and C.CustomerID = O.CustomerID
	and year(O.OrderDate) = @currYear
group by
	OD.OrderID,
	cast(O.OrderDate as date),
	C.ContactName,
	E.FirstName + ' ' + E.LastName
go

--Order Items Procedure
go
create proc GetOrderItems(@OrderID int) as
select
	P.ProductID,
	P.ProductName,
	OD.UnitPrice,
	OD.Quantity,
	OD.UnitPrice * OD.Quantity 'Line Total'
from
	[Order Details] OD,
	Products P
where
	P.ProductID = OD.ProductID
	and OD.OrderID = @OrderID
order by
	P.ProductID
go


--Form Here it is for Update Products Form
go
create proc GetProducts as
select *
from Products
order by ProductName
go

go
create proc GetProductByID(@ProductID int) as
select
	ProductID,
	ProductName,
	SupplierID,
	CategoryID,
	QuantityPerUnit,
	UnitPrice,
	UnitsInStock,
	UnitsOnOrder,
	ReorderLevel
from
	Products
where ProductID = @ProductID
go

go
create proc GetProductByName(@ProductName nvarchar(40)) as
select
	ProductID,
	ProductName,
	SupplierID,
	CategoryID,
	QuantityPerUnit,
	UnitPrice,
	UnitsInStock,
	UnitsOnOrder,
	ReorderLevel
from
	Products
where ProductName = @ProductName
go

go
create proc GetSupplierIDBySupplierName(@ContactName nvarchar(30)) as
select
	SupplierID,
	ContactName
from
	Suppliers
where
	ContactName = @ContactName
go


go
create proc GetSupplierNameBySupplierID(@SupplierID int) as
select
	SupplierID,
	ContactName
from
	Suppliers
where
	SupplierID = @SupplierID
go

go
create proc GetSuppliers as
select
	SupplierID,
	ContactName
from
	Suppliers
order by
	ContactName
go

go
create proc GetCategories as
select
	CategoryID,
	CategoryName
from
	Categories
order by
	CategoryName
go