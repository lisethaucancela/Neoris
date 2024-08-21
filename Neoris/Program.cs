using Microsoft.EntityFrameworkCore;
using Neoris.Data;
using Neoris.Mapping;
using Neoris.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICuentasService, CuentasServicecs>();
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<IReporteService, ReporteService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<MiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

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
