using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FiLimsTest.Data;

// Hand-written partial that supplements the scaffolded FossLimsExportContext.
// Kept in a separate file so re-running `dotnet ef dbcontext scaffold` (which
// overwrites FossLimsExportContext.cs) does not clobber this configuration.
public partial class FossLimsExportContext
{
    // The connection string lives in User Secrets (out of source control), under
    //   ConnectionStrings:FossLimsExport
    // Set it with:
    //   dotnet user-secrets set "ConnectionStrings:FossLimsExport" "<connection string>"
    private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
        .AddUserSecrets<FossLimsExportContext>()
        .Build();

    // Parameterless constructor so the WPF app can do `new FossLimsExportContext()`
    // without setting up dependency injection.
    public FossLimsExportContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Configuration.GetConnectionString("FossLimsExport")
                ?? throw new InvalidOperationException(
                    "Connection string 'FossLimsExport' was not found. Configure it with: " +
                    "dotnet user-secrets set \"ConnectionStrings:FossLimsExport\" \"<connection string>\"");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
