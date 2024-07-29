using ECommerce.Discount.Entites;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ECommerce.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ONUR_PC\\SQLDENEME; initial catalog = ECommerceDiscountDb;Integrated Security = true");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection createConnection() => new SqlConnection(_connectionString);
    }
}
