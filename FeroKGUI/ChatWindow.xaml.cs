using System;
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
using System.Windows.Shapes;
using System.Net.Http; //for http requests
using Newtonsoft.Json; //for parasing http requests

namespace FeroKGUI
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
            InitializeComponent();
            var dueTime = TimeSpan.FromSeconds(5);
            var interval = TimeSpan.FromSeconds(5);
            //RunPeriodicAsync(OnTick, dueTime, interval, CancellationToken.None);
        }

        private static async Task RunPeriodicAsync(Action onTick, TimeSpan dueTime, TimeSpan interval, CancellationToken token)
        {
            if(dueTime > TimeSpan.Zero)
            {
                await Task.Delay(dueTime, token);
            }
            while(!token.IsCancellationRequested)
            {
                onTick?.Invoke();
            }
        }

        private void OnTick()
        {
            HttpClient public_client = new HttpClient();
            public_client.BaseAddress = new Uri("https://feropublic.herokuapp.com/");
            var publicClientTask = public_client.GetAsync("/numberofusers");
            publicClientTask.Wait();
            var publicClientResult = publicClientTask.Result;
            int numberofusers = int.Parse(publicClientResult.Content.ReadAsStringAsync().Result);
            Console.WriteLine(numberofusers);
            List<PublicWebsite> publicList = new List<PublicWebsite>();

            for (int i = 1; i <= numberofusers; i++)
            {
                publicClientTask = public_client.GetAsync("/?id=" + i);
                publicClientTask.Wait();
                publicClientResult = publicClientTask.Result;
                PublicWebsite public_obj = JsonConvert.DeserializeObject<PublicWebsite>(publicClientResult.Content.ReadAsStringAsync().Result);
                publicList.Add(public_obj);


            }

        }

        private void Border_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState != WindowState.Maximized)
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).WindowState = WindowState.Normal;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
