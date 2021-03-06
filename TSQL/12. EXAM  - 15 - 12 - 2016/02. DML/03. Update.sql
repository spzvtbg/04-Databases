/*   CONDITIONS   

	The back-end developers have slightly failed and let some chats to have messages with a date,
    earlier than the creation date of the chat. You have to fix that. 

	For all chats which have messages before the chat StartDate update the chat StartDate 
	to be equal to the earliest message in that chat.

*/
USE TheNerdHerd;


--UPDATE Chats 
--SET StartDate 

UPDATE Chats
SET StartDate =
(
  SELECT MIN(m.SentOn) FROM Chats AS c
  JOIN Messages AS m ON m.ChatId = c.Id
  WHERE c.Id = Chats.Id
)
WHERE Chats.Id IN
(
  SELECT c.Id FROM Chats AS c
  JOIN Messages AS m ON m.ChatId = c.Id
  GROUP BY c.Id, c.StartDate
  HAVING c.StartDate > MIN(m.SentOn)
);