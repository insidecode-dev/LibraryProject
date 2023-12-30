using LibraryProject.Context;
using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Interfaces;
using LibraryProject.RepositoryPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.RepositoryPattern.Concrete
{
    public class BookRepository : Repository<Books>, IBookRepository
    {
        public BookRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {
        }

        public List<Books> GetBooksWithRelatedEntities()
        {
            return _Table.Where(book=>book.DataStatus!=Enums.DataStatus.Deleted).Include(auth=> auth.Authors).Include(bookType=> bookType.BookTypes).ToList();
        }

        public Books GetBooksWithRelatedEntitiesByID(int id)
        {
            Books books = _Table.Where(book => book.DataStatus != Enums.DataStatus.Deleted && book.ID==id).Include(auth => auth.Authors).Include(bookType => bookType.BookTypes).FirstOrDefault();
            if (books is null) throw new InvalidOperationException("there is not such book");
            return books;
        }
    }
}
