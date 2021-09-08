using Discount.Api.Entities;
using Discount.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Discount.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discount;

        public DiscountController(IDiscountRepository discount)
        {
            _discount = discount;
        }

        [HttpGet("{productname}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDiscount(string productname)
        {
            var coupon = await _discount.GetDiscount(productname);
            return Ok(coupon);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDiscount(Coupon coupon)
        {
            await _discount.CreateDiscount(coupon);
            return CreatedAtAction("GetDiscount", new { productname = coupon.ProductName }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDiscount(Coupon coupon)
        {
           return Ok(await _discount.CreateDiscount(coupon));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDiscount(string productname)
        {
            return Ok(await _discount.DeleteDiscount(productname));
        }
    }
}
