namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBNews : DbContext
    {
        public DBNews()
            : base("name=DBNews")
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.News)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.News1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.UpdatedUser);
        }
    }
}
