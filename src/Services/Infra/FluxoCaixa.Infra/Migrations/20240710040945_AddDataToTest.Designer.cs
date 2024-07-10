﻿// <auto-generated />
using System;
using FluxoCaixa.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FluxoCaixa.Infra.Migrations
{
    [DbContext(typeof(FluxoCaixaContext))]
    [Migration("20240710040945_AddDataToTest")]
    partial class AddDataToTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FluxoCaixa.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Payments", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d5ca8048-e6b2-4bf3-a482-fb2a893efe18"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4026),
                            Description = "Salário",
                            PaymentDate = new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentType = 1,
                            PaymentValue = 2000.0m,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("d36dd245-f6ed-45e9-8d53-86621fb6be66"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4143),
                            Description = "Conta de Luz",
                            PaymentDate = new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentType = 0,
                            PaymentValue = 200.0m,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("946e0050-86e7-42f7-ac17-9f9e48dbab75"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4149),
                            Description = "Assinatura streaming",
                            PaymentDate = new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentType = 0,
                            PaymentValue = 20.0m,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4cc732e5-eb95-43db-b55c-1e5d83cc35e3"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4154),
                            Description = "Restaurante",
                            PaymentDate = new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentType = 0,
                            PaymentValue = 100.0m,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FluxoCaixa.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fdf75ccb-c77a-4848-8807-e0821259a0ac"),
                            CreatedAt = new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(3832),
                            Password = "123",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
