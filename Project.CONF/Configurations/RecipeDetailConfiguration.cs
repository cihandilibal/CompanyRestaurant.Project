using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Configurations
{
    public class RecipeDetailConfiguration: BaseConfiguration<RecipeDetail>
    {
        public override void Configure(EntityTypeBuilder<RecipeDetail> builder)
        {
            base.Configure(builder);
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.IngredientID,
                x.RecipeID
            });
            builder.Property(x => x.IngredientQuantity).HasColumnType("decimal(18,2)");
        }
    }
}
