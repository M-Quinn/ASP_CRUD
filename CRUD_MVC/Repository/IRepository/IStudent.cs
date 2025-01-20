using CRUD.Model.Models;

namespace CRUD_MVC.Repository.IRepository
{
    public interface IStudent : IRepository<Student>
    {
        void Update(Student obj);
        void Save();
    }
}
