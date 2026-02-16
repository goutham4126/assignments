using LibraryApi.Models;
using LibraryApi.DTOs;

namespace LibraryApi.Services
{
    public class LibraryService : ILibraryService
    {
        private static List<Library> libraries = new List<Library>
        {
            new Library { libraryId = 1, libraryName = "Central Library", numberOfBooks = 10000 },
            new Library { libraryId = 2, libraryName = "Community Library", numberOfBooks = 5000 },
            new Library { libraryId = 3, libraryName = "University Library", numberOfBooks = 20000 }
        };

        public List<LibraryDto> GetAll()
        {
            return libraries.Select(l => new LibraryDto
            {
                libraryId = l.libraryId,
                libraryName = l.libraryName,
                numberOfBooks = l.numberOfBooks
            }).ToList();
        }

        public LibraryDto GetById(int id)
        {
            var lib = libraries.FirstOrDefault(l => l.libraryId == id);
            if (lib == null) return null;

            return new LibraryDto
            {
                libraryId = lib.libraryId,
                libraryName = lib.libraryName,
                numberOfBooks = lib.numberOfBooks
            };
        }

        public LibraryDto Add(CreateLibraryDto dto)
        {
            var newLibrary = new Library
            {
                libraryId = libraries.Max(l => l.libraryId) + 1,
                libraryName = dto.libraryName,
                numberOfBooks = dto.numberOfBooks
            };

            libraries.Add(newLibrary);

            return new LibraryDto
            {
                libraryId = newLibrary.libraryId,
                libraryName = newLibrary.libraryName,
                numberOfBooks = newLibrary.numberOfBooks
            };
        }

        public LibraryDto Update(int id, UpdateLibraryDTO dto)
        {
            var lib = libraries.FirstOrDefault(l => l.libraryId == id);
            if (lib == null) return null;
            lib.libraryName = dto.libraryName;
            lib.numberOfBooks = dto.numberOfBooks;
            return new LibraryDto
            {
                libraryId = lib.libraryId,
                libraryName = lib.libraryName,
                numberOfBooks = lib.numberOfBooks
            };
        }

        public LibraryDto Delete(DeleteLibraryDTO id)
        {
            var lib = libraries.FirstOrDefault(l => l.libraryId == id.libraryId);
            if (lib == null) return null;
            libraries.Remove(lib);
            return new LibraryDto
            {
                libraryId = lib.libraryId,
                libraryName = lib.libraryName,
                numberOfBooks = lib.numberOfBooks
            };
        }
    }
}
