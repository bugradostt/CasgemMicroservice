using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Payment.WebApi.Dal
{
    public class PaymentContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PaymentCasgemDb;User=sa;Password=123456Aa*");
        }

        public DbSet<PaymentDetail> PaymentDetails  { get; set; }
    }
}
