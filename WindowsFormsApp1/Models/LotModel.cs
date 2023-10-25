
namespace WindowsFormsApp1.Models
{
    class LotModel
    {
        public int id { get; set; }
        public int id_camion { get; set; }
        public int almacen_destino { get; set; }

        public LotModel(int id, int id_camion, int almacen_destino)
        {
            this.id = id;
            this.id_camion = id_camion;
            this.almacen_destino = almacen_destino;
        }
    }
}
