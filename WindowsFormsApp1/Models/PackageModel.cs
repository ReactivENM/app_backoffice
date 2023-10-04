
namespace WindowsFormsApp1.Models
{
    class PackageModel
    {
        public int id_interno { get; set; }
        public string id_externo { get; set; }
        public int id_almacen { get; set; }
        public double peso { get; set; }
        public string descripcion { get; set; }
        public string dir_envio { get; set; }
        public string estado { get; set; }

        public PackageModel(int id_interno, string id_externo, int id_almacen, double peso, string descripcion, string dir_envio, string estado)
        {
            this.id_interno = id_interno;
            this.id_externo = id_externo;
            this.id_almacen = id_almacen;
            this.peso = peso;
            this.descripcion = descripcion;
            this.dir_envio = dir_envio;
            this.estado = estado;
        }
    }
}
