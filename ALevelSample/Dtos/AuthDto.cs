using Newtonsoft.Json;

namespace ALevelSample.Dtos;
public class AuthDto
{
    [JsonProperty("email")]
    public string Email { get; set; } = null!;

    [JsonProperty("password")]
    public string Password { get; set; } = null!;
}
