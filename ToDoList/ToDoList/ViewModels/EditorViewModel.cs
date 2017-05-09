using Microsoft.Practices.Prism.Commands;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoList.DAL;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class EditorViewModel : ObservedObject, IModalDialogViewModel
    {
        private CalendarTaskDataAccessLayer _dal;

        public long Id { get; set; }
        public string Time { get; set; } = "00:00";
        public DateTime Date { get; set; }
        public string Action { get; set; }

        private MainViewModel _parentViewModel;
        public MainViewModel ParentViewModel
        {
            get { return _parentViewModel; }
            set { _parentViewModel = value; }
        }

        private string _windowTitle;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set { _windowTitle = value; }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new DelegateCommand(SaveActivity);
                }
                return _saveCommand;
            }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new DelegateCommand(CloseWindow);
                }
                return _cancelCommand;
            }
        }

        public EditorViewModel() { }

        public EditorViewModel(MainViewModel mainViewModel)
        {
            ParentViewModel = mainViewModel;
        }

        public EditorViewModel(DateTime selectedDate, MainViewModel mainViewModel) : this(mainViewModel)
        {
            Date = selectedDate;
            WindowTitle = "Nowe zadanie";
        }

        public EditorViewModel(long? id, MainViewModel mainViewModel) : this(mainViewModel)
        {
            Id = id.Value;
            _dal = new CalendarTaskDataAccessLayer();
            Activity currentActivity = new Activity();
            currentActivity= _dal.GetById(Id);
            Action = currentActivity.Action;
            Date = Convert.ToDateTime(currentActivity.Date);
            Time = Date.ToString("HH:mm");
            WindowTitle = "Edycja zadania";
        }

        private void SaveActivity()
        {
            Regex timePattern = new Regex("^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$");

            if ((Action=="")||(Action == null))
            {
                MessageBox.Show("Proszę uzupełnić pole z treścią zadania.");
            }
            else if (!timePattern.IsMatch(Time))
            {
                MessageBox.Show("Proszę poprawnie wypełnić czas zadania. Poprawny format to HH:MM");
            } 
            else
            {
                _dal = new CalendarTaskDataAccessLayer();
                DateTime TimeOfDay = new DateTime();
                DateTime.TryParse(Time, out TimeOfDay);
                DateTime CombinedDate = Date.Date.Add(TimeOfDay.TimeOfDay);

                if (Id != 0)
                {
                    _dal.ModifyActivity(new Activity() { Date = CombinedDate.ToString("yyyy-MM-dd HH:mm"), Action = Action, Id = Id });
                }
                else
                { 
                     _dal.AddActivity(new Activity() { Date = CombinedDate.ToString("yyyy-MM-dd HH:mm"), Action = Action });
                }
                ParentViewModel.RefreshWindow(Date);
                CloseWindow();
            }
        }
        
        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    return;
                }
            }
        }

        public bool? DialogResult
        {
            get;
        }
    }
}
