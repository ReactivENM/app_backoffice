using System;
using System.Collections.Generic;
using WindowsFormsApp1.Models;
using MySqlConnector;
using WindowsFormsApp1.DB;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controllers.TruckController
{
    class TruckController
    {
        MySqlConnection connection;
        public TruckController()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public List<TruckModel> GetAll()
        {
            List<TruckModel> data = new List<TruckModel>();

            try
            {
                string sql = "SELECT * FROM Camion";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string matricula = reader.GetString(1);
                            string marca = reader.GetString(2);
                            string modelo = reader.GetString(3);
                            double capacidad = reader.GetDouble(4);
                            TruckModel truck = new TruckModel(id, matricula, marca, modelo, capacidad);
                            data.Add(truck);
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

        public int Create(string matricula, string marca, string modelo, double capacidad)
        {
            try
            {
                string sql = "INSERT INTO Camion(matricula, marca, modelo, capacidad) VALUES(@matricula, @marca, @modelo, @capacidad); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@matricula", matricula);
                    command.Parameters.AddWithValue("@marca", marca);
                    command.Parameters.AddWithValue("@modelo", modelo);
                    command.Parameters.AddWithValue("@capacidad", capacidad);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Camion agregado exitosamente con ID: {id}");
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

        public bool Edit(int id, string matricula, string marca, string modelo, double capacidad)
        {
            try
            {
                string sql = "UPDATE Camion SET matricula = @matricula, marca = @marca, modelo = @modelo, capacidad = @capacidad WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@matricula", matricula);
                    command.Parameters.AddWithValue("@marca", marca);
                    command.Parameters.AddWithValue("@modelo", modelo);
                    command.Parameters.AddWithValue("@capacidad", capacidad);

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
                string sql = "DELETE FROM Camion WHERE id = @id";
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
