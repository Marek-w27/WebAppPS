using Microsoft.EntityFrameworkCore;
using WebAppPS.Entity;

#nullable disable

namespace WebAppPS.Models
{
    public partial class RekrutacjaContext : DbContext
    {
        public RekrutacjaContext()
        {
        }

        public RekrutacjaContext(DbContextOptions<RekrutacjaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Klienci> Klienci { get; set; }
        public virtual DbSet<KlienciKontrahenci> KlienciKontrahencis { get; set; }

        public virtual DbSet<Weryfikacja> Weryfikacja { set; get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseLazyLoadingProxies();


        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-LV3SD93\\SQLEXPRESS;Database=Rekrutacja;Trusted_Connection=True;");
        //    }
       // }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.ToTable("klienci");

                entity.Property(e => e.DataDodania).HasColumnType("datetime");

                entity.Property(e => e.DataPodpisaniaUmowy).HasColumnType("datetime");

                entity.Property(e => e.LimitNaUmowie).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.NazwaPelna).HasMaxLength(250);

                entity.Property(e => e.NazwaSkrocona).HasMaxLength(150);

                entity.Property(e => e.Nip)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NumerUmowy).HasMaxLength(50);

                entity.Property(e => e.Profil)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Rola)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KlienciKontrahenci>(entity =>
            {
                entity.HasKey(e => new { e.IdKlienta, e.IdKontrahenta })
                    .HasName("PK__klienci___25DE50FD09E17413");

                entity.ToTable("klienci_kontrahenci");

                entity.Property(e => e.LimitNaUmowie).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.IdKlientaNavigation)
                    .WithMany(p => p.KlienciKontrahenciIdKlientaNavigations)
                    .HasForeignKey(d => d.IdKlienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__klienci_k__IdKli__267ABA7A");

                entity.HasOne(d => d.IdKontrahentaNavigation)
                    .WithMany(p => p.KlienciKontrahenciIdKontrahentaNavigations)
                    .HasForeignKey(d => d.IdKontrahenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__klienci_k__IdKon__276EDEB3");
            });


            modelBuilder.Entity<Weryfikacja>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Weryfikacja");

                entity.Property(e => e.DataWysz).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Weryfikacja1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Weryfikacja")
                    .IsFixedLength(true);

                entity.Property(e => e.WyszNip)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

         

        OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
