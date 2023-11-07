using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.DB;

namespace Models.LotModel
{
    public class LotModel
    {
        public int id { get; set; }
        public int almacen_destino { get; set; }
        public string estado { get; set; }

        MySqlConnection connection;

        public LotModel()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public LotModel(int id, int almacen_destino, string estado): this()
        {
            this.id = id;
            this.almacen_destino = almacen_destino;
            this.estado = estado;
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
                            int almacen_destino = reader.GetInt32(1);
                            string estado = reader.GetString(2);
                            LotModel lot = new LotModel(id, almacen_destino, estado);
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

        public int Create(int id_almacen, string estado)
        {
            try
            {
                string sql = "INSERT INTO Lote(id_almacen, estado) VALUES(@id_almacen, @estado); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_almacen", id_almacen);
                    command.Parameters.AddWithValue("@estado", estado);

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

        public bool Edit(int id, int id_almacen, string estado)
        {
            try
            {
                string sql = "UPDATE Lote SET id_almacen = @id_almacen, estado = @estado  WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@id_almacen", id_almacen);
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
