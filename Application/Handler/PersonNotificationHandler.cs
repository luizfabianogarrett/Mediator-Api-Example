using Domain_Example.Handler;
using Domain_Example.Notification.Person;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handler
{
    public class PersonNotificationHandler : IPersonNotificationHandler
    {

        private readonly ILogger<PersonNotificationHandler> _logger;

        public PersonNotificationHandler(ILogger<PersonNotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NewPersonNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var message = $"New user: { notification.Name} Date: {notification.Date}";
                _logger.LogInformation(message);
            });
        }
    }
}
