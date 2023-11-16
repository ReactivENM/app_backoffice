using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.DB;

namespace Models.WareHouseModel
{
    public class WareHouseModel
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string calle { get; set; }
        public string nro_puerta { get; set; }
        public string cod_postal { get; set; }
        public string capacidad { get; set; }
        public string departamento { get; set; }

        MySqlConnection connection;

        public WareHouseModel()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public WareHouseModel(int id, string descripcion, string calle, string nro_puerta, string cod_postal, string capacidad, string departamento): this()
        {
            this.id = id;
            this.descripcion = descripcion;
            this.calle = calle;
            this.nro_puerta = nro_puerta;
            this.cod_postal = cod_postal;
            this.capacidad = capacidad;
            this.departamento = departamento;
        }

        public List<WareHouseModel> GetAll()
        {
            List<WareHouseModel> data = new List<WareHouseModel>();

            try
            {
                string sql = "SELECT * FROM almacen";
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
                string sql = "INSERT INTO almacen(descripcion, calle, nro_puerta, cod_postal, capacidad, departamento) VALUES(@descripcion, @calle, @nro_puerta, @cod_postal, @capacidad, @departamento); SELECT LAST_INSERT_ID()";
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
                string sql = "UPDATE almacen SET descripcion = @descripcion, calle = @calle, nro_puerta = @nro_puerta, cod_postal = @cod_postal, capacidad = @capacidad, departamento = @departamento WHERE id = @id";
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
                string sql = "DELETE FROM almacen WHERE id = @id";
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