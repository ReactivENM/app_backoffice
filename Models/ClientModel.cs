using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.DB;

namespace Models.ClientModel
{
    public class ClientModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public string telefono { get; set; }

        MySqlConnection connection;

        public ClientModel()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public ClientModel(int id, string nombre, string calle, string telefono): this()
        {
            this.id = id;
            this.nombre = nombre;
            this.calle = calle;
            this.telefono = telefono;
        }

        public List<ClientModel> GetAll()
        {
            List<ClientModel> data = new List<ClientModel>();

            try
            {
                string sql = "SELECT * FROM Cliente";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            string calle = reader.GetString(2);
                            string telefono = reader.GetString(3);
                            ClientModel client = new ClientModel(id, nombre, calle, telefono);
                            data.Add(client);
                        }
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return data;
            }
            finally
            {
                connection.Close();
            }
        }

        public int Create(string nombre, string calle, string telefono)
        {
            try
            {
                string sql = "INSERT INTO Cliente(nombre, calle, telefono) VALUES(@nombre, @calle, @telefono); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@calle", calle);
                    command.Parameters.AddWithValue("@telefono", telefono);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Cliente agregado exitosamente con ID: {id}");
                    return id;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Edit(int id, string nombre, string calle, string telefono)
        {
            try
            {
                string sql = "UPDATE Cliente SET nombre = @nombre, calle = @calle, telefono = @telefono WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@calle", calle);
                    command.Parameters.AddWithValue("@telefono", telefono);

                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Cliente WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
