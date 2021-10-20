using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OdosVids.Data
{
    public partial class ODOSVIDSContext : DbContext
    {
        public ODOSVIDSContext()
        {
        }

        public ODOSVIDSContext(DbContextOptions<ODOSVIDSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerSchedule> CustomerSchedules { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\;Initial Catalog=ODOSVIDS;Trusted_Connection=False;user id=totalsecret;password=5TP6DSVV!b;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.CellNumber).HasMaxLength(50);

                entity.Property(e => e.ChildName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.StopOn).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Children_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerName).HasMaxLength(250);
            });

            modelBuilder.Entity<CustomerSchedule>(entity =>
            {
                entity.Property(e => e.MessageOn).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSchedules)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSchedules_Customers");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.CustomerSchedules)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSchedules_Videos");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("Message");

                entity.Property(e => e.SentOn).HasColumnType("datetime");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Children");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.VideoDesc)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VideoLink)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VideoName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
