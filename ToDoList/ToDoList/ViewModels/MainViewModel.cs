using Microsoft.Practices.Prism.Commands;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ToDoList.DAL;
using ToDoList.Models;
using ToDoList.Views;

namespace ToDoList.ViewModels
{
    public class MainViewModel : ObservedObject
    {
        private readonly IDialogService _dialogService;
        private readonly DispatcherTimer _timer;
        private readonly CalendarTaskDataAccessLayer _dal;

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                ReloadGrid();
                OnPropertyChanged("activityList", "calendar","SelectedDate");
            }
        }

        private ObservableCollection<Activity> _activityList = new ObservableCollection<Activity>();
        public ObservableCollection<Activity> ActivityList
        {
            get { return _activityList; }
        }

        private ICommand _addTaskCommand;
        public ICommand AddTaskCommand
        {
            get
            {
                if (_addTaskCommand == null)
                {
                    _addTaskCommand = new DelegateCommand(ShowEditWindow);
                }
                return _addTaskCommand;
            }
        }

        private ICommand _editTaskCommand;
        public ICommand EditTaskCommand
        {
            get
            {
                if (_editTaskCommand == null)
                {
                    _editTaskCommand = new DelegateCommand<long?>(ShowEditWindow);
                }
                return _editTaskCommand;
            }
        }

        private ICommand _deleteTaskCommand;
        public ICommand DeleteTaskCommand
        {
            get
            {
                if (_deleteTaskCommand == null)
                {
                    _deleteTaskCommand = new DelegateCommand<long?>(DeleteActivity);
                }
                return _deleteTaskCommand;
            }
        }

        public MainViewModel()
        {
            _dialogService = new DialogService();
            _dal = new CalendarTaskDataAccessLayer();
            ReloadGrid();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
            _timer.Start();
            _timer.Tick += (o, e) => TaskNotification(); 
        }

        public void RefreshWindow(DateTime lastDate)
        {
            SelectedDate = lastDate;
        }

        private void ReloadGrid()
        {
            string SelectedDateString=SelectedDate.ToString("yyyy-MM-dd");
            _activityList = new ObservableCollection<Activity>(_dal.GetByDate(SelectedDateString));
        }
                
        private void ShowEditWindow()
        {
            var editorDialog = new EditorViewModel(SelectedDate, this);
            _dialogService.ShowDialog<Editor>(this, editorDialog);
        }

        private void ShowEditWindow(long? id)
        {
            var editorDialog = new EditorViewModel(id, this);
            _dialogService.ShowDialog<Editor>(this, editorDialog);
        }

        private void DeleteActivity(long? id)
        {
            _dal.DeleteActivity(id);
            ReloadGrid();
            OnPropertyChanged("activityList", "calendar");
        }

        private void TaskNotification()
        {
            DateTime now = DateTime.Now;
            now=now.AddMinutes(15);
            String nowString = now.ToString("yyyy-MM-dd HH:mm");
            Activity nextActivity = _dal.GetByDateSingle(nowString);
            if(nextActivity != null)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Za 15 minut nowe zadanie: " + nextActivity.Action);
            }
        }
    }
}
