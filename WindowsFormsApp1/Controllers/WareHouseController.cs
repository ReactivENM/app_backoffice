using System;
using System.Collections.Generic;
using WindowsFormsApp1.Models;
using MySqlConnector;
using WindowsFormsApp1.DB;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controllers.WarehouseController
{
    class WareHouseController
    {
        MySqlConnection connection;
        public WareHouseController()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public List<WareHouseModel> GetAll()
        {
            List<WareHouseModel> data = new List<WareHouseModel>();

            try
            {
                string sql = "SELECT * FROM Almacen";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string descripcion = reader.GetString(1);
                            string calle = reader.GetString(2);
                            string nro_puerta = reader.GetString(3);
                            string cod_postal = reader.GetString(4);
                            string capacidad = reader.GetInt32(5).ToString();
                            string departamento = reader.GetString(6);
                            WareHouseModel wh = new WareHouseModel(id, descripcion, calle, nro_puerta, cod_postal, capacidad, departamento);
                            data.Add(wh);
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

        public int Create(string descripcion, string calle, string nro_puerta, string cod_postal, int capacidad, string departamento)
        {
            try
            {
                string sql = "INSERT INTO Almacen(descripcion, calle, nro_puerta, cod_postal, capacidad, departamento) VALUES(@descripcion, @calle, @nro_puerta, @cod_postal, @capacidad, @departamento); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@calle", calle);
                    command.Parameters.AddWithValue("@nro_puerta", nro_puerta);
                    command.Parameters.AddWithValue("@cod_postal", cod_postal);
                    command.Parameters.AddWithValue("@capacidad", capacidad);
                    command.Parameters.AddWithValue("@departamento", departamento);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Almacen agregado exitosamente con ID: {id}");
                    return id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Edit(int id, string descripcion, string calle, string nro_puerta, string cod_postal, int capacidad, string departamento)
        {
            try
            {
                string sql = "UPDATE Almacen SET descripcion = @descripcion, calle = @calle, nro_puerta = @nro_puerta, cod_postal = @cod_postal, capacidad = @capacidad, departamento = @departamento WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@calle", calle);
                    command.Parameters.AddWithValue("@nro_puerta", nro_puerta);
                    command.Parameters.AddWithValue("@cod_postal", cod_postal);
                    command.Parameters.AddWithValue("@capacidad", capacidad);
                    command.Parameters.AddWithValue("@departamento", departamento);

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
                string sql = "DELETE FROM Almacen WHERE id = @id";
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
