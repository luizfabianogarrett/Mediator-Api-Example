using MediatR;

namespace Domain_Example.Command
{
    public class NewPersonCommand : IRequest<string>
    {
        public string Name { get; set; }
    }
}
