using JobsTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsTracker.Infrastructure.Persistence.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.AppliedDate)
                .IsRequired();

            builder.Property(x => x.JobUrl)
            .HasMaxLength(500);

            builder.HasMany(x => x.Notes)
                .WithOne()
                .HasForeignKey(n => n.JobApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }   
    }
}
