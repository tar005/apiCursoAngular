namespace apiCursoAngular.Repository.Interface
{
    public interface IRepository<T>
    {
        //Devuelve todas las entidades
        public Task<List<T>> GetAll();
        //Devuelve una entidad concreta
        public Task<T> GetOne(T entidad);
        //Inserta una entidad concreta
        public Task<T> InsertOne(T entidad);
        //Inserta una lista de entidades concreta
        public Task<List<T>> InsertAll(List<T> entidad);
        //Actualiza una entidad concreta
        public Task<T> UpdateOne(T entidad);
        //Actualiza una lista de entidades concretas
        public Task<T> UpdateAll(T entidad);
        //Elimina una entidad concreta
        public Task<T> DeleteOne(T entidad);
        //Elimina una entidad concreta
        public Task<List<T>> DeleteAll(List<T> entidad);
    }
}
