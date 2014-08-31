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
                if (HttpContext.Current.Session["Sightings"] == null)
                {
                    HttpContext.Current.Session["Sightings"] = new List<SightingModel>();
                }
                
                return (List<SightingModel>)HttpContext.Current.Session["Sightings"];
            }
            set
            {
                HttpContext.Current.Session["Sightings"] = value;
            }
        }
    }
}