using System.Threading.Tasks;
using ALevelSample.Model;

namespace ALevelSample.Services.Abstractions;
public interface IResourceService
{
    Task<Resource> GetResource(int id);
    Task<CollectionData<Resource>> GetResources();
}
