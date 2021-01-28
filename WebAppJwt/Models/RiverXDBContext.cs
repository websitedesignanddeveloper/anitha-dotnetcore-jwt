using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAppJwt.Models
{
    public partial class RiverXDBContext : DbContext
    {
        public RiverXDBContext()
        {
        }

        public RiverXDBContext(DbContextOptions<RiverXDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<InputCrossing> InputCrossings { get; set; }
        public virtual DbSet<InputEca> InputEcas { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=RiverXDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("Case");

                entity.Property(e => e.CaseId).ValueGeneratedNever();

                entity.Property(e => e.CaseDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CaseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsEcaanalysisAvail).HasColumnName("isECAAnalysisAvail");

                entity.Property(e => e.IsFatigueAnalysisAvail).HasColumnName("isFatigueAnalysisAvail");

                entity.Property(e => e.IsModelAvail).HasColumnName("isModelAvail");

                entity.Property(e => e.IsStaticAnalysisAvail).HasColumnName("isStaticAnalysisAvail");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InputCrossing>(entity =>
            {
                entity.HasKey(e => e.CrossingId);

                entity.ToTable("InputCrossing");

                entity.Property(e => e.CrossingId).ValueGeneratedNever();

                entity.Property(e => e.CaseFid).HasColumnName("CaseFID");

                entity.Property(e => e.IsGapRange)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("isGapRange");

                entity.Property(e => e.IsLspanRange)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("isLspanRange");

                entity.Property(e => e.MaxEOnD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("max_e_on_D");

                entity.Property(e => e.MaxL)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("max_L");

                entity.Property(e => e.MinDeltaOnD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("min_Delta_on_D");

                entity.Property(e => e.MinEOnD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("min_e_on_D");

                entity.Property(e => e.MinHeOnD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("min_He_on_D");

                entity.Property(e => e.MinL)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("min_L");

                entity.Property(e => e.MinTheta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("min_theta");

                entity.Property(e => e.MinZOnD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("min_z_on_D");

                entity.Property(e => e.NumEOnD)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("num_e_on_D");

                entity.Property(e => e.NumL)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("num_L");
            });

            modelBuilder.Entity<InputEca>(entity =>
            {
                entity.HasKey(e => e.EcaId);

                entity.ToTable("InputECA");

                entity.Property(e => e.EcaId)
                    .ValueGeneratedNever()
                    .HasColumnName("EcaID");

                entity.Property(e => e.CapLength)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CaseFid).HasColumnName("CaseFID");

                entity.Property(e => e.CrackH)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrackLen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrackLigament)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrackType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cvn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CVN");

                entity.Property(e => e.EpsLuderEnd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpsLuderEndFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpsUts)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("epsUTS");

                entity.Property(e => e.EpsY)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("epsY");

                entity.Property(e => e.Fadoption)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FADOption");

                entity.Property(e => e.Fcgr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FCGR");

                entity.Property(e => e.FracToughType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HiLo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsLuderPlateau)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kmat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadingEntryType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lrmax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LrmaxUserFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pb)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qb)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RootLength)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SigmaEpsUserFlag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uts)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UTS");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Membership");

                entity.Property(e => e.MembershipType)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Tpamcommittees)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("TPAMCommittees");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.OrganizationId).ValueGeneratedNever();

                entity.Property(e => e.Membership)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Groups)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Organization)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
