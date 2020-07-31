using Domain_Example.Command;
using Domain_Example.Entity;
using Domain_Example.Repository;
using Domain_Example.Service;
using System;
using System.Threading.Tasks;

namespace Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;

        }
        public async Task<int> Save(NewPersonCommand item)
        {
            var person = new Person
            {
                Id = new Random((int)DateTime.Now.Ticks).Next(1, int.MaxValue),
                Name = item.Name
            };
            
            await _repository.Add(person);
            return person.Id;
        }

        public async Task<bool> Delete(DeletePersonCommand id)
        {
            await _repository.Delete(id.Id);
            return true;
        }

        public async Task<bool> Edit(EditPersonCommand item)
        {
            var actual = await _repository.Get(item.Id);
            actual.Name = item.Name;
            await _repository.Edit(actual);
            return true;
        }
    }
}
