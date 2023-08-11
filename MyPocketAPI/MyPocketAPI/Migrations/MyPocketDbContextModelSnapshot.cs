﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPocketAPI.Data;

#nullable disable

namespace MyPocketAPI.Migrations
{
    [DbContext(typeof(MyPocketDbContext))]
    partial class MyPocketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyPocketAPI.Data.Models.Month", b =>
                {
                    b.Property<long>("MonthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MonthId"));

                    b.Property<int>("MonthNumber")
                        .HasColumnType("int");

                    b.Property<long>("PocketDetailId")
                        .HasColumnType("bigint");

                    b.HasKey("MonthId");

                    b.HasIndex("PocketDetailId");

                    b.ToTable("Month");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.MonthDetail", b =>
                {
                    b.Property<long>("MonthDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MonthDetailId"));

                    b.Property<long>("MonthId")
                        .HasColumnType("bigint");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.HasKey("MonthDetailId");

                    b.HasIndex("MonthId");

                    b.ToTable("MonthDetail");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.Movement", b =>
                {
                    b.Property<long>("MovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MovementId"));

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<long>("MonthDetailId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Payday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaydayLimit")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("MovementId");

                    b.HasIndex("MonthDetailId");

                    b.ToTable("Movement");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.Pocket", b =>
                {
                    b.Property<long>("PocketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PocketId"));

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("PocketId");

                    b.HasIndex("UserId");

                    b.ToTable("Pocket", (string)null);
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.PocketDetail", b =>
                {
                    b.Property<long>("PocketDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PocketDetailId"));

                    b.Property<long>("PocketId")
                        .HasColumnType("bigint");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("PocketDetailId");

                    b.HasIndex("PocketId");

                    b.ToTable("PocketDetail");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.UserPassword", b =>
                {
                    b.Property<long>("UserPasswordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserPasswordId"));

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("UserPasswordId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPassword", (string)null);
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.Month", b =>
                {
                    b.HasOne("MyPocketAPI.Data.Models.PocketDetail", "PocketDetail")
                        .WithMany()
                        .HasForeignKey("PocketDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PocketDetail");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.MonthDetail", b =>
                {
                    b.HasOne("MyPocketAPI.Data.Models.Month", "Month")
                        .WithMany()
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Month");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.Movement", b =>
                {
                    b.HasOne("MyPocketAPI.Data.Models.MonthDetail", "MonthDetail")
                        .WithMany()
                        .HasForeignKey("MonthDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonthDetail");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.Pocket", b =>
                {
                    b.HasOne("MyPocketAPI.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.PocketDetail", b =>
                {
                    b.HasOne("MyPocketAPI.Data.Models.Pocket", "Pocket")
                        .WithMany()
                        .HasForeignKey("PocketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pocket");
                });

            modelBuilder.Entity("MyPocketAPI.Data.Models.UserPassword", b =>
                {
                    b.HasOne("MyPocketAPI.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
