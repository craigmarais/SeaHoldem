using SeaHoldemExtensions;
using SeaHoldemLogic;
using SeaHoldemWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();

builder.Services.AddHoldemGame(options =>
{
    options.Logger = new SeaLogger();
});

builder.Services.AddHostedService<GameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
