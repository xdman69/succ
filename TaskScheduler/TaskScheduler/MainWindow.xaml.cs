using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32.TaskScheduler;

namespace TaskScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string Task = "New Task";

        public MainWindow()
        {
            InitializeComponent();

            TaskService ts = new TaskService();

            TaskDefinition td = ts.NewTask();
            td.RegistrationInfo.Description = "Test";
            td.Principal.LogonType = TaskLogonType.InteractiveToken;

            TimeTrigger tTrigger = (TimeTrigger)td.Triggers.Add(new TimeTrigger());
            tTrigger.StartBoundary = DateTime.Now + TimeSpan.FromSeconds(5);
            tTrigger.EndBoundary = DateTime.Today + TimeSpan.FromDays(7);
            tTrigger.ExecutionTimeLimit = TimeSpan.FromSeconds(15);
            tTrigger.Id = "Time test";
            tTrigger.Repetition.Duration = TimeSpan.FromMinutes(10);
            tTrigger.Repetition.Interval = TimeSpan.FromMinutes(2);
            tTrigger.Repetition.StopAtDurationEnd = true;

            td.Actions.Add(new ExecAction("cmd.exe", "c:\\test.log", null));

            ts.RootFolder.RegisterTaskDefinition(Task, td);
            taskList.Items.Add(Task);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (TaskService ts = new TaskService())
            {
                Microsoft.Win32.TaskScheduler.Task t = ts.GetTask(Task);
                if (t == null) return;
                ts.RootFolder.DeleteTask(Task);
                taskList.Items.Remove(Task);
            }
        }
    }
}
