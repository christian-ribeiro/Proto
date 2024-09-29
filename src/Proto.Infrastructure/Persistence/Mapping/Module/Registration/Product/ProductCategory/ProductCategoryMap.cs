using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;

namespace Proto.Infrastructure.Persistence.Mapping.Module.Registration;

public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasOne(x => x.CreationUser).WithMany(x => x.ListCreationUserProductCategory).HasForeignKey(x => x.CreationUserId).HasConstraintName("fk_categoria_produto_id_usuario_criacao");
        builder.HasOne(x => x.ChangeUser).WithMany(x => x.ListChangeUserProductCategory).HasForeignKey(x => x.ChangeUserId).HasConstraintName("fk_categoria_produto_id_usuario_alteracao");

        builder.ToTable("categoria_produto");

        builder.HasKey(x => x.Id).HasName("id");

        builder.Property(x => x.CreationUserId).HasColumnName("id_usuario_criacao");
        builder.Property(x => x.CreationUserId).IsRequired();

        builder.Property(x => x.CreationDate).HasColumnName("data_criacao");
        builder.Property(x => x.CreationDate).IsRequired();

        builder.Property(x => x.ChangeUserId).HasColumnName("id_usuario_alteracao");

        builder.Property(x => x.ChangeDate).HasColumnName("data_alteracao");

        builder.Property(x => x.Code).HasColumnName("codigo");
        builder.Property(x => x.Code).HasMaxLength(6);
        builder.Property(x => x.Code).IsRequired();

        builder.Property(x => x.Description).HasColumnName("descricao");
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired();
    }
}