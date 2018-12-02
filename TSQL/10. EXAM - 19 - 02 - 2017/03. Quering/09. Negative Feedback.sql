-- *** ----------------------------------------------------------------------------------

USE Bakery;

-- *** ----------------------------------------------------------------------------------

SELECT f.[ProductId], 
	   f.[Rate], 
	   f.[Description],
	   f.[CustomerId],
	   c.[Age],
	   c.[Gender]
FROM Feedbacks AS f
LEFT JOIN Customers AS c ON c.Id = f.CustomerId
WHERE [Rate] < 5
ORDER BY f.[ProductId] DESC, f.[Rate]

-- *** ----------------------------------------------------------------------------------
