using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);

        builder.Property(book => book.Title)
        .IsRequired()
        .HasMaxLength(200);

         builder.Property(book => book.ISBN)
            .IsRequired()
            .HasMaxLength(13);

         builder.Property(book => book.Pages)
         .IsRequired()
         .HasMaxLength(1000);

         builder.Property(book => book.Description)
         .IsRequired()
         .HasMaxLength(1000);


              builder.HasOne(b => b.Author)
              .WithMany(a => a.Books)
              .HasForeignKey(b => b.AuthorId)
              .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(b => b.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(b => b.GenreId)
            .OnDelete(DeleteBehavior.Restrict);


           

    }

}
