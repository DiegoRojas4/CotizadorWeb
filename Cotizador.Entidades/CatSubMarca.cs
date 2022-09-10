using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Entidades
{
    public class CatSubMarca
    {
        private int submarcaid = 0;
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private string nombre = string.Empty;
        public string Nombre { get => nombre; set => nombre = value; }

        private int agenciaId = 0;
        public int AgenciaId { get => agenciaId; set => agenciaId = value; }
    }
}
