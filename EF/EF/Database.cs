using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

static class Database
{
   public static void AddCar(Car car, string connectionString)
    {
        var NewCar = "INSERT INTO Cars (Brand, Model, Year, Price)" + "VALUES (@Brand, @Model, @Year, @Price)" + "SELECT CAST(SCOPE_IDENTITY() AS INT)";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var newCarId = connection.Execute(NewCar, new { Brand = car.Brand, Model = car.Model, Year = car.Year, Price = car.Price });
        }
    }

    public static bool RemoveCar(int Id, string connectionString)
    {
        var commandString = "DELETE FROM Cars WHERE Id = @CarId";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var newCarId = connection.Execute(commandString, new { Id = Id });
            return true;
        }

    }

    public static bool UpdateCar(int Id,decimal Price, string connectionString)
    {
        
        var commandString = "UPDATE Cars SET Price = @NewPrice WHERE Id = @CarId";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var newCarId = connection.Execute(commandString, new { Id = Id, Price = Price });
            return true;
        }
        
    }

    public static void ShowCars(string connectionString)
    {
        var commandString = "select * from Cars";
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        using var command = new SqlCommand(commandString, connection);
        using var reader = command.ExecuteReader();
        Console.WriteLine($"");
        while (reader.Read())
        {
            Console.WriteLine($"Id- {reader["Id"]}  Brand- {reader["Brand"]}  Model- {reader["Model"]}  Year- {reader["Year"]}  Price- {reader["Price"]}");
        }
    }
    
    public static void ShowCarsFromBrand(string Brand, string connectionString)
    {
        var commandString = "SELECT * FROM Cars WHERE Brand = @Brand";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var reader = connection.ExecuteReader(commandString, new { Brand = Brand });
            while (reader.Read())
            {
                Console.WriteLine($"Id- {reader["Id"]}  Brand- {reader["Brand"]}  Model- {reader["Model"]}  Year- {reader["Year"]}  Price- {reader["Price"]}");
            }
        }
    }
}