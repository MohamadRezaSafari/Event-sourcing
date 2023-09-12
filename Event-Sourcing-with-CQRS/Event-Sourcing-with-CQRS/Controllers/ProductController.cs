using Event_Sourcing_with_CQRS.Domain.Commands;
using Event_Sourcing_with_CQRS.EventReplay;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Event_Sourcing_with_CQRS.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            try
            {
                var productId = await _mediator.Send(command);
                return Ok(productId);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or validation errors
                return BadRequest(ex.Message);
            }
        }
    }
}