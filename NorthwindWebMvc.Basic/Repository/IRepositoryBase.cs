namespace NorthwindWebMvc.Basic.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
