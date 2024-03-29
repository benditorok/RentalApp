﻿using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace RentalApp.Client.Services;

/// <summary>
/// Connection service used to communicate with the endpoint.
/// </summary>
public class ConnectionService : IConnectionService
{
    protected static readonly HttpClient _client = new HttpClient();
    private readonly ILogger<ConnectionService>? _logger = null;

    private const int _pingInterval = 2000;
    private Timer _pingTimer;
    private bool _status = false;

    public event EventHandler<bool> StatusEventHandler = null!;

    // Bearer token data
    private string? _tokenType;
    private string? _accessToken;
    private string? _refreshToken;
    private int _expiresIn = int.MaxValue;
    private Timer? _refreshTimer;

    public ConnectionService(string baseurl, string pingableEndpoint)
    {
        _client.BaseAddress = new Uri(baseurl);
        _client.DefaultRequestHeaders.Accept.Clear();

        _client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        _pingTimer = new Timer(async x => await Ping(pingableEndpoint), null, _pingInterval, Timeout.Infinite);
    }

    public ConnectionService(ILogger<ConnectionService> logger, string baseurl = "http://localhost:8080/", string pingableEndpoint = "Status") : this(baseurl, pingableEndpoint)
    {
        _logger = logger;
    }

    private async Task Ping(string pingableEndpoint)
    {
        try
        {
            var response = await _client.GetAsync(pingableEndpoint);

            if (response.IsSuccessStatusCode)
                _status = true;
            else
                _status = false;
        }
        catch (Exception)
        {
            _status = false;
            _logger?.LogInformation("Endpoint {pingableEndpoint} is not accessible, ping failed", pingableEndpoint);
        }
        finally
        {
            StatusEventHandler?.Invoke(this, _status);
            _pingTimer?.Change(_pingInterval, Timeout.Infinite);
        }
    }

    /// <summary>
    /// Set the access token of the http header.
    /// </summary>
    private void UpdateHeaderToken()
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType!, _accessToken);
        _logger?.LogInformation("Updated bearer token.");
    }

    /// <summary>
    /// Refreshes the bearer token when it expires using the refresh token.
    /// </summary>
    /// <returns></returns>
    private async Task RefreshTokenAsync()
    {
        try
        {
            var requestData = new
            {
                refreshToken = _refreshToken
            };

            string jsonData = JsonSerializer.Serialize(requestData);
            var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("refresh", requestContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                // Get the values from the response
                JsonDocument doc = JsonDocument.Parse(content);
                JsonElement root = doc.RootElement;

                // Set token data
                _tokenType = root.GetProperty("tokenType").GetString();
                _accessToken = root.GetProperty("accessToken").GetString();
                _refreshToken = root.GetProperty("refreshToken").GetString();
                _expiresIn = root.GetProperty("expiresIn").GetInt32() * 1000;

                // Update the token of the header
                UpdateHeaderToken();
            }
        }
        catch (Exception)
        {
            _logger?.LogInformation("Refreshing bearer token failed!");
        }
        finally
        {
            _refreshTimer?.Change(_expiresIn, Timeout.Infinite);
        }
    }

    /// <summary>
    /// Log in to the user account using an username/email and a password
    /// </summary>
    /// <param name="_username">Username</param>
    /// <param name="_password">Password</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task AuthorizeAsync(string _username, string _password)
    {
        // Json type definition
        var requestData = new
        {
            email = _username,
            password = _password,
            twoFactorCode = "string",
            twoFactorRecoveryCode = "string"
        };

        // Convert request data to JSON
        string jsonData = JsonSerializer.Serialize(requestData);
        var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PostAsync("login", requestContent);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();

            // Get the values from the response
            JsonDocument doc = JsonDocument.Parse(content);
            JsonElement root = doc.RootElement;

            // Set token data
            _tokenType = root.GetProperty("tokenType").GetString();
            _accessToken = root.GetProperty("accessToken").GetString();
            _refreshToken = root.GetProperty("refreshToken").GetString();
            _expiresIn = root.GetProperty("expiresIn").GetInt32() * 1000;

            // Update the token of the header
            UpdateHeaderToken();

            // Create a timer to refresh the access token
            _refreshTimer = new Timer(async x => await RefreshTokenAsync(), null, _expiresIn, Timeout.Infinite);
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }
    }

    public async Task<List<T>> GetAsync<T>(string endpoint)
    {
        List<T>? items;
        HttpResponseMessage response = await _client.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            items = await response.Content.ReadFromJsonAsync<List<T>>();
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }

        return items!;
    }

    public async Task<string> GetAsJsonAsync<T>(string endpoint)
    {
        string? content;
        HttpResponseMessage response = await _client.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            content = await response.Content.ReadAsStringAsync();
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }

        return content!;
    }

    public async Task<T> GetSingleAsync<T>(string endpoint)
    {
        T? item;
        HttpResponseMessage response = await _client.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            item = await response.Content.ReadFromJsonAsync<T>();
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }

        return item!;
    }

    public async Task<T> GetAsync<T>(int id, string endpoint)
    {
        T? item;
        HttpResponseMessage response = await _client.GetAsync(endpoint + "/" + id.ToString());

        if (response.IsSuccessStatusCode)
        {
            item = await response.Content.ReadFromJsonAsync<T>();
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }

        return item!;
    }

    public async Task PostAsync<T>(T item, string endpoint)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync(endpoint, item);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            _logger?.LogInformation("[POST ERROR] " + error?.Message);

            throw new ArgumentException(error?.Message);
        }
    }

    /// <summary>
    /// Returns the Json data as a string.
    /// </summary>
    /// <param name="item">JSON serialized input</param>
    /// <param name="endpoint">Endpoint</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<string> PostAsJsonAsync(string item, string endpoint)
    {
        string? content;
        HttpResponseMessage response = await _client.PostAsJsonAsync(endpoint, item);

        if (response.IsSuccessStatusCode)
        {
            content = await response.Content.ReadAsStringAsync();
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }

        return content!;
    }

    public async Task DeleteAsync(int id, string endpoint)
    {
        HttpResponseMessage response = await _client.DeleteAsync(endpoint + "/" + id.ToString());

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }
    }

    public async Task PutAsync<T>(T item, string endpoint)
    {
        HttpResponseMessage response = await _client.PutAsJsonAsync(endpoint, item);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }
    }
}