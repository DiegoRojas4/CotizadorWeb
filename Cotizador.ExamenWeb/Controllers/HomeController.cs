using Cotizador.Entidades;
using Cotizador.ExamenWeb.Models;
using Cotizador.Herramientas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Cotizador.ExamenWeb.Models.Cotizacion;

namespace Cotizador.ExamenWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ClienteRest _clienteRest;

        private int ModeloId = 0;
        private int SubMarca = 0;
        List<ColoniaValores> colonias = new List<ColoniaValores>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<CatAgencias> marcas = new List<CatAgencias>();

            var response = await GetObtenerMarcas();


            if (response.Count() > 0)
            {
                foreach (var item in response)
                {
                    CatAgencias marca = new CatAgencias();
                    marca.AgenciaId = item.AgenciaId;
                    marca.Nombre = item.Nombre;

                    marcas.Add(marca);
                }
            }

            ViewBag.marcas = new SelectList(marcas, "AgenciaId", "Nombre");


            return View();
        }

 

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<List<CatAgencias>> GetObtenerMarcas()
        {
            List<CatAgencias> agencias = new List<CatAgencias>();
            try
            {
                _clienteRest = new ClienteRest("https://localhost:5001/Catalogos/api/ConsultarMarcas");

                var response = await _clienteRest.SimpleGet<Catalogos<List<CatAgencias>>>();

                if (response.Codigo == 1)
                {
                    agencias = new List<CatAgencias>(response.Catalogo);
                    agencias.Add(new CatAgencias { AgenciaId = 0, Nombre = "Selecciona una Marca" });
                }

                return agencias.OrderBy(x => x.AgenciaId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult ObtenerSubMarcas(int idMarca)
        {
            Catalogos<List<CatSubMarca>> submarcasResponse = new Catalogos<List<CatSubMarca>>();

            List<ModeloSubMarca> SubMarcasModelos = new List<ModeloSubMarca>();
            List<ModeloSubMarca> TempList = new List<ModeloSubMarca>();
            try
            {
                _clienteRest = new ClienteRest("https://localhost:5001/Catalogos/api/ConsultarSubMarcas");

                RequestCotizador request = new RequestCotizador();
                request.MarcaId = idMarca;
                SubMarca = idMarca;

                submarcasResponse = _clienteRest.SimplePost<RequestCotizador, Catalogos<List<CatSubMarca>>>(request).Result;

                if (submarcasResponse.Codigo == 1)
                {
                    foreach (var i in submarcasResponse.Catalogo)
                    {
                        ModeloSubMarca submarca = new ModeloSubMarca();

                        submarca.AgenciaId = i.AgenciaId;
                        submarca.SubMarcaId = i.SubMarcaId;
                        submarca.Nombre = i.Nombre;

                        SubMarcasModelos.Add(submarca);
                    }

                    SubMarcasModelos.Add(new ModeloSubMarca { AgenciaId = 0, SubMarcaId = 0, Nombre = "Selecciona una Submarca" });

                    TempList = SubMarcasModelos.OrderBy(x => x.SubMarcaId).ToList();

                    SubMarcasModelos = new List<ModeloSubMarca>(TempList);
                }
                else
                {
                    SubMarcasModelos.Add(new ModeloSubMarca { AgenciaId = 0, SubMarcaId = 0, Nombre = "Selecciona una Submarca" });
                }

                return Json(SubMarcasModelos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult ObtenerModelos(int idSubMarca)
        {
            Catalogos<List<CatModeloAnio>> modeloResponse = new Catalogos<List<CatModeloAnio>>();

            List<ModeloAnio> modeloAnios = new List<ModeloAnio>();
            List<ModeloAnio> TempList = new List<ModeloAnio>();

            try
            {
                _clienteRest = new ClienteRest("https://localhost:5001/Catalogos/api/ConsultarModelos");

                RequestCotizador request = new RequestCotizador();
                request.SubMarcaId = idSubMarca;

                modeloResponse = _clienteRest.SimplePost<RequestCotizador, Catalogos<List<CatModeloAnio>>>(request).Result;

                if (modeloResponse.Codigo == 1)
                {
                    foreach (var i in modeloResponse.Catalogo)
                    {
                        ModeloAnio modeloAnio = new ModeloAnio();
                        modeloAnio.ModeloId = i.ModeloId;
                        modeloAnio.AgenciaId = i.AgenciaId;
                        modeloAnio.SubMarcaId = i.SubMarcaId;
                        modeloAnio.Anio = i.Anio.ToString();

                        modeloAnios.Add(modeloAnio);
                    }

                    modeloAnios.Add(new ModeloAnio { AgenciaId = 0, ModeloId = 0, SubMarcaId = 0, Anio = "Selecciona un modelo" });

                    TempList = modeloAnios.OrderBy(x => x.ModeloId).ToList();

                    modeloAnios = new List<ModeloAnio>(TempList);
                }
                else
                {
                    modeloAnios.Add(new ModeloAnio { AgenciaId = 0, ModeloId = 0, SubMarcaId = 0, Anio = "Selecciona un modelo" });
                }

                return Json(modeloAnios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult ObtenerDescripciones(int idmodelo, int idsubmarca)
        {
            Catalogos<List<CatDescripciones>> descripcionResponse = new Catalogos<List<CatDescripciones>>();

            List<ModeloDescripcion> modeloDescripcion = new List<ModeloDescripcion>();
            List<ModeloDescripcion> TempList = new List<ModeloDescripcion>();

            try
            {
                _clienteRest = new ClienteRest("https://localhost:5001/Catalogos/api/ConsultarDescripciones");

                RequestCotizador request = new RequestCotizador();
                request.SubMarcaId = idsubmarca;
                request.ModeloId = idmodelo;


                descripcionResponse = _clienteRest.SimplePost<RequestCotizador, Catalogos<List<CatDescripciones>>>(request).Result;

                if (descripcionResponse.Codigo == 1)
                {
                    foreach (var i in descripcionResponse.Catalogo)
                    {
                        ModeloDescripcion modDescripcion = new ModeloDescripcion();
                        modDescripcion.SubMarcaId = i.SubMarcaId;
                        modDescripcion.ModeloId = i.ModeloId;
                        modDescripcion.Descripcion = i.Descripcion;
                        modDescripcion.DescripcionId = i.DescripcionId;

                        modeloDescripcion.Add(modDescripcion);

                    }

                    modeloDescripcion.Add(new ModeloDescripcion { SubMarcaId = 0, DescripcionId = "", ModeloId = 0, Descripcion = "Selecciona una descripción" });

                    TempList = modeloDescripcion.OrderBy(x => x.SubMarcaId).ToList();

                    modeloDescripcion = new List<ModeloDescripcion>(TempList);
                }
                else
                {
                    modeloDescripcion.Add(new ModeloDescripcion { SubMarcaId = 0, DescripcionId = "", ModeloId = 0, Descripcion = "Selecciona una descripción" });
                }

                return Json(modeloDescripcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpGet]
        public JsonResult ConsultarCodigoPostal(string codigopostal)
        {
            List<ModelCodigoPostal> modCodigosP = new List<ModelCodigoPostal>();
            List<DireccionValores> valores = new List<DireccionValores>();
            try
            {
                string tamaniocp = string.IsNullOrEmpty(codigopostal) ? "0" : codigopostal;

                if (tamaniocp.Length == 5)
                {
                    _clienteRest = new ClienteRest(string.Concat("https://api-test.aarco.com.mx/api-examen/api/examen/sepomex/", codigopostal.ToString()));

                    var response = _clienteRest.SimpleGet<CatalogosMunicipio>().Result;

                    if (response.Error == null)
                    {
                        modCodigosP = JsonConvert.DeserializeObject<List<ModelCodigoPostal>>(response.CatalogoJsonString);
                    }

                    DireccionValores val = new DireccionValores();
                    val.colonias = new List<ColoniaValores>();
                    val.colonias.Add(new ColoniaValores { IdColonia = 0, Nombre = "Selecciona una colonia" });
                    valores.Add(val);

                    foreach (var i in modCodigosP)
                    {
                        DireccionValores valor = new DireccionValores();
                        valor.Municipio = i.Municipio.sMunicipio;
                        valor.Estado = i.Municipio.Estado.sEstado;

                        valor.colonias = new List<ColoniaValores>();

                        foreach (var it in i.Ubicacion)
                        {
                            ColoniaValores valorcol = new ColoniaValores();

                            valorcol.IdColonia = it.iIdUbicacion;
                            valorcol.Nombre = it.sUbicacion;

                            valor.colonias.Add(valorcol);
                        }

                        valores.Add(valor);
                    }
                }
                else
                {
                    DireccionValores valor = new DireccionValores();
                    valor.colonias = new List<ColoniaValores>();
                    valor.colonias.Add(new ColoniaValores { IdColonia = 0, Nombre = "Selecciona una colonia" });

                    valores.Add(valor);

                }

                return Json(valores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
