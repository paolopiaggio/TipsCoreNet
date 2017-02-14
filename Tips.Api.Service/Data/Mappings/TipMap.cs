using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tips.Model;

namespace Tips.Data.Mapping
{
    public class TipMap
    {
        public TipMap(EntityTypeBuilder<Tip> entityBuilder) {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Text).IsRequired();
        }
    }
}