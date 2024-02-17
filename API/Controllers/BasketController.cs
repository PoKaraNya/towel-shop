using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BasketController(IBasketRepository basketRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketId(string id)
    {
        var basket = await basketRepository.GetBasketAsync(id);
        return Ok(basket ?? new CustomerBasket(id));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
    {
        var updatedBasked = await basketRepository.UpdateBasketAsync(basket);
        return Ok(updatedBasked);
    }

    [HttpDelete]
    public async Task DeleteBasketAsync(string id)
    {
        await basketRepository.DeleteBasketAsync(id);
    }
}