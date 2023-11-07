using System.Collections.Generic;
using Models.WareHouseModel;

namespace Controllers.WarehouseController
{
    public class WareHouseController
    {
        private WareHouseModel model;

        public WareHouseController()
        {
            WareHouseModel wareHouseModel = new WareHouseModel();
            model = wareHouseModel;
        }

        public List<WareHouseModel> GetAll()
        {
            return model.GetAll();
        }

        public int Create(string descripcion, string calle, string nro_puerta, string cod_postal, int capacidad, string departamento)
        {
            return model.Create(descripcion, calle, nro_puerta, cod_postal, capacidad, departamento);
        }

        public bool Edit(int id, string descripcion, string calle, string nro_puerta, string cod_postal, int capacidad, string departamento)
        {
            return model.Edit(id, descripcion, calle, nro_puerta, cod_postal, capacidad, departamento);
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
