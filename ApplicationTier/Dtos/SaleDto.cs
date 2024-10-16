// SaleDto.cs
public class SaleDto
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int StoreID { get; set; } // The ID of the customer associated with the sale
    public DateTime DateSold { get; set; } // Sale date
}