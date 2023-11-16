using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.DB;

namespace Models.TruckLotModel
{
    public class TruckLotModel
    {
        public int id { get; set; }
        public int id_camion { get; set; }
        public int id_lote { get; set; }

        MySqlConnection connection;

        public TruckLotModel()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public TruckLotModel(int id, int id_camion, int id_lote): this()
        {
            this.id = id;
            this.id_camion = id_camion;
            this.id_lote = id_lote;
        }

        /* public TruckLotModel GetOneByTruckId(int id_interno_paquete)
        {
            TruckLotModel data = new TruckLotModel(0, 0, 0, "");

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
        } */

        public List<TruckLotModel> GetAllByTruckId(int id_camion)
        {
            List<TruckLotModel> data = new List<TruckLotModel>();

            try
            {
                string sql = "SELECT * FROM camionlote WHERE id_camion = @id_camion";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_camion", id_camion);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int id_lote = reader.GetInt32(2);
                            TruckLotModel truckLot = new TruckLotModel(id, id_camion, id_lote);
                            data.Add(truckLot);
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

        public int Create(int id_camion, int id_lote)
        {
            try
            {
                string sql = "INSERT INTO camionlote(id_camion, id_lote) VALUES@id_camion, @id_lote); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_camion", id_camion);
                    command.Parameters.AddWithValue("@id_lote", id_lote);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Lote agregado exitosamente a camion con ID: {id_camion}");
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

        public bool Edit(int id, int id_camion, int id_lote)
        {
            try
            {
                string sql = "UPDATE camionlote SET id_camion = @id_camion, id_lote = @id_lote WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@id_camion", id_camion);
                    command.Parameters.AddWithValue("@id_lote", id_lote);

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
        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM camionlote WHERE id = @id";
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
