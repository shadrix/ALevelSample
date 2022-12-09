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

public class UserService : BaseService, IUserService
{
    private readonly IInternalHttpClientService _internalHttpClientService;
    private readonly ApiOption _apiOption;

    public UserService(
        IInternalHttpClientService internalHttpClientService,
        IOptions<ApiOption> options)
    {
        _apiOption = options.Value;
        _internalHttpClientService = internalHttpClientService;
    }

    public async Task<User> GetUser(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var response =
                await _internalHttpClientService.SendAsync<PagingResponse<UserDto>>($"{_apiOption.Host}/users/{id}", HttpMethod.Get);

            if (response!.Data != null)
            {
                return new User
                {
                    Email = response.Data.Email,
                    FirstName = response.Data.FirstName,
                    Id = response.Data.Id,
                    LastName = response.Data.LastName,
                    UrlAvatar = response.Data.UrlAvatar
                };
            }

            return null!;
        });
    }

    public async Task<CollectionData<User>> GetUsersByPage(int page)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var response =
                await _internalHttpClientService.SendAsync<PagingResponse<UserDto[]>>($"{_apiOption.Host}/users?page={page}", HttpMethod.Get);

            if (response!.Data != null)
            {
                return new CollectionData<User>()
                {
                    Data = response.Data.Select(s => new User
                    {
                        Email = s.Email,
                        FirstName = s.FirstName,
                        Id = s.Id,
                        LastName = s.LastName,
                        UrlAvatar = s.UrlAvatar
                    }).ToList()
                };
            }

            return null!;
        });
    }

    public async Task<CollectionData<User>> GetUsersByDelay(int delay)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var response =
                await _internalHttpClientService.SendAsync<PagingResponse<UserDto[]>>($"{_apiOption.Host}/users?delay={delay}", HttpMethod.Get);

            if (response!.Data != null)
            {
                return new CollectionData<User>()
                {
                    Data = response.Data.Select(s => new User
                    {
                        Email = s.Email,
                        FirstName = s.FirstName,
                        Id = s.Id,
                        LastName = s.LastName,
                        UrlAvatar = s.UrlAvatar
                    }).ToList()
                };
            }

            return null!;
        });
    }

    public async Task<Employee> CreateUserEmployee(string name, string job)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var request = new EmployeeDto { Name = name, Job = job };
            var response =
                await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOption.Host}/users", HttpMethod.Post, request);

            if (response != null)
            {
                return new Employee
                {
                    CreatedAt = response.CreatedAt,
                    Job = response.Job,
                    Id = response.Id,
                    Name = response.Name,
                    UpdatedAt = response.UpdatedAt
                };
            }

            return null!;
        });
    }

    public async Task<Employee> UpdateUserEmployee(int id, string name, string job)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var request = new EmployeeDto { Name = name, Job = job };
            var response =
                await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOption.Host}/users/{id}", HttpMethod.Put, request);

            if (response != null)
            {
                return new Employee
                {
                    CreatedAt = response.CreatedAt,
                    Job = response.Job,
                    Id = response.Id,
                    Name = response.Name,
                    UpdatedAt = response.UpdatedAt
                };
            }

            return null!;
        });
    }

    public async Task<Employee> ModifyUserEmployee(int id, string name, string job)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var request = new EmployeeDto { Name = name, Job = job };
            var response =
                await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOption.Host}/users/{id}", HttpMethod.Patch, request);

            if (response != null)
            {
                return new Employee
                {
                    CreatedAt = response.CreatedAt,
                    Job = response.Job,
                    Id = response.Id,
                    Name = response.Name,
                    UpdatedAt = response.UpdatedAt
                };
            }

            return null!;
        });
    }

    public async Task<VoidResult> RemoveUserEmployee(int id)
    {
        return await ExecuteSafeAsync<VoidResult>(async () =>
        {
            await _internalHttpClientService.SendAsync($"{_apiOption.Host}/users/{id}", HttpMethod.Delete);
            return null!;
        });
    }
}