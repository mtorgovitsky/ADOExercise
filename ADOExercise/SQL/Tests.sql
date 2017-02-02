use Northwind
--Annual Report Query
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

--Check Functionality of GetAnnualReport
exec GetAnnualReport


--Orders Table Query
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
	and year(O.OrderDate) = 1998
group by
	OD.OrderID,
	cast(O.OrderDate as date),
	C.ContactName,
	E.FirstName + ' ' + E.LastName

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


--Check Functionality of GetCurrentYear
exec GetCurrentYear 1997

--Order Items
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
	--and OD.OrderID = 10252
order by
	P.ProductID

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

--Check Functionality of GetOrderItems
exec GetOrderItems 10253


--For Product Update Form
use Northwind

go
create proc GetAllSuppliersAndCategories as
select
	SupplierID,
	CategoryID
from
	Products
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
create proc FetAllProducts as
select *
from Products
go

select count(ProductID)from Products

select *
from Products