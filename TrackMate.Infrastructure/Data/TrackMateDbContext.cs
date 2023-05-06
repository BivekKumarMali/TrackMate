using Microsoft.EntityFrameworkCore;
using TrackMate.Domain;
using TrackMate.Domain.Common;
using TrackMate.Domain.Entities;
using TrackMate.Domain.Enums;
using Task = TrackMate.Domain.Entities.Task;

namespace TrackMate.Infrastructure.Data;
public class TrackMateDbContext: DbContext
{
    public TrackMateDbContext(DbContextOptions<TrackMateDbContext> options) : base(options)
    {
    }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<CommentContent> CommentContents { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectMember> ProjectMembers { get; set; }
    public DbSet<SubTask> Tasks { get; set; }
    public DbSet<Task> SubTasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Task - Comment relationship
        modelBuilder.Entity<Comment>()
            .HasOne<Task>()
            .WithMany(t => t.Comments)
            .HasForeignKey(c => new { c.CommentableId, c.CommentableType })
            .HasPrincipalKey(t => new { CommentableId = t.Id, CommentableType = CommentableType.Task })
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Subtask - Comment relationship
        modelBuilder.Entity<Comment>()
            .HasOne<SubTask>()
            .WithMany(s => s.Comments)
            .HasForeignKey(c => new { c.CommentableId, c.CommentableType })
            .HasPrincipalKey(s => new { CommentableId = s.Id, CommentableType = CommentableType.SubTask })
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Task - Attachment relationship
        modelBuilder.Entity<Attachment>()
            .HasOne<Task>()
            .WithMany(t => t.Attachments)
            .HasForeignKey(a => new { a.AttachableId, a.AttachableType })
            .HasPrincipalKey(t => new { AttachableId = t.Id, AttachableType = AttachableType.Task })
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Subtask - Attachment relationship
        modelBuilder.Entity<Attachment>()
            .HasOne<SubTask>()
            .WithMany(s => s.Attachments)
            .HasForeignKey(a => new { a.AttachableId, a.AttachableType })
            .HasPrincipalKey(s => new { AttachableId = s.Id, AttachableType = AttachableType.SubTask })
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Comment - Attachment relationship
        modelBuilder.Entity<Attachment>()
            .HasOne<Comment>()
            .WithMany(c => c.Attachments)
            .HasForeignKey(a => new { a.AttachableId, a.AttachableType })
            .HasPrincipalKey(c => new { AttachableId = c.Id, AttachableType = AttachableType.Comment })
            .OnDelete(DeleteBehavior.Cascade);
    }
}
