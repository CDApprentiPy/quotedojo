using Microsoft.EntityFrameworkCore;

namespace newqd.Models
{
    public class newqdContext : DbContext
    {
        public newqdContext(DbContextOptions<newqdContext> options) : base(options) 
        {

        }

        public DbSet<Author> authors {get; set;}
        public DbSet<Category> category {get; set;}
        // category
        public DbSet<Meta> metas {get; set;}
        // categoryquote
        public DbSet<QuoteCat> quotecategory {get; set;}
        // quotes
        public DbSet<Quote> quotes {get; set;}
    }
}