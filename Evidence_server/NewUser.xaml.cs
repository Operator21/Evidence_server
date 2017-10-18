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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        FrontControl fc;
        public NewUser(FrontControl f)
        {
            InitializeComponent();
            fc = f;
        }
        private void Create()
        {
            try
            {
                User u = new User();
                u.name = name.Text;
                u.surname = surname.Text;
                u.birth = birth.DisplayDate;
                u.birth_num = birth_num.Text;
                u.gender = select.SelectedValue.ToString();

                var client = new RestClient("https://student.sps-prosek.cz/~zdychst14/connection/insert.php");
                var request = new RestRequest(Method.POST);
                request.AddHeader("postman-token", "39c36bd1-61b5-1361-11f2-70f50d01c83c");
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(u), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch
            {
                MessageBox.Show("Vyskytla se chyba");
            }
        }
        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Submit.Content = "Create user " + name.Text; 
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Create();
            fc.frame.Navigate(new UserList(fc));
        }
    }
        
}
