using System;
using System.Collections.Generic;
using WindowsFormsApp1.Models;
using MySqlConnector;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1.Controllers.PackageController
{
    class PackageController
    {
        MySqlConnection connection;
        public PackageController()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public List<PackageModel> GetAll()
        {
            List<PackageModel> data = new List<PackageModel>();

            try
            {
                string sql = "SELECT * FROM Paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_interno = reader.GetInt32(0);
                            string id_externo = reader.GetString(1);
                            int id_almacen = reader.GetInt32(2);
                            double peso = reader.GetDouble(3);
                            string descripcion = reader.GetString(4);
                            string dir_envio = reader.GetString(5);
                            string estado = reader.GetString(6);
                            PackageModel package = new PackageModel(id_interno, id_externo, id_almacen, peso, descripcion, dir_envio, estado);
                            data.Add(package);
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

        public int Create(string id_externo, int id_almacen, double peso, string descripcion, string dir_envio, string estado)
        {
            try
            {
                string sql = "INSERT INTO Paquete(id_externo, id_almacen, peso, descripcion, dir_envio, estado) VALUES(@id_externo, @id_almacen, @peso, @descripcion, @dir_envio, @estado); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_externo", id_externo);
                    command.Parameters.AddWithValue("@id_almacen", id_almacen);
                    command.Parameters.AddWithValue("@peso", peso);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@dir_envio", dir_envio);
                    command.Parameters.AddWithValue("@estado", estado);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Usuario agregado exitosamente con ID: {id}");
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

        public bool Edit(int id_interno, string id_externo, int id_almacen, double peso, string descripcion, string dir_envio, string estado)
        {
            try
            {
                string sql = "UPDATE Paquete SET id_externo = @id_externo, id_almacen = @id_almacen, peso = @peso, descripcion = @descripcion, dir_envio = @dir_envio, estado = @estado  WHERE id_interno = @id_interno";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_interno", id_interno);
                    command.Parameters.AddWithValue("@id_externo", id_externo);
                    command.Parameters.AddWithValue("@id_almacen", id_almacen);
                    command.Parameters.AddWithValue("@peso", peso);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@dir_envio", dir_envio);
                    command.Parameters.AddWithValue("@estado", estado);

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
    }
}
