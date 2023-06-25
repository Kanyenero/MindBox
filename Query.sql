SELECT 
	p.Name,
	c.Name
FROM 
	dbo.Product AS p
	LEFT OUTER JOIN dbo.ProductCategory AS pc ON p.Id = pc.ProductId
	LEFT OUTER JOIN dbo.Category AS c ON c.Id = pc.CategoryId
