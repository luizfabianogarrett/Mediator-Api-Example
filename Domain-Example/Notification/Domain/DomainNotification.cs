using MediatR;

namespace Domain_Example.Notification.Domain
{
    public class DomainNotification : INotification
    {
        public DomainNotificationType Type { get; protected set; }
        public string Value { get; protected set; }

        public DomainNotification(DomainNotificationType type, string value)
        {
            Type = type;
            Value = value;
        }

    }
}
