using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using MomokoBlog.Classifications;
using Volo.Abp.EntityFrameworkCore.Modeling;
using MomokoBlog.Comments;
using MomokoBlog.Tags;
using MomokoBlog.Posts;

namespace MomokoBlog.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MomokoBlogDbContext :
    AbpDbContext<MomokoBlogDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

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

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Classification> Classifications { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostTag> PostTags { get; set; }

    public MomokoBlogDbContext(DbContextOptions<MomokoBlogDbContext> options)
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
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MomokoBlogConsts.DbTablePrefix + "YourEntities", MomokoBlogConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        /* Configure your own tables/entities inside here */
        //add Post
        builder.Entity<Post>(b =>
        {
            b.ToTable("Posts");
            b.ConfigureByConvention();
            b.Property(x => x.Title)
                  .HasMaxLength(PostConsts.MaxTitleLength)
                  .IsRequired();
            b.Property(x => x.Description).HasMaxLength(PostConsts.MaxDescriptionLength);
            b.Property(x => x.Author).HasMaxLength(PostConsts.MaxAuthorLength); ;
            b.Property(x => x.Picture).HasMaxLength(PostConsts.MaxImageUrlLength);

            //one-to-many relationship with Classification table
            b.HasOne<Classification>().WithMany().HasForeignKey(x => x.ClassId).IsRequired();
            //many-to-many relationship with Category table => BookCategories
            b.HasMany(x => x.PostTags).WithOne().HasForeignKey(x => x.PostId).IsRequired();

            b.HasIndex(x => x.Title);
            b.HasIndex(x => x.ClassId);
            b.HasIndex(x => x.IsTop);
        });
        //Classification
        builder.Entity<Classification>(b =>
        {
            b.ToTable("Classifications");
            b.ConfigureByConvention();
            b.Property(x => x.Description).HasMaxLength(ClassificationConsts.MaxDescriptionLength);
            b.Property(x => x.Name).HasMaxLength(ClassificationConsts.MaxNameLength); ;

        });
        //Comment
        builder.Entity<Comment>(b =>
        {
            b.ToTable("Comments");
            b.ConfigureByConvention();
            b.Property(x => x.Description).HasMaxLength(CommentConsts.MaxDescriptionLength);
            b.Property(x => x.Title).HasMaxLength(CommentConsts.MaxNameLength); ;
            b.HasIndex(x => x.Title);
        });
        //Tag
        builder.Entity<Tag>(b =>
        {
            b.ToTable("Tags");
            b.ConfigureByConvention();
            b.Property(x => x.Name).HasMaxLength(ClassificationConsts.MaxNameLength); ;
            b.Property(x => x.NickName).HasMaxLength(TagConsts.MaxNickNameLength);

        });

        // PostTag
        builder.Entity<PostTag>(b =>
        {
            b.ToTable("PostTags");
            b.ConfigureByConvention();

            //define composite key
            b.HasKey(x => new { x.PostId, x.TagId });

            //many-to-many configuration
            b.HasOne<Post>().WithMany(x => x.PostTags).HasForeignKey(x => x.PostId).IsRequired();
            b.HasOne<Tag>().WithMany().HasForeignKey(x => x.TagId).IsRequired();

            b.HasIndex(x => new { x.PostId, x.TagId });
        });
    }
}
