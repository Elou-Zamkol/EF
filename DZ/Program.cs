using ConsoleApp1;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.EntityFrameworkCore;
static void AddCar(Car car)
{
    using var connection = new ShowroomContext();
    if (car.Make == "" || car.Model == "" || car.Year < 1)
    {
        throw new InvalidOperationException("Car not Add");
    }
    connection.Cars.Add(car);
    connection.SaveChanges();
}

static void RemoveCar(int Id) 
{
    using var connection = new ShowroomContext();
    var objekt= connection.Cars.FirstOrDefault(cars => cars.Id == Id && cars.IsDeleted == false) ?? throw new InvalidOperationException("Car not found");
    objekt.IsDeleted = true;
    connection.SaveChanges();
}

static void UpdateCar(int Id, Car newCar)
{
    using var connection = new ShowroomContext();
    
    var objekt= connection.Cars.FirstOrDefault(cars => cars.Id == Id) ?? throw new InvalidOperationException("Car not found");
     
    objekt.Make = newCar.Make == "" ? objekt.Make : newCar.Make;
    objekt.Model = newCar.Model == "" ? objekt.Model : newCar.Model;
    objekt.Year = newCar.Year == 0 ? objekt.Year : newCar.Year;
    connection.SaveChanges();
     
}

static void ShowCars()
{
    using var connection = new ShowroomContext();

    foreach (Car car in connection.Cars)
    {
        if (car.IsDeleted == false)
        {
            Console.WriteLine($"Id- {car.Id}  Brand- {car.Make}  Model- {car.Model}  Year- {car.Year}  DealerId- {car.DealerId}");
        }
            
    }

}

//------------------------------------------------------------

using (var context = new ShowroomContext())
{
    var car = context.Cars.FirstOrDefault(c => c.Id == 1);

    if (car != null)
    {

        context.Entry(car).Reference(c => c.Dealer).Load();
        
        Console.WriteLine($"Car- {car.Make} {car.Model}  Dealer- {car.Dealer.Name}  Location- {car.Dealer.Location}");
    }
}

//---------------------------------------------------

using (var context = new ShowroomContext()){

    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {

            Dealer NewDealer = new Dealer("AutoMax", "Baku");
        
            context.Dealers.Add(NewDealer);
            context.SaveChanges(); 
            
            Car car = new Car("Audi", "RS6", 2019, NewDealer.Id);
             
            context.Cars.Add(car);
            context.SaveChanges(); 

            
            transaction.Commit();
            Console.WriteLine("The car and dealer have been successfully added.");
        }
        catch (Exception ex)
        {
            
            transaction.Rollback();
            Console.WriteLine($"Error- {ex.Message}");
        }
    }
}

//------------------------------

using (var context = new ShowroomContext())
{
    var DealerCar = context.Cars
        .Include(C => C.Dealer)
        .ToList();
    foreach (var car in DealerCar)
    {
        Console.WriteLine($"Car- {car.Make} {car.Model}  Dealer- {car.Dealer.Name}  Location- {car.Dealer.Location}");
    }
}





/*AddCar(new Car("leksus", "r4", 2022, 2));

RemoveCar(2);

UpdateCar(3, new Car("Audi", "A6", 2021, 2));

ShowCars();*/
    
    
