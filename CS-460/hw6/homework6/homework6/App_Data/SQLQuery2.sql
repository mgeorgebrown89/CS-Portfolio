RESTORE DATABASE AdventureWorks2014  
FROM DISK = 'C:\Users\Michael\Documents\CS Portfolio\CS 460\hw6\AdventureWorks2014.bak'  
WITH MOVE 'AdventureWorks2014_Data' TO 'C:\Users\Michael\Documents\CS Portfolio\CS 460\hw6\AdventureWorks2014_Data.mdf',  
MOVE 'AdventureWorks2014_Log' TO 'C:\Users\Michael\Documents\CS Portfolio\CS 460\hw6\AdventureWorks2014_Log.ldf' 