using System;
using System.Collections.Generic;
using WindowsFormsApp1.Models;
using MySqlConnector;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1.Controllers.UserController
{
    class UserController
    {
        MySqlConnection connection;
        public UserController()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public List<UserModel> GetAll()
        {
            List<UserModel> data = new List<UserModel>();

            try
            {
                string sql = "SELECT * FROM Usuario";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string p_nombre = reader.GetString(1);
                            string s_nombre = reader.GetString(2);
                            string p_apellido = reader.GetString(3);
                            string s_apellido = reader.GetString(4);
                            string nro_documento = reader.GetString(5);
                            string nacionalidad = reader.GetString(6);
                            string rol = reader.GetString(7);
                            UserModel user = new UserModel(id, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, rol);
                            data.Add(user);
                        }
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                return data;
            }
        }

        public int Create(string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, string rol)
        {
            try
            {
                string sql = "INSERT INTO Usuario(p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, rol) VALUES(@p_nombre, @s_nombre, @p_apellido, @s_apellido, @nro_documento, @nacionalidad, @rol); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@p_nombre", p_nombre);
                    command.Parameters.AddWithValue("@s_nombre", s_nombre);
                    command.Parameters.AddWithValue("@p_apellido", p_apellido);
                    command.Parameters.AddWithValue("@s_apellido", s_apellido);
                    command.Parameters.AddWithValue("@nro_documento", nro_documento);
                    command.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                    command.Parameters.AddWithValue("@rol", rol);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"Usuario agregado exitosamente con ID: {id}");
                    return id;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool Edit(int id, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, string rol)
        {
            try
            {
                string sql = "UPDATE Usuario SET p_nombre = @p_nombre, s_nombre = @s_nombre, p_apellido = @p_apellido, s_apellido = @s_apellido, nro_documento = @nro_documento, nacionalidad = @nacionalidad, rol = @rol  WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@p_nombre", p_nombre);
                    command.Parameters.AddWithValue("@s_nombre", s_nombre);
                    command.Parameters.AddWithValue("@p_apellido", p_apellido);
                    command.Parameters.AddWithValue("@s_apellido", s_apellido);
                    command.Parameters.AddWithValue("@nro_documento", nro_documento);
                    command.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                    command.Parameters.AddWithValue("@rol", rol);

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
        }

        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Usuario WHERE id = @id";
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
        }
    }
}
