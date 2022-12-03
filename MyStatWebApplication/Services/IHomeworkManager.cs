using MyStatWebApplication.Models;

namespace MyStatWebApplication.Services;

public interface IHomeworkManager : IEnumerable<Homework>
{
    Task<bool> AddHomeworkAsync(Homework product);
    Task<bool> RemoveHomeworkAsync(int? id);
    Task<Homework?> GetHomeworkByIdAsync(int? id);
}