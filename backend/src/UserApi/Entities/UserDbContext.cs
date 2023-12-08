﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Entities;

public partial class UserDbContext : DbContext
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    
    public virtual DbSet<Chatroom> Chatrooms { get; set; }
    public virtual DbSet<ChatHistory> ChatHistory { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:UserDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.HasIndex(e => e.Email, "Users_Email_key").IsUnique();

            entity.HasIndex(e => e.Username, "Users_Username_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FailedLoginAttempts).HasDefaultValueSql("0");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValueSql("true");
            entity.Property(e => e.LastLogin).HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        modelBuilder.Entity<Chatroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Chatrooms_pkey");

            entity.Property(e => e.UserId).HasMaxLength(36);

            entity.HasIndex(e => e.Title, "Chatrooms_Title_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Capacity).HasDefaultValueSql("0");
            entity.Property(e => e.TotalUsers).HasDefaultValueSql("0");
        });
        
        modelBuilder.Entity<ChatHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ChatHistory_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Message).HasMaxLength(4096);
            entity.Property(e => e.RoomId).HasMaxLength(36);
            entity.Property(e => e.UserId).HasMaxLength(36);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
