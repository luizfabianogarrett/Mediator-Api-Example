using MediatR;

namespace Domain_Example.Command
{
    public class EditPersonCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
