using LibraryApi.DTOs;

namespace LibraryApi.Services
{
    public interface ILibraryService
    {
        List<LibraryDto> GetAll();
        LibraryDto GetById(int id);
        LibraryDto Add(CreateLibraryDto dto);
        bool Update(int id, CreateLibraryDto dto);
        bool Delete(int id);
    }
}
