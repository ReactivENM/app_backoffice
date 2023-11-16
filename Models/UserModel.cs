using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.DB;
using MD5Hash;

namespace Models.UserModel
{
    public class UserModel
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string p_nombre { get; set; }
        public string s_nombre { get; set; }
        public string p_apellido { get; set; }
        public string s_apellido { get; set; }
        public string nro_documento { get; set; }
        public string nacionalidad { get; set; }
        public int deshabilitado { get; set; }
        public string rol { get; set; }

        MySqlConnection connection;

        public UserModel()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public UserModel(int id, string correo, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol): this()
        {
            this.id = id;
            this.correo = correo;
            this.p_nombre = p_nombre;
            this.s_nombre = s_nombre;
            this.p_apellido = p_apellido;
            this.s_apellido = s_apellido;
            this.nro_documento = nro_documento;
            this.nacionalidad = nacionalidad;
            this.deshabilitado = deshabilitado;
            this.rol = rol;
        }

        public bool Login(string correo, string contrasena)
        {
            Dictionary<string, string> auth = new Dictionary<string, string>();

            string hashedPassword = contrasena.GetMD5();
            try
            {
                string sql = "SELECT contrasena FROM usuario WHERE correo = @correo";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string resContrasena = reader.GetString(0);
                            if(resContrasena == hashedPassword)
                            {
                                return true;
                            }
                        }
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

        public List<UserModel> GetAll()
        {
            List<UserModel> data = new List<UserModel>();

            try
            {
                string sql = "SELECT * FROM usuario";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string correo = reader.GetString(1);
                            string p_nombre = reader.GetString(3);
                            string s_nombre = reader.GetString(4);
                            string p_apellido = reader.GetString(5);
                            string s_apellido = reader.GetString(6);
                            int nro_documento = reader.GetInt32(7);
                            string nacionalidad = reader.GetString(8);
                            int deshabilitado = reader.GetInt32(9);
                            string rol = reader.GetString(10);
                            UserModel user = new UserModel(id, correo, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento.ToString(), nacionalidad, deshabilitado, rol);
                            data.Add(user);
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

        public int Create(string correo, string contrasena, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, string rol)
        {
            string hashedPassword = contrasena.GetMD5();
            try
            {
                string sql = "INSERT INTO usuario(correo, contrasena, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, rol) VALUES(@correo, @contrasena, @p_nombre, @s_nombre, @p_apellido, @s_apellido, @nro_documento, @nacionalidad, @rol); SELECT LAST_INSERT_ID()";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contrasena", hashedPassword);
                    command.Parameters.AddWithValue("@p_nombre", p_nombre);
                    command.Parameters.AddWithValue("@s_nombre", s_nombre);
                    command.Parameters.AddWithValue("@p_apellido", p_apellido);
                    command.Parameters.AddWithValue("@s_apellido", s_apellido);
                    command.Parameters.AddWithValue("@nro_documento", nro_documento);
                    command.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                    command.Parameters.AddWithValue("@rol", rol);

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"usuario agregado exitosamente con ID: {id}");
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

        public bool Edit(int id, string correo, string contrasena, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol)
        {
            string hashedPassword = contrasena.GetMD5();
            try
            {
                string sql = "";
                if(contrasena.Length == 0)
                {
                    sql = "UPDATE usuario SET correo = @correo, p_nombre = @p_nombre, s_nombre = @s_nombre, p_apellido = @p_apellido, s_apellido = @s_apellido, nro_documento = @nro_documento, nacionalidad = @nacionalidad, deshabilitado = @deshabilitado, rol = @rol  WHERE id = @id";
                } else
                {
                    sql = "UPDATE usuario SET correo = @correo, contrasena = @contrasena, p_nombre = @p_nombre, s_nombre = @s_nombre, p_apellido = @p_apellido, s_apellido = @s_apellido, nro_documento = @nro_documento, nacionalidad = @nacionalidad, deshabilitado = @deshabilitado, rol = @rol  WHERE id = @id";
                }
                        
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contrasena", hashedPassword);
                    command.Parameters.AddWithValue("@p_nombre", p_nombre);
                    command.Parameters.AddWithValue("@s_nombre", s_nombre);
                    command.Parameters.AddWithValue("@p_apellido", p_apellido);
                    command.Parameters.AddWithValue("@s_apellido", s_apellido);
                    command.Parameters.AddWithValue("@nro_documento", nro_documento);
                    command.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                    command.Parameters.AddWithValue("@deshabilitado", deshabilitado);
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
            finally
            {
                connection.Close();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM usuario WHERE id = @id";
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
