using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
    
        builder.HasKey(genre => genre.Id);

        builder.Property(genre => genre.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(genre => genre.Description)
            .HasMaxLength(500);

        builder.Property(genre => genre.IsFiction)
            .IsRequired();

        builder.Property(genre => genre.Popularity)
            .IsRequired();

        builder.HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.GenreId)
            .OnDelete(DeleteBehavior.Restrict);

    
        builder.HasIndex(g => g.Name)
            .IsUnique();
    }
}