using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using SimpleMVVM.Model;
using Xamarin.Forms;

namespace SimpleMVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _name;
        private string _lastName;
        private Person _selectedPerson;
        private ObservableCollection<Person> _people;

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                if (_selectedPerson == value) return;
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                if(_people == value) return;
                _people = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddPersonCommand { get; set; }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>();
            AddPersonCommand = new Command(AddPersonAction,CanExecute);
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == nameof(Name) || args.PropertyName == nameof(LastName))
                (AddPersonCommand as Command)?.ChangeCanExecute();
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(LastName);
        }

        private void AddPersonAction()
        {
            People.Add(new Person()
            {
                Name = Name,
                LastName = LastName
            });
            Name = string.Empty;
            LastName = string.Empty;
        }
    }
}