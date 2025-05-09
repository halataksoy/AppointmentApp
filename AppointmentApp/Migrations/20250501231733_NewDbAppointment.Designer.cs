﻿// <auto-generated />
using System;
using AppointmentApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250501231733_NewDbAppointment")]
    partial class NewDbAppointment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("AppointmentApp.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTime = new DateTime(2025, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Dahiliye",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateTime = new DateTime(2025, 5, 6, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            Department = "Kardiyoloji",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            DateTime = new DateTime(2025, 4, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Göz",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AppointmentApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "123",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "456",
                            UserName = "testuser"
                        });
                });

            modelBuilder.Entity("AppointmentApp.Models.Appointment", b =>
                {
                    b.HasOne("AppointmentApp.Models.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppointmentApp.Models.User", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
