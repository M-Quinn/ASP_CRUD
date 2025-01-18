using CRUD_Razor.Data;
using CRUD_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Student> Students { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Students = _dbContext.Students_Razor.ToList();
        }
    }
}
