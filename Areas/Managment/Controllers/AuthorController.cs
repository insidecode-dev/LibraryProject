using LibraryProject.Models;
using LibraryProject.Models.FluentValidators;
using LibraryProject.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LibraryProject.Areas.Managment.Controllers
{
	[Area("Managment")]
    [Authorize(Policy ="AdminPolicy")]
    public class AuthorController : Controller
	{
		private readonly IAuthorRepository _repository;
		public AuthorController(IAuthorRepository repository)
		{
			_repository = repository;
		}

		//this annotation makes this action checks aithorization and authentation control when this action is requested 
		
		public IActionResult AuthorList()
		{
			List<Authors> authorsList = _repository.GetActives();
			return View(authorsList);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Authors authors)
		{
            //ModelState.IsValid verifies that if our annotations for model are correct
            //string fgf= ModelState.;

            //var validator = new AuthorValidator();
            //var result = validator.Validate(authors);
            if (!ModelState.IsValid)
			{
				return View(authors);
			}
			//try
			//{
			_repository.Add(authors);
                return RedirectToAction("AuthorList", "Author", new { area = "Managment" });
   //         }
			//catch (Exception ex)
			//{
			//	string sds= ex.Message;	
			//	return BadRequest();
			//}
			
		}

		public IActionResult Edit(int id)
		{
			Authors authors = _repository.GetByID(id);
			return View(authors);
		}
		[HttpPost]
		public IActionResult Edit(Authors authors)
		{
			_repository.Update(authors);
			return RedirectToAction("AuthorList", "Author", new { area = "Managment" });
		}

		public IActionResult Delete(int id)
		{
			_repository.SoftDelete(id);
			return RedirectToAction("AuthorList", "Author", new
			{
				area = "Managment"
			});
		}
	}
}
