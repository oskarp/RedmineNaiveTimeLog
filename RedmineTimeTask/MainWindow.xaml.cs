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


using System.Collections.Specialized;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections;
using RedmineTimeTask.Infrastructure;

namespace RedmineTimeTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RequestProxy rp = new RequestProxy();
            // Put on its own thread later. 
            rp.fetchIssues();
            issues_ListBox.ItemsSource = rp.Issues;

        }

        private void settings_Menu(object sender, RoutedEventArgs e) {
            Settings settingsWindow = new Settings();
            settingsWindow.Show();
        }
    }
}
