using PR44.Classes;
using PR44.Context;
using PR44.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PR44.ViewModels
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new TasksContext();
        public ObservableCollection<Tasks> Tasks { get; set; }
        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));
        public RelayCommand OnAddTask
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Tasks NewTask = new Tasks()
                    {
                        DateExecute = DateTime.Now
                    };
                    Tasks.Add(NewTask);
                    tasksContext.Tasks.Add(NewTask);
                    tasksContext.SaveChanges();
                });
            }
        }
    }
}
