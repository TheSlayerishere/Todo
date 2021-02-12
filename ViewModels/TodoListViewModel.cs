//This is the view model creator for our todo list
using Todo.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Todo.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public TodoListViewModel(IEnumerable<TodoItem> items){
            items = new ObservableCollection<TodoItem>(items);
            
        }
        public ObservableCollection<TodoItem> items{get;}
    }
}