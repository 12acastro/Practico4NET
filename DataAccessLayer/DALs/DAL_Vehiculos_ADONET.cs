
using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.DALs
{
    public class DAL_Vehiculos_ADONET : IDAL_Vehiculos
    {
        private string connectionString; // Reemplaza con tu cadena de conexión a la base de datos

        public DAL_Vehiculos_ADONET(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Delete(string matricula)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Vehiculos WHERE Matricula = @Matricula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Matricula", matricula);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Vehiculo> Get()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Vehiculos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehiculo vehiculo = new Vehiculo
                            {

                                Marca = reader["Marca"].ToString(),
                                Modelo = reader["Modelo"].ToString(),
                                Matricula = reader["Matricula"].ToString(),
                            };
                            vehiculos.Add(vehiculo);
                        }
                    }
                }
            }

            return vehiculos;
        }

        public Vehiculo Get(string matricula)
        {
            Vehiculo vehiculo = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Vehiculos WHERE Matricula = @Matricula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Matricula", matricula);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            vehiculo = new Vehiculo
                            {
                                Marca = reader["Marca"].ToString(),
                                Modelo = reader["Modelo"].ToString(),
                                Matricula = reader["Matricula"].ToString(),

                            };
                        }
                    }
                }
            }

            return vehiculo;
        }

        public void Insert(Vehiculo vehiculo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES (@Marca, @Modelo, @Matricula, @PersonaId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                    command.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                    command.Parameters.AddWithValue("@Matricula", vehiculo.Matricula);


                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Vehiculo vehiculo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Vehiculos SET Marca = @Marca, Modelo = @Modelo, PersonaId = @PersonaId WHERE Matricula = @Matricula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                    command.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);

                    command.Parameters.AddWithValue("@Matricula", vehiculo.Matricula);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}