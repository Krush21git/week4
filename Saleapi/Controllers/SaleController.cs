using ApplicationTier.Classes;
using ApplicationTier.Interfaces;
using Azure.Identity;
using IndustryConnect_Week_Microservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {

        private readonly ISaleMethods _saleMethods;

        public SaleController(ISaleMethods saleMethods)
        {
            _saleMethods = saleMethods;

        }

        [HttpPost(Name = "AddSale")]
        public async Task<JsonResult> AddSale(int productId, int customerId, DateTime? datesold, int storeId)
        {

            var sale = await _saleMethods.AddSale(productId, customerId, datesold, storeId);

            return new JsonResult(sale);
        }
    }
}
