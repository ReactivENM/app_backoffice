﻿
namespace WindowsFormsApp1.Models
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

        public UserModel(int id, string correo, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol)
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
    }
}
