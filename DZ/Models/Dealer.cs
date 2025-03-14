


using System.ComponentModel.DataAnnotations;

public class Dealer //  Дилер
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Location { get; set; }
    


    public Dealer(string name, string location)
    {
        Name = name;
        Location = location;
    }
    
    public Dealer(){}

}