SELECT ProductName, CategoryName
FROM Products LEFT OUTER JOIN Categories
ON Products.Id = Categories.Id
