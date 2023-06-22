﻿// <auto-generated />
using System;
using Andreitoledo.UoW.Data.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Andreitoledo.UoW.Data.Migrations
{
    [DbContext(typeof(UoWDbContext))]
    [Migration("20230622021239_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Andreitoledo.UoW.Domain.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<Guid?>("VooId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VooId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Andreitoledo.UoW.Domain.Voo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<int>("Disponibilidade")
                        .HasColumnType("int");

                    b.Property<string>("Nota")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Voo");
                });

            modelBuilder.Entity("Andreitoledo.UoW.Domain.Pessoa", b =>
                {
                    b.HasOne("Andreitoledo.UoW.Domain.Voo", "Voo")
                        .WithMany("Pessoas")
                        .HasForeignKey("VooId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("Andreitoledo.UoW.Domain.Voo", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
