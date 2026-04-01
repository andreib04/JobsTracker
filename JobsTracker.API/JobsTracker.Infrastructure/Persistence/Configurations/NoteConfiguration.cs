using JobsTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsTracker.Infrastructure.Persistence.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
           builder.HasKey(n => n.Id);

           builder.Property(n => n.Content)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
