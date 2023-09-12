﻿using capaEntidad;
using capaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace webDBDokkan.Controllers
{
    [Authorize]
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Categoria()
        {
            return View();
        }
        public ActionResult Producto()
        {
            return View();
        }

        /*******************************CATEGORIA***************/
        #region CATEGORIA
        [HttpGet]
        public JsonResult ListarCategorias()
        {

            List<Categoria> olista = new List<Categoria>();
            olista = new CN_Categoria().Listar();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GuardarCategorias(Categoria objeto)
        {

            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdCategoria == 0)
            {
                resultado = new CN_Categoria().Registrar(objeto, out mensaje);

            }
            else
            {
                resultado = new CN_Categoria().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)

        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Categoria().Eliminar(id, out mensaje);

            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        /*******************************Producto***************/
        #region PRODUCTO

        [HttpGet]
        public JsonResult ListarProductos()
        {

            List<Producto> olista = new List<Producto>();
            olista = new CN_Producto().Listar();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public JsonResult GuardarProducto(string  objeto,HttpPostedFileBase archivoImagen)
        {

            object resultado;
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            bool guardar_imagen_exito=true;

            Producto oProducto=new Producto();
            oProducto = JsonConvert.DeserializeObject<Producto>(objeto);
            decimal precio;
            if(decimal.TryParse(oProducto.PrecioTexto, System.Globalization.NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"),out precio))
            {
                oProducto.Precio=precio;
            }
            else
            {
                return Json(new { operacioExitosa = false, mensaje = "El formato del precio debe de ser ##.##" }, JsonRequestBehavior.AllowGet);
;            }




            if (oProducto.IdProducto == 0)
            {
                int idProductoGenerado = new CN_Producto().Registrar(oProducto, out mensaje);
                if(idProductoGenerado != 0)
                {
                    oProducto.IdProducto = idProductoGenerado;
                }
                else { 
                    operacion_exitosa = false; }

            }
            else
            {
                operacion_exitosa = new CN_Producto().Editar(oProducto, out mensaje);
            }
            if (operacion_exitosa)
            {
                if (archivoImagen != null)
                {
                    string ruta_guardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombre_imagen=string.Concat(oProducto.IdProducto.ToString(), extension);
                    try {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar, nombre_imagen));
                    }catch (Exception ex)
                    {
                        string msg = ex.Message;
                        guardar_imagen_exito = false;
                    }
                    if (guardar_imagen_exito)
                    {
                        oProducto.RutaImagen = ruta_guardar;
                        oProducto.NombreImagen= nombre_imagen;
                        bool rspta = new CN_Producto().GuardarDatosImagen(oProducto, out mensaje);

                    }
                    else
                    {
                        mensaje = "Se ha guardado el producto pero hubo problemas con la imagen ";
                    }
                }
            }
            return Json(new { operacionExitosa= operacion_exitosa, idGenedado=oProducto.IdProducto, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ImagenProducto(int id)
        {
            bool conversion;
            Producto oproducto= new CN_Producto().Listar().Where(p => p.IdProducto == id).FirstOrDefault();
            string textoBase64 = CN_Recursos.ConvertirBase64(Path.Combine(oproducto.RutaImagen, oproducto.NombreImagen), out conversion);

            return Json(new
            {
                conversion = conversion,
                textobase64 = textoBase64,
                extension = Path.GetExtension(oproducto.NombreImagen)
            },
            JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarProducto(int id)

        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new CN_Producto().Eliminar(id, out mensaje);

            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
       


        #endregion
    }
}


