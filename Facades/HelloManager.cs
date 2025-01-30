using System.Data;
using MySql.Data.MySqlClient;
using FreeAutoApi.Config;

namespace FreeAutoApi.Facades
{
    public class HelloManager
    {
        public static DataTable GetHelloMessages()
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = Common.CreateConnection())
            {
                connection.Open();
                string query = "SELECT * FROM test";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }
    }
}
