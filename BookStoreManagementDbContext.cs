using BookStoreManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreManagement.DataAccessLayer
{
    public class BookStoreManagementDbContext : DbContext
    {
        public BookStoreManagementDbContext()
        {

        }

        public BookStoreManagementDbContext(DbContextOptions<BookStoreManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Transcations> Transcations { get; set; }
    }
}
