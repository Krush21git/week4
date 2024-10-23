using ApplicationTier.Dtos;

namespace ApplicationTier.Interfaces
{
    public interface ISaleMethods
    {
        Task<bool> AddSale(int productId, int customerId, DateTime? datesold, int storeId); // Returns Task<bool>
    }
}


