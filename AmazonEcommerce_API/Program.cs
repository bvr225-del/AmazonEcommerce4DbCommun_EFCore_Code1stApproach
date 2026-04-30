using AmazonEcommerce_BusinessEntities.Interfaces;
using AmazonEcommerce_DbConnectivity;
using AmazonEcommerce_RepositoryLayer;
using AmazonEcommerce_ServiceLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//We must register your context classes and pointing to your connectionstring
//you should tell to ef core this context class is pointing to this database.
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCodeFirstApproachDatabase")));
builder.Services.AddDbContext<OrderContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderCodeFirstApproachDatabase")));
builder.Services.AddDbContext<DepartmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DepartmentCodeFirstApproachDatabase")));
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantCodeFirstApproachDatabase")));
//===========================================================================
//Here we are registering the service and repository classes in the dependency injection container.
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//===========================================================================
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
//===========================================================================
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
