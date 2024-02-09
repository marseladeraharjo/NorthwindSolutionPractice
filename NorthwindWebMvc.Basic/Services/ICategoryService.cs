namespace NorthwindWebMvc.Basic.Services
{
    public interface ICategoryService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Create(TEntity entity);
        TEntity GetById(int id);
        void Delete(int id);
        void Edit(int id, TEntity entity);
    }
}
