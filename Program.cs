using Microsoft.EntityFrameworkCore.Storage;
using ProductAPI.Domain.Entities;
using ProductAPI.Infra.Database.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/product",
        (DataBaseContext dataBase) =>
        {
            var listProduct = new List<Product>();

            var products = dataBase.products.ToList();
            foreach (var product in products)
            {
                listProduct.Add(new Product(product));
            }
            return listProduct;
        }
    )
    .WithName("GetProduct")
    .WithOpenApi();

app.MapPost(
        "/product",
        (DataBaseContext dataBase, ProductModel request) =>
        {
            dataBase.products.Add(request);
            dataBase.SaveChanges();
        }
    )
    .WithName("PostProduct")
    .WithOpenApi();

app.MapPut(
        "/product/{id}",
        (DataBaseContext dataBase, int id, ProductModel request) =>
        {
            var product = dataBase.products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                if (request.Name != null)
                {
                    product.Name = request.Name;
                }
                if (request.Price != null)
                {
                    product.Price = request.Price;
                }
                if (request.Quantity != null)
                {
                    product.Quantity = request.Quantity;
                }
                dataBase.SaveChanges();
            }
        }
    )
    .WithName("PutProduct")
    .WithOpenApi();

app.MapDelete(
        "/product/{id}",
        (DataBaseContext dataBase, int id) =>
        {
            var product = dataBase.products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                dataBase.products.Remove(product);
                dataBase.SaveChanges();
            }
            else
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        }
    )
    .WithName("DeleteProduct")
    .WithOpenApi();

app.Run();
