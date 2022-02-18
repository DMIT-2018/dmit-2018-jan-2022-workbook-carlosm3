﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public class DbVersionInfo
    {
        // The view that is used by the "outside world"
        // Access must match the method where the classd is used (typically public)
        // Purpose: use to simply carry data
        //          create data fields as auto-implemented properties
        //          consists of the "raw" data of the query

        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
