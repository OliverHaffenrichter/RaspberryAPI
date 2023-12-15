using Microsoft.EntityFrameworkCore;
using RaspberryAPI.Models;

namespace RaspberryAPI.DBContext
{
    public class ScannerDbContext : DbContext
    {
        private readonly string _connectionString;

        public ScannerDbContext(DbContextOptions<ScannerDbContext> options, string connectionString)
            : base(options)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_connectionString);
            }
        }

        public DbSet<ScannedData> scanneddata { get; set; }
    }
}
