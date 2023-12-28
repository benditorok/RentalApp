using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace RentalApp.Client.RestApi;

/// <summary>
/// REST API implementation.
/// </summary>
public class RestService : IRestService
{
    private static readonly HttpClient client = new HttpClient();

    public RestService(string baseurl, string pingableEndpoint) 
    {
        HttpResponseMessage response = null!;

        do
        {
            try
            {
                response = client.GetAsync(pingableEndpoint).GetAwaiter().GetResult();
            }
            catch { }

        } while (!response.IsSuccessStatusCode);

        Init(baseurl);
    }

    private void Init(string baseurl)
    {
        client.BaseAddress = new Uri(baseurl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept
            .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            client.GetAsync("").GetAwaiter().GetResult();
        }
        catch (HttpRequestException)
        {
            throw new ArgumentException("Endpoint is not available!");
        }
    }

    public async Task<List<T>> GetAsync<T>(string endpoint)
    {
        List<T>? items = new List<T>();
        HttpResponseMessage response = await client.GetAsync(endpoint);

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
        HttpResponseMessage response = await client.GetAsync(endpoint);

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
        HttpResponseMessage response = await client.GetAsync(endpoint);

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
        HttpResponseMessage response = await client.GetAsync(endpoint + "/" + id.ToString());

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
        HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, item);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }
    }

    public async Task DeleteAsync(int id, string endpoint)
    {
        HttpResponseMessage response = await client.DeleteAsync(endpoint + "/" + id.ToString());

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }
    }

    public async Task PutAsync<T>(T item, string endpoint)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync(endpoint, item);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<Exception>();
            throw new ArgumentException(error?.Message);
        }
    }
}