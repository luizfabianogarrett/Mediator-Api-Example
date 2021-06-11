using MediatR;

namespace Domain_Example.Command
{
    public class DeletePersonCommand : IRequest<object>
    {
        public int Id { get; set; }
    }
}
