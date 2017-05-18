using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
  public class TodoRepository : ITodoRepository
  {
    private TodoContext _context;

    public TodoRepository(TodoContext context)
    {
      _context = context;

      if (!_context.TodoItems.Any())
        Add(new TodoItem() { Name = "Item1" });
    }

    public IEnumerable<TodoItem> GetAll()
    {
      return _context.TodoItems.ToList();
    }

    public void Add(TodoItem item)
    {
      _context.TodoItems.Add(item);
      _context.SaveChanges();
    }

    public TodoItem Find(long key)
    {
      return _context.TodoItems.FirstOrDefault(t => t.Key == key);
    }

    public void Remove(long key)
    {
      var item = _context.TodoItems.FirstOrDefault(t => t.Key == key);
      _context.TodoItems.Remove(item);
      _context.SaveChanges();
    }

    public void Update(TodoItem item)
    {
      _context.TodoItems.Update(item);
      _context.SaveChanges();
    }
  }
}
