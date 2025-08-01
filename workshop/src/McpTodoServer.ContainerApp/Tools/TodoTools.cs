using McpTodoServer.ContainerApp.Data;
using McpTodoServer.ContainerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace McpTodoServer.ContainerApp.Tools;

/// <summary>
/// 할 일 목록 관리 도구 (트랜잭션 포함)
/// </summary>
public class TodoTools
{
    private readonly TodoDbContext _db;

    public TodoTools(TodoDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// 할 일 생성
    /// </summary>
    public async Task<TodoItem> CreateAsync(string text)
    {
        var todo = new TodoItem { Text = text, IsCompleted = false };
        await using var tx = await _db.Database.BeginTransactionAsync();
        _db.Todos.Add(todo);
        await _db.SaveChangesAsync();
        await tx.CommitAsync();
        return todo;
    }

    /// <summary>
    /// 전체 할 일 목록 조회
    /// </summary>
    public async Task<List<TodoItem>> ListAsync()
    {
        return await _db.Todos.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// 할 일 텍스트 수정
    /// </summary>
    public async Task<TodoItem?> UpdateAsync(int id, string newText)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return null;
        await using var tx = await _db.Database.BeginTransactionAsync();
        todo.Text = newText;
        await _db.SaveChangesAsync();
        await tx.CommitAsync();
        return todo;
    }

    /// <summary>
    /// 할 일 완료 처리
    /// </summary>
    public async Task<TodoItem?> CompleteAsync(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return null;
        await using var tx = await _db.Database.BeginTransactionAsync();
        todo.IsCompleted = true;
        await _db.SaveChangesAsync();
        await tx.CommitAsync();
        return todo;
    }

    /// <summary>
    /// 할 일 삭제
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return false;
        await using var tx = await _db.Database.BeginTransactionAsync();
        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync();
        await tx.CommitAsync();
        return true;
    }
}
