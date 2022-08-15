using Farmasi.Basket.Data;
using Farmasi.Basket.Data.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// requires using Microsoft.Extensions.Options
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

//adding product services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<BasketService>();

//adding controllers
builder.Services.AddControllers();

//enabling cors for client app
builder.Services.AddCors(o => o.AddPolicy("LowCorsPolicy", builder => {
    builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
}));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//use the new cors policy
app.UseCors("LowCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
