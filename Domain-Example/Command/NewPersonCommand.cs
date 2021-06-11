using MediatR;

namespace Domain_Example.Command
{
    public class NewPersonCommand : IRequest<object>
    {
        public string Name { get; set; }
    }
}
