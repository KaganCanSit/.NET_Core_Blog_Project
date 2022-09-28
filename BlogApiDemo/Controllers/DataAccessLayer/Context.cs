using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.Controllers.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL Adres İsmi (Bağlantı Adresi) - Oluşturulacak Database İsmi 
            optionsBuilder.UseSqlServer(@"Server=KAGANCANSIT; Database=CoreBlogApiDB; Integrated Security=True; Trusted_Connection=True;");
        }
        public DbSet<Employee> Employees  { get; set; }
    }
}
