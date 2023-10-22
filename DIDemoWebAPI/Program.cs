using DIDemoWebAPI.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// реєстрація залежності
builder.Services.AddSingleton<IMyLogger, DBLogger>();

// реєстрація іншої реалізації залежності
//builder.Services.AddSingleton<IMyLogger, FileLogger>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
