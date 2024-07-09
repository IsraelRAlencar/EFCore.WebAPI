﻿// <auto-generated />
using System;
using EFCore.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.WebAPI.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20240709190234_HeroesBattles_Identities")]
    partial class HeroesBattles_Identities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCore.WebAPI.Models.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.HeroBattle", b =>
                {
                    b.Property<int>("BattleId")
                        .HasColumnType("int");

                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.HasKey("BattleId", "HeroId");

                    b.HasIndex("HeroId");

                    b.ToTable("HeroesBattles");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.SecretIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeroId")
                        .IsUnique();

                    b.ToTable("SecretIdentities");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.HeroBattle", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Battle", "Battle")
                        .WithMany("HeroesBattles")
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.WebAPI.Models.Hero", "Hero")
                        .WithMany("HeroesBattles")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Battle");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.SecretIdentity", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Hero", "Hero")
                        .WithOne("Identity")
                        .HasForeignKey("EFCore.WebAPI.Models.SecretIdentity", "HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Weapon", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Hero", "Hero")
                        .WithMany("Weapons")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Battle", b =>
                {
                    b.Navigation("HeroesBattles");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Hero", b =>
                {
                    b.Navigation("HeroesBattles");

                    b.Navigation("Identity")
                        .IsRequired();

                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
