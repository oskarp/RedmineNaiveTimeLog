using Redmine.Net.Api.Types;
using RedmineTimeTask.Infrastructure;
using RedmineTimeTask.Models;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace RedmineTimeTask
{
    /// <summary>
    /// Interaction logic for SubmitTime.xaml
    /// </summary>
    public partial class SubmitTime : Window
    {

        RequestProxy rp;
        TimeEvent te;

        public SubmitTime()
        {
            InitializeComponent();

        }
        public void issues_BoxLoaded(object sender, RoutedEventArgs e)
        {
            if(te.Issue != null)
            {
                IList tempIssuesList = new List<Issue>();
                tempIssuesList.Add(te.Issue);
                issues_Box.ItemsSource = tempIssuesList;
                issues_Box.SelectedIndex = 0;
                updateActivitiesBox();
            } else { 
                issues_Box.ItemsSource = rp.Issues;
            }
            hours_box.Text = Math.Round((decimal)te.Timespan.TotalHours, 3).ToString();
        } 

        internal RequestProxy Rp
        {
            get
            {
                return rp;
            }

            set
            {
                rp = value;
            }
        }

        internal TimeEvent Te
        {
            get
            {
                return te;
            }

            set
            {
                te = value;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            te.Issue = (Issue)issues_Box.SelectedItem;

            te.Activity = ((TimeEntryActivity)activities_Box.SelectedItem).Id;
            te.Comment = comment_Box.Text;        
            rp.submitTime(te);
            Close();
        }

        private void issues_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateActivitiesBox();
        }

        private void updateActivitiesBox() {
            te.Issue = (Issue)issues_Box.SelectedItem;
            IList<TimeEntryActivity> list = rp.getActivitiesForProject(te.Issue.Project.Id.ToString());
            activities_Box.ItemsSource = list;
            activities_Box.SelectedIndex = 0;
        }
    }
}
