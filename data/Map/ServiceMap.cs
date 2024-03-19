using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using razorApp.models;

namespace razorApp.data.Map{

    public class ServiceMap: IEntityTypeConfiguration<ServiceModel>{

        public void Configure(EntityTypeBuilder<ServiceModel> builder){

            builder.HasKey(x=> x.id);
            builder.Property(x => x.contact).IsRequired().HasMaxLength(70);
            builder.Property(x => x.name).IsRequired().HasMaxLength(70);
            builder.Property(x => x.service).IsRequired().HasMaxLength(70);
            builder.Property(x => x.value).IsRequired().HasMaxLength(70);
            builder.Property(x => x.date).IsRequired().HasMaxLength(70);

        }

    }


}