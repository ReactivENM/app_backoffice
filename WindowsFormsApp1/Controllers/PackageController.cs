using System;
using System.Collections.Generic;
using WindowsFormsApp1.Models;
using MySqlConnector;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1.Controllers.PackageController
{
    class PackageController
    {
        MySqlConnection connection;
        public PackageController()
        {
            DBConnection conn = new DBConnection();
            conn.OpenConnection();
            connection = conn.GetConnection();
        }

        public List<PackageModel> GetAll()
        {
            List<PackageModel> data = new List<PackageModel>();

            try
            {
                string sql = "SELECT * FROM Paquete";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id_interno = reader.GetInt32(0);
                            string id_externo = reader.GetString(1);
                            int id_almacen = reader.GetInt32(2);
                            double peso = reader.GetDouble(3);
                            string descripcion = reader.GetString(4);
                            string dir_envio = reader.GetString(5);
                            string estado = reader.GetString(6);
                            PackageModel user = new PackageModel(id_interno, id_externo, id_almacen, peso, descripcion, dir_envio, estado);
                            data.Add(user);
                            Console.WriteLine(user);
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
        }
    }
}
