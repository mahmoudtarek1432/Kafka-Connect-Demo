using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.DATA
{
    class DatabaseQueries
    {
        public const string CreateDB = "CREATE DATABASE CDC;";
        public const string CreateTable = 
                                               " CREATE TABLE Source(" +
                                               "   Id SERIAL PRIMARY KEY," +
                                               "  Name VARCHAR(100) NULL," +
                                               "  Description VARCHAR(100) NULL" +
                                                ");";
        public const string InsertData = "INSERT INTO Source ( Name, Description) VALUES ( @Name, @Description)";
        public const string DeleteData = "DELETE FROM Source WHERE id in (select top(1) id from dbo.source)";
        public const string QueryData = "SELECT * FROM Source"; 
    }
}
