﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWebAPIApp.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
    }
}