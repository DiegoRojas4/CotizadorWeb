using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.ExamenWeb.Models
{
    public class ModeloDescripcion
    {
        private int modeloid = 0;
        public int ModeloId { get => modeloid; set => modeloid = value; }

        private int submarcaid = 0;
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private string descripcion = string.Empty;
        public string Descripcion { get => descripcion; set => descripcion = value; }

        private string descripcionid = string.Empty;
        public string DescripcionId { get => descripcionid; set => descripcionid = value; }
    }
}
