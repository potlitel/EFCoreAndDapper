using EFCoreAndDapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencyInjection(builder.Configuration);

//builder.Services.AddMvc()
//     .AddNewtonsoftJson(
//          options =>
//          {
//              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//          });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Dapper y Entity Framework Core en .NET 7",
        Description = "Dapper con Entity Framework Core en .Net 7",
    });
});

var app = builder.Build();

// Seed Data
if (app.Configuration.GetValue<bool>("UseInMemoryDatabase"))
{
    using (var scope = app.Services.CreateScope())
    {
        var scopeProvider = scope.ServiceProvider;
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        await ApplicationContextSeed.SeedSampleDataAsync(dbContext);
    }
}

// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.InjectStylesheet("/swagger-ui/custom.css");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();