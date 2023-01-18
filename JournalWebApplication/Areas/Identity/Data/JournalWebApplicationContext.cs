using JournalWebApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JournalWebApplication.Data;

public class JournalWebApplicationContext : IdentityDbContext<JournalWebApplicationUser>
{
    public JournalWebApplicationContext(DbContextOptions<JournalWebApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        //builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
       
    }
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        // получаем файл конфигурации
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        // устанавливаем для контекста строку подключения
        string connectionStringKey = configuration.GetSection("UseConnection").Value;
        option.UseNpgsql(configuration.GetConnectionString(connectionStringKey), options => options.SetPostgresVersion(new Version(9, 6)));
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<JournalWebApplicationUser>
{
    public void Configure(EntityTypeBuilder<JournalWebApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(256);
        builder.Property(u => u.LastName).HasMaxLength(256);
        builder.Property(u => u.MiddleName).HasMaxLength(256);
        builder.Property(u => u.Adress).HasMaxLength(256);
        builder.Property(u => u.BirthDate).HasMaxLength(256);
        builder.Property(u => u.PhoneNumber).HasMaxLength(256);
    }
}