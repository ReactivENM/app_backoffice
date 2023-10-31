
namespace WindowsFormsApp1.Models
{
    class PackageModel
    {
        public int id_interno { get; set; }
        public string id_externo { get; set; }
        public int id_cliente { get; set; }
        public double peso { get; set; }
        public string dir_envio { get; set; }
        public string estado { get; set; }

        public PackageModel(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado)
        {
            this.id_interno = id_interno;
            this.id_externo = id_externo;
            this.id_cliente = id_cliente;
            this.peso = peso;
            this.dir_envio = dir_envio;
            this.estado = estado;
        }
    }
}
