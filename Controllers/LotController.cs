using System.Collections.Generic;
using Models.LotModel;

namespace Controllers.LotController
{
    public class LotController
    {
        private LotModel model;

        public LotController()
        {
            LotModel lotModel = new LotModel();
            model = lotModel;
        }

        public List<LotModel> GetAll()
        {
            return model.GetAll();
        }

        public int Create(int id_almacen, string estado)
        {
            return model.Create(id_almacen, estado);
        }

        public bool Edit(int id, int id_almacen, string estado)
        {
            return model.Edit(id, id_almacen, estado);
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
