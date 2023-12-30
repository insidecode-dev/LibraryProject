using LibraryProject.Models;

namespace LibraryProject.RepositoryPattern.Interfaces
{
    public interface IBookRepository:IRepository<Books> 
    {
        List<Books> GetBooksWithRelatedEntities();
        Books GetBooksWithRelatedEntitiesByID(int id);
    }
}
