// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PromtTranslation.Dtl.Context;

namespace PromtTranslation.Api.Migrations
{
    [DbContext(typeof(TranslationDbContext))]
    [Migration("20210112140956_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PromtTranslation.Domain.Models.LanguageRouteStepsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<Guid?>("RouteModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("RouteSteps")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RouteModelId");

                    b.ToTable("LanguageRouteStepsModel");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.RouteModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RouteName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RouteModel");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.StatusModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("StatusValue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StatusModel");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.TranslationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RouteModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RouteModelId");

                    b.HasIndex("StatusId");

                    b.ToTable("TranslationModel");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.TranslationTextModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<Guid?>("TranslationModelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TranslationModelId");

                    b.ToTable("TranslationTextModel");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.LanguageRouteStepsModel", b =>
                {
                    b.HasOne("PromtTranslation.Domain.Models.RouteModel", null)
                        .WithMany("LanguageRouteSteps")
                        .HasForeignKey("RouteModelId");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.TranslationModel", b =>
                {
                    b.HasOne("PromtTranslation.Domain.Models.RouteModel", "Route")
                        .WithMany("Translations")
                        .HasForeignKey("RouteModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PromtTranslation.Domain.Models.StatusModel", "Status")
                        .WithMany("Translations")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.TranslationTextModel", b =>
                {
                    b.HasOne("PromtTranslation.Domain.Models.TranslationModel", null)
                        .WithMany("Translations")
                        .HasForeignKey("TranslationModelId");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.RouteModel", b =>
                {
                    b.Navigation("LanguageRouteSteps");

                    b.Navigation("Translations");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.StatusModel", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.TranslationModel", b =>
                {
                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
