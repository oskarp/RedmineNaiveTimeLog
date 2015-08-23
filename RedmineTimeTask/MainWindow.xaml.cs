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
using RedmineTimeTask.Models;

namespace RedmineTimeTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RequestProxy rp = new RequestProxy();
        Timer timer = new Timer();

        public MainWindow()
        {
            InitializeComponent();

            // Put on its own thread later. 
            rp.createManager();
            rp.fetchIssues();
            issues_ListBox.ItemsSource = rp.Issues;

        }

        private void settings_Menu(object sender, RoutedEventArgs e) {
            Settings settingsWindow = new Settings();
            settingsWindow.Show();
        }

        private void about_Menu(object sender, RoutedEventArgs e)
        {
            about aboutWindow = new about();
            aboutWindow.Show();
        }

        private void startWatch_Menu(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(sender.ToString());
            MenuItem item = (System.Windows.Controls.MenuItem)sender;
            if((string)item.Header == "_Start Timer") {
                item.Header = "_Stop Timer";
                this.timer.start();
            } else if((string)item.Header == "_Stop Timer")
            {
                SubmitTime subWindow = new SubmitTime();
                subWindow.Rp = this.rp;
                subWindow.Te = new TimeEvent(timer.getTimeSpan(), null);
                subWindow.Show();
                item.Header = "_Start Timer";
            }


        }

        private void ForceRefresh_Menu(object sender, RoutedEventArgs e)
        {
            rp.createManager();
            rp.fetchIssues();
            issues_ListBox.ItemsSource = rp.Issues;

        }
    }
}
                                                                                      