using LibraryProject.Context;
using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Areas.Managment.Controllers
{
    [Area("Managment")]
    [Authorize(Policy = "AdminPolicy")]
    public class BookTypeController : Controller
    {
        private readonly IBookTypeRepository _repository;
        public BookTypeController(IBookTypeRepository repository)
        {
            _repository = repository;

        }
        public IActionResult BookTypeList()
        {
            List<BookTypes> bookTypes = _repository.GetActives();
            return View(bookTypes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookTypes bookTypes)
        {
            if (!ModelState.IsValid)
            {
                return View(bookTypes);
            }
            _repository.Add(bookTypes);
            return RedirectToAction("BookTypeList", "BookType", new { area="Managment"});
        }

        public IActionResult Edit(int id)
        {
            BookTypes bookTypes = _repository.GetByID(id);
            return View(bookTypes);
        }
        [HttpPost]
        public IActionResult Edit(BookTypes bookTypes)
        {
            _repository.Update(bookTypes);
            return RedirectToAction("BookTypeList", "BookType", new { area = "Managment" });
        }

        public IActionResult Delete(int id)
        {
            _repository.SoftDelete(id);
            return RedirectToAction("BookTypeList", "BookType", new { area = "Managment" });
        }

    }
}
