using System;
using Microsoft.Data.SqlClient;

namespace Projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=BaltaPopulado;User ID=sa;Password=;TrustServerCertificate=True";
            // Microsoft.Data.SqlClient

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader(); // Retorna registros
                                                          //command.ExecuteNonReader(); Retorna quantidade de linhas afetadas
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }
        }
    }

}
