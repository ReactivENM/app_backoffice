using System.Collections.Generic;
using Models.TruckLotModel;

namespace Controllers.TruckLotController
{
    public class TruckLotController
    {
        private TruckLotModel model;

        public TruckLotController()
        {
            TruckLotModel truckLotModel = new TruckLotModel();
            model = truckLotModel;
        }

        /*public TruckLotModel GetOneByTruckId(int id_interno_paquete)
        {
            return model.GetOneByTruckId(id_interno_paquete);
        }*/ 

        public List<TruckLotModel> GetAllByTruckId(int id_camion)
        {
            return model.GetAllByTruckId(id_camion);
        }

        public int Create(int id_camion, int id_lote)
        {
            return model.Create(id_camion, id_lote);
        }

        public bool Edit(int id, int id_camion, int id_lote)
        {
            return model.Edit(id, id_camion, id_lote);
        }
        public bool Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
