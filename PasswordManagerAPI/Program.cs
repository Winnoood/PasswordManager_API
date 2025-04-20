using Microsoft.EntityFrameworkCore;
using PasswordManagerAPI.Data;
using PasswordManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<PasswordContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("PasswordDb")));

builder.Services.AddDbContext<PasswordContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(new[] { "http://localhost:7800", "http://localhost:4200" })
    .SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddScoped<PasswordService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("corsapp");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
