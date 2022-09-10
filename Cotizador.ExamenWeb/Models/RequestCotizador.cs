using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.ExamenWeb.Models
{
    public class RequestCotizador
    {
        private int marcaid = 0;
        public int MarcaId { get => marcaid; set => marcaid = value; }

        private int submarcaid = 0;
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private int modeloid = 0;
        public int ModeloId { get => modeloid; set => modeloid = value; }

        private string descripcionid = string.Empty;
        public string DescripcionId { get => descripcionid; set => descripcionid = value; }




    }
}
