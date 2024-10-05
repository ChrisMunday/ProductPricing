using PP.Data.Factories;
using PP.Data.Interfaces.Async;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add products services.
builder.Services.AddTransient<IProductFactoryAsync, ProductFactoryAsync>();
builder.Services.AddTransient<IProductHistoryFactoryAsync, ProductFactoryAsync>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
