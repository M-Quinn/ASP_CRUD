using System.Diagnostics;
using CRUD_MVC.Repository.IRepository;
using CRUD.DataAccess.Data;
using CRUD.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudent _studentRepository;

        private const string TEMP_SUCCESS = "success";

        public HomeController(ILogger<HomeController> logger, IStudent studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View(_studentRepository.GetAll().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (string.IsNullOrEmpty(student.FName))
            {
                ModelState.AddModelError("FName", "Students need to have a first name");
                return View();
            }
            if (string.IsNullOrEmpty(student.LName))
            {
                ModelState.AddModelError("LName", "Students need to have a first name");
                return View();
            }
            if (student.Gpa > 4.0f || student.Gpa <= 0.0f)
            {
                ModelState.AddModelError("Gpa", "GPA must be between 0.1 and 4.0");
                return View();
            }

            _studentRepository.Add(student);
            _studentRepository.Save();

            TempData[TEMP_SUCCESS] = "Student was successfully added.";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Student studentFromDb = _studentRepository.Get(x => x.Id == id);

            return View(studentFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (string.IsNullOrEmpty(student.FName))
            {
                ModelState.AddModelError("FName", "Students need to have a first name");
                return View();
            }
            if (string.IsNullOrEmpty(student.LName))
            {
                ModelState.AddModelError("LName", "Students need to have a first name");
                return View();
            }
            if (student.Gpa > 4.0f || student.Gpa <= 0.0f)
            {
                ModelState.AddModelError("Gpa", "GPA must be between 0.1 and 4.0");
                return View();
            }

            _studentRepository.Update(student);
            _studentRepository.Save();

            TempData[TEMP_SUCCESS] = "Student record was successfully edited.";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Student studentFromDb = _studentRepository.Get(x => x.Id == id);// _dbContext.StudentsMVC.FirstOrDefault(x => x.Id == id);

            return View(studentFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _studentRepository.Remove(student);
            _studentRepository.Save();

            TempData[TEMP_SUCCESS] = "Student record was deleted.";

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
