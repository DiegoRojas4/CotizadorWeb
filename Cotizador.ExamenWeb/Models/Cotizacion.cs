using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.ExamenWeb.Models
{
    public class Cotizacion
    {
        public class Aseguradora
        {
            public int PeticionAseguradoraId { get; set; }
            public int PeticionId { get; set; }
            public int AseguradoraId { get; set; }
            public double Tarifa { get; set; }
        }

        public class Root
        {
            public int PeticionId { get; set; }
            public string Marca { get; set; }
            public string Submarca { get; set; }
            public int Modelo { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionId { get; set; }
            public bool PeticionFinalizada { get; set; }
            public string PeticionLlave { get; set; }
            public List<Aseguradora> aseguradoras { get; set; }
        }
    }
}
