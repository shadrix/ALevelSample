using Newtonsoft.Json;

namespace ALevelSample.Dtos;
public class ErrorTextDto
{
    [JsonProperty("error")]
    public string? ErrorBody { get; set; }
}
