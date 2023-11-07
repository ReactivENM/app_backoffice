using System.Collections.Generic;
using Models.PackageLotModel;

namespace Controllers.PackageLotController
{
    public class PackageLotController
    {
        private PackageLotModel model;

        public PackageLotController()
        {
            PackageLotModel packageLotModel = new PackageLotModel();
            model = packageLotModel;
        }

        /*public PackageLotModel GetOneByPackageId(int id_interno_paquete)
        {
            return model.GetOneByPackageId(id_interno_paquete);
        }*/

        public List<PackageLotModel> GetAllByLotId(int id_lote)
        {
            return model.GetAllByLotId(id_lote);
        }

        public PackageLotModel Create(string id_externo_paquete, int id_lote, int id_usuario = 3)
        {
            return model.Create(id_externo_paquete, id_lote, id_usuario);
        }

        public bool Edit(string id_externo_paquete, int id_lote, int id_usuario, System.DateTime fecha_hora)
        {
            return model.Edit(id_externo_paquete, id_lote, id_usuario, fecha_hora);
        }
        public bool Delete(string id_externo_paquete)
        {
            return model.Delete(id_externo_paquete);
        }
    }
}
