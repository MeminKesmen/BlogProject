using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class BlogDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=BlogDB;integrated security=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.SenderWriter)
                .WithMany(w => w.WriterSenders)
                .HasForeignKey(f => f.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.ReceiverWriter)
                .WithMany(w => w.WriterReceivers)
                .HasForeignKey(f => f.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Blog>()
                .ToTable(tb => tb.HasTrigger("AddBlogInRatingTable"));
            modelBuilder.Entity<Comment>()
                .ToTable(tb => tb.HasTrigger("AddScoreInComment"));

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<MailNewsLetter> MailNewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WriterRole> WriterRoles { get; set; }

    }
}
