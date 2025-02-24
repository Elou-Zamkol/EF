using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

static class Database
{
   public static void AddCarAndOwner(Car car, Owner owner, string connectionString)
    {
        var NewCar = """INSERT INTO Cars (Brand, Model, Year, Price) VALUES (@Brand, @Model, @Year, @Price) SELECT CAST(SCOPE_IDENTITY() AS INT)""";
        var NewOwner = """INSERT INTO Owners (Name, CarId) VALUES (@Name, @CarId) SELECT CAST(SCOPE_IDENTITY() AS INT)""";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var newCarId = connection.QuerySingle<int>(NewCar, car);
            owner.CarId = newCarId;
            connection.Execute(NewOwner, owner);
        }
    }

    public static void RemoveCar(int Id, string connectionString)
    {
        var commandCars = "DELETE FROM Cars WHERE Id = @CarId";
        var commandOwners = "DELETE FROM Owners WHERE CarId = @CarId";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            connection.Execute(commandOwners, new { CarId = Id });
            connection.Execute(commandCars, new { CarId = Id });
        }

    }


    public static void UpdateCar(int Id, string Name, string connectionString)
    {
        
        var commandString = """
                            UPDATE Owners SET Name = @NewName
                            WHERE CarId = @CarId
                            """;
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var newCarId = connection.Execute(commandString, new { NewName = Name, CarId = Id});
        }
        
    }

    public static void ShowCarsAndOwner(string connectionString)
    {
        var commandString = """
                            select * from Cars C
                            join Owners O on C.Id = O.CarId
                            """;
        
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        using var command = new SqlCommand(commandString, connection);
        using var reader = command.ExecuteReader();
        Console.WriteLine($"");
        while (reader.Read())
        {
            Console.WriteLine($"Id- {reader["Id"]}  Brand- {reader["Brand"]}  Model- {reader["Model"]}  Year- {reader["Year"]}  Price- {reader["Price"]}    Name-{reader["Name"]}");
        }
    }
    
    public static void ShowCarsFromName(string Name, string connectionString)
    {
        var commandString = """
                            SELECT * FROM Owners O
                            join Cars C on O.CarId = c.Id
                            WHERE Name = 'tom'
                            """;
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var reader = connection.ExecuteReader(commandString, new { Name = Name });
            while (reader.Read())
            {
                Console.WriteLine($"Id- {reader["Id"]}  Brand- {reader["Brand"]}  Model- {reader["Model"]}  Year- {reader["Year"]}  Price- {reader["Price"]}");
            }
        }
    }
}