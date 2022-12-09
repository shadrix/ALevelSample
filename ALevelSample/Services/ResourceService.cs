using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;
using ALevelSample.Model;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class ResourceService : BaseService, IResourceService
{
    private readonly IInternalHttpClientService _internalHttpClientService;
    private readonly ApiOption _apiOption;

    public ResourceService(
        IInternalHttpClientService internalHttpClientService,
        IOptions<ApiOption> options)
    {
        _apiOption = options.Value;
        _internalHttpClientService = internalHttpClientService;
    }

    public async Task<Resource> GetResource(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var response =
                await _internalHttpClientService.SendAsync<PagingResponse<ResourceDto>>($"{_apiOption.Host}/unknown/{id}", HttpMethod.Get);

            if (response!.Data != null)
            {
                return new Resource
                {
                    Color = response.Data.Color,
                    Name = response.Data.Name,
                    Id = response.Data.Id,
                    PantoneValue = response.Data.PantoneValue,
                    Year = response.Data.Year
                };
            }

            return null!;
        });
    }

    public async Task<CollectionData<Resource>> GetResources()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var response =
                await _internalHttpClientService.SendAsync<PagingResponse<ResourceDto[]>>($"{_apiOption.Host}/unknown", HttpMethod.Get);

            if (response!.Data != null)
            {
                return new CollectionData<Resource>()
                {
                   Data = response.Data.Select(s => new Resource
                    {
                        Color = s.Color,
                        Name = s.Name,
                        Id = s.Id,
                        PantoneValue = s.PantoneValue,
                        Year = s.Year
                    }).ToList()
                };
            }

            return null!;
        });
    }
}