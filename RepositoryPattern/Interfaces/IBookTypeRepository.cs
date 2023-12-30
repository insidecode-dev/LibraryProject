using LibraryProject.DTO;
using LibraryProject.Models;

namespace LibraryProject.RepositoryPattern.Interfaces
{
    public interface IBookTypeRepository:IRepository<BookTypes>
    {
        List<BookTypeDTO> GetBookTypesDTO();
    }
}
