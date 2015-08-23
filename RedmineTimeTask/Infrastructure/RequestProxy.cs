using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Specialized;
using RedmineTimeTask.Models;

namespace RedmineTimeTask.Infrastructure
{
    class RequestProxy
    {
        IList<Issue> _issues;
        IList<TimeEvent> _timeevents = new List<TimeEvent>();
       // IList<TimeEntryActivity> _activities;
        RedmineManager manager;

        public IList<Issue> Issues
        {
            get
            {
                return _issues;
            }

            set
            {
                _issues = value;
            }
        }
        public void createManager()
        {
            if (Properties.Settings.Default.Host.Length != 0 && Properties.Settings.Default.APIkey.Length != 0) {
                this.manager = new RedmineManager(Properties.Settings.Default.Host, Properties.Settings.Default.APIkey);
            }
        }
        public void fetchIssues()
        {
            if(this.manager != null) {
                try
                {
                    var parameters = new NameValueCollection { { "assigned_to_id", "me" } };
                    parameters.Add("status_id", "open");
                    this.Issues = manager.GetObjectList<Issue>(parameters);
                } 
                catch (RedmineException e)
                {
                    Console.WriteLine("ERROR : " + e.Message);
                }
            }
        }
       
        public void submitTime(TimeEvent te)
        {
            _timeevents.Add(te);
            /*if(te.Issue.SpentHours != null)
            {
                te.Issue.SpentHours = te.Issue.SpentHours + (float)Math.Round((decimal)te.Timespan.TotalHours, 2);
            } else
            {
                te.Issue.SpentHours = (float)Math.Round((float)te.Timespan.TotalHours, 2);
            } */
            TimeEntry timeentry = new TimeEntry();
            timeentry.Hours = Math.Round((decimal)te.Timespan.TotalHours, 2);
            timeentry.Project = new IdentifiableName { Id = te.Issue.Project.Id };
            timeentry.Activity = new IdentifiableName { Id = te.Activity };
            timeentry.Comments = te.Comment;
            timeentry.Issue = new IdentifiableName {Id = te.Issue.Id };

            //manager.
            try
            {
                manager.CreateObject(timeentry);
            //manager.UpdateObject(timeentry.Id.ToString(), (TimeEntry)timeentry);
            } catch (RedmineException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IList<TimeEntryActivity> getActivitiesForProject(String project_id) {
            var parameters = new NameValueCollection { { "project_id", project_id } };
            //var parameters = new NameValueCollection{};
            IList<TimeEntryActivity> list = manager.GetObjectList<TimeEntryActivity>(parameters);
            return list;
        }
    }
}
