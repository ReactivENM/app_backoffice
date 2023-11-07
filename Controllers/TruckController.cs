using System.Collections.Generic;
using Models.TruckModel;

namespace Controllers.TruckController
{
    public class TruckController
    {
        private TruckModel model;

        public TruckController()
        {
            TruckModel truckModel = new TruckModel();
            model = truckModel;
        }

        public List<TruckModel> GetAll()
        {
            return model.GetAll();
        }

        public int Create(string matricula, string marca, string modelo, double capacidad)
        {
            return model.Create(matricula, marca, modelo, capacidad);
        }

        public bool Edit(int id, string matricula, string marca, string modelo, double capacidad)
        {
            return model.Edit(id, matricula, marca, modelo, capacidad);
        }

        public bool Delete(int id)
        {
            return model.Delete(id);
        }
    }
}
