using IndustryConnect_Week_Microservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationTier.Dtos;
using Microsoft.EntityFrameworkCore;
using ApplicationTier.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace ApplicationTier.Classes
{
    public class SaleMethods : ISaleMethods
    {

        public SaleMethods() { }

        public async Task<bool> AddSale(int productId,int customerId, DateTime? datesold, int storeId)
        {
            var context = new IndustryConnectWeek2Context();

            var customersale = new Sale
            {
                ProductId = productId,
                CustomerId = customerId,
                DateSold = datesold,
                StoreId = storeId
            };

            context.Add(customersale);
            var result = await context.SaveChangesAsync();

            return result > 0; // Return true if the sale was successfully added
        }

        //public class SaleDto
        //{
        //    public DateTime? DateSold { get; set; } // Nullable DateTime
        //}

        //private static SaleDto Mapper(Sale? customersale)
        //{
        //    if (customersale != null)
        //    {
        //        var saleDto = new SaleDto
        //        {
        //            DateSold = customersale.DateSold
        //        };

        //        return saleDto;
        //    }
        //    else
        //    {
        //        // Return an empty SaleDto instead of null
        //        return null;
        //    }
        //}

    }
}
