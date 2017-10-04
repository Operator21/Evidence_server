using RestSharp;
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
        }
        private async Task Getusers()
        {
            string url = "https://student.sps-prosek.cz/~zdychst14/connection/script.php";
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);
            // request.AddParameter("error", "1"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            request.AddHeader("header", "value");

            IRestResponse response = client.Execute(request);

            IParser parser = new JsonParser();
            People_list.ItemsSource = await parser.ParseString<List<User>>(response.Content);
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch
            {
                MessageBox.Show("Vyskytla se chyba");
            }
        }
    }
}
