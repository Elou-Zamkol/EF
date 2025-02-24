using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;


var connectionString = "Data Source=localhost; Initial Catalog=Academy1; Integrated Security=true; Trust Server Certificate=true";

while (true)
{
    Console.WriteLine("");
    short choice;
    Console.WriteLine("1 - Add Car and Owner\n2 - Update Owner\n3 - Remove Car\n4 - Output Car \n5 - Output Car for Brand.");
    Console.Write("Your choice: ");
    choice = Convert.ToInt16(Console.ReadLine());

    if (choice == 1)
    {
        Console.Clear();
        Console.Write("Enter your Brand: ");
        string Brand = Console.ReadLine();
        Console.Write("Enter your Model: ");
        string Model = Console.ReadLine();
        Console.Write("Enter your Year: ");
        int Year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your Price: ");
        decimal Price = Convert.ToDecimal(Console.ReadLine());
        
        Console.Write("Enter your Name: ");
        string Name = Console.ReadLine();
        
        Car car = new Car(Brand, Model, Year, Price);
        Owner owner = new Owner(Name, 0);
        Database.AddCarAndOwner(car, owner, connectionString);
        Console.Clear();

    }

    else if (choice == 2)
    {
        Console.Clear();
        Console.Write("Enter ID car: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter NewName: ");
        string NewName = Console.ReadLine();
        
        Database.UpdateCar(id, NewName, connectionString);
        Console.Clear();
        
    }

    else if (choice == 3)
    {
        Console.Clear();
        Console.Write("Enter ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Database.RemoveCar(id, connectionString);
        Console.Clear();
    }

    else if (choice == 4)
    {
        Console.Clear();
        Database.ShowCarsAndOwner(connectionString);
    }
    
    else if (choice == 5)
    {
        Console.Clear();
        Console.Write("Enter your Brand: ");
        string Brand = Console.ReadLine();
        Database.ShowCarsFromName(Brand, connectionString);
    }

    else
    {
        break;
    }

}