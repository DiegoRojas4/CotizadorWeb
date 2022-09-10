using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.ExamenWeb.Models
{
    public class DireccionValores
    {
        public string Estado { get; set; }
        public string Municipio { get; set; }

        public List<ColoniaValores> colonias { get; set; }
    }


    public class ColoniaValores
    {
        private int id = 0;
        public int IdColonia { get => id; set => id = value; }

        private string nombre = string.Empty;
        public string Nombre { get => nombre; set => nombre = value; }

    }

}
