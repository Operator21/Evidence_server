using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

namespace Evidence_server
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient httpClient = new HttpClient();
        User i = new User();
        List<User> users = new List<User>();
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            //users.Add(new User() { name = "rnd", surname = "sur", birth = DateTime.Today, birth_num = rnd.Next(11111,99999).ToString(), gender = "male" });
            Getusers();
            People_list.ItemsSource = users;
        }
        private async Task Getusers()
        {
            var ip = await httpClient.GetStringAsync("https://student.sps-prosek.cz/~zdychst14/connection/script.php");
            Debug.WriteLine(ip);
            IParser parser = new JsonParser();
            i = await parser.ParseString<User>(ip);
            Debug.WriteLine(i.name);
        }
    }
}
