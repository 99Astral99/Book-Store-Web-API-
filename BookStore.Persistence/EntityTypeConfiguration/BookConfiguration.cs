using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.EntityTypeConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id);
            builder.Property(t => t.Title).HasMaxLength(60).IsRequired();
            builder.Property(a => a.Author).HasMaxLength(60).IsRequired();
            builder.Property(a => a.Amount).HasDefaultValue(0);
            builder.Property(p => p.Price).IsRequired();
        }
    }
}
