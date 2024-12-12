
using CrudApp.DAL.Models.Person;

namespace CrudApp.DAL.Interfaces
{
    public interface IDaoPerson
    {
        void Create(PersonCreateModel personCreate);
        void Update(PersonUpdateModel personUpdate);
        void Delete(PersonRemoveModel personRemove);
        List<GetPersonModel> GetAll();
        GetPersonModel GetByID(int id);
    }
}
