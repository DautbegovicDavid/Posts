using Microsoft.EntityFrameworkCore;
using Posts.API.Models;

namespace Posts.API.Database
{
    public class PostsContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=BlogPosts;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlite(@"Data Source=C:\database\posts.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostID, pt.TagID });
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(b => b.tagList)
                .HasForeignKey(bc => bc.PostID);
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(c => c.postList)
                .HasForeignKey(bc => bc.TagID);
        }
      
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostsTags { get; set; }
    }
}
