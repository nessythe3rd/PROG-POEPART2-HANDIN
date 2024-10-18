using Microsoft.EntityFrameworkCore;
using tester_final.Models.Entities;

namespace tester_final.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<UploadDocument> UploadDocuments { get; set; }
    }
}
