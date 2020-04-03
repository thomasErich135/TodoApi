using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Mappings
{
    public class TodoMap : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
           builder.Property(p => p.Id)
                    .HasColumnName("IdTodo")
                    .IsRequired();
            
            builder.Property(p => p.Title)
                    .IsRequired()
                    .HasColumnType("VARCHAR(20)");

            builder.Property(p => p.Done)
                    .IsRequired()
                    .HasColumnType("TINYINT(1)");

            builder.Property(p => p.Date)
                    .IsRequired()
                    .HasColumnType("DATETIME");

            builder.Property(p => p.User)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)");

            builder.HasKey(p => p.Id);

            builder.ToTable("TodoItems");
        }
    }
}
