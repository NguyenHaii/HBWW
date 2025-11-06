using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HWW.Data;
using HWW.UnitOfWork;
using HWW.Services;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("YOUR_CONNECTION_STRING"));

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<ProductService>();

var provider = services.BuildServiceProvider();

var service = provider.GetService<ProductService>();

await service.AddProductWithCategory("Laptop", 1500, "Electronics");

Console.WriteLine("Saved successfully!");
