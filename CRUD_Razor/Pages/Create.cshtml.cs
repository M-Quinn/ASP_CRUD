using CRUD_Razor.Data;
using CRUD_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Student Student { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Student.FName))
            {
                ModelState.AddModelError("FName", "Students need to have a first name");
                return Page();
            }
            if (string.IsNullOrEmpty(Student.LName))
            {
                ModelState.AddModelError("LName", "Students need to have a first name");
                return Page();
            }
            if (Student.Gpa > 4.0f || Student.Gpa <= 0.0f)
            {
                ModelState.AddModelError("Gpa", "GPA must be between 0.1 and 4.0");
                return Page();
            }

            _context.Add(Student);
            _context.SaveChanges();

            TempData["success"] = "Student was successfully added.";

            return RedirectToPage("Index");
        }
    }
}
