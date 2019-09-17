using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HorsesWebAPI.Models
{
    public partial class horsesContext : DbContext
    {
        public horsesContext()
        {
        }

        public horsesContext(DbContextOptions<horsesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Characteristic> Characteristic { get; set; }
        public virtual DbSet<Evaluate> Evaluate { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Eventcharacteristic> Eventcharacteristic { get; set; }
        public virtual DbSet<Eventhclass> Eventhclass { get; set; }
        public virtual DbSet<Eventhorse> Eventhorse { get; set; }
        public virtual DbSet<Hclass> Hclass { get; set; }
        public virtual DbSet<Horse> Horse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseNpgsql("Host=localhost;Database=horses;Username=postgres;Password=1488");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.ToTable("characteristic");

                entity.Property(e => e.Characteristicid)
                    .HasColumnName("characteristicid")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Evaluate>(entity =>
            {
                entity.ToTable("evaluate");

                entity.Property(e => e.Evaluateid)
                    .HasColumnName("evaluateid")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Characteristicid).HasColumnName("characteristicid");

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Horseid).HasColumnName("horseid");

                entity.Property(e => e.Judge).HasColumnName("judge");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.Evaluate)
                    .HasForeignKey(d => d.Characteristicid)
                    .HasConstraintName("evaluate_characteristicid_fkey");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Evaluate)
                    .HasForeignKey(d => d.Eventid)
                    .HasConstraintName("evaluate_eventid_fkey");

                entity.HasOne(d => d.Horse)
                    .WithMany(p => p.Evaluate)
                    .HasForeignKey(d => d.Horseid)
                    .HasConstraintName("evaluate_horseid_fkey");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.Eventid)
                    .HasColumnName("eventid")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasColumnType("character varying");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("eventdate")
                    .HasColumnType("date");

                entity.Property(e => e.Judges).HasColumnName("judges");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Eventcharacteristic>(entity =>
            {
                entity.HasKey(e => new { e.Eventid, e.Characteristicid })
                    .HasName("eventcharacteristic_pkey");

                entity.ToTable("eventcharacteristic");

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Characteristicid).HasColumnName("characteristicid");

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.Eventcharacteristic)
                    .HasForeignKey(d => d.Characteristicid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventcharacteristic_characteristicid_fkey");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Eventcharacteristic)
                    .HasForeignKey(d => d.Eventid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventcharacteristic_eventid_fkey");
            });

            modelBuilder.Entity<Eventhclass>(entity =>
            {
                entity.HasKey(e => new { e.Eventid, e.Hclassid })
                    .HasName("eventhclass_pkey");

                entity.ToTable("eventhclass");

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Hclassid).HasColumnName("hclassid");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Eventhclass)
                    .HasForeignKey(d => d.Eventid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventhclass_eventid_fkey");

                entity.HasOne(d => d.Hclass)
                    .WithMany(p => p.Eventhclass)
                    .HasForeignKey(d => d.Hclassid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventhclass_hclassid_fkey");
            });

            modelBuilder.Entity<Eventhorse>(entity =>
            {
                entity.HasKey(e => new { e.Eventid, e.Horseid })
                    .HasName("eventhorse_pkey");

                entity.ToTable("eventhorse");

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Horseid).HasColumnName("horseid");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Eventhorse)
                    .HasForeignKey(d => d.Eventid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventhorse_eventid_fkey");

                entity.HasOne(d => d.Horse)
                    .WithMany(p => p.Eventhorse)
                    .HasForeignKey(d => d.Horseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventhorse_horseid_fkey");
            });

            modelBuilder.Entity<Hclass>(entity =>
            {
                entity.ToTable("hclass");

                entity.Property(e => e.Hclassid)
                    .HasColumnName("hclassid")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Horse>(entity =>
            {
                entity.ToTable("horse");

                entity.Property(e => e.Horseid)
                    .HasColumnName("horseid")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Hclassid).HasColumnName("hclassid");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Hclass)
                    .WithMany(p => p.Horse)
                    .HasForeignKey(d => d.Hclassid)
                    .HasConstraintName("horse_classid_fkey");
            });
        }
    }
}
