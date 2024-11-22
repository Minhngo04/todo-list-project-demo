﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoBackEnd.Data;

#nullable disable

namespace TodoBackEnd.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20241122014516_init-todos")]
    partial class inittodos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodoBackEnd.Model.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsComplete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("todos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsComplete = false,
                            Name = "Nhiệm vụ 1"
                        },
                        new
                        {
                            Id = 2,
                            IsComplete = false,
                            Name = "Nhiệm vụ 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}