public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CarId { get; set; }

    public Owner(string Name, int CarId)
    {
        this.Name = Name;
        this.CarId = CarId;
    }
    
}