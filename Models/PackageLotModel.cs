using System;
using System.Collections.Generic;
using MySqlConnector;
using Models.DB;

namespace Models.PackageLotModel
{
    public class PackageLotModel
    {
        public string id_externo_paquete { get; set; }
        public int id_lote { get; set; }
        public string usuario { get; set; }
        public string fecha_hora { get; set; }

        MySqlConnection connection;

        public PackageLotModel()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public PackageLotModel(string id_externo_paquete, int id_lote, string usuario, string fecha_hora): this()
        {
            this.id_externo_paquete = id_externo_paquete;
            this.id_lote = id_lote;
            this.usuario = usuario;
            this.fecha_hora = fecha_hora;
        }

        /* public PackageLotModel GetOneByPackageId(int id_interno_paquete)
        {
            PackageLotModel data = new PackageLotModel(0, 0, 0, "");

            try
            {
                string sql = "SELECT * FROM paquetelote WHERE id_interno_paquete = @id_interno_paquete";
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
        }*/

        public List<PackageLotModel> GetAllByLotId(int id_lote)
        {
            List<PackageLotModel> data = new List<PackageLotModel>();

            try
            {
                string sql = "SELECT p.id_externo, u.p_nombre, u.p_apellido, fecha_hora FROM paquetelote pq JOIN Paquete p ON p.id_externo = pq.id_externo_paquete JOIN Usuario u ON u.id = pq.id_usuario WHERE id_lote = @id_lote;";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_lote", id_lote);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id_externo_paquete = reader.GetString(0);
                            string usuario = $"{reader.GetString(1)} {reader.GetString(2)}";
                            System.DateTime fecha_hora = reader.GetDateTime(3);
                            PackageLotModel packageLot = new PackageLotModel(id_externo_paquete, id_lote, usuario, fecha_hora.ToString());
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

        public PackageLotModel Create(string id_externo_paquete, int id_lote, int id_usuario = 3)
        {

            PackageLotModel packageLot = new PackageLotModel("", 0, "", ""); ;

            try
            {
                string sql = "INSERT INTO paquetelote(id_externo_paquete, id_lote, id_usuario) VALUES(@id_externo_paquete, @id_lote, @id_usuario); SELECT p.id_externo, u.p_nombre, u.p_apellido, fecha_hora FROM paquetelote pq JOIN Paquete p ON p.id_externo = pq.id_externo_paquete JOIN Usuario u ON u.id = pq.id_usuario WHERE id_externo_paquete = @id_externo_paquete;";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_externo_paquete", id_externo_paquete);
                    command.Parameters.AddWithValue("@id_lote", id_lote);
                    command.Parameters.AddWithValue("@id_usuario", id_usuario);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string usuario = $"{reader.GetString(1)} {reader.GetString(2)}";
                            System.DateTime fecha_hora = reader.GetDateTime(3);
                            packageLot.id_externo_paquete = id_externo_paquete;
                            packageLot.id_lote = id_lote;
                            packageLot.usuario = usuario;
                            packageLot.fecha_hora = fecha_hora.ToString();
                        }
                        return packageLot;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return packageLot;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Edit(string id_externo_paquete, int id_lote, int id_usuario, System.DateTime fecha_hora)
        {
            try
            {
                string sql = "UPDATE paquetelote SET id_lote = @id_lote, id_usuario = @id_usuario, fecha_hora = @fecha_hora WHERE id_externo_paquete = @id_externo_paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_externo_paquete", id_externo_paquete);
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
        public bool Delete(string id_externo_paquete)
        {
            try
            {
                string sql = "DELETE FROM paquetelote WHERE id_externo_paquete = @id_externo_paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_externo_paquete", id_externo_paquete);

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
