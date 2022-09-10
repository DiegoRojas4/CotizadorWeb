using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.ExamenWeb.Models
{
    public class ModeloSubMarca
    {
        private int submarcaid = 0;
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private string nombre = string.Empty;
        public string Nombre { get => nombre; set => nombre = value; }

        private int agenciaId = 0;
        public int AgenciaId { get => agenciaId; set => agenciaId = value; }
    }
}
