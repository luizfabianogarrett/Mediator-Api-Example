using Domain_Example.Notification.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mediator_Api_Example.Filter
{
    public class CustomFilter : IActionFilter
    {
        private readonly IDomainNotificationContext _notificationContext;
        public CustomFilter(IDomainNotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificationContext.HasErrorNotifications)
            {
                context.Result = new BadRequestObjectResult(_notificationContext.GetErrorNotifications());
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
   
        }
    }
}
