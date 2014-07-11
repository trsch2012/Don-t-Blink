using DontBlink.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DontBlink.API.Code
{
    public class SessionStateSink
    {
        public static List<SightingModel> Sightings
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["Sightings"] == null) return null;
                
                return (List<SightingModel>)System.Web.HttpContext.Current.Session["Sightings"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["Sightings"] = value;
            }
        }
    }
}