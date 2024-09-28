using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Infrastructure.Persistence.Entry.Module.General;

namespace Template.Infrastructure.Persistence.Mapping.Module.General;

public class EmailConfigurationMap : IEntityTypeConfiguration<EmailConfiguration>
{
    public void Configure(EntityTypeBuilder<EmailConfiguration> builder)
    {
        builder.HasOne(x => x.CreationUser).WithMany(x => x.ListCreationUserEmailConfiguration).HasForeignKey(x => x.CreationUserId).HasConstraintName("fk_configuracao_email_id_usuario_criacao");
        builder.HasOne(x => x.ChangeUser).WithMany(x => x.ListChangeUserEmailConfiguration).HasForeignKey(x => x.ChangeUserId).HasConstraintName("fk_configuracao_email_id_usuario_alteracao");

        builder.ToTable("configuracao_email");

        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.CreationUserId).HasColumnName("id_usuario_criacao");
        builder.Property(x => x.CreationUserId).IsRequired();

        builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
        builder.Property(x => x.CreationDate).IsRequired();

        builder.Property(x => x.ChangeUserId).HasColumnName("id_usuario_alteracao");

        builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");

        builder.Property(x => x.Server).HasColumnName("servidor");
        builder.Property(x => x.Server).HasMaxLength(100);
        builder.Property(x => x.Server).IsRequired();

        builder.Property(x => x.Port).HasColumnName("porta");
        builder.Property(x => x.Port).IsRequired();

        builder.Property(x => x.DisplayName).HasColumnName("nome_exibicao");
        builder.Property(x => x.DisplayName).HasMaxLength(100);
        builder.Property(x => x.DisplayName).IsRequired();

        builder.Property(x => x.FromEmail).HasColumnName("remetente");
        builder.Property(x => x.FromEmail).HasMaxLength(100);
        builder.Property(x => x.FromEmail).IsRequired();

        builder.Property(x => x.Username).HasColumnName("usuario");
        builder.Property(x => x.Username).HasMaxLength(100);
        builder.Property(x => x.Username).IsRequired();

        builder.Property(x => x.Password).HasColumnName("senha");
        builder.Property(x => x.Password).HasMaxLength(100);
        builder.Property(x => x.Password).IsRequired();

        builder.Property(x => x.Ssl).HasColumnName("ssl");
        builder.Property(x => x.Ssl).IsRequired();

        builder.Property(x => x.EmailCopy).HasColumnName("copia_email");
        builder.Property(x => x.EmailCopy).HasMaxLength(100);

        builder.Property(x => x.EmailConfigurationType).HasColumnName("tipo_configuracao_email");
        builder.Property(x => x.EmailConfigurationType).IsRequired();
    }
}