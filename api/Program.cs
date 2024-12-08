using api.Data;
using api.Interface;
using api.Repository;
using api.Service;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();


builder.Services.AddHttpClient<StockService>((serviceProvider, client) => {

    // var settings = serviceProvider
    // .GetRequiredService<IOptions<MovieServiceSettings>>().Value;
    
    client.DefaultRequestHeaders.Add("Accept", "*/*");
    client.DefaultRequestHeaders.Add("User-Agent", "User-Agent");

    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //http://localhost:5125/scalar/v1#tag/stock/GET/api/stocks
    app.MapScalarApiReference(o => 
        o.WithTheme(ScalarTheme.Moon));
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

