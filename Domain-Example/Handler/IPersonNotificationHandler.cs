using Domain_Example.Notification.Person;
using MediatR;

namespace Domain_Example.Handler
{
    public interface IPersonNotificationHandler : 
        INotificationHandler<NewPersonNotification>
    {
    }
}
