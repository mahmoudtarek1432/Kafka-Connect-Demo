// See https://aka.ms/new-console-template for more information
using Dapper;
using Npgsql;
using Producer.DATA;
using System.Data.Common;
using System.Data.SqlTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=postgres;Username=docker;Password=docker"))
{
    connection.Open();
    try
    {
        connection.Execute(DatabaseQueries.CreateDB);
        connection.Execute(DatabaseQueries.CreateTable);
    }
    catch { }


    while (true)
    {
        Console.WriteLine("Database and table created successfully");
        Console.WriteLine("1. Insert data");
        Console.WriteLine("2. Delete data");
        Console.WriteLine("3. Query data");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                connection.Execute(DatabaseQueries.InsertData, new Source { Name = "Source1", Description = "Description1" });
                break;
            case "2":
                connection.Execute(DatabaseQueries.DeleteData);
                break;
            case "3":
                connection.Query<Source>(DatabaseQueries.QueryData).ToList().ForEach(x => Console.WriteLine($"Id: {x.Id}, Name: {x.Name}, Description: {x.Description}"));
                break;
        }
        Console.ReadLine();
        Console.Clear();
    }
}