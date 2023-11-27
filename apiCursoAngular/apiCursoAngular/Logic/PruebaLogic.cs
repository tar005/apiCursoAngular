using apiCursoAngular.EntityModels;
using apiCursoAngular.Repository;

namespace apiCursoAngular.Logic
{
    public class PruebaLogic
    {
        private readonly ProductsRepository _repo;
        public PruebaLogic(ProductsRepository repo)
        {
            _repo = repo;
        }

        public async Task<Productos> UploadImageProductos(int id, IFormFile uploads)
        {
            var fileName = $"{Path.GetFileNameWithoutExtension(uploads.FileName)}_{Guid.NewGuid()}{Path.GetExtension(uploads.FileName)}";

            var filePath = Path.Combine("uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await uploads.CopyToAsync(stream);
            }

            var productUpdated = await PutProductos(new Productos() { Id = id, Imagen = fileName });

            return productUpdated;
        }

        public async Task<Productos> PostProductos(Productos productos)
        {
            var productosInsert = await _repo.InsertOne(productos);

            if (productosInsert == null)
                return null;

            return productosInsert;
        }

        public async Task<Productos> PutProductos(Productos productos)
        {
            var productosUpdated = await _repo.UpdateOne(productos);

            if (productosUpdated == null)
                return null;

            return productosUpdated;
        }

        public async Task<Productos> DeleteProductos(int id)
        {
            var productosDelete = await _repo.DeleteOne(new Productos() { Id = id });

            if (productosDelete == null)
                return null;

            return productosDelete;
        }

        public async Task<List<Productos>> GetAllProductos()
        {
            var productos = await _repo.GetAll();

            if (productos == null)
                return null;

            return productos;
        }

        public async Task<Productos> GetProductos(int id)
        {
            var productos = await _repo.GetOne(new Productos() { Id = id});

            if (productos == null)
                return null;

            return productos;
        }
    }
}
