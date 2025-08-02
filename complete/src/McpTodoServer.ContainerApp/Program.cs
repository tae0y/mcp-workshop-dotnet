using McpTodoServer.ContainerApp.Data;
using McpTodoServer.ContainerApp.Repositories;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/**
* connection 객체를 직접 생성하여,
* 여러 dbcontext 인스턴스에서 공유할 수 있습니다.
*/
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
builder.Services.AddSingleton(connection);
builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlite(connection));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

/**
* DI에서 connection 객체를 생성하여,
* DBContext마다 별도의 connection을 사용합니다.
* 따라서 각 요청별로 db가 공유되지 않습니다. 
*/
//builder.Services.AddDbContext<TodoDbContext>(options =>
//    options.UseSqlite("DataSource=:memory:")
//           .EnableSensitiveDataLogging()
//);

builder.Services.AddMcpServer()
                .WithHttpTransport(o => o.Stateless = true)
                .WithToolsFromAssembly();

var app = builder.Build();

// Initialise the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapMcp("/mcp");

app.Run();
