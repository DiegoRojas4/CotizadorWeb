using System;
using System.Collections.Generic;
using System.Text;

namespace Cotizador.Entidades
{
    public class Catalogos<T>
    {
        public T Catalogo { get; set; }

        public int Codigo { get; set; }
        public string Mensaje { get; set; }

    }

    public class CatalogosMunicipio
    {
        public string CatalogoJsonString { get; set; }

        public string Error { get; set; }
    }

}
