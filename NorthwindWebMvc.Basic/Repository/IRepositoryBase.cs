namespace NorthwindWebMvc.Basic.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Save(TEntity entity);
        TEntity Get(int id);
        void Delete(int id);
        void Update(int id, TEntity entity);
    }
}
