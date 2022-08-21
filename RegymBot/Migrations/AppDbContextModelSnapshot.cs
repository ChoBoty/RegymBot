﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegymBot.Data;

namespace RegymBot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RegymBot.Data.Entities.ClientEntity", b =>
                {
                    b.Property<Guid>("ClientGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Enrol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientGuid");

                    b.ToTable("Clients");
                });

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

            modelBuilder.Entity("RegymBot.Data.Entities.PageEntity", b =>
                {
                    b.Property<Guid>("PageGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("PageGuid");

                    b.ToTable("Pages");
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

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("StaticMessageGuid");

                    b.HasIndex("PageId")
                        .IsUnique();

                    b.ToTable("StaticMessages");
                });

            modelBuilder.Entity("RegymBot.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

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

            modelBuilder.Entity("RegymBot.Data.Entities.StaticMessageEntity", b =>
                {
                    b.HasOne("RegymBot.Data.Entities.PageEntity", "Page")
                        .WithOne("Message")
                        .HasForeignKey("RegymBot.Data.Entities.StaticMessageEntity", "PageId")
                        .HasPrincipalKey("RegymBot.Data.Entities.PageEntity", "PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");
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

            modelBuilder.Entity("RegymBot.Data.Entities.PageEntity", b =>
                {
                    b.Navigation("Message");
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
