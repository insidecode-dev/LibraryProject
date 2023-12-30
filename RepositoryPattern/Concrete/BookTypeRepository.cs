using LibraryProject.Context;
using LibraryProject.DTO;
using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Interfaces;
using LibraryProject.RepositoryPattern.Repository;

namespace LibraryProject.RepositoryPattern.Concrete
{
    public class BookTypeRepository : Repository<BookTypes>, IBookTypeRepository
    {
        public BookTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public List<BookTypeDTO> GetBookTypesDTO()
        {
            return _Table.Where(x => x.DataStatus != Enums.DataStatus.Deleted)
                .Select(x =>
                new BookTypeDTO
                {
                    ID = x.ID,
                    Name = x.Name

                }).ToList();
        }
    }
}
