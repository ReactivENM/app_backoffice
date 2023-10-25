using System;
using System.Collections.Generic;
using WindowsFormsApp1.Models;
using MySqlConnector;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1.Controllers.LotController
{
    class LotController
    {
        MySqlConnection connection;
        public LotController()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public List<LotModel> GetAll()
        {
            List<LotModel> data = new List<LotModel>();

            try
            {
                string sql = "SELECT * FROM Lote";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int id_camion = reader.GetInt32(1);
                            int almacen_destino = reader.GetInt32(2);
                            LotModel lot = new LotModel(id, id_camion, almacen_destino);
                            data.Add(lot);
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

        public int Create(int id_camion, int almacen_destino)
        {
            try
            {
                string sql = "INSERT INTO Lote(id_camion, almacen_destino) VALUES(@id_camion, @almacen_destino); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_camion", id_camion);
                    command.Parameters.AddWithValue("@almacen_destino", almacen_destino);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Lote agregado exitosamente con ID: {id}");
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

        public bool Edit(int id, int id_camion, int almacen_destino)
        {
            try
            {
                string sql = "UPDATE Lote SET id_camion = @id_camion, almacen_destino = @almacen_destino  WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@id_camion", id_camion);
                    command.Parameters.AddWithValue("@almacen_destino", almacen_destino);

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
                string sql = "DELETE FROM Lote WHERE id = @id";
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
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
