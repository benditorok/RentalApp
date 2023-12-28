using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;

namespace RentalApp.Client.RestApi;

/// <summary>
/// REST API implementation.
/// </summary>
public class RestService : IRestService
{
    private static readonly HttpClient _client = new HttpClient();
    private const int _interval = 10000;
    private Timer _timer;
    private bool _status = false;

    public bool Status { get { return _status; } }
    
    public RestService(string baseurl, string pingableEndpoint) 
    {
        _client.BaseAddress = new Uri(baseurl);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept
            .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

         _timer = new Timer(x => Tick(pingableEndpoint), null, _interval, Timeout.Infinite);
    }

    private async Task Tick(string pingableEndpoint)
    {
        try
        {
            var response = await _client.GetAsync(pingableEndpoint);

            if (response.IsSuccessStatusCode)
                _status = true;
            else
                _status = false;
        }
        finally
        {
            _timer?.Change(_interval, Timeout.Infinite);
        }
    }

    public async Task<List<T>> GetAsync<T>(string endpoint)
    {
        List<T>? items = new List<T>();
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
        string? content = string.Empty;
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
        T? item = default(T);
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
        T? item = default(T);
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
            throw new ArgumentException(error?.Message);
        }
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