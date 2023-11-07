using System.Collections.Generic;
using Models.UserModel;


namespace Controllers.UserController
{
    public class UserController
    {
        private UserModel model;

        public UserController()
        {
            UserModel userModel = new UserModel();
            model = userModel;
        }

        public bool Login(string correo, string contrasena)
        {
            return model.Login(correo, contrasena);
        }

        public List<UserModel> GetAll()
        {
            return model.GetAll();
        }

        public int Create(string correo, string contrasena, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, string rol)
        {
            return model.Create(correo, contrasena, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, rol);
        }

        public bool Edit(int id, string correo, string contrasena, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol)
        {
            return model.Edit(id, correo, contrasena, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, deshabilitado, rol);
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
