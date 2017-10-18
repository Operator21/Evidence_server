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
        FrontControl fc = new FrontControl();
        public MainWindow()
        {
            InitializeComponent();
            fc.frame = frame;
            frame.Navigate(new UserList(fc));
        }
        

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new NewUser(fc));
        }
    }
}
