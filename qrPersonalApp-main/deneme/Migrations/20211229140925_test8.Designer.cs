﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using deneme.Models;

namespace deneme.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211229140925_test8")]
    partial class test8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("deneme.Models.Intime", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("perId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("intimes");
                });

            modelBuilder.Entity("deneme.Models.Outtime", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("perId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("outtimes");
                });

            modelBuilder.Entity("deneme.Models.Personal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("lastName")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<bool>("state")
                        .HasColumnType("boolean");

                    b.Property<string>("tc")
                        .HasColumnType("text");

                    b.Property<string>("tel")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("personals");
                });

            modelBuilder.Entity("deneme.Models.Qr", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("perId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("qrByte")
                        .HasColumnType("bytea");

                    b.HasKey("id");

                    b.ToTable("qrs");
                });
#pragma warning restore 612, 618
        }
    }
}
