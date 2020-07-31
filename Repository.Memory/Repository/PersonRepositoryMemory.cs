using Domain_Example.Entity;
using Domain_Example.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Memory.Repository
{
    public class PersonRepositoryMemory : IRepository<Person>
    {
        private static Dictionary<int, Person> Persons = new Dictionary<int, Person>();

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await Task.Run(() => Persons.Values.ToList());
        }

        public async Task<Person> Get(int id)
        {
            return await Task.Run(() => Persons[id]);
        }

        public async Task Add(Person Person)
        {
            await Task.Run(() => Persons.Add(Person.Id, Person));
        }

        public async Task Edit(Person Person)
        {
            await Task.Run(() =>
            {
                Persons.Remove(Person.Id);
                Persons.Add(Person.Id, Person);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => Persons.Remove(id));
        }
    }
}
