using System;
using Todo.Services;

namespace Todo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(DataBase db)
        {
            List = new TodoListViewModel(db.GetItems());

        }
        public TodoListViewModel List {get;}
    }   
}
