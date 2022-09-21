using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
    }
}