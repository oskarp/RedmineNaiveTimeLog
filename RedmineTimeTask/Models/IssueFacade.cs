using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redmine.Net.Api.Types;
namespace RedmineTimeTask.Models
{
    class IssueFacade
    {
        Issue _issue;
        String _color;
        Timer _timer;

        public IssueFacade(Issue issue, String color, Timer timer)
        {
            this._issue = issue;
            this._color = color;
            this._timer = timer;
        }


    }

}
