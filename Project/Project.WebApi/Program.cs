using Project.Application.Configuration;
using Project.Infrastructure;
using Project.Infrastructure.Context;
using Project.WebApi.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Insert this shit to migrations run
builder.Services.ConfigurePersistenceApp(builder.Configuration);
// mediat
builder.Services.ConfigureApplicationApp();
builder.Services.AddMvc()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add CORS extension
builder.Services.ConfigureCorsPolicy();

// Add extensions (Mine)
builder.AddConfiguration();
builder.AddJwtAuthentication();


var app = builder.Build();
CreateDatabase(app);

// Allow CORS POLICY
app.UseCors();

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

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}