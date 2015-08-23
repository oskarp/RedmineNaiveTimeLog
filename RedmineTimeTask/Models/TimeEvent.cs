using Redmine.Net.Api.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineTimeTask.Models
{
    class TimeEvent
    {
        TimeSpan _timespan;
        Issue _issue;
        int _activity;
        string _comment;


        public TimeEvent(TimeSpan timespan, Issue issue)
        {
            this._timespan = timespan;
            this._issue = issue;
        }

        public TimeSpan Timespan
        {
            get
            {
                return _timespan;
            }

            set
            {
                _timespan = value;
            }
        }

        public Issue Issue
        {
            get
            {
                return _issue;
            }

            set
            {
                _issue = value;
            }
        }

        public string Comment
        {
            get
            {
                return _comment;
            }

            set
            {
                _comment = value;
            }
        }

        public int Activity
        {
            get
            {
                return _activity;
            }

            set
            {
                _activity = value;
            }
        }
    }
}
