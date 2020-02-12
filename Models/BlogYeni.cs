namespace Blogg.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogYeni : DbContext
    {
        public BlogYeni()
            : base("name=BlogYeni1")
        {
        }

        public virtual DbSet<Etiket> Etikets { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Makale> Makales { get; set; }
        public virtual DbSet<Resim> Resims { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Yazar> Yazars { get; set; }
        public virtual DbSet<YazarTakip> YazarTakips { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makales)
                .WithMany(e => e.Etikets)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.Kategori)
                .HasForeignKey(e => e.KategoriID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.YazarTakips)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Resims)
                .WithOptional(e => e.Makale)
                .HasForeignKey(e => e.MakaleID);

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorums)
                .WithRequired(e => e.Makale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Makales)
                .WithOptional(e => e.Resim)
                .HasForeignKey(e => e.ResimID);

            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Yazars)
                .WithOptional(e => e.Resim)
                .HasForeignKey(e => e.ResimID);

            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Yazars1)
                .WithOptional(e => e.Resim1)
                .HasForeignKey(e => e.ResimID);

            modelBuilder.Entity<Yazar>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.Yazar)
                .HasForeignKey(e => e.YazarID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yazar>()
                .HasMany(e => e.Resims)
                .WithOptional(e => e.Yazar)
                .HasForeignKey(e => e.YazarID);

            modelBuilder.Entity<Yazar>()
                .HasMany(e => e.YazarTakips)
                .WithRequired(e => e.Yazar)
                .HasForeignKey(e => e.YazarID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yazar>()
                .HasMany(e => e.YazarTakips1)
                .WithRequired(e => e.Yazar1)
                .HasForeignKey(e => e.YazarID)
                .WillCascadeOnDelete(false);
        }
    }
}
