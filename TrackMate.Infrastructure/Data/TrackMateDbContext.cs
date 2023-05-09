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
            .HasOne(c => c.Task)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Subtask - Comment relationship
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.SubTask)
            .WithMany(s => s.Comments)
            .HasForeignKey(c => c.SubTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Task - Attachment relationship
        modelBuilder.Entity<Attachment>()
            .HasOne(a => a.Task)
            .WithMany(t => t.Attachments)
            .HasForeignKey(a => a.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Subtask - Attachment relationship
        modelBuilder.Entity<Attachment>()
            .HasOne(a => a.SubTask)
            .WithMany(s => s.Attachments)
            .HasForeignKey(a => a.SubTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Comment - Attachment relationship
        modelBuilder.Entity<Attachment>()
            .HasOne(a => a.Comment)
            .WithMany(c => c.Attachments)
            .HasForeignKey(a => a.CommentId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
