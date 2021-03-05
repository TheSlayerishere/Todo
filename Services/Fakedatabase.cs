using Todo.Models;
using System.Collections.Generic;
using System.IO;
namespace Todo.Services
{
    //Here we create a fake database to store all todo items
    public class DataBase
    {

        public static void SaveItems(Todo.ViewModels.TodoListViewModel List)
        {
            var ItemList = List.Items;
            // string Description;
            // bool IsChecked;
            using (var streamWriter = File.CreateText(@"Todoitems.txt"))
            {
                foreach (Todo.Models.TodoItem item in ItemList)
                {
                    streamWriter.WriteLineAsync($"{item.Description.ToString()}AND{item.IsChecked.ToString()}");
                }
                
            }           
        }
        public IEnumerable<TodoItem> LoadItems(){
            var ItemList = File.ReadAllLines(@"Todoitems.txt");
            List<TodoItem> TodoList = new List<TodoItem>();
            string[] SplitItems = new string[1];
            foreach (var item in ItemList)
            {
                SplitItems = item.Split("AND");

                TodoList.Add(new TodoItem{Description=SplitItems[0], IsChecked= System.Boolean.Parse(SplitItems[1])});               

            }
            return TodoList;
        }
    }

}
