using MediatR;
using System;

namespace Domain_Example.Notification.Person
{
    public class NewPersonNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
