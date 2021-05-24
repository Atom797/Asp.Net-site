﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public string annemail { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string request { get; set; }
    }
}
