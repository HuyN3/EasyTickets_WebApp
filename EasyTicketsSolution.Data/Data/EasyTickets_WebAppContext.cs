using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasyTicketsSolution.Data.Data
{
    public partial class EasyTickets_WebAppContext : DbContext
    {
        public EasyTickets_WebAppContext()
        {
        }

        public EasyTickets_WebAppContext(DbContextOptions<EasyTickets_WebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ShowAsignment> ShowAsignments { get; set; } = null!;
        public virtual DbSet<ShowType> ShowTypes { get; set; } = null!;
        public virtual DbSet<Theater> Theaters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EasyTickets_WebApp;User ID=sa;Password=100199");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.DateBooking).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Booking__UserId__4222D4EF");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.ToTable("Booking_Detail");

                entity.Property(e => e.BookingDetailId).HasColumnName("Booking_DetailId");

                entity.Property(e => e.Seat)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Booking_D__Booki__46E78A0C");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Booking_D__Servi__44FF419A");

                entity.HasOne(d => d.ShowAsignment)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ShowAsignmentId)
                    .HasConstraintName("FK__Booking_D__ShowA__45F365D3");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasColumnName("Zip_Code");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.Publisher).HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.ShowType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ShowTypeId)
                    .HasConstraintName("FK__Product__ShowTyp__30F848ED");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(20);

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__UserId__3F466844"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__RoleId__3E52440B"),
                        j =>
                        {
                            j.HasKey("RoleId", "UserId").HasName("PK__UserRole__5B8242DE07A9F662");

                            j.ToTable("UserRole");
                        });
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TheaterId)
                    .HasConstraintName("FK__Room__TheaterId__29572725");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceDescription).HasMaxLength(100);

                entity.Property(e => e.ServicePrice).HasColumnType("money");

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TheaterId)
                    .HasConstraintName("FK__Service__Theater__2C3393D0");
            });

            modelBuilder.Entity<ShowAsignment>(entity =>
            {
                entity.ToTable("ShowAsignment");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ShowTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShowAsignments)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ShowAsign__Produ__34C8D9D1");

                entity.HasOne(d => d.Romm)
                    .WithMany(p => p.ShowAsignments)
                    .HasForeignKey(d => d.RommId)
                    .HasConstraintName("FK__ShowAsign__RommI__35BCFE0A");
            });

            modelBuilder.Entity<ShowType>(entity =>
            {
                entity.ToTable("ShowType");

                entity.Property(e => e.ShowTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Theater>(entity =>
            {
                entity.ToTable("Theater");

                entity.Property(e => e.TheaterName).HasMaxLength(100);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Theaters)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Theater__CityId__267ABA7A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534091590DB")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456FF4291F8")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
