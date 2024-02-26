using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.webapp.Models;

namespace SMS.webapp.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.student).WithMany(x=>x.Country).HasForeignKey(x=>x.StudentId).OnDelete(DeleteBehavior.Restrict);
    }
}
