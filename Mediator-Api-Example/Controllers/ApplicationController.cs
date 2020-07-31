using Domain_Example.Notification.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Mediator_Api_Example.Controllers
{
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IDomainNotificationContext _notificationContext;
        public ApplicationController(IDomainNotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public bool HasErrorNotifications => _notificationContext.HasErrorNotifications;

        public List<DomainNotification> GetErrorNotifications => _notificationContext.GetErrorNotifications();

        [HttpGet("health")]
        public object Health()
        {
            return new Dictionary<string, bool> { { "healthy", true } };
        }
    }
}
