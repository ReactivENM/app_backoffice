
namespace WindowsFormsApp1.Models
{
    class LotModel
    {
        public int id { get; set; }
        public int almacen_destino { get; set; }
        public string estado { get; set; }

        public LotModel(int id, int almacen_destino, string estado)
        {
            this.id = id;
            this.almacen_destino = almacen_destino;
            this.estado = estado;
        }
    }
}
