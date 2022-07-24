using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data;

public interface ICommandRepo
{
    Task SaveChanges();
    Task<Command?> GetCommandById(int it);
    Task<IEnumerable<Command>> GetAllCommands();
    Task CreateCommand(Command command);
    void DeleteCommand(Command command);
}

public class CommandRepo : ICommandRepo
{
    private readonly AppDbContext _context;
    
    public CommandRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Command?> GetCommandById(int id)
    {
        return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Command>> GetAllCommands()
    {
        return await _context.Commands.ToListAsync();
    }

    public async Task CreateCommand(Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        await _context.AddAsync(command);
    }

    public void DeleteCommand(Command command)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        _context.Commands.Remove(command);
    }
}

