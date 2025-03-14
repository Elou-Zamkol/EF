using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer // Покупатель
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string SurName { get; set; }
    
    
    public Customer(string name, string surName)
    {
        Name = name;
        SurName = surName;
    }

    public Customer(){}
}