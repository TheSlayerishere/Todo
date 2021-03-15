//This is the DataBase for our todo items
using Todo.Models;
using System.Collections.Generic;
using System.IO;
namespace Todo.Services
{
    //Here we create a fake database to store all todo items
    public class DataBase
    {
        private static string Todoitems = @"Todoitems.txt";
        public static void SaveItems(Todo.ViewModels.TodoListViewModel List)
        {
            var ItemList = List.Items;
            // string Description;
            // bool IsChecked;
            using (var streamWriter = File.CreateText(Todoitems))
            {
                foreach (Todo.Models.TodoItem item in ItemList)
                {
                    streamWriter.WriteLineAsync($"{item.Description.ToString()}FAUHGSUYFGUASYGFYUDGFUYGAUYHDSJBFHJKBAFKJBNSDJFDHYGBSJHKFNQWEJUHNRDJBAFUUIEFHBDNKSBFNJHSKBFEJKSDBFNIEBFNKJSFBUIWEHFBNAKJBNSJFHSAJBFDJSDBFUABJNSFBDJKBSJDJHSDHJSDSJHDJHSDSJHDSJHDSJHDSHJDSJHAKLSNFUWAOHFEUYSPT;IHURNBBBDFJKISNFJDS{item.IsChecked.ToString()}");
                }
                
            }           
        }
        public IEnumerable<TodoItem> LoadItems(){
            
            if (!File.Exists(Todoitems))
            {
                File.Create(Todoitems);
            }
            var ItemList = File.ReadAllLines(Todoitems);
            List<TodoItem> TodoList = new List<TodoItem>();
            string[] SplitItems = new string[1];
            foreach (var item in ItemList)
            {
                SplitItems = item.Split("FAUHGSUYFGUASYGFYUDGFUYGAUYHDSJBFHJKBAFKJBNSDJFDHYGBSJHKFNQWEJUHNRDJBAFUUIEFHBDNKSBFNJHSKBFEJKSDBFNIEBFNKJSFBUIWEHFBNAKJBNSJFHSAJBFDJSDBFUABJNSFBDJKBSJDJHSDHJSDSJHDJHSDSJHDSJHDSJHDSHJDSJHAKLSNFUWAOHFEUYSPT;IHURNBBBDFJKISNFJDS");
                bool flag; 
                System.Boolean.TryParse(SplitItems[1], out flag);
                TodoList.Add(new TodoItem{Description=SplitItems[0], IsChecked=flag});               

            }
            return TodoList;
        }
    }

}
