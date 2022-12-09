namespace ALevelSample.Model;
public class RegisterResult : Validation
{
    public int Id { get; set; }
    public string Token { get; set; } = null!;
}
