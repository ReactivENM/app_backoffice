namespace WindowsFormsApp1.Models
{
    class TruckLotModel
    {
        public int id { get; set; }
        public int id_camion { get; set; }
        public int id_lote { get; set; }

        public TruckLotModel(int id, int id_camion, int id_lote)
        {
            this.id = id;
            this.id_camion = id_camion;
            this.id_lote = id_lote;
        }
    }
}
