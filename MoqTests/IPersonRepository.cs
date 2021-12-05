using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqTests
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Task<IEnumerable<Person>> GetAllAsync();
        Person Get(string name);
        Task<Person> GetAsync(string name);
        void Save(Person person);
    }
}