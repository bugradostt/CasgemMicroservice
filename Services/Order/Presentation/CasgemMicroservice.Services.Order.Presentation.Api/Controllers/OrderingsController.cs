﻿using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingGetById(int id)
        {
            var foundId = await _mediator.Send(new GetByIdOrderingQueryRequest(id));
            return Ok(foundId);
        }

        [HttpPost]
        public async Task<IActionResult> OrderingCreate(CreateOrderingCommandRequest p)
        {
            await _mediator.Send(p);
            return Ok("Ordering eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> OrderingUpdate(UpdateOrderingCommandRequest p)
        {
            await _mediator.Send(p);
            return Ok("Ordering güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> OrderingDelete(int id)
        {
            await _mediator.Send(new RemoveOrderingCommandRequest(id));
            return Ok("Ordering silindi");
        }

    }
}
