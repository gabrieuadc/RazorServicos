using Microsoft.EntityFrameworkCore;
using razorApp.data;
using razorApp.models;
using razorApp.repositories.interfaces;

namespace razorApp.repositories{

    public class ServiceRepository: IServiceRepository{

        private readonly ServiceDBContext _dbContex;

        public ServiceRepository(ServiceDBContext serviceDBContex){
            _dbContex= serviceDBContex;
        }

        public async Task<List<ServiceModel>> FindAllService()
        {
            return await _dbContex.Services.ToListAsync();
        }

        public async Task<ServiceModel> FindById(int id)
        {
            return await _dbContex.Services.FirstOrDefaultAsync(x=> x.id==id);
        }

        public async Task<ServiceModel> Add(ServiceModel service)
        {
            await _dbContex.Services.AddAsync(service);
            await _dbContex.SaveChangesAsync();

            return service;
        }

        public async Task<ServiceModel> Patch(ServiceModel service, int id)
        {
            ServiceModel serviceModelbyid= await FindById(id);

            if(serviceModelbyid ==null){
                throw new Exception("not found for id.");
            }
            serviceModelbyid.name= service.name;
            _dbContex.Services.Update(serviceModelbyid);
            await _dbContex.SaveChangesAsync();
            return serviceModelbyid;
        }

        public async Task<bool> Delete(int id)
        {
            ServiceModel serviceModelbyid= await FindById(id);

            if(serviceModelbyid ==null){
                throw new Exception("not found for id");
            }

            _dbContex.Services.Remove(serviceModelbyid);
            await _dbContex.SaveChangesAsync();
            return true;
        }


    }


}