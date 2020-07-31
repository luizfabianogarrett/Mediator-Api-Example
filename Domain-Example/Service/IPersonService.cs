using Domain_Example.Command;
using System.Threading.Tasks;

namespace Domain_Example.Service
{
    public interface IPersonService
    {
        Task<int> Save(NewPersonCommand item);

        Task<bool> Edit(EditPersonCommand item);

        Task<bool> Delete(DeletePersonCommand id);
    }
}
