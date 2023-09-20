﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreServices.API.ShoppingCart.Persistency;

#nullable disable

namespace StoreServices.API.ShoppingCart.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    [Migration("20230905134639_CreatedDateColumnAdded")]
    partial class CreatedDateColumnAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StoreServices.API.ShoppingCart.Models.ShoppingCart", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("StoreServices.API.ShoppingCart.Models.ShoppingCartDetails", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Product")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("ShoppingCartID")
                        .HasColumnType("binary(16)");

                    b.HasKey("ID");

                    b.HasIndex("ShoppingCartID");

                    b.ToTable("ShoppingCartDetails");
                });

            modelBuilder.Entity("StoreServices.API.ShoppingCart.Models.ShoppingCartDetails", b =>
                {
                    b.HasOne("StoreServices.API.ShoppingCart.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("Detail")
                        .HasForeignKey("ShoppingCartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("StoreServices.API.ShoppingCart.Models.ShoppingCart", b =>
                {
                    b.Navigation("Detail");
                });
#pragma warning restore 612, 618
        }
    }
}
