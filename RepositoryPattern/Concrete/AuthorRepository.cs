using LibraryProject.Context;
using LibraryProject.DTO;
using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Interfaces;
using LibraryProject.RepositoryPattern.Repository;

namespace LibraryProject.RepositoryPattern.Concrete
{
    public class AuthorRepository : Repository<Authors>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public List<AuthorDTO> GetAuthorDTO()
        {
            return _Table.Where(x => x.DataStatus != Enums.DataStatus.Deleted)
                .Select(x =>
                new AuthorDTO
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList();
        }
    }
}
