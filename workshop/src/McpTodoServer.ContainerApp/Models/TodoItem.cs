namespace McpTodoServer.ContainerApp.Models;

/// <summary>
/// 할 일 항목 모델
/// </summary>
public class TodoItem
{
    /// <summary>
    /// 고유 ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// 할 일 내용
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// 완료 여부
    /// </summary>
    public bool IsCompleted { get; set; }
}
