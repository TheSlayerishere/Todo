using ReactiveUI;
using Todo.Services;
using System.Reactive.Linq;
using Todo.Models;
using System;
namespace Todo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public MainWindowViewModel(DataBase db)
        {
            Content = List = new TodoListViewModel(db.GetItems());


        }
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public TodoListViewModel List { get; }
        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        List.Items.Add(model);
                        Todo.Services.DataBase.SaveItems(List);              
                    }

                    Content = List;
                });
            

            Content = vm;
            
        }
    }
}
