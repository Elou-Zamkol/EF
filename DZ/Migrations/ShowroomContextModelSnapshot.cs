﻿// <auto-generated />
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DZ.Migrations
{
    [DbContext(typeof(ShowroomContext))]
    partial class ShowroomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("Make", "Model")
                        .IsUnique();

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DealerId = 1,
                            IsDeleted = false,
                            Make = "Toyota",
                            Model = "Camry",
                            Year = 2022
                        },
                        new
                        {
                            Id = 2,
                            DealerId = 2,
                            IsDeleted = false,
                            Make = "Honda",
                            Model = "Civic",
                            Year = 2023
                        },
                        new
                        {
                            Id = 3,
                            DealerId = 1,
                            IsDeleted = false,
                            Make = "Ford",
                            Model = "Focus",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("CarOrder", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CarOrders");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            CustomerId = 1
                        },
                        new
                        {
                            CarId = 2,
                            CustomerId = 2
                        },
                        new
                        {
                            CarId = 3,
                            CustomerId = 3
                        });
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John Doe",
                            SurName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane Smith",
                            SurName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Alice Johnson",
                            SurName = "Johnson"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bob Brown",
                            SurName = "Brown"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Chris White",
                            SurName = "White"
                        },
                        new
                        {
                            Id = 6,
                            Name = "David Black",
                            SurName = "Black"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Eve Green",
                            SurName = "Green"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Frank Harris",
                            SurName = "Harris"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Grace Lee",
                            SurName = "Lee"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Henry King",
                            SurName = "King"
                        });
                });

            modelBuilder.Entity("Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dealers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "New York",
                            Name = "AutoMax"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Los Angeles",
                            Name = "Speedster Motors"
                        });
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.HasOne("Dealer", "Dealer")
                        .WithMany()
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("CarOrder", b =>
                {
                    b.HasOne("Car", "Car")
                        .WithMany("CarOrders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.Navigation("CarOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
