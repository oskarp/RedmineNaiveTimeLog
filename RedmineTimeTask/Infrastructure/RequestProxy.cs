﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Specialized;

namespace RedmineTimeTask.Infrastructure
{
    class RequestProxy
    {
        IList<Issue> _issues;

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

        public void fetchIssues()
        {
            var manager = new RedmineManager(Properties.Settings.Default.Host, Properties.Settings.Default.APIkey);

            var parameters = new NameValueCollection { { "assigned_to_id", "me" } };
            parameters.Add("status_id", "open");
            this.Issues = manager.GetObjectList<Issue>(parameters);
        }
    }
}
