
using McpTodoServer.ContainerApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MCP 서버 등록
builder.Services.AddMcpServer()
                .WithHttpTransport(o => o.Stateless = true)
                .WithToolsFromAssembly();

// SQLite 인메모리 DB 등록
// Create and open a single SQLite in-memory connection for the application's lifetime
var sqliteConnection = new Microsoft.Data.Sqlite.SqliteConnection("DataSource=./todo.db");
sqliteConnection.Open();

builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlite(sqliteConnection)
           .EnableSensitiveDataLogging()
);

var app = builder.Build();

// 앱 시작 시 DB 초기화 및 인메모리 DB 오픈 유지
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
    db.Database.OpenConnection();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.MapMcp("/mcp");

app.Run();
