using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Infrastructure.Persistence.Entry;

namespace Template.Infrastructure.Persistence.Mapping;

public class MenuMap : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasOne(x => x.ParentMenu).WithMany(x => x.ListMenu).HasForeignKey(x => x.ParentMenuId).HasConstraintName("fk_menu_id_menu_pai");

        builder.ToTable("menu");

        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.Route).HasColumnName("rota");
        builder.Property(x => x.Route).HasMaxLength(100);
        builder.Property(x => x.Route).IsRequired();

        builder.Property(x => x.Description).HasColumnName("descricao");
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired();

        builder.Property(x => x.Icon).HasColumnName("icone");
        builder.Property(x => x.Icon).HasMaxLength(100);
        builder.Property(x => x.Icon).IsRequired();

        builder.Property(x => x.Position).HasColumnName("posicao");
        builder.Property(x => x.Position).IsRequired();

        builder.Property(x => x.ParentMenuId).HasColumnName("id_menu_pai");

        builder.HasData(new List<Menu>
        {
            new Menu("/Sistema", "Sistema", "icon-sistema", 1, default, default, default, default).SetInternalData(1),
            new Menu("/Usuario", "Usuário", "icon-user", 2, 1, default, default, default).SetInternalData(2),
        });
    }
}