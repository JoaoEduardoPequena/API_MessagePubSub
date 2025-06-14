using Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.Id_Categoria);

            builder.Property(c => c.Id_Categoria)
             .IsRequired()
             .HasColumnName("Id_Categoria")
             .HasColumnType("int")
             .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(400)");
        }
    }
}
