using System;
using System.Collections.Generic;
using WindowsFormsApp1.Models;
using MySqlConnector;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1.Controllers.PackageLotController
{
    class PackageLotController
    {
        MySqlConnection connection;
        public PackageLotController()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public PackageLotModel GetOneByPackageId(int id_interno_paquete)
        {
            PackageLotModel data = new PackageLotModel(0, 0, 0, "");

            try
            {
                string sql = "SELECT * FROM PaqueteLote WHERE id_interno_paquete = @id_interno_paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_interno_paquete", id_interno_paquete);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_lote = reader.GetInt32(1);
                            int id_usuario = reader.GetInt32(2);
                            DateTime fecha_hora = reader.GetDateTime(3);
                            data.id_interno_paquete = id_interno_paquete;
                            data.id_lote = id_lote;
                            data.id_usuario = id_usuario;
                            data.fecha_hora = fecha_hora.ToString();
                        }
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                return data;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<PackageLotModel> GetAllByLotId(int id_lote)
        {
            List<PackageLotModel> data = new List<PackageLotModel>();

            try
            {
                string sql = "SELECT * FROM PaqueteLote WHERE id_lote = @id_lote";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_lote", id_lote);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_interno_paquete = reader.GetInt32(0);
                            int id_usuario = reader.GetInt32(2);
                            System.DateTime fecha_hora = reader.GetDateTime(3);
                            PackageLotModel packageLot = new PackageLotModel(id_interno_paquete, id_lote, id_usuario, fecha_hora.ToString());
                            data.Add(packageLot);
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

        public int Create(int id_interno_paquete, int id_lote, int id_usuario = 3)
        {
            try
            {
                string sql = "INSERT INTO PaqueteLote(id_interno_paquete, id_lote, id_usuario) VALUES(@id_interno_paquete, @id_lote, @id_usuario); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_interno_paquete", id_interno_paquete);
                    command.Parameters.AddWithValue("@id_lote", id_lote);
                    command.Parameters.AddWithValue("@id_usuario", id_usuario);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Paquete agregado exitosamente a lote con ID: {id_lote}");
                    return id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Edit(int id_interno_paquete, int id_lote, int id_usuario, System.DateTime fecha_hora)
        {
            try
            {
                string sql = "UPDATE PaqueteLote SET id_lote = @id_lote, id_usuario = @id_usuario, fecha_hora = @fecha_hora WHERE id_interno_paquete = @id_interno_paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_interno_paquete", id_interno_paquete);
                    command.Parameters.AddWithValue("@id_lote", id_lote);
                    command.Parameters.AddWithValue("@id_usuario", id_usuario);
                    command.Parameters.AddWithValue("@fecha_hora", fecha_hora);

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
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Delete(int id_interno_paquete)
        {
            try
            {
                string sql = "DELETE FROM PaqueteLote WHERE id_interno_paquete = @id_interno_paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_interno_paquete", id_interno_paquete);

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
