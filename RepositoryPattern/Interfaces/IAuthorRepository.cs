using LibraryProject.DTO;
using LibraryProject.Models;

namespace LibraryProject.RepositoryPattern.Interfaces
{
    public interface IAuthorRepository:IRepository<Authors>
    {
        List<AuthorDTO> GetAuthorDTO();
    }
}
