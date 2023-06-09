﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceTech.Database.Contexts;

#nullable disable

namespace SpaceTech.Database.Migrations
{
    [DbContext(typeof(SpaceTechContext))]
    [Migration("20230511193919_VR01")]
    partial class VR01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SpaceTech.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("Record identifier.");

                    b.Property<DateTime?>("ChangedAt")
                        .HasColumnType("datetime(6)")
                        .HasComment("Date and time of last record change.");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasComment("Record creation date and time.");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasComment("E-mail.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasComment("Name.");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasComment("Password.");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(220)")
                        .HasComment("Surname.");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("unq1_User");

                    b.ToTable("User", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                });
#pragma warning restore 612, 618
        }
    }
}
