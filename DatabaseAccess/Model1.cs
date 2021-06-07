using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseAccess
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<History_Buy> History_Buy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.parent_category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.thumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.sub_category)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.idProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.History_Buy)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.idProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.parent_category)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.sub_category);

            modelBuilder.Entity<User>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.googleID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.facebookID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.History_Buy)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Favorite>()
                .Property(e => e.idUser)
                .IsUnicode(false);

            modelBuilder.Entity<Favorite>()
                .Property(e => e.idProduct)
                .IsUnicode(false);

            modelBuilder.Entity<History_Buy>()
                .Property(e => e.idUser)
                .IsUnicode(false);

            modelBuilder.Entity<History_Buy>()
                .Property(e => e.idProduct)
                .IsUnicode(false);
        }
    }
}
