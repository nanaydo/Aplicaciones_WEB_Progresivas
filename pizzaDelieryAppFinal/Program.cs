using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configuración de MongoDB
var mongoConnectionString = builder.Configuration.GetConnectionString("PizzaDeliveryDatabase");
var mongoClient = new MongoClient(mongoConnectionString);
var database = mongoClient.GetDatabase("PizzaDeliveryDB");

// Registramos MongoDB como un servicio
builder.Services.AddSingleton(database);

// Agregar el servicio de controladores
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura el pipeline de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=ObtenerPizzas}/{id?}");  // Cambié a Pizza controller como la ruta inicial

app.Run();


