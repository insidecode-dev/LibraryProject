using LibraryProject.Context;
using LibraryProject.DTO;
using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Areas.Managment.Controllers
{
	[Area("Managment")]
    [Authorize(Policy = "AdminPolicy")]
    public class BookController : Controller
    {
        
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookTypeRepository _bookTypeRepository;
        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookTypeRepository bookTypeRepository)
        {
            
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookTypeRepository = bookTypeRepository;
        }
        public IActionResult BookList()
        {
            List<Books> bookList = _bookRepository.GetBooksWithRelatedEntities();
            return View(bookList);
        }

        public IActionResult Create()
        {
            // we use AuthorDTO instead of Authors class itself, because we don't need to get all data of an author, we just need 3 column 
            List<AuthorDTO> authorDTO = _authorRepository.GetAuthorDTO();
            List<BookTypeDTO> bookTypeDTO = _bookTypeRepository.GetBookTypesDTO();
            return View((new Books(), authorDTO, bookTypeDTO));
        }
        [HttpPost]
        public IActionResult Create([Bind(Prefix ="Item1")]Books books)
        {
            if (!ModelState.IsValid)
            {
                List<AuthorDTO> authorDTO = _authorRepository.GetAuthorDTO();
                List<BookTypeDTO> bookTypeDTO = _bookTypeRepository.GetBookTypesDTO();
                return View((books, authorDTO, bookTypeDTO));
            }
            _bookRepository.Add(books);
            return RedirectToAction("BookList", "Book", new { area="Managment"});
        }

        public IActionResult Edit(int id)
        {
            Books books = _bookRepository.GetBooksWithRelatedEntitiesByID(id);
            List<AuthorDTO> authorDTO = _authorRepository.GetAuthorDTO();
            List<BookTypeDTO> bookTypeDTO = _bookTypeRepository.GetBookTypesDTO();
            return View((books, authorDTO, bookTypeDTO));
        }
        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "Item1")] Books books)
        {
            _bookRepository.Update(books);
            return RedirectToAction("BookList", "Book", new { area = "Managment" });
        }

        public IActionResult Delete(int id)
        {
            _bookRepository.SoftDelete(id);
            return RedirectToAction("BookList", "Book", new
			{
				area = "Managment"
			});
        }
    }
}
