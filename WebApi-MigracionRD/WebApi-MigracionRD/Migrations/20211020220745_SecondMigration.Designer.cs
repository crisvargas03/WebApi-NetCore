// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_MigracionRD.Context;

namespace WebApi_MigracionRD.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20211020220745_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("WebApi_MigracionRD.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("WebApi_MigracionRD.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("StatusId");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("WebApi_MigracionRD.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusName")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("WebApi_MigracionRD.Models.Request", b =>
                {
                    b.HasOne("WebApi_MigracionRD.Models.Person", "Person")
                        .WithMany("Requests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_MigracionRD.Models.Status", "Status")
                        .WithMany("Requests")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("WebApi_MigracionRD.Models.Person", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("WebApi_MigracionRD.Models.Status", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
