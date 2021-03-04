using Todo.Models;
using System.Collections.Generic;
using System.IO;
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
        public static void SaveItems(Todo.ViewModels.TodoListViewModel List)
        {
            var ItemList = List.Items;
            // string Description;
            // bool IsChecked;
            using (var streamWriter = File.CreateText(@"Todoitems.txt"))
            {
                foreach (var item in ItemList)
                {
                    streamWriter.WriteLineAsync($"{item.Description.ToString()}AND{item.IsChecked.ToString()}");
                }
                
            }


           
        }
    }

}
