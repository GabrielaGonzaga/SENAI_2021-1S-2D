using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HROADSContext : DbContext
    {
        public HROADSContext()
        {
        }

        public HROADSContext(DbContextOptions<HROADSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagen> Personagens { get; set; }
        public virtual DbSet<Relacao> Relacaos { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TiposDeUsuario> TiposDeUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-RGIIP6F; initial catalog=HROADS; user Id=sa; pwd=Semprepea10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classes__60FFF8015403C919");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F75281E7327B4");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__Habilidad__idTip__4BAC3F29");
            });

            modelBuilder.Entity<Personagen>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72EC7A77F62");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.CapacidadeMaMana)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("capacidadeMaMana");

                entity.Property(e => e.CapacidadeMaVida)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("capacidadeMaVida");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__5165187F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Personage__idUsu__60A75C0F");
            });

            modelBuilder.Entity<Relacao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Relacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Relacao__idClass__4D94879B");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Relacao__idHabil__4E88ABD4");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__TipoHabi__B197B8328241CE3E");

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposDeUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TiposDeU__03006BFF121C5A0A");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6D85EA0BA");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E616485926803")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.idTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.idTipoUsuario)
                    .HasConstraintName("FK__Usuarios__idTipo__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
