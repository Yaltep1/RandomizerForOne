using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
//це автоматично згенерований для мене  WPF клас для обробки івентів інтерфейсу
namespace Randomizer2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer;
        Stack<string> contentStack;
        Controller controller;
        public MainWindow()
        {
            controller = new Controller();
            contentStack=new Stack<string>();
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Visible;
            bool res = controller.loginUser(log.Text, pass.Password);
            if (!res)
            {
                grid3.Visibility = Visibility.Hidden;
                grid1.Visibility = Visibility.Visible;
                error1.Visibility = Visibility.Visible;
            }
            else
            {
                content.Text = "";
                error1.Visibility = Visibility.Hidden;
                grid3.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Visible;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            error2.Visibility = Visibility.Hidden;
            controller.logout();
            grid2.Visibility = Visibility.Hidden;
            grid1.Visibility = Visibility.Visible;
        }
        private void waitSome()
        {   
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Visible;

            wait.Content = "Wait";
            TimerCallback tm = new TimerCallback(Tick);
             timer = new Timer(tm, null, 0, 1000);
           
        }
       public  void Tick(object o) {

            content.Dispatcher.Invoke(() =>
            {
                if ((string)wait.Content == "Wait...") { wait.Content = "Wait"; }
                else { wait.Content += "."; }
            });
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            error2.Visibility = Visibility.Hidden;
            content.Text = "";
            ArrayList hist = controller.getRequests();
            foreach (object s in hist) { content.Text += s + " \r\n\r\n"; }
        }

        private async void random_Click(object sender, RoutedEventArgs e)
        {
            if (!controller.tryIncertReq(start.Text, end.Text)) { error2.Visibility = Visibility.Visible; }

            else
            {
                error2.Visibility = Visibility.Hidden;
                waitSome();
                string start1 = start.Text;
                string end1 = end.Text;
                await Task.Run(() => startRequest(start1,end1));
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                grid2.Visibility = Visibility.Visible;
                grid3.Visibility = Visibility.Hidden;
            }
        }
       void startRequest(string start1,string end1)
        {
            contentStack=controller.randomize(start1, end1);
            content.Dispatcher.Invoke(() => content.Text = "", DispatcherPriority.Background);
                while (contentStack.Count != 0)
                {
                
                content.Dispatcher.Invoke(() =>content.Text += contentStack.Pop(), DispatcherPriority.Background);
            }
          
        }
    }
}

