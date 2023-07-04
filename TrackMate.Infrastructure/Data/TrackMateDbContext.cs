using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackMate.Domain.Common;
using TrackMate.Domain.Entities;
using Task = TrackMate.Domain.Entities.Task;

namespace TrackMate.Infrastructure.Data;
public class TrackMateDbContext : IdentityDbContext<User, IdentityRole, string, IdentityUserClaim<string>, ProjectMember, UserLogin, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public TrackMateDbContext(DbContextOptions<TrackMateDbContext> options) : base(options)
    {
    }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<CommentContent> CommentContents { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<SubTask> SubTasks { get; set; }

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigureAttachments(modelBuilder);
        ConfigureIdentityEntities(modelBuilder);
        ConfigureUsers(modelBuilder);

    }

    #endregion

    #region Private Method

    private void ConfigureUsers(ModelBuilder modelBuilder)
    {
        //// Configure cascade delete behavior for Task and User
        //modelBuilder.Entity<Task>()
        //    .HasOne(t => t.AssignedUser)
        //    .WithMany()
        //    .HasForeignKey(t => t.AssignedUserId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Task>()
        //    .HasOne(t => t.CreatedBy)
        //    .WithMany()
        //    .HasForeignKey(t => t.UserId)
        //    .OnDelete(DeleteBehavior.Restrict);

        // Configure cascade delete behavior for SubTask and User
        //modelBuilder.Entity<SubTask>()
        //    .HasOne(st => st.AssignedUser)
        //    .WithMany()
        //    .HasForeignKey(st => st.AssignedUserId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<SubTask>()
        //    .HasOne(st => st.CreatedBy)
        //    .WithMany()
        //    .HasForeignKey(st => st.UserId)
        //    .OnDelete(DeleteBehavior.Restrict);

        // Configure cascade delete behavior for Comment and User
        //modelBuilder.Entity<Comment>()
        //    .HasOne(st => st.CreatedBy)
        //    .WithMany()
        //    .HasForeignKey(st => st.UserId)
        //    .OnDelete(DeleteBehavior.Restrict);

    }
    private void ConfigureAttachments(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Attachment>()
        //    .HasOne(a => a.Task)
        //    .WithMany()
        //    .HasForeignKey(a => a.TaskId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //modelBuilder.Entity<Attachment>()
        //    .HasOne(a => a.SubTask)
        //    .WithMany()
        //    .HasForeignKey(a => a.SubTaskId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //modelBuilder.Entity<Attachment>()
        //    .HasOne(a => a.Comment)
        //    .WithMany()
        //    .HasForeignKey(a => a.CommentId)
        //    .OnDelete(DeleteBehavior.SetNull);
    }

    private void ConfigureIdentityEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        modelBuilder.Entity<ProjectMember>()
            .HasKey(pm => new { pm.UserId, pm.RoleId, pm.ProjectId });
    }
    #endregion
    #region Overridden Methods  
    public override int SaveChanges()
    {
        ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Added).ToList().ForEach(x =>
        {
            ((BaseModel)x.Entity).CreatedAt = DateTime.UtcNow;
        });
        ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Modified).ToList().ForEach(x =>
        {
            ((BaseModel)x.Entity).UpdatedAt = DateTime.UtcNow;
        });

        var result = base.SaveChanges();
        return result;
    }

    /// <summary>
    /// override savechangesasync method
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Added).ToList().ForEach(x =>
        {
            ((BaseModel)x.Entity).CreatedAt = DateTime.UtcNow;
        });
        ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Modified).ToList().ForEach(x =>
        {
            ((BaseModel)x.Entity).UpdatedAt = DateTime.UtcNow;
        });

        Task<int> result;
        result = base.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion

}
