using Mediator_Api_Example.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Mediator_Api_Example.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(CustomFilter))]
    public class ApplicationController : ControllerBase
    {
    
    }
}
