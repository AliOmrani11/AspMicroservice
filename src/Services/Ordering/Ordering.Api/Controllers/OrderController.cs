using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}",Name ="GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderByUsername(string username)
        {
            var query = new GetOrdersListQuery(username);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }


        [HttpPost(Name ="CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckoutOrder(CheckoutOrderCommand entry)
        {
            var resulr = await _mediator.Send(entry);
            return Ok(entry);
        }


        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand entry)
        {
            var resulr = await _mediator.Send(entry);
            return NoContent();
        }


        [HttpDelete("{id}",Name = "DeleteOrder")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand { Id = id };
            var resulr = await _mediator.Send(command);
            return NoContent();
        }
    }
}
