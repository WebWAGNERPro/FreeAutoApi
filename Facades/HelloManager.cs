using FreeAutoApi.Config;
using System.Collections.Generic;
using MySql.Data.MySqlClient; // Utilisation de MySQL.Data
using System.Threading.Tasks;

namespace FreeAutoApi.Facades
{
    public class HelloManager
    {
        private readonly Common _common;

        public HelloManager(Common common)
        {
            _common = common;
        }

        public async Task<List<string>> GetHelloMessagesAsync()
        {
            using (MySqlConnection connection = _common.CreateConnection()) // Utilisation de MySqlConnection
            {
                await connection.OpenAsync();

                // Effectuer une simple requête pour tester la connexion
                string query = "SELECT 'Connexion réussie' AS Message";
                var cmd = new MySqlCommand(query, connection);
                var result = await cmd.ExecuteScalarAsync();

                return new List<string> { result.ToString() }; // Retourner le message de la connexion
            }
        }
    }
}
