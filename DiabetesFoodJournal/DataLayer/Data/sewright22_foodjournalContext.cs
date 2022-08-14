﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Data
{
    public partial class sewright22_foodjournalContext : DbContext
    {
        public sewright22_foodjournalContext()
        {
        }

        public sewright22_foodjournalContext(DbContextOptions<sewright22_foodjournalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dose> Doses { get; set; } = null!;
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Journalentry> Journalentries { get; set; } = null!;
        public virtual DbSet<Journalentrydose> Journalentrydoses { get; set; } = null!;
        public virtual DbSet<Journalentrynutritionalinfo> Journalentrynutritionalinfos { get; set; } = null!;
        public virtual DbSet<Journalentrytag> Journalentrytags { get; set; } = null!;
        public virtual DbSet<Nutritionalinfo> Nutritionalinfos { get; set; } = null!;
        public virtual DbSet<Password> Passwords { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userjournalentry> Userjournalentries { get; set; } = null!;
        public virtual DbSet<Userpassword> Userpasswords { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // TODO: Figure out how to access connection string from user secrets.
                optionsBuilder.UseMySql("", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.6.44-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Dose>(entity =>
            {
                entity.ToTable("doses");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Extended).HasColumnType("int(11)");

                entity.Property(e => e.InsulinAmount).HasPrecision(18, 2);

                entity.Property(e => e.TimeExtended).HasPrecision(18, 2);

                entity.Property(e => e.TimeOffset).HasColumnType("int(11)");

                entity.Property(e => e.UpFront).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Journalentry>(entity =>
            {
                entity.ToTable("journalentries");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Logged).HasMaxLength(6);

                entity.Property(e => e.Notes)
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Title)
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<Journalentrydose>(entity =>
            {
                entity.ToTable("journalentrydoses");

                entity.HasIndex(e => e.DoseId, "IX_JournalEntryDoses_DoseId");

                entity.HasIndex(e => e.JournalEntryId, "IX_JournalEntryDoses_JournalEntryId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DoseId).HasColumnType("int(11)");

                entity.Property(e => e.JournalEntryId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Journalentrynutritionalinfo>(entity =>
            {
                entity.ToTable("journalentrynutritionalinfos");

                entity.HasIndex(e => e.JournalEntryId, "IX_JournalEntryNutritionalInfos_JournalEntryId");

                entity.HasIndex(e => e.NutritionalInfoId, "IX_JournalEntryNutritionalInfos_NutritionalInfoId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.JournalEntryId).HasColumnType("int(11)");

                entity.Property(e => e.NutritionalInfoId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Journalentrytag>(entity =>
            {
                entity.ToTable("journalentrytags");

                entity.HasIndex(e => e.JournalEntryId, "IX_JournalEntryTags_JournalEntryId");

                entity.HasIndex(e => e.TagId, "IX_JournalEntryTags_TagId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.JournalEntryId).HasColumnType("int(11)");

                entity.Property(e => e.TagId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Nutritionalinfo>(entity =>
            {
                entity.ToTable("nutritionalinfos");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Calories).HasColumnType("int(11)");

                entity.Property(e => e.Carbohydrates).HasColumnType("int(11)");

                entity.Property(e => e.Protein).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("passwords");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<Userjournalentry>(entity =>
            {
                entity.ToTable("userjournalentries");

                entity.HasIndex(e => e.JournalEntryId, "IX_UserJournalEntries_JournalEntryId");

                entity.HasIndex(e => e.UserId, "IX_UserJournalEntries_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.JournalEntryId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Userpassword>(entity =>
            {
                entity.ToTable("userpasswords");

                entity.HasIndex(e => e.PasswordId, "IX_UserPasswords_PasswordId");

                entity.HasIndex(e => e.UserId, "IX_UserPasswords_UserId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PasswordId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}