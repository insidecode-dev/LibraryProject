using LibraryProject.Models;
using System.Linq.Expressions;

namespace LibraryProject.RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T : BaseEntity 
    {
        List<T> GetAll();
        List<T> GetActives();
        T GetByID(int id);
        void Add(T _object); 
        //I firstly written like update and delete methods return type is bool, but then I decided that I can check this inside repository, not controller, because it's confusing job then I changed it 
        void SoftDelete(int id);
        void HardDelete(int id);
        void Update(T _object);
        List<T> GetByFilter(Expression<Func<T, bool>> expression);
        T Default(Expression<Func<T, bool>> exp);
        int Count();
        bool Any(Expression<Func<T,bool>> expression);
        List<T> SelectActivesByLimit(int count);
    }
}
