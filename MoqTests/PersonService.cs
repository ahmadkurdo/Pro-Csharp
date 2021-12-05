using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoqTests
{
    public class PersonService
    {
        private readonly IPersonRepository _repo;

        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Person> GetAllPeople()
        {
            var model = _repo.GetAll().Where(p => p.Age >= 18);
            return model;
        }
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            var model = await _repo.GetAllAsync();
            return model.Where(p => p.Age >= 18);
        }
        public async Task<Person> GetAsync(string naam)
        {
            var model = await _repo.GetAsync(naam);
            if(model == null)
            {
                return null;
            }
            return model;
        }
        public void AddPerson(Person model)
        {
            if(model.Name != null && model.Age >= 0)
            {
                var entity = new Person { Name = model.Name, Age = model.Age };
                _repo.Save(entity);
            }
        }
    }
}