using CasgemMicroservice.Services.Discount.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CasgemMicroservice.Services.Discount.Context
{
	public class DapperContext : DbContext
	{
		/*private readonly IConfiguration _configuration;
		private readonly string _connectionstrings;
		private readonly DbContext _context;
		*/
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CasgemDiscountDb;User=sa;Password=123456Aa*");

		}
		/*
		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionstrings = _configuration.GetConnectionString("DefaultConnection");
		}*/

        public DbSet<DiscountCoupons> DiscountCouponses { get; set; }

       // public IDbConnection CreateConnection() => new SqlConnection(_connectionstrings);
	}
}
