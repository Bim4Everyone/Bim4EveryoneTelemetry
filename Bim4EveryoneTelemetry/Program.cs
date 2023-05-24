using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Connections;
using Bim4EveryoneTelemetry.Models.Connections.MongoDB;
using Bim4EveryoneTelemetry.Models.Events;
using Bim4EveryoneTelemetry.Models.Scripts;

using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add mongodb settings
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("pyRevitDataBase"));

// repositories
builder.Services.AddTransient<IDBConnectionStatus, MongoDBConnection>();
builder.Services.AddTransient<IRepository<EventRecord>, MongoDBConnection>();
builder.Services.AddTransient<IRepository<ScriptRecord>, MongoDBConnection>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();