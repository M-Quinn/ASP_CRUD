using CRUD_Razor.Data;
using CRUD_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }

        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
                Student = _context.Students_Razor.FirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost()
        {
            _context.Remove(Student);
            _context.SaveChanges();

            TempData["Success"] = "Student record was deleted.";

            return RedirectToPage("Index");
        }
    }
}
