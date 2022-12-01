using System;

namespace ALevelSample.Dtos.Responses;

public class UserResponse
{
    public string Name { get; set; }
    public string Job { get; set; }
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}