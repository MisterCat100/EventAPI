namespace EventApi.Model.Entities;

public class ApiResponse<T>
{
    public bool IsSucess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}
