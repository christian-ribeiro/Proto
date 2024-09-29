using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;

namespace Proto.Infrastructure.Persistence.Mapping.Module.Registration;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(x => x.CreationUser).WithMany(x => x.ListCreationUserProduct).HasForeignKey(x => x.CreationUserId).HasConstraintName("fk_produto_id_usuario_criacao");
        builder.HasOne(x => x.ChangeUser).WithMany(x => x.ListChangeUserProduct).HasForeignKey(x => x.ChangeUserId).HasConstraintName("fk_produto_id_usuario_alteracao");

        builder.HasOne(x => x.Brand).WithMany(x => x.ListProduct).HasForeignKey(x => x.BrandId).HasConstraintName("fk_produto_id_marca");
        builder.HasOne(x => x.ProductCategory).WithMany(x => x.ListProduct).HasForeignKey(x => x.ProductCategoryId).HasConstraintName("fk_produto_id_categoria_produto");

        builder.ToTable("produto");

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

        builder.Property(x => x.BarCode).HasColumnName("codigo_barras");
        builder.Property(x => x.BarCode).HasMaxLength(100);

        builder.Property(x => x.CostValue).HasColumnName("valor_custo");
        builder.Property(x => x.CostValue).IsRequired();

        builder.Property(x => x.SaleValue).HasColumnName("valor_venda");
        builder.Property(x => x.SaleValue).IsRequired();

        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.Status).IsRequired();

        builder.Property(x => x.Weight).HasColumnName("peso");
        builder.Property(x => x.Weight).IsRequired();

        builder.Property(x => x.NetWeight).HasColumnName("peso_liquido");
        builder.Property(x => x.NetWeight).IsRequired();

        builder.Property(x => x.Observation).HasColumnName("observacao");
        builder.Property(x => x.Observation).HasMaxLength(400);

        builder.Property(x => x.BrandId).HasColumnName("id_marca");
        builder.Property(x => x.BrandId).IsRequired();

        builder.Property(x => x.ProductCategoryId).HasColumnName("id_categoria_produto");
    }
}