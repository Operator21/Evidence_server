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
        User u;
        bool edit;
        string url;
        public NewUser(FrontControl f)
        {
            InitializeComponent();
            fc = f;
        }
        public NewUser(FrontControl f, User us)
        {
            InitializeComponent();
            fc = f;
            u = us;
            edit = true;
            name.Text = u.name;
            surname.Text = u.surname;
            birth_num.Text = u.birth_num;
            birth.DisplayDate = u.birth;
            select.SelectedValue = u.gender;
        }
        private void Create()
        {
            try
            {
                User uc = new User();
                
                uc.name = name.Text;
                uc.surname = surname.Text;
                uc.birth = birth.DisplayDate;
                uc.birth_num = birth_num.Text;
                uc.gender = select.SelectedValue.ToString();
                if (edit)
                {
                    url = "https://student.sps-prosek.cz/~zdychst14/connection/insert.php?ID=" + u.ID;
                    MessageBox.Show(url);
                }
                else
                {
                    url = "https://student.sps-prosek.cz/~zdychst14/connection/insert.php";
                }
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("postman-token", "39c36bd1-61b5-1361-11f2-70f50d01c83c");
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(uc), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch
            {
                MessageBox.Show("Vyskytla se chyba");
            }
        }
        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (edit)
            {
                Submit.Content = "Edit user " + name.Text;
            }
            else
            {
                Submit.Content = "Create user " + name.Text;
            }       
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Create();
            if (edit)
            {
                fc.frame.Navigate(new UserInfo(fc,u.ID));
            }
            else
            {
                fc.frame.Navigate(new UserList(fc));
            }
            
        }
    }
        
}
