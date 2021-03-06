﻿// <auto-generated />
using Fisher.GroceryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Fisher.GroceryApi.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20180417190703_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Fisher.GroceryApi.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("Id");

                    b.ToTable("GroceryItems");
                });
#pragma warning restore 612, 618
        }
    }
}
