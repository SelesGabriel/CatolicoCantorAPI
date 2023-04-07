using CatolicoCantorAPI.Interfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;


namespace CatolicoCantorAPI.Data
{
    public class DatabaseBootstrap:IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Category';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Category")
                return;

            connection.Execute("Create Table Category (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(1000) NOT NULL);");
        }
    }
}
