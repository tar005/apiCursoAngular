using apiCursoAngular.DataBase;
using apiCursoAngular.EntityModels;
using apiCursoAngular.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace apiCursoAngular.Repository
{
    public class ProductsRepository : IRepository<Productos>
    {
        private readonly DataBaseContext _database;

        public ProductsRepository(DataBaseContext database)
        {
            _database = database;
        }

        public Task<List<Productos>> DeleteAll(List<Productos> entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<Productos> DeleteOne(Productos entidad)
        {
            var entidadRemoved = _database!.Productos!.Remove(entidad);
            try
            {
                await _database.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }


            return entidadRemoved.Entity;
        }

        public async Task<List<Productos>> GetAll()
        {
            var entidades = await _database!.Productos!.ToListAsync();
            return entidades;
        }

        public async Task<Productos> GetOne(Productos entidad)
        {
            var entidadGet = await _database!.Productos!.FindAsync(entidad.Id);
            return entidadGet;
        }

        public Task<List<Productos>> InsertAll(List<Productos> entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<Productos> InsertOne(Productos entidad)
        {
            var entidadSaved = await _database!.Productos!.AddAsync(entidad);
            try
            {
                await _database.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }


            return entidadSaved.Entity;
        }

        public Task<Productos> UpdateAll(Productos entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<Productos> UpdateOne(Productos entidad)
        {
            var entityToUpdate = await _database!.Productos!.FindAsync(entidad.Id);

            if (entityToUpdate == null)
                return null;

            entityToUpdate.Id = entidad.Id;
            entityToUpdate.Descripcion = entidad.Descripcion ?? entityToUpdate.Descripcion;
            entityToUpdate.Nombre = entidad.Nombre ?? entityToUpdate.Nombre;
            entityToUpdate.Precio = entidad.Precio ?? entityToUpdate.Precio;
            entityToUpdate.Imagen = entidad.Imagen ?? entityToUpdate.Imagen;

            try
            {
                await _database.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return entityToUpdate;
        }
    }
}
