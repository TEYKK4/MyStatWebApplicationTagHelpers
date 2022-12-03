using System.Collections;
using Microsoft.EntityFrameworkCore;
using MyStatWebApplication.Models;

namespace MyStatWebApplication.Services;

public class HomeworkManager : IHomeworkManager
{
    private readonly MyStatDbContext _dbContext;

    public HomeworkManager(MyStatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Homework?> GetHomeworkByIdAsync(int? id)
    {
        if (id == null)
        {
            return null;
        }

        return await _dbContext.Homeworks.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> AddHomeworkAsync(Homework product)
    {
        try
        {
            await _dbContext.Homeworks.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerator<Homework> GetEnumerator()
    {
        return ((IEnumerable<Homework>)_dbContext.Homeworks).GetEnumerator();
    }

    public async Task<bool> RemoveHomeworkAsync(int? id)
    {
        try
        {
            var result = await GetHomeworkByIdAsync(id);

            if (result == null) return false;
            
            _dbContext.Homeworks.Remove(result);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}