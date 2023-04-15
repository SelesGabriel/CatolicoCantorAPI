using CatolicoCantorAPI.Interfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System.Linq;


namespace CatolicoCantorAPI.Data
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new MySqlConnection(databaseConfig.Name);

            var category = connection.Query<string>("SELECT table_name FROM information_schema.tables where table_name = 'Category';");
            var music = connection.Query<string>("SELECT table_name FROM information_schema.tables where table_name = 'Music';");
            var playlist = connection.Query<string>("SELECT table_name FROM information_schema.tables where table_name = 'Playlist';");

            var musicPlaylist  = connection.Query<string>("SELECT table_name FROM information_schema.tables where table_name = 'musicPLaylist';");
            var musicCategory = connection.Query<string>("SELECT table_name FROM information_schema.tables where table_name = 'musicCategory';"); 

            if (string.IsNullOrEmpty(category.FirstOrDefault()))
                connection.Execute(@"Create Table Category (Id INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL, Nome VARCHAR(100) NOT NULL);");

            if (string.IsNullOrEmpty(music.FirstOrDefault()))
                connection.Execute(@"Create Table Music (Id INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL
                                    ,Nome VARCHAR(100) NOT NULL
                                    ,Cantor VARCHAR(100) NOT NULL
                                    ,Letra VARCHAR(100) NULL
                                    ,Cifra VARCHAR(100) NULL
                                    ,Youtube VARCHAR(100) NOT NULL
                                    ,Tags VARCHAR(1000) NOT NULL
                                    );");

            if (string.IsNullOrEmpty(playlist.FirstOrDefault()))
                connection.Execute(@"Create Table Playlist (Id INTEGER PRIMARY KEY AUTO_INCREMENT NOT NULL
                                    ,Nome VARCHAR(1000) NOT NULL
                                    ,IdUsuario INTEGER NULL
                                    ,Publica BOOLEAN
                                    ,DataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                    );");


        }
    }
}
