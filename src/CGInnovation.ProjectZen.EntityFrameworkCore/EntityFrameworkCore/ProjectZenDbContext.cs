using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

using CGInnovation.ProjectZen.Risks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.Strategies;
using CGInnovation.ProjectZen.RisksProjects;

namespace CGInnovation.ProjectZen.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class ProjectZenDbContext : AbpDbContext<ProjectZenDbContext>, IIdentityDbContext, ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        public DbSet<Risk> Risks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Strategy> Strategies { get; set; }

        #region Identity

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        #endregion

        #region Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
        #endregion

        public ProjectZenDbContext(DbContextOptions<ProjectZenDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            //builder.Ignore<RiskProject>();

            /* Configure your own tables/entities inside here */
            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ProjectZenConsts.DbTablePrefix + "YourEntities", ProjectZenConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Risk>(b =>
            {
                //b.Ignore(b => b.Projects); //todo (My): remove  the line later
                b.ToTable(ProjectZenConsts.DbTablePrefix + "Risks", ProjectZenConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure fore the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });

            builder.Entity<Project>(b =>
            {
                //b.Ignore(b => b.Risks); //todo (My): remove  the line later
                b.ToTable(ProjectZenConsts.DbTablePrefix + "Projects", ProjectZenConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(ProjectConsts.MaxNameLength);
                b.HasIndex(x => x.Name);
            });

            //builder.Entity<RiskProject>(e =>
            //{
            //    e.HasKey(rp => new { rp.RiskId, rp.ProjectId });
            //    e.ToTable(ProjectZenConsts.DbTablePrefix + "RisksProjects", ProjectZenConsts.DbSchema);
            //    e.ConfigureByConvention();
            //});

            builder.Entity<RiskProject>(e =>
            {
                e.HasKey(rp => new { rp.RiskId, rp.ProjectId });
                e.HasOne(sc => sc.Risk)
                    .WithMany(s => s.RisksOfProject)
                    .HasForeignKey(sc => sc.RiskId).IsRequired();
                e.HasOne(sc => sc.Project)
                    .WithMany(c => c.RisksOfProject)
                    .HasForeignKey(sc => sc.ProjectId).IsRequired();
                e.HasIndex(rp => new { rp.RiskId, rp.ProjectId });
                e.ToTable(ProjectZenConsts.DbTablePrefix + "RisksProjects", ProjectZenConsts.DbSchema);
                e.ConfigureByConvention();
            });

            builder.Entity<Strategy>(b =>
            {
                b.ToTable(ProjectZenConsts.DbTablePrefix + "Strategies", ProjectZenConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired(false);
                b.HasIndex(x => x.Name);
            });
        }
    }
}
