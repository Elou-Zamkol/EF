using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1;


public class ShowroomContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    
    
    public DbSet<Dealer> Dealers { get; set; }
    
    
    public DbSet<CarOrder> CarOrders { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new ConfigurationBuilder().AddJsonFile("Appsettings.json").Build()
            .GetConnectionString("Default");

        optionsBuilder.UseSqlServer(connectionString);
        
        optionsBuilder.UseLazyLoadingProxies();
        
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CarOrder>()
            .HasKey(co => new { co.CarId, co.CustomerId }); 
        
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "John Doe", SurName = "Doe" },
            new Customer { Id = 2, Name = "Jane Smith", SurName = "Smith" },
            new Customer { Id = 3, Name = "Alice Johnson", SurName = "Johnson" },
            new Customer { Id = 4, Name = "Bob Brown", SurName = "Brown" },
            new Customer { Id = 5, Name = "Chris White", SurName = "White" },
            new Customer { Id = 6, Name = "David Black", SurName = "Black" },
            new Customer { Id = 7, Name = "Eve Green", SurName = "Green" },
            new Customer { Id = 8, Name = "Frank Harris", SurName = "Harris" },
            new Customer { Id = 9, Name = "Grace Lee", SurName = "Lee"},
            new Customer { Id = 10, Name = "Henry King", SurName = "King" }
        );

   
        modelBuilder.Entity<Dealer>().HasData(
            new Dealer { Id = 1, Name = "AutoMax", Location = "New York" },
            new Dealer { Id = 2, Name = "Speedster Motors", Location = "Los Angeles" }
        );

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2022, DealerId = 1 },
            new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2023, DealerId = 2 },
            new Car { Id = 3, Make = "Ford", Model = "Focus", Year = 2022, DealerId = 1 }
        );

     
        modelBuilder.Entity<CarOrder>().HasData(
            new CarOrder { CarId = 1, CustomerId = 1 },
            new CarOrder { CarId = 2, CustomerId = 2 },
            new CarOrder { CarId = 3, CustomerId = 3 }
        );
        
    }
    
    
}