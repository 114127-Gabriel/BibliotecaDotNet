using MinhaBiblioteca.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Apenas Singleton (mantém os dados na memória enquanto a API estiver rodando)
builder.Services.AddSingleton<IMaterialRepository, MaterialRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors("PermitirFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();