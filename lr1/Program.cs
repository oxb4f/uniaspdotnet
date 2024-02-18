using lr1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Відповідь "Hello World!" на головну сторінку
app.MapGet("/", () => "Hello World!");

// Відповідь з інформацією про компанію
app.MapGet("/company", () => new Company
{
    Name = "Example Co.",
    Address = "1234 Street Rd, City",
    EmployeeCount = 100
});

// Відповідь з випадковим числом
app.MapGet("/random", () => {
    var random = new Random();
    return random.Next(0, 101); // Повертає випадкове число від 0 до 100
});

app.Run();
