﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegymBot.Data;

namespace RegymBot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220804132426_AddDescriptionToUserEntity")]
    partial class AddDescriptionToUserEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RegymBot.Data.Entities.FeedbackEntity", b =>
                {
                    b.Property<Guid>("FeedbackGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("FeedbackGuid");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.PriceEntity", b =>
                {
                    b.Property<Guid>("PriceGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PriceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceType")
                        .HasColumnType("int");

                    b.HasKey("PriceGuid");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("RoleGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleGuid");

                    b.HasIndex("Role")
                        .IsUnique()
                        .HasFilter("[Role] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.StaticMessageEntity", b =>
                {
                    b.Property<Guid>("StaticMessageGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Page")
                        .HasColumnType("int");

                    b.HasKey("StaticMessageGuid");

                    b.ToTable("StaticMessages");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserGuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.UserRoleEntity", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserGuid", "RoleGuid");

                    b.HasIndex("RoleGuid");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.UserRoleEntity", b =>
                {
                    b.HasOne("RegymBot.Data.Entities.RoleEntity", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegymBot.Data.Entities.UserEntity", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.RoleEntity", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.UserEntity", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
