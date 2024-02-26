using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SMS.webapp.Models;

namespace SMS.webapp.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
   public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(56).IsRequired();
        builder.HasData(new Student
        {
            Id = 1,
            Name="Ayesha Siddika"
        });
        
    }
}
