using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.DATA
{
    class DatabaseQueries
    {
        public const string CreateDB = "CREATE DATABASE IF NOT EXISTS CDC;";
        public const string CreateTable = "IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Source' AND TABLE_SCHEMA = 'dbo')" +
                                            "BEGIN" +
                                               " CREATE TABLE dbo.Source(" +
                                               "   Id INT PRIMARY KEY," +
                                               "  Name NVARCHAR(100) NULL" +
                                               "  Description NVARCHAR(100) NULL" +
                                                ");" +
                                            "END";
        public const string InsertData = "INSERT INTO dbo.Source (Id, Name, Description) VALUES (@Id, @Name, @Description)";
        public const string DeleteData = "DELETE FROM dbo.Source WHERE id in (select top(1) id from dbo.source)";
        public const string QueryData = "SELECT * FROM dbo.Source"; 
    }
}
