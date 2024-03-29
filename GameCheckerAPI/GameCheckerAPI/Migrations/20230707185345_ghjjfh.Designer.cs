﻿// <auto-generated />
using System;
using GameCheckerAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameCheckerAPI.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20230707185345_ghjjfh")]
    partial class ghjjfh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GameCheckerAPI.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AccountHolderId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AccountHolderId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.ComputerHardware", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraphicsCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankingScale")
                        .HasColumnType("int");

                    b.Property<string>("guid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("computerHardware");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.GameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Appid")
                        .HasColumnType("int");

                    b.Property<bool>("Has_community_visible_stats")
                        .HasColumnType("bit");

                    b.Property<string>("Img_icon_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Playtime_forever")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("gameModel");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.Hardware2User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ComputerHardwareId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ComputerHardwareId");

                    b.HasIndex("UserId");

                    b.ToTable("hardware2Users");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.Specification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiskSpaceRequired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraphicsCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankingScale")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.Specifications2Game", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("gameId")
                        .HasColumnType("int");

                    b.Property<int?>("specificationid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("gameId");

                    b.HasIndex("specificationid");

                    b.ToTable("Specifications2Games");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("userModel");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.Account", b =>
                {
                    b.HasOne("GameCheckerAPI.Models.UserModel", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId");

                    b.Navigation("AccountHolder");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.Hardware2User", b =>
                {
                    b.HasOne("GameCheckerAPI.Models.ComputerHardware", "ComputerHardware")
                        .WithMany()
                        .HasForeignKey("ComputerHardwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameCheckerAPI.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComputerHardware");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameCheckerAPI.Models.Specifications2Game", b =>
                {
                    b.HasOne("GameCheckerAPI.Models.GameModel", "game")
                        .WithMany()
                        .HasForeignKey("gameId");

                    b.HasOne("GameCheckerAPI.Models.Specification", "specification")
                        .WithMany()
                        .HasForeignKey("specificationid");

                    b.Navigation("game");

                    b.Navigation("specification");
                });
#pragma warning restore 612, 618
        }
    }
}
