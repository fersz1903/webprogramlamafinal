using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace moonCafeWebApp.Models;

public partial class MooncafedbContext : DbContext
{
    public MooncafedbContext()
    {
    }

    public MooncafedbContext(DbContextOptions<MooncafedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CmCategory> CmCategories { get; set; }

    public virtual DbSet<CmMenu> CmMenus { get; set; }

    public virtual DbSet<CmOrder> CmOrders { get; set; }

    public virtual DbSet<CmSong> CmSongs { get; set; }

    public virtual DbSet<CmUser> CmUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=MYSQL6008.site4now.net;database=db_a9a62c_cafedb;Uid=a9a62c_cafedb;Pwd=mooncafe12389", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_turkish_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CmCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cm_category");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ImagePath)
                .HasColumnType("text")
                .HasColumnName("imagePath");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CmMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cm_menu");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("categoryId");
            entity.Property(e => e.ImagePath)
                .HasColumnType("text")
                .HasColumnName("imagePath");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
        });

        modelBuilder.Entity<CmOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cm_order");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.TableNo)
                .HasColumnType("int(11)")
                .HasColumnName("tableNo");
        });

        modelBuilder.Entity<CmSong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cm_song");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.SongName)
                .HasMaxLength(200)
                .HasColumnName("songName");
            entity.Property(e => e.TableNo)
                .HasColumnType("int(11)")
                .HasColumnName("tableNo");
        });

        modelBuilder.Entity<CmUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cm_user");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Password)
                .HasColumnType("tinytext")
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
