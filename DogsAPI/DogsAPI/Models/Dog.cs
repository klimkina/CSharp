using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogsAPI.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Notes { get; set; }
    }
}