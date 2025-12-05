using Microsoft.EntityFrameworkCore;
using Restaurant_Backend;
using Restaurant_Backend.Repository;
using Restaurant_Backend.Repository.Category;
using Restaurant_Backend.Repository.Client;
using Restaurant_Backend.Repository.Gallery;
using Restaurant_Backend.Repository.Ingredient;
using Restaurant_Backend.Repository.Menu_Item;
using Restaurant_Backend.Repository.Menu;
using Restaurant_Backend.Repository.Order;
using Restaurant_Backend.Repository.Product_Ingredient;
using Restaurant_Backend.Repository.Product;
using Restaurant_Backend.Repository.Reservation;
using Restaurant_Backend.Repository.Table;
using Restaurant_Backend.Repository.Ticket;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
//// add all repositories to do 
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IClientRepository,ClientRepository>();
builder.Services.AddScoped<IGalleryRepository,GalleryRepository>();
builder.Services.AddScoped<IIngredientRepository,IngredientRepository>();
builder.Services.AddScoped<IMenuRepository,MenuRepository>();
builder.Services.AddScoped<IMenuItemRepository,MenuItemRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductIngredientRepository,ProductIngredientRepository>();
builder.Services.AddScoped<IReservationRepository,ReservationRepository>();
builder.Services.AddScoped<ITableRepository,TableRepository>();
builder.Services.AddScoped<ITicketRepository,TicketRepository>();

// AddControllers
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("MyDatabase");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
