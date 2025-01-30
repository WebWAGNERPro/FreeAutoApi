using System;
using MySql.Data.MySqlClient; // Utilisation de MySQL.Data
using DotNetEnv; // Importer DotNetEnv

namespace FreeAutoApi.Config
{
    public static class Common
    {
        static Common()
        {
            Env.Load(); // Charger le fichier .env
        }

        public static string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("La chaîne de connexion est manquante dans les variables d'environnement.");
            }
            return connectionString;
        }

        public static MySqlConnection CreateConnection()
        {
            try
            {
                string connectionString = GetConnectionString();
                return new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la création de la connexion à la base de données.", ex);
            }
        }
    }
}
