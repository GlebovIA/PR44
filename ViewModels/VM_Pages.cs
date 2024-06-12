using PR44.Classes;

namespace PR44.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Tasks vm_tasks = new VM_Tasks();
        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new View.Main(vm_tasks));
        }
        public RelayCommand OnClose
        {
            get
            {
                return new RelayCommand(obj => MainWindow.init.Close());
            }
        }
    }
}
