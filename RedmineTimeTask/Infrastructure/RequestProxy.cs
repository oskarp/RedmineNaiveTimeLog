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
                    TimeEntry t = new TimeEntry();
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
            te.Issue.SpentHours = te.Issue.SpentHours + 2.50F;
            try
            { 
            manager.UpdateObject(te.Issue.Id.ToString(), (Issue)te.Issue);
            } catch (RedmineException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
