using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _mediator.Send(new GetAllOrderDetailQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailGetById(int id)
        {
            var foundId = await _mediator.Send(new GetByIdOrderDetailQueryRequest(id));
            return Ok(foundId);
        }

        [HttpPost]
        public async Task<IActionResult> OrderDetailCreate(CreateOrderDetailCommandRequest p)
        {
            await _mediator.Send(p);
            return Ok("Ordering eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> OrderDetailUpdate(UpdateOrderDetailCommandRequest p)
        {
            await _mediator.Send(p);
            return Ok("Ordering güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> OrderDetailDelete(int id)
        {
            await _mediator.Send(new RemoveOrderDetailCommandRequest(id));
            return Ok("Ordering silindi");
        }
    }
}
