using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Configurations;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Extensions;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Converters;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Infrastructure.EntityFrameworkDataAccess
{
    public class Context : DbContext
    {
        public const string DbName = "ManagementSystem";

        public Context(DbContextOptions<Context> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder
                .Properties<string>()
                .AreUnicode(true)
                .HaveMaxLength(500);
            configurationBuilder
                .Properties<Enum>()
                .HaveMaxLength(500);

            configurationBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                        .ApplyConfiguration(new TeacherEntityConfiguration())
                        .ApplyConfiguration(new StudentEntityConfiguration());

            modelBuilder.ConvertEnumsToStrings();
        }
    }
}
