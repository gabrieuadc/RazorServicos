using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using razorApp.data.Map;
using razorApp.models;

namespace razorApp.data{

    public class ServiceDBContext: DbContext{


        public ServiceDBContext(DbContextOptions<ServiceDBContext> options): base(options){}

        public DbSet<ServiceModel> Services{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new ServiceMap());
            base.OnModelCreating(modelBuilder);
        }

}

}