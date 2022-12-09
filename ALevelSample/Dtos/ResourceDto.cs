using Newtonsoft.Json;

namespace ALevelSample.Dtos;
public class ResourceDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("year")]
    public int Year { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; } = null!;

    [JsonProperty("pantone_value")]
    public string PantoneValue { get; set; } = null!;
}
