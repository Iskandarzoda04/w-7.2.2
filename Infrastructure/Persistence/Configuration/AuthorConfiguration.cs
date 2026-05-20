using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
       
        builder.HasKey(author => author.Id);

        builder.Property(author => author.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(author => author.BirthYear)
            .IsRequired();

        builder.Property(author => author.Country)
            .HasMaxLength(100);

        builder.Property(author => author.Biography)
            .HasMaxLength(2000);

        
        builder.HasMany(author => author.Books)
            .WithOne(book => book.Author)
            .HasForeignKey(book => book.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    }


