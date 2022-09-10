using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Entidades
{
    public class CatModeloAnio
    {
        private int modeloid = 0;
        public int ModeloId { get => modeloid; set => modeloid = value; }

        private int submarcaid = 0;
        public int SubMarcaId { get => submarcaid; set => submarcaid = value; }

        private int agenciaId = 0;
        public int AgenciaId { get => agenciaId; set => agenciaId = value; }

        private int anio = 0;
        public int Anio { get => anio; set => anio = value; }
    }
}
