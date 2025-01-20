using CRUD_MVC.Repository.IRepository;
using CRUD.DataAccess.Data;
using CRUD.Model.Models;

namespace CRUD_MVC.Repository
{
    public class StudentRepository: Repository<Student>, IStudent
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Student obj)
        {
            _dbContext.StudentsMVC.Update(obj);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
