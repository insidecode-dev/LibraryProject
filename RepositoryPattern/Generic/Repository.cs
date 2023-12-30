using LibraryProject.Context;
using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryProject.RepositoryPattern.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        //we first should inject an instance of ApplicationDbContext class through IOC library
        private readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<T> _Table;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _Table = _applicationDbContext.Set<T>();
        }
        private void Save()
        {
            _applicationDbContext.SaveChanges();
        }
        public void Add(T _object)
        {
            if (_object is null) throw new InvalidOperationException("there is not such instance");
            _Table.Add(_object);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _Table.Any(expression);
        }

        public int Count()
        {
            return _Table.Count();
        }

        public List<T> GetActives()
        {
            return _Table.Where(t => t.DataStatus != Enums.DataStatus.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return _Table.ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> expression)
        {
            return _Table.Where(expression).ToList();
        }

        public T GetByID(int id)
        {
            T _object = _Table.Find(id);
            if (_object is null) throw new InvalidOperationException("there is not such data");
            return _object;
        }

        public void HardDelete(int id)
        {
            T _object = GetByID(id);            
            _Table.Remove(_object);
            Save();
        }

        public List<T> SelectActivesByLimit(int count)
        {
            return _Table.Where(x => x.DataStatus != Enums.DataStatus.Deleted).Take(count).ToList();
        }

        public void SoftDelete(int id)
        {
            T _object = GetByID(id);
            _object.DataStatus = Enums.DataStatus.Deleted;
            _object.ModifiedDate = DateTime.Now;
            _Table.Update(_object);
            Save();
        }

        public void Update(T _object)
        {
            if (_object is null) throw new InvalidOperationException("there is not such instance");
            _object.DataStatus = Enums.DataStatus.Updated;
            _object.ModifiedDate = DateTime.Now;
            _Table.Update(_object);
            Save();
        }

        public T Default(Expression<Func<T, bool>> exp)
        {
            return _Table.FirstOrDefault(exp);
        }
    }
}
