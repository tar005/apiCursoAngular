using apiCursoAngular.EntityModels;
using apiCursoAngular.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace apiCursoAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PruebaController : Controller
    {
        
        private readonly ILogger<PruebaController> _logger;
        private readonly PruebaLogic _pruebaLogic;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PruebaController(ILogger<PruebaController> logger, PruebaLogic pruebaLogic, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _pruebaLogic = pruebaLogic;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("pruebas", Name = "GetPruebas")]
        [HttpGet]
        public IActionResult GetPruebas()
        {
            return Json("Hola mundo");
        }

        [Route("probando", Name = "GetProbando")]
        [HttpGet]
        public IActionResult GetProbando()
        {
            return Json("Otro texto cualquiera");
        }

        [Route("getallproductos", Name = "GetAllProductos")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            var result = await _pruebaLogic.GetAllProductos();
            if (result != null)
                return Json(result);

            return StatusCode(500, "Ha ocurrido algún problema");
        }

        [Route("getproductos", Name = "GetProducto")]
        [HttpGet]
        public async Task<IActionResult> GetProducto([FromQuery] int id)
        {
            var result = await _pruebaLogic.GetProductos(id);
            if (result != null)
            {
                var baseUrl = $"{_httpContextAccessor?.HttpContext?.Request.Scheme}://{_httpContextAccessor?.HttpContext?.Request.Host}";

                // Construir la URL completa para la imagen
                var imageUrl = $"{baseUrl}/uploads/{result.Imagen}"; // Combina la dirección base y la URL relativa

                result.Imagen = imageUrl;
                return Ok(Json(result));
            }
                
            
            return StatusCode(404, "Entidad no encontrada");
        }

        [Route("productos", Name = "PutProductos")]
        [HttpPut]
        public async Task<IActionResult> PutProductos([FromForm] Productos producto)
        {
            var result = await _pruebaLogic.PutProductos(producto);
            if (result != null)
                return Ok(Json(new
                {
                    mensaje = "Producto editado correctamente",
                    id = result.Id
                }));

            return StatusCode(500, "Ha ocurrido algún problema");
        }

        [Route("productos", Name = "PostProductos")]
        [HttpPost]
        public async Task<IActionResult> PostProductos([FromForm] Productos producto)
        {
            var result = await _pruebaLogic.PostProductos(producto);

            if (result != null)
                return Ok(Json(new
                {
                    mensaje = "Producto creado correctamente",
                    id = result.Id
                }));

            return StatusCode(500, "Ha ocurrido algún problema");
        }

        [Route("uploadfile", Name = "UploadFile")]
        [HttpPost]
        public async Task<IActionResult> UploadFile(int id, IFormFile uploads)
        {
            try
            {
                if (uploads != null && uploads.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpeg", ".jpg", ".png" , ".gif" };

                    if (!allowedExtensions.Contains(Path.GetExtension(uploads.FileName)))
                    {
                        return BadRequest("El tipo de archivo no es válido. Solo se permiten archivos .jpeg, .jpg, .png. y .gif.");
                    }

                    var result = await _pruebaLogic.UploadImageProductos(id, uploads);

                    if(result != null)
                        return Ok(Json(new
                        {
                            mensaje = "Imagen subida correctamente",
                            id = result.Id
                        }));

                    return StatusCode(500, "Error interno");
                }

                return BadRequest("No se proporcionó ningún archivo.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [Route("deleteproductos", Name = "DeleteProducto")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProducto([FromQuery] int id)
        {
            var result = await _pruebaLogic.DeleteProductos(id);
            if (result != null)
                return Ok(Json(new
                {
                    mensaje = "Producto borrado correctamente",
                    id = result.Id
                }));

            return StatusCode(500, "Ha ocurrido algún problema");
        }
    }
}