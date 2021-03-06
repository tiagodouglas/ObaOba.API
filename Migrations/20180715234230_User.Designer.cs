﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ObaOba.API.Data;

namespace ObaOba.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180715234230_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ObaOba")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ObaOba.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("DateCreated");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnName("DateUpdated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(30);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("PasswordSalt");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
