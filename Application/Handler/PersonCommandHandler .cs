using Domain_Example.Command;
using Domain_Example.Handler;
using Domain_Example.Notification.Person;
using Domain_Example.Service;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handler
{
    public class PersonCommandHandler : IPersonCommandHandler
    {
        private readonly IPersonService _personService;
        private readonly IMediator _mediator;

        public PersonCommandHandler(
            IPersonService personService,
            IMediator mediator)
        {
            _personService = personService;
            _mediator = mediator;
        }
        public async Task<object> Handle(NewPersonCommand request, CancellationToken cancellationToken)
        {
            var id = await _personService.Save(request);
            
            await _mediator.Publish(
                new NewPersonNotification
                { 
                    Id = id,
                    Name = request.Name,
                    Date = DateTime.Now
                });

            return new { id };
        }

        public Task<object> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
