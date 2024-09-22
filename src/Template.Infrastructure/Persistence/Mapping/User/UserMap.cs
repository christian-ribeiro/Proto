using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Infrastructure.Persistence.Entry;

namespace Template.Infrastructure.Persistence.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.CreationUserId).HasColumnName("id_usuario_criacao");

        builder.Property(x => x.CreationDate).HasColumnName("data_criacao");

        builder.Property(x => x.ChangeUserId).HasColumnName("id_usuario_alteracao");

        builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");

        builder.Property(x => x.Name).HasColumnName("nome");
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Name).IsRequired();

        builder.Property(x => x.Password).HasColumnName("senha");
        builder.Property(x => x.Password).HasMaxLength(100);
        builder.Property(x => x.Password).IsRequired();

        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired();

        builder.Property(x => x.Language).HasColumnName("idioma");
        builder.Property(x => x.Email).IsRequired();
    }
}