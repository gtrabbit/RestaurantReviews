﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoREST.DataAccess;

#nullable disable

namespace NoREST.DataAccess.Migrations
{
    [DbContext(typeof(NoRESTContext))]
    partial class NoRESTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NoREST.DataAccess.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("CreatedById")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentityProviderId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystemUser")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.UserRestaurantBan", b =>
                {
                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RestaurantId", "UserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UserId");

                    b.ToTable("UserRestaurantBans");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.Restaurant", b =>
                {
                    b.HasOne("NoREST.DataAccess.Entities.User", "CreatedBy")
                        .WithMany("Restaurants")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.Review", b =>
                {
                    b.HasOne("NoREST.DataAccess.Entities.User", "CreatedBy")
                        .WithMany("Reviews")
                        .HasForeignKey("CreatedById");

                    b.HasOne("NoREST.DataAccess.Entities.Restaurant", "Restaurant")
                        .WithMany("Reviews")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("CreatedBy");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.UserRestaurantBan", b =>
                {
                    b.HasOne("NoREST.DataAccess.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoREST.DataAccess.Entities.Restaurant", "Restaurant")
                        .WithMany("BannedUsers")
                        .HasForeignKey("RestaurantId")
                        .IsRequired();

                    b.HasOne("NoREST.DataAccess.Entities.User", "User")
                        .WithMany("BannedRestaurants")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.Restaurant", b =>
                {
                    b.Navigation("BannedUsers");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("NoREST.DataAccess.Entities.User", b =>
                {
                    b.Navigation("BannedRestaurants");

                    b.Navigation("Restaurants");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
