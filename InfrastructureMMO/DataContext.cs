using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using InfrastructureMMO.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace InfrastructureMMO
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BrowserEntity> BrowserEntity { get; set; }

        private readonly string _connectionString;

        public DataContext() // SQL Server connection string
            => _connectionString = "Server=DESKTOP-D1B32EL;Database=AdminEyesMMO;Trusted_Connection=True;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_connectionString);

        private void SeedData()
        {
            if (!Users.Any())
            {
                Users.Add(new UserEntity { Id = Guid.NewGuid().ToString(),  Email = "Email@email.com", Status = "Updated", LastUpdatePwd = DateTime.Now });
                SaveChanges();
            }
        }
    }
}
