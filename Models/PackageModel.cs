using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.DB;

namespace Models.PackageModel
{
    public class PackageModel
    {
        public int id_interno { get; set; }
        public string id_externo { get; set; }
        public int id_cliente { get; set; }
        public double peso { get; set; }
        public string dir_envio { get; set; }
        public string estado { get; set; }

        MySqlConnection connection;

        public PackageModel()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public PackageModel(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado): this()
        {
            this.id_interno = id_interno;
            this.id_externo = id_externo;
            this.id_cliente = id_cliente;
            this.peso = peso;
            this.dir_envio = dir_envio;
            this.estado = estado;
        }

        public List<PackageModel> GetAll()
        {
            List<PackageModel> data = new List<PackageModel>();

            try
            {
                string sql = "SELECT * FROM paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_interno = reader.GetInt32(0);
                            string id_externo = reader.GetString(1);
                            int id_cliente = reader.GetInt32(2);
                            double peso = reader.GetDouble(3);
                            string dir_envio = reader.GetString(4);
                            string estado = reader.GetString(5);
                            PackageModel package = new PackageModel(id_interno, id_externo, id_cliente, peso, dir_envio, estado);
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

        public int Create(string id_externo, int id_cliente, double peso, string dir_envio, string estado)
        {
            try
            {
                string sql = "INSERT INTO paquete(id_externo, id_cliente, peso, dir_envio, estado) VALUES(@id_externo, @id_cliente, @peso, @dir_envio, @estado); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_externo", id_externo);
                    command.Parameters.AddWithValue("@id_cliente", id_cliente);
                    command.Parameters.AddWithValue("@peso", peso);
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

        public bool Edit(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado)
        {
            try
            {
                string sql = "UPDATE paquete SET id_externo = @id_externo, id_cliente = @id_cliente, peso = @peso, dir_envio = @dir_envio, estado = @estado  WHERE id_interno = @id_interno";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_interno", id_interno);
                    command.Parameters.AddWithValue("@id_externo", id_externo);
                    command.Parameters.AddWithValue("@id_cliente", id_cliente);
                    command.Parameters.AddWithValue("@peso", peso);
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
        public bool Delete(int id_interno)
        {
            try
            {
                string sql = "DELETE FROM paquete WHERE id_interno = @id_interno";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_interno", id_interno);

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
