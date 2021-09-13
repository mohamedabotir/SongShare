using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using GigsApplication.Controllers;
using GigsApplication.Core.Models;

namespace GigsApplication.Core.ViewModels
{
    public class GigsViewModel
    {

        public int id { set; get; }
        public ApplicationUser Artist { set; get; }
        [Required]
        public string Venue { set; get; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public int Genre { set; get; }
        public string Action
        {

            get
            {
                Expression<Func<GigsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GigsController, ActionResult>> create = (c => c.Create(this));
                var action = (id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
        public IEnumerable<Genre> Genres { set; get; }
        public string Heading { get; set; }

        public DateTime getDateTime()
        {

            return DateTime.Parse(string.Format("{0} {1}", Date, Time));

        }

    }
}