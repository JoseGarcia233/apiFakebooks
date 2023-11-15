using FakeRestApiB.Entities;
using Microsoft.EntityFrameworkCore;

namespace FakeRestApiB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
