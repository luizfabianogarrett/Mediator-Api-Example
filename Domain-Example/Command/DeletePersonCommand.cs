using MediatR;

namespace Domain_Example.Command
{
    public class DeletePersonCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
