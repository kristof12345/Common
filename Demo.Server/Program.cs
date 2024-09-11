using System;
using System.Net.Http;
using Common.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5101/") });

services.AddSignalR(e => { e.MaximumReceiveMessageSize = 102400000; });
services.AddRazorPages();
services.AddServerSideBlazor();

services.AddHttpClient();

services.AddCommonServices();

services.AddScoped<LoginService>();
services.AddScoped<DataService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/Host");

app.Run();