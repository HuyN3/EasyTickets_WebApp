using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasyTicketsSolution.WebApp.Data
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
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ShowAsignment> ShowAsignments { get; set; } = null!;
        public virtual DbSet<ShowType> ShowTypes { get; set; } = null!;
        public virtual DbSet<Theater> Theaters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SJNFETB\\SQLEXPRESS;Initial Catalog=EasyTickets_WebApp;User ID=sa;Password=100199;Trusted_Connection=True");
//            }
//        }

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
                    .HasConstraintName("FK__Booking__Custome__571DF1D5");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.ToTable("Booking_Detail");

                entity.Property(e => e.BookingDetailId).HasColumnName("Booking_DetailId");

                entity.Property(e => e.Seat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Booking_D__Booki__59FA5E80");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Booking_D__Servi__5BE2A6F2");

                entity.HasOne(d => d.ShowAsignment)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ShowAsignmentId)
                    .HasConstraintName("FK__Booking_D__ShowA__5AEE82B9");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasColumnName("Zip_code");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Mail, "UQ__Customer__2724B2D155A2B240")
                    .IsUnique();

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                //entity.HasOne(d => d.Customer)
                //    .WithMany(p => p.Users)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK__Customer__UserId__5441852A");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Publisher).HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TheaterId)
                    .HasConstraintName("FK__Room__TheaterId__3D5E1FD2");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TheaterId)
                    .HasConstraintName("FK__Service__Theater__3A81B327");
            });

            modelBuilder.Entity<ShowAsignment>(entity =>
            {
                entity.ToTable("ShowAsignment");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ShowTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShowAsignments)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ShowAsign__Produ__440B1D61");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ShowAsignments)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__ShowAsign__RoomI__44FF419A");
            });

            modelBuilder.Entity<ShowType>(entity =>
            {
                entity.ToTable("ShowType");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Theater>(entity =>
            {
                entity.ToTable("Theater");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E440DCB511")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__RoleId__5070F446"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__UserId__4F7CD00D"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF2760ADB6DE45EE");

                            j.ToTable("UserRole");
                        });
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Customer__UserId__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
