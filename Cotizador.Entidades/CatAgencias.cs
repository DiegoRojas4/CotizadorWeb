using System;

namespace Cotizador.Entidades
{
    public class CatAgencias
    {
        private int agenciaid = 0;
        public int AgenciaId { get => agenciaid; set => agenciaid = value; }

        private string nombre = string.Empty;
        public string Nombre { get => nombre; set => nombre = value; }

    }
}
