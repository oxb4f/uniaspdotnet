using lr2;

var builder = WebApplication.CreateBuilder(args);

// Додавання сервісів до DI контейнера
builder.Services.AddScoped<CalcService>();
builder.Services.AddTransient<TimeOfDayService>();
builder.Services.AddControllers();

var app = builder.Build();

// Налаштування маршрутів
app.MapControllers();

app.Run();