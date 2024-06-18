using PR44.Classes;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace PR44.Models
{
    public class Tasks : Notification
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, ".{1,50}");
                if (!match.Success) MessageBox.Show("Наименование не должно быть пустым, и не более 50 символов.", "Некорректный ввод значенияю");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                Match match = Regex.Match(value, ".{1,30}");
                if (!match.Success) MessageBox.Show("Приоритет не должен быть пустым, и не более 30 символов.", "Некорректный ввод значенияю");
                else
                {
                    priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }
        private DateTime dateExecute;
        public DateTime DateExecute
        {
            get { return dateExecute; }
            set
            {
                if (value.Date < DateTime.Now.Date) MessageBox.Show("Дата выполнения не может быть меньше текущей.", "Некорректный ввод значенияю");
                else
                {
                    dateExecute = value;
                    OnPropertyChanged("DateExecute");
                }
            }
        }
        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                Match match = Regex.Match(value, ".{1,1000}");
                if (!match.Success) MessageBox.Show("Приоритет не должен быть пустым, и не более 1000 символов.", "Некорректный ввод значенияю");
                else
                {
                    comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }
        private bool done;
        public bool Done
        {
            get { return done; }
            set
            {
                done = value;
                OnPropertyChanged("Done");
                OnPropertyChanged("IsDoneText");
            }
        }
        [Schema.NotMapped]
        private bool isEnabled;
        [Schema.NotMapped]
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("IsEnabledText");
            }
        }
        [Schema.NotMapped]
        public string IsEnabledText
        {
            get
            {
                if (IsEnabled) return "Сохранить";
                else return "Изменить";
            }
        }
        [Schema.NotMapped]
        public string IsDoneText
        {
            get
            {
                if (Done) return "Не выполненно";
                else return "Выполненно";
            }
        }
        [Schema.NotMapped]
        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    IsEnabled = !IsEnabled;
                    if (!IsEnabled) (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                });
            }
        }
        [Schema.NotMapped]
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить задачу?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.Tasks.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                    }
                });
            }
        }
        [Schema.NotMapped]
        public RelayCommand OnDone
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Done = !Done;
                });
            }
        }
    }
}
