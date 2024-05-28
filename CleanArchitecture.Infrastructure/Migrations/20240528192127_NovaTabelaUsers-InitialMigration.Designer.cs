﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240528192127_NovaTabelaUsers-InitialMigration")]
    partial class NovaTabelaUsersInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CleanArchitecture.Domain.Usuarios.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)")
                        .HasColumnName("USUA_Id");

                    b.Property<ulong>("Admin")
                        .HasColumnType("bit")
                        .HasColumnName("USUA_Admin");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("USUA_CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("USUA_Email");

                    b.Property<int>("Idade")
                        .HasColumnType("int")
                        .HasColumnName("USUA_Idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("USUA_Nome");

                    b.Property<Guid>("RegDel")
                        .HasColumnType("char(36)")
                        .HasColumnName("RegDel");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("USUA_Senha");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("USUA_UpdatedOn");

                    b.HasKey("Id")
                        .HasName("USUA_01");

                    b.ToTable("tbUSUA", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}