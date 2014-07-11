﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DontBlink.API.Models
{
    public class SightingModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageUrl { get; set; }
    }
}