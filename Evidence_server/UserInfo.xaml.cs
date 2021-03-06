﻿using Newtonsoft.Json;
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
        User u;
        int ID;
        public UserInfo(int id)
        {
            InitializeComponent();
            ID = id;
            GetUser();
            name.Content = u.name + " " + u.surname;
            gender.Content = u.gender;
            birth.Content = u.birth.ToString("dd.MM. yyyy");
            birth_num.Content = u.birth_num;
        }
        private void GetUser()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~zdychst14/connection/script.php?ID=" + ID);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            IParser parser = new JsonParser();
            string result = response.Content.Replace(@"[", "");
            result = result.Replace(@"]", "");
            u = JsonConvert.DeserializeObject<User>(result);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new UserList());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new NewUser(u));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Delete " + u.name + " ?","Deleting item",MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                var client = new RestClient("https://student.sps-prosek.cz/~zdychst14/connection/delete.php?ID=" + ID);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                IRestResponse response = client.Execute(request);
                BackEnd.frame.Navigate(new UserList());
            } 
        }
    }
}
