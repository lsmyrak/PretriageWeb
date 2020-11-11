﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pretriage.Context;

namespace Pretriage.Context.Migrations
{
    [DbContext(typeof(PretriageContext))]
    [Migration("20201126204500_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pretriage.Entitis.Model.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfUnits")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("UnitValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("Pretriage.Entitis.Model.PretriageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataWpisu")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Do")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Od")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Export")
                        .HasColumnType("bit");

                    b.Property<string>("InnyDokument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kod_Produktu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Liczba_Jednostek_Roz")
                        .HasColumnType("int");

                    b.Property<string>("Miejsce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa_Produktu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerSeria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("Wartosc")
                        .HasColumnType("float");

                    b.Property<double>("Wartosc_Jednostki")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pretriage");
                });

            modelBuilder.Entity("Pretriage.Entitis.Model.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("Pretriage.Entitis.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
