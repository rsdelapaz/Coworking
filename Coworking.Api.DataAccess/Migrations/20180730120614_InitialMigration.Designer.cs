﻿// <auto-generated />
using Coworking.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Coworking.Api.DataAccess.Migrations
{
    [DbContext(typeof(CoworkingDBContext))]
    [Migration("20180730120614_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("OfficeId");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.BookingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BookingDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("OfficeId");

                    b.Property<bool>("RentWorkSpace");

                    b.Property<int?>("RoomId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.OfficeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<bool>("HasIndividualWorkSpace");

                    b.Property<int>("IdAdmin");

                    b.Property<string>("Name");

                    b.Property<int>("NumberWorkSpaces");

                    b.Property<string>("Phone");

                    b.Property<float>("PriceWorkSpaceDaily");

                    b.Property<float>("PriceWorkSpaceMonthly");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.Offices2RoomsEntity", b =>
                {
                    b.Property<int>("OfficeId");

                    b.Property<int>("RoomId");

                    b.HasKey("OfficeId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("Office2Room");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.Room2ServicesEntity", b =>
                {
                    b.Property<int>("IdRoom");

                    b.Property<int>("IdService");

                    b.HasKey("IdRoom", "IdService");

                    b.HasIndex("IdService");

                    b.ToTable("Room2Services");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.AdminEntity", b =>
                {
                    b.HasOne("Coworking.Api.DataAccess.Contracts.Entities.OfficeEntity", "Office")
                        .WithOne("Admin")
                        .HasForeignKey("Coworking.Api.DataAccess.Contracts.Entities.AdminEntity", "OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.BookingEntity", b =>
                {
                    b.HasOne("Coworking.Api.DataAccess.Contracts.Entities.OfficeEntity", "Office")
                        .WithOne("Booking")
                        .HasForeignKey("Coworking.Api.DataAccess.Contracts.Entities.BookingEntity", "OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coworking.Api.DataAccess.Contracts.Entities.UserEntity", "User")
                        .WithOne("Booking")
                        .HasForeignKey("Coworking.Api.DataAccess.Contracts.Entities.BookingEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.Offices2RoomsEntity", b =>
                {
                    b.HasOne("Coworking.Api.DataAccess.Contracts.Entities.OfficeEntity", "Office")
                        .WithMany("Office2Room")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coworking.Api.DataAccess.Contracts.Entities.RoomEntity", "Room")
                        .WithMany("Office2Room")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coworking.Api.DataAccess.Contracts.Entities.Room2ServicesEntity", b =>
                {
                    b.HasOne("Coworking.Api.DataAccess.Contracts.Entities.RoomEntity", "Room")
                        .WithMany("Room2Service")
                        .HasForeignKey("IdRoom")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coworking.Api.DataAccess.Contracts.Entities.ServiceEntity", "Service")
                        .WithMany("Room2Service")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
