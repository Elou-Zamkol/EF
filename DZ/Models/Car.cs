using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Make), nameof(Model), IsUnique = true)]

public class Car  // Машина
{
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    
    public string Make { get; set; }
    
    [Required]
    public string Model { get; set; }
    
    [Range(1900, 2100)]
    public int Year { get; set; }
    
    public bool IsDeleted { get; set; } = false;
    
    public int DealerId { get; set; }
    public virtual  Dealer Dealer { get; set; }
    
    
    public virtual ICollection<CarOrder> CarOrders { get; set; }
    
    public Car(string make, string model, int year , int dealerId)
    {
        Make = make;
        Model = model;
        Year = year;
        DealerId = dealerId;

    }
    
    public Car(){}
    
}