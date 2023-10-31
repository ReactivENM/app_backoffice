
namespace WindowsFormsApp1.Models
{
    class ClientModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public string telefono { get; set; }

        public ClientModel(int id, string nombre, string calle, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.calle = calle;
            this.telefono = telefono;
        }
    }
}
