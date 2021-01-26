﻿// <auto-generated />
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
    [Migration("20210125153144_Add_seed_data")]
    partial class Add_seed_data
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

                    b.Property<string>("LanguageFrom")
                        .HasColumnType("text");

                    b.Property<string>("LanguageTo")
                        .HasColumnType("text");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("LanguageRouteStepsModel");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9dff18fc-2aa8-40e1-a4ad-8c0e4e8af887"),
                            LanguageFrom = "ru",
                            LanguageTo = "en",
                            RouteId = new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10")
                        },
                        new
                        {
                            Id = new Guid("19a012c9-7b00-4cc9-b7fa-21d0872c8f65"),
                            LanguageFrom = "ru",
                            LanguageTo = "fr",
                            RouteId = new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10")
                        },
                        new
                        {
                            Id = new Guid("36ff39a8-33cf-4b3f-90e5-6480508aaf53"),
                            LanguageFrom = "ru",
                            LanguageTo = "it",
                            RouteId = new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10")
                        },
                        new
                        {
                            Id = new Guid("d5cd212b-5a47-49cb-bca9-12fdd86ee304"),
                            LanguageFrom = "en",
                            LanguageTo = "da",
                            RouteId = new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10")
                        },
                        new
                        {
                            Id = new Guid("0a95de40-468b-4d4c-b97f-53d4b3616de1"),
                            LanguageFrom = "en",
                            LanguageTo = "ru",
                            RouteId = new Guid("2f803145-f343-4481-849c-556eaa2c9571")
                        },
                        new
                        {
                            Id = new Guid("327aa458-9c53-46e8-998b-9a1c5ec7b087"),
                            LanguageFrom = "en",
                            LanguageTo = "da",
                            RouteId = new Guid("2f803145-f343-4481-849c-556eaa2c9571")
                        },
                        new
                        {
                            Id = new Guid("e180ca3e-4516-4cf6-b966-8458db70b870"),
                            LanguageFrom = "en",
                            LanguageTo = "fr",
                            RouteId = new Guid("2f803145-f343-4481-849c-556eaa2c9571")
                        },
                        new
                        {
                            Id = new Guid("d6f6eade-e731-43c4-9874-ea29352f70ec"),
                            LanguageFrom = "en",
                            LanguageTo = "it",
                            RouteId = new Guid("2f803145-f343-4481-849c-556eaa2c9571")
                        },
                        new
                        {
                            Id = new Guid("c34c0955-2516-40c2-8e92-616130a85fc0"),
                            LanguageFrom = "fr",
                            LanguageTo = "ru",
                            RouteId = new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129")
                        },
                        new
                        {
                            Id = new Guid("2b49b3b9-ea68-4eed-9f38-e380b2cc8c5e"),
                            LanguageFrom = "fr",
                            LanguageTo = "en",
                            RouteId = new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129")
                        },
                        new
                        {
                            Id = new Guid("e384dea0-7bd5-48e5-92ee-7219345fd63b"),
                            LanguageFrom = "fr",
                            LanguageTo = "it",
                            RouteId = new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129")
                        },
                        new
                        {
                            Id = new Guid("2ffb76ac-bcff-428b-acf9-8198e2f1db24"),
                            LanguageFrom = "fr",
                            LanguageTo = "da",
                            RouteId = new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129")
                        },
                        new
                        {
                            Id = new Guid("6a40c7ec-5892-4f9e-aa01-e4a9ddd3fb91"),
                            LanguageFrom = "it",
                            LanguageTo = "ru",
                            RouteId = new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668")
                        },
                        new
                        {
                            Id = new Guid("16da83cd-e58e-4891-be53-2d70c456a887"),
                            LanguageFrom = "it",
                            LanguageTo = "en",
                            RouteId = new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668")
                        },
                        new
                        {
                            Id = new Guid("69486995-40d6-424b-9040-cb31500390a7"),
                            LanguageFrom = "it",
                            LanguageTo = "fr",
                            RouteId = new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668")
                        },
                        new
                        {
                            Id = new Guid("76b665df-3c08-4281-9831-9a65ed094ce5"),
                            LanguageFrom = "it",
                            LanguageTo = "da",
                            RouteId = new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668")
                        },
                        new
                        {
                            Id = new Guid("bfe8a521-8ba9-42eb-b057-790dc3ef0a75"),
                            LanguageFrom = "da",
                            LanguageTo = "en",
                            RouteId = new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d")
                        },
                        new
                        {
                            Id = new Guid("87f50c0a-f4ee-4efc-93d6-28bd45da8c47"),
                            LanguageFrom = "da",
                            LanguageTo = "it",
                            RouteId = new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d")
                        },
                        new
                        {
                            Id = new Guid("b93422af-377e-4cd3-b798-0e55455f7397"),
                            LanguageFrom = "da",
                            LanguageTo = "fr",
                            RouteId = new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d")
                        },
                        new
                        {
                            Id = new Guid("b00bbeeb-e964-41a0-bf3a-36517f5f6e5b"),
                            LanguageFrom = "en",
                            LanguageTo = "ru",
                            RouteId = new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d")
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10"),
                            RouteName = "ru"
                        },
                        new
                        {
                            Id = new Guid("2f803145-f343-4481-849c-556eaa2c9571"),
                            RouteName = "en"
                        },
                        new
                        {
                            Id = new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129"),
                            RouteName = "fr"
                        },
                        new
                        {
                            Id = new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668"),
                            RouteName = "it"
                        },
                        new
                        {
                            Id = new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d"),
                            RouteName = "da"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c4687c6-fddf-470c-b697-6a64528804c1"),
                            StatusValue = "Добавлен"
                        },
                        new
                        {
                            Id = new Guid("105cd0f4-a93e-4971-bdd4-a4c752813a6c"),
                            StatusValue = "Обрабатывается"
                        },
                        new
                        {
                            Id = new Guid("b4773afd-793c-46bf-9a9c-f54c75306612"),
                            StatusValue = "Обравботан"
                        });
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

                    b.Property<Guid>("TranslationModelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TranslationModelId");

                    b.ToTable("TranslationTextModel");
                });

            modelBuilder.Entity("PromtTranslation.Domain.Models.LanguageRouteStepsModel", b =>
                {
                    b.HasOne("PromtTranslation.Domain.Models.RouteModel", "Route")
                        .WithMany("LanguageRouteSteps")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
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
                        .HasForeignKey("TranslationModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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