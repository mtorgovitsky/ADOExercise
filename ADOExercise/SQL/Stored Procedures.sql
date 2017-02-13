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

--Gets all current Products
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

--Find Product by Name
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

--Find Supplier ID by Supplier Name
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


--Find Supplier Name by Supplier ID
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

--Get All suppliers
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

--Get all Categories
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

--Update Given Product
go
create proc UpdateProduct(
	@productName nvarchar(40),
	@supplierID int,
	@categoryID int,
	@quantityPerUnit nvarchar(20),
	@unitPrice money,
	@unitsInStock int,
	@unitsOnOrder int,
	@reorderLevel int)as
update Products
set SupplierID = @supplierID,
	CategoryID = @categoryID,
	QuantityPerUnit = @quantityPerUnit,
	UnitPrice = @unitPrice,
	UnitsInStock = @unitsInStock,
	UnitsOnOrder = @unitsOnOrder,
	ReorderLevel = @reorderLevel
where ProductName = @productName
go
