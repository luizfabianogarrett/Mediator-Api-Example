using Domain_Example.Command;
using MediatR;

namespace Domain_Example.Handler
{
    public interface IPersonCommandHandler : 
        IRequestHandler<NewPersonCommand, object>,
        IRequestHandler<EditPersonCommand, object>,
        IRequestHandler<DeletePersonCommand, object>
    {
    }
}
