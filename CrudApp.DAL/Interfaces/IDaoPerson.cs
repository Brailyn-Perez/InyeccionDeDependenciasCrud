
using CrudApp.DAL.Models.Person;

namespace CrudApp.DAL.Interfaces
{
    public interface IDaoPerson
    {
        void Create(PersonCreateModel personCreate);
        void Update(GetPersonModel personUpdate);
        void Delete(GetPersonModel personRemove);
        List<GetPersonModel> GetAll();
        GetPersonModel GetByID(int id);
    }
}
