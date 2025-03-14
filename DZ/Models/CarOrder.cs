using System.ComponentModel.DataAnnotations.Schema;

public class CarOrder
{
    [ForeignKey("CarType")]
    public int CarId { get; set; }
    public virtual Car Car { get; set; }
    
    [ForeignKey("CustomerType")]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    
    public CarOrder(){}

    public CarOrder(int carId, int customerId)
    {
        CarId = carId;
        CustomerId = customerId;
    }
}