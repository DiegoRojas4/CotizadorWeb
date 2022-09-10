using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.ExamenWeb.Models
{
    public class ModeloAnio
    {
        private int modeloid = 0;
        public int ModeloId { get => modeloid; set => modeloid = value; }

        private int submarcaid = 0;
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private int agenciaId = 0;
        public int AgenciaId { get => agenciaId; set => agenciaId = value; }

        private string anio = string.Empty;
        public string Anio { get => anio; set => anio = value; }
    }
}
