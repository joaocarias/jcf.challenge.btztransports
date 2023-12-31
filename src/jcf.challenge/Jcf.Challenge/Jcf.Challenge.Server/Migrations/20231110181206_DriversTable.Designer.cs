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
    [Migration("20231110181206_DriversTable")]
    partial class DriversTable
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

                    b.Property<string>("LicenseCategories")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

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

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.ToTable("Drivers");
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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.Driver", b =>
                {
                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.Navigation("UserCreate");
                });

            modelBuilder.Entity("Jcf.Challenge.Server.Models.User", b =>
                {
                    b.HasOne("Jcf.Challenge.Server.Models.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.Navigation("UserCreate");
                });
#pragma warning restore 612, 618
        }
    }
}
