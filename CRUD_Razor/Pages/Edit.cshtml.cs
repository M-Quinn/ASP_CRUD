using CRUD_Razor.Data;
using CRUD_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if(id!=null && id!=0)
                Student = _context.Students_Razor.FirstOrDefault(x => x.Id == id);
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

            _context.Students_Razor.Update(Student);
            _context.SaveChanges();

            TempData["success"] = "Student record was successfully edited.";

            return RedirectToPage("/Index");
        }
    }
}
