using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proto.Arguments.Enum;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;

namespace Proto.Infrastructure.Persistence.Mapping.Module.Registration;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(x => x.CreationUser).WithMany(x => x.ListCreationUserUser).HasForeignKey(x => x.CreationUserId).HasConstraintName("fk_usuario_id_usuario_criacao");
        builder.HasOne(x => x.ChangeUser).WithMany(x => x.ListChangeUserUser).HasForeignKey(x => x.ChangeUserId).HasConstraintName("fk_usuario_id_usuario_alteracao");

        builder.ToTable("usuario");

        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.CreationUserId).HasColumnName("id_usuario_criacao");

        builder.Property(x => x.CreationDate).HasColumnName("data_criacao");

        builder.Property(x => x.ChangeUserId).HasColumnName("id_usuario_alteracao");

        builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");

        builder.Property(x => x.Code).HasColumnName("codigo");
        builder.Property(x => x.Code).HasMaxLength(6);
        builder.Property(x => x.Code).IsRequired();

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
        builder.Property(x => x.Language).IsRequired();

        builder.Property(x => x.RefreshToken).HasColumnName("refresh_token");
        builder.Property(x => x.RefreshToken).HasMaxLength(100);

        builder.Property(x => x.LoginKey).HasColumnName("chave_login");

        builder.Property(x => x.PasswordRecoveryCode).HasColumnName("codigo_recuperacao_senha");
        builder.Property(x => x.PasswordRecoveryCode).HasMaxLength(6);

        builder.HasData(new User("001", "Christian Ribeiro", "$2a$11$252h2vGrxOa1D/ZO.SCreebeBKyQfoa8MAo4V6wx7O21U3nfxbXWO", "christian.des.ribeiro@gmail.com", EnumLanguage.Portuguese, default, default, default).SetInternalData(1, DateTime.MinValue, default, default, default));
    }
}