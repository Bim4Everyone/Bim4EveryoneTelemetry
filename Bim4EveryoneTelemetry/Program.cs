using Bim4EveryoneTelemetry.Models;
using Bim4EveryoneTelemetry.Models.Connections;
using Bim4EveryoneTelemetry.Models.Connections.MongoDB;
using Bim4EveryoneTelemetry.Models.Events;
using Bim4EveryoneTelemetry.Models.Scripts;

using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console());

// Add http logging (body, request, response)
builder.Services.AddHttpLogging(logging => {
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

// Add services to the container.
builder.Services.AddControllers();

// Add default environment prefix
builder.Configuration.AddEnvironmentVariables(prefix: "B4E");

// Add mongodb settings
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("pyRevitDataBase"));

// Add repositories
builder.Services.AddTransient<IDBConnectionStatus, MongoDBConnection>();
builder.Services.AddTransient<IRepository<EventRecord>, MongoDBConnection>();
builder.Services.AddTransient<IRepository<ScriptRecord>, MongoDBConnection>();
builder.Services.AddTransient<IRepository<LogEventRecord>, MongoDBConnection>();

// Add Swagger Gen doc
builder.Services.AddSwaggerGen(options => {
    // Include xml comments
    var basePath = AppContext.BaseDirectory;
    options.IncludeXmlComments(Path.Combine(basePath, "Bim4EveryoneTelemetry.xml"));

    // Add open api metadata
    options.SwaggerDoc("v2",
        new OpenApiInfo {
            Version = "v2",
            Title = "Bim4Everyone Telemetry",
            Description = "Telemetry server api",
            Contact = new OpenApiContact {
                Name = "dosymep", 
                Url = new Uri("https://github.com/Bim4Everyone")
            },
            License = new OpenApiLicense {
                Name = "MIT License",
                Url = new Uri("https://github.com/Bim4Everyone/Bim4EveryoneTelemetry/blob/master/LICENSE.md")
            },
        });
});

// Add app versioning
builder.Services.AddApiVersioning(setup => {
    setup.DefaultApiVersion = new ApiVersion(2, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

// Add app versioning settings
builder.Services.AddVersionedApiExplorer(setup => {
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseHttpLogging();

    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();