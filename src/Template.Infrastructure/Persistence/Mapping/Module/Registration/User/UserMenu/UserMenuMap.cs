using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Infrastructure.Persistence.Entry.Module.Registration;

namespace Template.Infrastructure.Persistence.Mapping.Module.Registration;

public class UserMenuMap : IEntityTypeConfiguration<UserMenu>
{
    public void Configure(EntityTypeBuilder<UserMenu> builder)
    {
        builder.HasOne(x => x.CreationUser).WithMany(x => x.ListCreationUserUserMenu).HasForeignKey(x => x.CreationUserId).HasConstraintName("fk_menu_usuario_id_usuario_criacao");
        builder.HasOne(x => x.ChangeUser).WithMany(x => x.ListChangeUserUserMenu).HasForeignKey(x => x.ChangeUserId).HasConstraintName("fk_menu_usuario_id_usuario_alteracao");
        builder.HasOne(x => x.Menu).WithMany(x => x.ListUserMenu).HasForeignKey(x => x.MenuId).HasConstraintName("fk_menu_usuario_id_menu");

        builder.ToTable("menu_usuario");

        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.CreationUserId).HasColumnName("id_usuario_criacao");
        builder.Property(x => x.CreationUserId).IsRequired();

        builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
        builder.Property(x => x.CreationDate).IsRequired();

        builder.Property(x => x.ChangeUserId).HasColumnName("id_usuario_alteracao");

        builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");

        builder.Property(x => x.MenuId).HasColumnName("id_menu");
        builder.Property(x => x.MenuId).IsRequired();

        builder.Property(x => x.Position).HasColumnName("posicao");
        builder.Property(x => x.Position).IsRequired();

        builder.Property(x => x.Favorite).HasColumnName("favorito");
        builder.Property(x => x.Favorite).IsRequired();

        builder.Property(x => x.Visible).HasColumnName("visivel");
        builder.Property(x => x.Visible).IsRequired();
    }
}