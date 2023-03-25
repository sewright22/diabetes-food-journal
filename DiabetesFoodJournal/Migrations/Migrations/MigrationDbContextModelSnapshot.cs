﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Migrations;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    partial class MigrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");

            modelBuilder.Entity("DataLayer.Data.Dose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("Extended")
                        .HasColumnType("int(11)");

                    b.Property<decimal>("InsulinAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TimeExtended")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TimeOffset")
                        .HasColumnType("int(11)");

                    b.Property<int>("UpFront")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("doses", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.ExternalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ExternalService", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.ExternalServiceUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessTokenId")
                        .HasColumnType("int(11)");

                    b.Property<int>("ExternalServiceId")
                        .HasColumnType("int(11)");

                    b.Property<DateTimeOffset?>("ExternalTokenExpiration")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RefreshTokenId")
                        .HasColumnType("int(11)");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("AccessTokenId");

                    b.HasIndex("ExternalServiceId");

                    b.HasIndex("RefreshTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("ExternalServiceUsers");
                });

            modelBuilder.Entity("DataLayer.Data.Journalentry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("Logged")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Notes"), "utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Title"), "utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("journalentries", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Journalentrydose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("DoseId")
                        .HasColumnType("int(11)");

                    b.Property<int>("JournalEntryId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DoseId" }, "IX_JournalEntryDoses_DoseId");

                    b.HasIndex(new[] { "JournalEntryId" }, "IX_JournalEntryDoses_JournalEntryId");

                    b.ToTable("journalentrydoses", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Journalentrynutritionalinfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("JournalEntryId")
                        .HasColumnType("int(11)");

                    b.Property<int>("NutritionalInfoId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("JournalEntryId")
                        .IsUnique();

                    b.HasIndex("NutritionalInfoId")
                        .IsUnique();

                    b.ToTable("journalentrynutritionalinfos", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Journalentrytag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("JournalEntryId")
                        .HasColumnType("int(11)");

                    b.Property<int>("TagId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "JournalEntryId" }, "IX_JournalEntryTags_JournalEntryId");

                    b.HasIndex(new[] { "TagId" }, "IX_JournalEntryTags_TagId");

                    b.ToTable("journalentrytags", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Nutritionalinfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("Calories")
                        .HasColumnType("int(11)");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("int(11)");

                    b.Property<int>("Protein")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("nutritionalinfos", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Text"), "utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("passwords", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Description"), "utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTimeOffset>("Expiration")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Token", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.TokenType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TokenType", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Email"), "utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Userjournalentry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("JournalEntryId")
                        .HasColumnType("int(11)");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "JournalEntryId" }, "IX_UserJournalEntries_JournalEntryId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserJournalEntries_UserId");

                    b.ToTable("userjournalentries", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.Userpassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("PasswordId")
                        .HasColumnType("int(11)");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PasswordId" }, "IX_UserPasswords_PasswordId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserPasswords_UserId")
                        .IsUnique();

                    b.ToTable("userpasswords", (string)null);
                });

            modelBuilder.Entity("DataLayer.Data.ExternalServiceUser", b =>
                {
                    b.HasOne("DataLayer.Data.Token", "AccessToken")
                        .WithMany()
                        .HasForeignKey("AccessTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Data.ExternalService", "ExternalService")
                        .WithMany("ExternalServiceUsers")
                        .HasForeignKey("ExternalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Data.Token", "RefreshToken")
                        .WithMany()
                        .HasForeignKey("RefreshTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Data.User", "User")
                        .WithMany("ExternalServiceUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessToken");

                    b.Navigation("ExternalService");

                    b.Navigation("RefreshToken");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Data.Journalentrynutritionalinfo", b =>
                {
                    b.HasOne("DataLayer.Data.Journalentry", "JournalEntry")
                        .WithOne("JournalEntryNutritionalInfo")
                        .HasForeignKey("DataLayer.Data.Journalentrynutritionalinfo", "JournalEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Data.Nutritionalinfo", "Nutritionalinfo")
                        .WithOne("JournalEntryNutritionalInfo")
                        .HasForeignKey("DataLayer.Data.Journalentrynutritionalinfo", "NutritionalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JournalEntry");

                    b.Navigation("Nutritionalinfo");
                });

            modelBuilder.Entity("DataLayer.Data.Journalentrytag", b =>
                {
                    b.HasOne("DataLayer.Data.Journalentry", "JournalEntry")
                        .WithMany("JournalEntryTags")
                        .HasForeignKey("JournalEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Data.Tag", "Tag")
                        .WithMany("JournalEntryTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JournalEntry");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("DataLayer.Data.Userpassword", b =>
                {
                    b.HasOne("DataLayer.Data.Password", "Password")
                        .WithMany()
                        .HasForeignKey("PasswordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Data.User", "User")
                        .WithOne("Userpassword")
                        .HasForeignKey("DataLayer.Data.Userpassword", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Password");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Data.ExternalService", b =>
                {
                    b.Navigation("ExternalServiceUsers");
                });

            modelBuilder.Entity("DataLayer.Data.Journalentry", b =>
                {
                    b.Navigation("JournalEntryNutritionalInfo");

                    b.Navigation("JournalEntryTags");
                });

            modelBuilder.Entity("DataLayer.Data.Nutritionalinfo", b =>
                {
                    b.Navigation("JournalEntryNutritionalInfo");
                });

            modelBuilder.Entity("DataLayer.Data.Tag", b =>
                {
                    b.Navigation("JournalEntryTags");
                });

            modelBuilder.Entity("DataLayer.Data.User", b =>
                {
                    b.Navigation("ExternalServiceUsers");

                    b.Navigation("Userpassword");
                });
#pragma warning restore 612, 618
        }
    }
}
