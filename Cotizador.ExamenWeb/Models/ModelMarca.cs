using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.ExamenWeb.Models
{
    public class ModelMarca
    {
        private int id = 0;
        public int Id { get => id; set => id = value; }


        private string nombre = string.Empty;
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
