using ReactiveUI;
using Todo.Services;


namespace Todo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public MainWindowViewModel(DataBase db)
        {
            Content = List = new TodoListViewModel(db.GetItems());
            

        }
        public ViewModelBase Content{
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public TodoListViewModel List {get;}
        public void AddItem(){
            Content = new AddItemViewModel();
        } 
    }   
}
