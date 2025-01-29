using System;
using MySql.Data.MySqlClient; // Utilisation de MySQL.Data
using DotNetEnv; // Importer DotNetEnv

namespace FreeAutoApi.Config
{
    public class Common
    {
        public Common()
        {
            Env.Load(); // Charger le fichier .env
        }

        public string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("La chaîne de connexion est manquante dans les variables d'environnement.");
            }

            Console.WriteLine($"Chaîne de connexion utilisée : {connectionString}"); // Affichage pour le debug
            return connectionString;
        }

        public MySqlConnection CreateConnection()
        {
            try
            {
                string connectionString = GetConnectionString();
                return new MySqlConnection(connectionString); // Crée une connexion MySQL
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la création de la connexion à la base de données.", ex);
            }
        }
    }
}
