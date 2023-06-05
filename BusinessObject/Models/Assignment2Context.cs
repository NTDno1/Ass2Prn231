using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObject.Models
{
    public partial class Assignment2Context : DbContext
    {
        public Assignment2Context()
        {
        }

        public Assignment2Context(DbContextOptions<Assignment2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookAuthor> BookAuthors { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server =localhost; database = Assignment2;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("city");

                entity.Property(e => e.EmailAdress)
                    .HasMaxLength(50)
                    .HasColumnName("email_adress");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .HasColumnName("state");

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Advance)
                    .HasMaxLength(50)
                    .HasColumnName("advance");

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .HasColumnName("notes");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PubId).HasColumnName("pub_id");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("published_date");

                entity.Property(e => e.Royalty)
                    .HasMaxLength(50)
                    .HasColumnName("royalty");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.YtdSales)
                    .HasMaxLength(20)
                    .HasColumnName("ytd_sales");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK_Book_Role");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.BookId });

                entity.ToTable("BookAuthor");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorOrder)
                    .HasMaxLength(50)
                    .HasColumnName("author_order");

                entity.Property(e => e.RoyalityPercentage).HasColumnName("royality_percentage");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookAuthor_Author");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookAuthor_Book");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("PK__Publishe__2515F222307990B6");

                entity.ToTable("Publisher");

                entity.Property(e => e.PubId).HasColumnName("pub_id");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .HasColumnName("country");

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(20)
                    .HasColumnName("publisher_name");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleDesc).HasColumnName("role_desc");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PubId).HasColumnName("pub_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Source)
                    .HasMaxLength(30)
                    .HasColumnName("source");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
