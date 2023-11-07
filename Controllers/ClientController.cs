using System.Collections.Generic;
using Models.ClientModel;

namespace Controllers.ClientController
{
    public class ClientController
    {
        private ClientModel model;

        public ClientController()
        {
            ClientModel clientModel = new ClientModel();
            model = clientModel;
        }
        
        public List<ClientModel> GetAll()
        {
            return model.GetAll();
        }

        public int Create(string nombre, string calle, string telefono)
        {
            return model.Create(nombre, calle, telefono);
        }

        public bool Edit(int id, string nombre, string calle, string telefono)
        {
            return model.Edit(id, nombre, calle, telefono);
        }
        public bool Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
