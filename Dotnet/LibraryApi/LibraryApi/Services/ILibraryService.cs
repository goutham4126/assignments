using LibraryApi.DTOs;

namespace LibraryApi.Services
{
    public interface ILibraryService
    {
        List<LibraryDto> GetAll();
        LibraryDto GetById(int id);
        LibraryDto Add(CreateLibraryDto dto);
        LibraryDto Update(int id, UpdateLibraryDTO dto);
        LibraryDto Delete(DeleteLibraryDTO id);
    }
}
