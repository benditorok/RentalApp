namespace RentalApp.Client.Services;

/// <summary>
/// Connection service interface.
/// </summary>
public interface IConnectionService
{
    event EventHandler<bool> StatusEventHandler;

    Task AuthorizeAsync(string _username, string _password);

    Task<List<T>> GetAsync<T>(string endpoint);

    Task<string> GetAsJsonAsync<T>(string endpoint);

    Task<T> GetSingleAsync<T>(string endpoint);

    Task<T> GetAsync<T>(int id, string endpoint);

    Task PostAsync<T>(T item, string endpoint);

    Task<string> PostAsJsonAsync(string item, string endpoint);

    Task DeleteAsync(int id, string endpoint);

    Task PutAsync<T>(T item, string endpoint);
}