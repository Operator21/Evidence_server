using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Evidence_server
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
            try
            {
                Getusers();
            }
            catch
            {
                Debug.WriteLine("Neplatná hodnota v databázi");
            }
        }
        private async Task Getusers()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~zdychst14/connection/script.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "831baaf3-6305-6de2-22ea-daee8334e754");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            IParser parser = new JsonParser();
            People_list.ItemsSource = await parser.ParseString<List<User>>(response.Content);
        }

        private void People_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ((User)People_list.SelectedItem).ID;
            //MessageBox.Show(id.ToString());
            BackEnd.frame.Navigate(new UserInfo(id));
        }
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            //frame.Navigate(new NewUser(fc));
            BackEnd.frame.Navigate(new NewUser());
        }
    }
}
