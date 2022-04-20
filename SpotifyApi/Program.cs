using SpotifyApi.Interfaces;
using SpotifyApi.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<IOAuthClientService, OAuthClientService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://accounts.spotify.com/");
    httpClient.DefaultRequestHeaders.Accept.Clear();
    // what we can accept in response
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    // set content_type header
    httpClient.DefaultRequestHeaders.Add("Content_Type", "application/x-www-form-encoded");
});

builder.Services.AddHttpClient<ISpotifyPlaylistService, SpotifyPlaylistService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.spotify.com/v1/playlists/");
    httpClient.DefaultRequestHeaders.Accept.Clear();
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();
