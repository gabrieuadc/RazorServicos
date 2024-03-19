using razorApp.models;

namespace razorApp.repositories.interfaces{

    public interface IServiceRepository{
        Task <List<ServiceModel>> FindAllService();
        Task<ServiceModel> FindById(int id);
        Task<ServiceModel> Add(ServiceModel service);
        Task<ServiceModel> Patch(ServiceModel service, int id);
        Task<bool> Delete(int id);

    }

}