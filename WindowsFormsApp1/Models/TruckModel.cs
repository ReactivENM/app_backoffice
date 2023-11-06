using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class TruckModel
    {
        public int id { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public double capacidad { get; set; }

        public TruckModel(int id, string matricula, string marca, string modelo, double capacidad)
        {
            this.id = id;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.capacidad = capacidad;
        }
    }
}
