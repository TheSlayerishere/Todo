using Todo.Models;
using System.Collections.Generic;

namespace Todo.Services
{
    //Here we create a fake database to store all todo items
    public class DataBase
    {
        public IEnumerable<TodoItem> GetItems() => new[] {
            new TodoItem{Description="Get Milk"},
            new TodoItem{Description="walk the dog"},
            new TodoItem {Description="Learn Avalonia", IsChecked=true},

        };
    }

}
