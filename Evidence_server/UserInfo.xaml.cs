using Newtonsoft.Json;
using RestSharp;
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

namespace Evidence_server
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        FrontControl fc;
        User u;
        List<User> users = new List<User>();
        int ID;
        public UserInfo(FrontControl f, int id)
        {
            InitializeComponent();
            fc = f;
            ID = id;
            GetUser();
            name.Content = u.name + " " + u.surname;
            gender.Content = u.gender;
            birth.Content = u.birth;
            birth_num.Content = u.birth_num;
        }
        private void GetUser()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~zdychst14/connection/script.php?ID=" + ID);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "831baaf3-6305-6de2-22ea-daee8334e754");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            IParser parser = new JsonParser();
            var u = JsonConvert.DeserializeObject<User>(response.Content);
        }
    }
}
