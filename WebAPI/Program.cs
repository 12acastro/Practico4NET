using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using DataAccessLayer;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// For Entity Framework
builder.Services.AddDbContext<DBContextCore>();
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/* ADD DEPENDENCIESv*/
//DALs
builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();
builder.Services.AddTransient<IDAL_Vehiculos, DAL_Vehiculos_EF>();
// BLs
builder.Services.AddTransient<IBL_Personas, BL_Personas>();
builder.Services.AddTransient<IBL_Vehiculos, BL_Vehiculos>();
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
UpdateDatabase();

app.Run();

void UpdateDatabase()
{
    using (var context = new DataAccessLayer.DBContextCore())
    {
        context?.Database.Migrate();
    }
}