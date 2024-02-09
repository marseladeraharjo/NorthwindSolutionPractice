using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.RepositoryContext;

namespace NorthwindWebMvc.Basic.Repository
{
    public class CategoryRepository : IRepositoryBase<Category>
    {
        private readonly RepositoryDbContext _context;

        public CategoryRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var category =  _context.Categories.FirstOrDefault(c => c.Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category Save(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();

            return _context.Categories.Find(entity.Id);
        }
    }
}
