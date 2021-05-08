RESTORE DATABASE [PremierServiceSolutionsDatabase] FROM DISK = '/tmp/PremierServiceSolutionsDatabase.bak'
WITH FILE = 1,
MOVE 'PremierServiceSolutionsDatabase' TO '/var/opt/mssql/data/PremierServiceSolutionsDatabase.mdf',
MOVE 'PremierServiceSolutionsDatabase_log' TO '/var/opt/mssql/data/PremierServiceSolutionsDatabase.ldf',
NOUNLOAD, REPLACE, STATS = 5
GO