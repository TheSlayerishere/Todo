
using System.Reactive;
using ReactiveUI;
using Todo.Models;

namespace Todo.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {

        string description;

        public AddItemViewModel()
        {
            System.IObservable<bool> okEnabled = this.WhenAnyValue(x => x.Description, x => !string.IsNullOrWhiteSpace(x));
            Ok = ReactiveCommand.Create(() => new TodoItem { Description = Description }, okEnabled);
            Cancel = ReactiveCommand.Create(() => { });

        }
        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }
        public ReactiveCommand<Unit, TodoItem> Ok { get; set; }
        public ReactiveCommand<Unit, Unit> Cancel { get; set; }

    }

}