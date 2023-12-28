namespace RentalApp.Client.RestApi;

/// <summary>
/// RestService interface.
/// </summary>
public interface IRestService
{
    public bool Status { get; }

    Task<List<T>> GetAsync<T>(string endpoint);

    Task<string> GetAsJsonAsync<T>(string endpoint);

    Task<T> GetSingleAsync<T>(string endpoint);

    Task<T> GetAsync<T>(int id, string endpoint);
    
    Task PostAsync<T>(T item, string endpoint);

    Task DeleteAsync(int id, string endpoint);

    Task PutAsync<T>(T item, string endpoint);
}
