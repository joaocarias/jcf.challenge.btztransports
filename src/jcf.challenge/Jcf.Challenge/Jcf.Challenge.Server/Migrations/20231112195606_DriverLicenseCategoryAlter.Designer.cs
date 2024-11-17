﻿// <auto-generated />
using System;
using Jcf.Challenge.Server.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jcf.Challenge.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231112195606_DriverLicenseCategoryAlter")]
    partial class DriverLicenseCategoryAlter
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Jcf.Challenge.Server.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LicenseCategory")
                        .HasColumnType("int");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdateId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.HasIndex("UserUpdateId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.Refueling", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateRefueling")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("char(36)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("PaidAmount")
                        .HasColumnType("double");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("UserCreateId");

                    b.HasIndex("UserUpdateId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Refuelings");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("UserUpdateId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.HasIndex("UserUpdateId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("08dbd59a-2683-4c67-8e16-689ba2648545"),
                            CreatedAt = new DateTime(2023, 11, 12, 19, 56, 5, 262, DateTimeKind.Utc).AddTicks(9752),
                            Email = "admin@email.com",
                            IsActive = true,
                            Name = "Administrador Usuário",
                            Password = "4BADAEE57FED5610012A296273158F5F",
                            Role = "ADMIN",
                            UserName = "admin@email.com"
                        },
                        new
                        {
                            Id = new Guid("08dbdc08-56e1-4e90-805f-db29361e075e"),
                            CreatedAt = new DateTime(2023, 11, 12, 19, 56, 5, 263, DateTimeKind.Utc).AddTicks(297),
                            Email = "basico@email.com",
                            IsActive = true,
                            Name = "Básico Usuário",
                            Password = "4BADAEE57FED5610012A296273158F5F",
                            Role = "BASIC",
                            UserName = "basico@email.com"
                        });
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<double>("MaxCapacityFuel")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Observation")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserUpdateId")
                        .HasColumnType("char(36)");

                    b.Property<int>("YearManufacture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.HasIndex("UserUpdateId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.Driver", b =>
                {
                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserUpdate")
                        .WithMany()
                        .HasForeignKey("UserUpdateId");

                    b.Navigation("UserCreate");

                    b.Navigation("UserUpdate");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.Refueling", b =>
                {
                    b.HasOne("Jcf.Challenge.Server.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserUpdate")
                        .WithMany()
                        .HasForeignKey("UserUpdateId");

                    b.HasOne("Jcf.Challenge.Server.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("UserCreate");

                    b.Navigation("UserUpdate");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.User", b =>
                {
                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserUpdate")
                        .WithMany()
                        .HasForeignKey("UserUpdateId");

                    b.Navigation("UserCreate");

                    b.Navigation("UserUpdate");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.Vehicle", b =>
                {
                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserUpdate")
                        .WithMany()
                        .HasForeignKey("UserUpdateId");

                    b.Navigation("UserCreate");

                    b.Navigation("UserUpdate");
                });
#pragma warning restore 612, 618
        }
    }
}