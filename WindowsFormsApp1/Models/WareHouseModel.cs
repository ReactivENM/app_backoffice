namespace WindowsFormsApp1.Models
{
    public class WareHouseModel
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string calle { get; set; }
        public string nro_puerta { get; set; }
        public string cod_postal { get; set; }
        public string capacidad { get; set; }
        public string departamento { get; set; }

        public WareHouseModel(int id, string descripcion, string calle, string nro_puerta, string cod_postal, string capacidad, string departamento)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.calle = calle;
            this.nro_puerta = nro_puerta;
            this.cod_postal = cod_postal;
            this.capacidad = capacidad;
            this.departamento = departamento;
        }
    }
}