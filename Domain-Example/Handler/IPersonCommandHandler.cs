using Domain_Example.Command;
using MediatR;

namespace Domain_Example.Handler
{
    public interface IPersonCommandHandler : 
        IRequestHandler<NewPersonCommand, string>,
        IRequestHandler<EditPersonCommand, string>,
        IRequestHandler<DeletePersonCommand, string>
    {
    }
}
