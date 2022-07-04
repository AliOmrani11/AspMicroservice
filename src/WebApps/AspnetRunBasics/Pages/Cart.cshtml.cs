using System;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CartModel(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public BasketModel Cart { get; set; } = new BasketModel();        

        public async Task<IActionResult> OnGetAsync()
        {
            var username = "Ali";
            Cart = await _basketService.GetBasket(username);            

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var username = "Ali";
            var basket = await _basketService.GetBasket(username);
            var item = basket.Items.FirstOrDefault(s => s.ProductId == productId);
            basket.Items.Remove(item);
            await _basketService.UpdateBasket(basket);
            return RedirectToPage();
        }
    }
}