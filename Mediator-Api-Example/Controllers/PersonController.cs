using Domain_Example.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mediator_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ApplicationController
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewPersonCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditPersonCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePersonCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
