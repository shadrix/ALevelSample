using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses;
public class PagingResponse<T>
{
    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("total_page")]
    public int TotalPage { get; set; }

    [JsonProperty("data")]
    public T? Data { get; set; }

    [JsonProperty("support")]
    public SupportDto? Support { get; set; }
}
