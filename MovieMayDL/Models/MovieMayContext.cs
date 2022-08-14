using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MovieMayDL.Models
{
    public partial class MovieMayContext : DbContext
    {
        public MovieMayContext()
        {
        }

        public MovieMayContext(DbContextOptions<MovieMayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MAYROSEANTONY\\SQLExpress;Database=MovieMay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("PK__movies__7C8D7D29CC972A22");

                entity.ToTable("movies");

                entity.Property(e => e.MId).HasColumnName("m_id");

                entity.Property(e => e.About)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.Director)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("director");

                entity.Property(e => e.Genre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Poster)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("poster");

                entity.Property(e => e.Producer)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("producer");

                entity.Property(e => e.Rating)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rating");

                entity.Property(e => e.Release)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("release");

                entity.Property(e => e.Starring)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("starring");

                entity.Property(e => e.Trailer)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("trailer");

                entity.Property(e => e.Watchtime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("watchtime");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__reviews__C4762327ACA6A36E");

                entity.ToTable("reviews");

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.PostDatetime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("post_datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MailNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Mail)
                    .HasConstraintName("FK__reviews__mail__38996AB5");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__reviews__movie_i__37A5467C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__users__AB6E61656D26CDA4");

                entity.ToTable("users");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pwd");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
