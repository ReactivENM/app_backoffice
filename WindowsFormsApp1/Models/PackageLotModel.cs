
namespace WindowsFormsApp1.Models
{
    class PackageLotModel
    {
        public int id_interno_paquete { get; set; }
        public int id_lote { get; set; }
        public int id_usuario { get; set; }
        public string fecha_hora { get; set; }

        public PackageLotModel(int id_interno_paquete, int id_lote, int id_usuario, string fecha_hora)
        {
            this.id_interno_paquete = id_interno_paquete;
            this.id_lote = id_lote;
            this.id_usuario = id_usuario;
            this.fecha_hora = fecha_hora;
        }
    }
}
