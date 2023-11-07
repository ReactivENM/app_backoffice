using System.Collections.Generic;
using Models.PackageModel;

namespace Controllers.PackageController
{
    public class PackageController
    {
        private PackageModel model;

        public PackageController()
        {
            PackageModel packageModel = new PackageModel();
            model = packageModel;
        }

        public List<PackageModel> GetAll()
        {
            return model.GetAll();
        }

        public int Create(string id_externo, int id_cliente, double peso, string dir_envio, string estado)
        {
            return model.Create(id_externo, id_cliente, peso, dir_envio, estado);
        }

        public bool Edit(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado)
        {
            return model.Edit(id_interno, id_externo, id_cliente, peso, dir_envio, estado);
        }
        public bool Delete(int id_interno)
        {
            return model.Delete(id_interno);
        }
    }
}
