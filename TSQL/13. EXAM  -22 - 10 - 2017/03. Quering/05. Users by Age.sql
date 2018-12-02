/*   CONDITIONS   

	Select all Usernames with their age ordered by age (ascending) then by username (descending). 
	Required columns:
	?	Username
	?	Age
	

*/
USE ReportService;

SELECT Username, Age FROM Users
ORDER BY Age, Username DESC

