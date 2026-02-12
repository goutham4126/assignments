//using LibraryApi.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace LibraryApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LibController : ControllerBase
//    {
//        private static List<Library> libraries = new List<Library>
//        {
//            new Library { libraryId = 1, libraryName = "Central Library", numberOfBooks = 10000 },
//            new Library { libraryId = 2, libraryName = "Community Library", numberOfBooks = 5000 },
//            new Library { libraryId = 3, libraryName = "University Library", numberOfBooks = 20000 }
//        };


//        // GET: api/Lib
//        [HttpGet]
//        public IActionResult GetAllLibraries()
//        {
//            return Ok(libraries);
//        }

//        // GET: api/Lib/[id]
//        [HttpGet("{id}")]

//        public IActionResult GetLibraryById(int id)
//        {
//            var library = libraries.FirstOrDefault(l=>l.libraryId == id);
//            if (library == null)
//            {
//                return NotFound("Library not found");
//            }
//            return Ok(library);
//        }

//        // POST: api/Lib
//        [HttpPost]
//        public IActionResult AddLibrary(Library library)
//        {
//            if(library == null)
//            {
//                return BadRequest("Library data is null");
//            }

//            library.libraryId = libraries.Max(l => l.libraryId) + 1;
//            libraries.Add(library);
//            return CreatedAtAction(nameof(GetLibraryById), new { id = library.libraryId }, library);
//        }

//        // PUT: api/Lib/[id]
//        [HttpPut("{id}")]
//        public IActionResult UpdateLibrary(int id,Library updatedLibrary)
//        {
//            var library = libraries.FirstOrDefault(l => l.libraryId == id);
//            if (library == null)
//            {
//                return NotFound("Library not found");
//            }

//            library.libraryName = updatedLibrary.libraryName;
//            library.numberOfBooks = updatedLibrary.numberOfBooks;

//            return Ok("Updated successfully");
//        }

//        // DELETE: api/Lib/[id]
//        [HttpDelete("{id}")]
//        public IActionResult DeleteLibrary(int id)
//        {
//            var library = libraries.FirstOrDefault(l => l.libraryId == id);
//            if (library == null)
//            {
//                return NotFound("Library not found");
//            }
//            libraries.Remove(library);
//            return Ok("Deleted successfully");
//        }


//    }
//}


// The below is using services
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Services;
using LibraryApi.DTOs;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibController : ControllerBase
    {
        private readonly ILibraryService _service;

        public LibController(ILibraryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lib = _service.GetById(id);
            if (lib == null)
                return NotFound("Library not found");

            return Ok(lib);
        }

        [HttpPost]
        public IActionResult Add(CreateLibraryDto dto)
        {
            var lib = _service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = lib.libraryId }, lib);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateLibraryDto dto)
        {
            if (!_service.Update(id, dto))
                return NotFound("Library not found");

            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound("Library not found");

            return Ok("Deleted successfully");
        }
    }
}

