using DemokrataTT.Data;
using DemokrataTT.Mapping;
using DemokrataTT.Pagination;
using DemokrataTT.Repository;
using DemokrataTT.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registry connection DB service
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registry automapper dto
builder.Services.AddAutoMapper(typeof(MappingConfig));

// Registry User repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Registry Pagination Service
builder.Services.AddScoped<IPagination, Pagination>();

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
