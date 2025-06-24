using HotelBooking.API.Extensions;
using HotelBooking.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddConfigurations(builder.Configuration)
    .AddValidation()
    .AddServices()
    .AddRepositories()
    .AddSwagger()
    .AddMongoDb(builder.Configuration)
    .AddCustomCors(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseMiddleware<ExeptionHandlingMiddleware>();

app.MapControllers();

app.Run();
