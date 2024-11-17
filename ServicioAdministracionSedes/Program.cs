
using Proyecto.Controller;
using Proyecto.Interfaces;
using Proyecto.Messages;

var builder = WebApplication.CreateBuilder(args);

// Agregar controladores
builder.Services.AddControllers();

// Configurar HttpClient para SedeController
builder.Services.AddHttpClient<SedesController>();

// Configurar IMessagePublisher con RabbitMQ
builder.Services.AddSingleton<IMessagePublisher>(provider => 
    new RabbitMqMessagePublisher("amqp://usuario:contraseña@localhost:5672"));

// Otras configuraciones de servicios (si existen)

// Construir la aplicación
var app = builder.Build();

// Configurar el middleware para usar controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();
